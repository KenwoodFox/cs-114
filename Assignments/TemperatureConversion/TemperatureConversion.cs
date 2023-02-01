using System;
using System.Collections.Generic;
using Gtk;

// Alias
using con = System.Console;

class TemperatureConversion : Window
{
    // Memory
    static NumericInput fahrenheitTemp;

    static NumericInput celsiusTemp;

    public TemperatureConversion() :
        base("Color Dialog")
    {
        // Start this application
        Application.Init();

        // Setup all objects
        Fixed fix = new Fixed();
        Button calcBtn = new Button("Convert Temp");
        fix.Put(calcBtn, 20, 180);
        Button clearBtn = new Button("Clear Temp");
        fix.Put(clearBtn, 150, 180);

        // All the input boxes
        fahrenheitTemp = new NumericInput("Fahrenheit Temp", "100");
        fix.Put(fahrenheitTemp.localFix, 20, 20);
        celsiusTemp = new NumericInput("Celsius Temp", "0");
        fix.Put(celsiusTemp.localFix, 20, 60);

        // Setup Callbacks
        calcBtn.Clicked += new EventHandler(pCalculate);
        clearBtn.Clicked += new EventHandler(pClear);

        Window window = new Window("Temperature Converter");

        // Check when window is closed.
        window.DeleteEvent += pExit;

        // Add the button to the window and display everything
        window.Add (fix);
        window.ShowAll();

        Application.Run();
    }

    // Callbacks
    static void pCalculate(object obj, EventArgs args)
    {
        double t_f = fahrenheitTemp.getEntry();

        con.WriteLine($"{(5 / 9) * (t_f - 32)}");

        celsiusTemp.setEntry($"{((5.0 / 9.0) * (t_f - 32.0)):0.00}");
    }

    static void pClear(object obj, EventArgs args)
    {
        fahrenheitTemp.setEntry("0");
        celsiusTemp.setEntry("0");
    }

    static void pExit(object obj, EventArgs args)
    {
        Application.Quit();
    }

    // Main
    public static void Main()
    {
        Application.Init();
        new TemperatureConversion();
        Application.Run();
    }
}

class NumericInput
{
    public Fixed localFix { get; }

    private Label localLabel;

    private Entry localEntry;

    // Creates a numeric input
    public NumericInput(string _inputLabel, string _default = "0")
    {
        localFix = new Fixed();
        localLabel = new Label(_inputLabel);
        localEntry = new Entry(_default); // Would require subclassing to enforce numbers only

        // Place widgets
        localFix.Put(localLabel, 0, 0);
        localFix.Put(localEntry, 140, 0);
    }

    public double getEntry()
    {
        double r = 0;
        try
        {
            r = double.Parse(localEntry.Text);
        }
        catch (Exception ex)
        {
            // On format exception...
            MessageDialog md =
                new MessageDialog(null,
                    DialogFlags.DestroyWithParent,
                    MessageType.Warning,
                    ButtonsType.Ok,
                    $"Error: {ex.GetType().ToString()}");
            md.Run(); // Run till button push
            md.Destroy();
        }

        return r;
    }

    public void setEntry(string str)
    {
        localEntry.Text = str;
    }
}
