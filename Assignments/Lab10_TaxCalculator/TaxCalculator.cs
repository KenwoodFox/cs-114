using System;
using System.Collections.Generic;
using Gtk;

// Alias
using con = System.Console;

class Calculator : Window
{
    static NumericInput income;

    static NumericInput owed;

    static NumericInput op2;

    static NumericInput re;

    public Calculator() :
        base("Color Dialog")
    {
        // Start this application
        Application.Init();

        // Setup all objects
        Fixed fix = new Fixed();
        Button calcBtn = new Button("Calculate");
        fix.Put(calcBtn, 20, 180);
        Button exitBtn = new Button("Exit");
        fix.Put(exitBtn, 100, 180);

        // All the input boxes
        income = new NumericInput("Taxable Income $", "35350");
        fix.Put(income.localFix, 20, 20);
        owed = new NumericInput("Income Tax Owed", "4044.5");
        fix.Put(owed.localFix, 20, 60);

        // Setup Callbacks
        calcBtn.Clicked += new EventHandler(pCalculate);
        exitBtn.Clicked += new EventHandler(pExit);

        Window window = new Window("Calculator");

        // Check when window is closed.
        window.DeleteEvent += pExit;

        // Add the button to the window and display everything
        window.Add (fix);
        window.ShowAll();

        Application.Run();
    }

    static void pCalculate(object obj, EventArgs args)
    {
        double _income = Calculator.income.getEntry();

        owed.setEntry($"{calculateTaxes(_income):C}");
    }

    static void pExit(object obj, EventArgs args)
    {
        Application.Quit();
    }

    static double calculateTaxes(double _income)
    {
        double tax = 0;

        tax += bracket(ref _income, 0, 0);
        tax += bracket(ref _income, 9875, 0.12, 987.5);
        tax += bracket(ref _income, 40125, 0.22, 4617.5);
        tax += bracket(ref _income, 85525, 0.24, 14605.5);
        tax += bracket(ref _income, 163300, 0.32, 33271.50);
        tax += bracket(ref _income, 207350, 0.35, 47367.50);
        tax += bracket(ref _income, 518400, 0.37, 156235);

        return tax;
    }

    static double bracket(ref double i, double b, double rate, double extra = 0)
    {
        if (i > b)
        {
            i = i - b;
            con.WriteLine($"Tax bracket {b} added {b * rate}");
            return (b * rate) + extra;
        }
        else
        {
            return 0;
        }
    }

    static void Main(string[] args)
    {
        Application.Init();
        new Calculator();
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

    public string getStr()
    {
        return localEntry.Text;
    }

    public void setEntry(string str)
    {
        localEntry.Text = str;
    }
}
