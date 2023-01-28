using System;
using System.Collections.Generic;
using Gtk;

// Alias
using con = System.Console;

class InvestmentCalculator : Window
{
    // Memory
    static NumericInput monthlyInvestment;

    static NumericInput yearlyInvestment;

    static NumericInput numberYears;

    static NumericInput futureValue;

    public InvestmentCalculator() :
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
        monthlyInvestment = new NumericInput("Monthly Investment", "100");
        fix.Put(monthlyInvestment.localFix, 20, 20);
        yearlyInvestment = new NumericInput("Yearly Investment", "7.5");
        fix.Put(yearlyInvestment.localFix, 20, 60);
        numberYears = new NumericInput("Number of years", "10");
        fix.Put(numberYears.localFix, 20, 100);
        futureValue = new NumericInput("Future Value");
        fix.Put(futureValue.localFix, 20, 140);

        // Setup Callbacks
        calcBtn.Clicked += new EventHandler(pCalculate);
        exitBtn.Clicked += new EventHandler(pExit);

        Window window = new Window("Future Value");

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
        double nYears = numberYears.getEntry();

        double result = mInvest;
        for (int i = 0; i < nYears * 12; i++)
        {
            result += mInvest + (i % 12 == 0 ? result * (yRate / 100) : 0);
        }

        futureValue.setEntry($"{result:C}");
    }

    static void pExit(object obj, EventArgs args)
    {
        Application.Quit();
    }

    // Main
    public static void Main()
    {
        Application.Init();
        new InvestmentCalculator();
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
        return double.Parse(localEntry.Text);
    }

    public void setEntry(string str)
    {
        localEntry.Text = str;
    }
}
