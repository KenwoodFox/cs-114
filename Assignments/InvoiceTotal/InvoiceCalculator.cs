using System;
using System.Collections.Generic;
using System.Linq;
using Gtk;

// Alias
using con = System.Console;

class Calculator : Window
{
    // Static memory
    static NumericInput inSubtotal;

    static NumericInput outSubtotal;

    static NumericInput outDiscountPercent;

    static NumericInput outDiscountAmount;

    static NumericInput outTotal;

    static NumericInput numberInvoices;

    static NumericInput totalInvoices;

    static NumericInput invoiceAverage;

    // Other memory
    static List<double> invoiceList = new List<double>();

    public Calculator() :
        base("Color Dialog")
    {
        // Start this application
        Application.Init();

        // Setup all objects
        Fixed fix = new Fixed();
        Button calcBtn = new Button("Calculate");
        fix.Put(calcBtn, 20, 220);
        Button clearBtn = new Button("Clear");
        fix.Put(clearBtn, 100, 220);
        Button exitBtn = new Button("Exit");
        fix.Put(exitBtn, 380, 220);

        // All the input boxes
        inSubtotal = new NumericInput("Enter Subtotal", "");
        fix.Put(inSubtotal.localFix, 20, 20);
        outSubtotal = new NumericInput("Subtotal", "$50.00");
        fix.Put(outSubtotal.localFix, 20, 60);
        outDiscountPercent = new NumericInput("Discount Percent", "25.0%");
        fix.Put(outDiscountPercent.localFix, 20, 100);
        outDiscountAmount = new NumericInput("Discount Amount", "12.50");
        fix.Put(outDiscountAmount.localFix, 20, 140);
        outTotal = new NumericInput("Total", "$37.50");
        fix.Put(outTotal.localFix, 20, 180);

        // Row 2
        numberInvoices = new NumericInput("Number Of Invoices", "");
        fix.Put(numberInvoices.localFix, 380, 20);
        totalInvoices = new NumericInput("Total of Invoices", "$165.00");
        fix.Put(totalInvoices.localFix, 380, 60);
        invoiceAverage = new NumericInput("Invoice Average", "$55.00");
        fix.Put(invoiceAverage.localFix, 380, 100);

        // Setup Callbacks
        calcBtn.Clicked += new EventHandler(pCalculate);
        exitBtn.Clicked += new EventHandler(pExit);
        clearBtn.Clicked += new EventHandler(pClear);

        Window window = new Window("Invoice Calculator");

        // Check when window is closed.
        window.DeleteEvent += pExit;

        // Add the button to the window and display everything
        window.Add (fix);
        window.ShowAll();

        Application.Run();
    }

    static void pClear(object obj, EventArgs args)
    {
        // Clears the.. whatever.
    }

    static void pCalculate(object obj, EventArgs args)
    {
        // Get the subtotal
        double userSubtotal = inSubtotal.getEntry();

        outSubtotal.setEntry($"{userSubtotal:C}"); // Idk why

        // Set the percentage for the discount (is this supposed to be dynamic?)
        double discountPercent = 0.25;
        outDiscountPercent.setEntry($"{discountPercent:P}");

        // The value of the discount
        double discount = discountPercent * userSubtotal;
        outDiscountAmount.setEntry($"{discount:C}");

        // The new total
        double total = userSubtotal - discount;
        outTotal.setEntry($"{total:C}");

        // Update the overall invoice list
        invoiceList.Add (total);
        numberInvoices.setEntry($"{invoiceList.Count}");
        totalInvoices.setEntry($"{invoiceList.Sum():C}");
        invoiceAverage.setEntry($"{invoiceList.Average():C}");
    }

    static void pExit(object obj, EventArgs args)
    {
        Application.Quit();
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
