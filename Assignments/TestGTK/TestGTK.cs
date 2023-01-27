using System;
using System.Collections.Generic;
using Gtk;

// Alias
using con = System.Console;

class TestGTK : Window
{
    // Memory
    static NumericInput monthlyInvestment;

    static NumericInput yearlyInvestment;

    static NumericInput nYears;

    static NumericInput futureValue;

    public TestGTK() :
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
        monthlyInvestment = new NumericInput("Monthly Investment");
        fix.Put(monthlyInvestment.localFix, 20, 20);
        yearlyInvestment = new NumericInput("Yearly Investment");
        fix.Put(yearlyInvestment.localFix, 20, 60);
        nYears = new NumericInput("Number of years");
        fix.Put(nYears.localFix, 20, 100);
        futureValue = new NumericInput("Future Value");
        fix.Put(futureValue.localFix, 20, 140);

        // Setup Callbacks
        calcBtn.Clicked += new EventHandler(pCalculate);
        exitBtn.Clicked += new EventHandler(pExit);

        Window window = new Window("helloworld");

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
        double mInvest = monthlyInvestment.getEntry();
        double yRate = yearlyInvestment.getEntry();
        double nYears = nYears.getEntry();
    }

    static void pExit(object obj, EventArgs args)
    {
        Application.Quit();
    }

    // Main
    public static void Main()
    {
        Application.Init();
        new TestGTK();
        Application.Run();
    }
}

class NumericInput
{
    public Fixed localFix { get; }

    Label localLabel;

    Entry localEntry;

    // Creates a numeric input
    public NumericInput(string _inputLabel)
    {
        localFix = new Fixed();
        localLabel = new Label(_inputLabel);
        localEntry = new Gtk.Entry(); // Would require subclassing to enforce numbers only

        // Place widgets
        localFix.Put(localLabel, 0, 0);
        localFix.Put(localEntry, 140, 0);
    }

    public double getEntry()
    {
        return double.Parse(localEntry.Text);
    }
}
