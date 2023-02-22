using System;
using System.Collections.Generic;
using Gtk;

// Alias
using con = System.Console;

class Calculator : Window
{
    static NumericInput op1;

    static NumericInput op;

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
        op1 = new NumericInput("Operand 1", "86");
        fix.Put(op1.localFix, 20, 20);
        op = new NumericInput("Operator", "/");
        fix.Put(op.localFix, 20, 60);
        op2 = new NumericInput("Operand 2", "86");
        fix.Put(op2.localFix, 20, 100);
        re = new NumericInput("Result", "86");
        fix.Put(re.localFix, 20, 140);

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
        double val1 = op1.getEntry();
        string userOp = op.getStr();
        double val2 = op2.getEntry();

        re.setEntry($"{parseLogic(userOp, val1, val2)}");
    }

    static void pExit(object obj, EventArgs args)
    {
        Application.Quit();
    }

    static double parseLogic(string op, double x, double y)
    {
        switch (op)
        {
            case "+":
                return x + y;
            case "-":
                return x - y;
            case "*":
                return x * y;
            case "/":
                return x / y;
            case "%":
                return x % y;
            case "^":
                return Math.Pow(x, y);
            default:
                AboutDialog about = new AboutDialog();
                about.Comments = @"Error invalid operator!";
                about.Run();
                about.Destroy();
                throw new Exception("Invalid Operator!");
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
