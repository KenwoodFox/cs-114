// HeartRate
using System;
using System.Collections.Generic;

// using System.Drawing;
// using System.Windows.Forms;
// Alias
using con = System.Console;

// public class MainForm : Form
// {
//     Label label1 = new Label();
//     Button b = new Button();
//     public MainForm()
//     {
//         this.SuspendLayout();
//         // Initialize your components here
//         this.label1.Text = "Hello, World!";
//         this.b.Text = "Click Me!";
//         this.b.Click += new EventHandler(Button_Click);
//         this.Controls.Add(label1);
//         this.Controls.Add(b); // Overlays?!
//         this.ResumeLayout();
//         this.Name = "MainForm Name.";
//         this.StartPosition =
//             System.Windows.Forms.FormStartPosition.CenterScreen;
//         this.Text = "MainForm Title!";
//     }
//     private void Button_Click(object sender, EventArgs e)
//     {
//         MessageBox.Show("Button Clicked!");
//     }
// }
public class HeartRate
{
    public static void Main(string[] args)
    {
        // // Not dealing with this atm
        // Application.EnableVisualStyles();
        // Application.SetCompatibleTextRenderingDefault(false);
        // Application.Run(new MainForm());
        con.Write("Welcome to heart rates.\n\nPlease enter your name: ");
        string _fn = con.ReadLine();
        con.Write("Please enter your last name: ");
        string _ln = con.ReadLine();
        int _yob = 0;
        int _cyr = 0;
        try
        {
            con.Write("Please enter the year you were born(1999): ");
            _yob = int.Parse(con.ReadLine());
            con.Write("Please enter the current year (2020): ");
            _cyr = int.Parse(con.ReadLine());
        }
        catch (System.FormatException)
        {
            con.WriteLine("Error! Invalid year!");
        }

        HeartRates myHeartRates = new HeartRates(_fn, _ln, _yob, _cyr);

        con
            .WriteLine($"Your age is {
                myHeartRates.GetAge()}, your avg max hr should be {
                myHeartRates
                    .GetHRE()
                    .avg_max_hr}, your optimal HR Zone is between {
                myHeartRates.GetHRE().target_bpm_lower} and {
                myHeartRates.GetHRE().target_bpm_upper}bpm.");
    }
}

struct HREntry
{
    public HREntry(
        int _age,
        int _target_bpm_lower,
        int _target_bpm_upper,
        int _avg_max_hr
    )
    {
        age = _age;
        target_bpm_upper = _target_bpm_upper;
        target_bpm_lower = _target_bpm_lower;
        avg_max_hr = _avg_max_hr;
    }

    public int age { get; } // User age

    public int target_bpm_upper { get; } // Target BPM

    public int target_bpm_lower { get; }

    public int avg_max_hr { get; } // Max hr
}

class HeartRates
{
    // Public
    public string fName { get; set; } // Never used?

    public string lName { get; set; } // Never used?

    public int yob { get; set; }

    public int cyr { get; set; }

    // Private
    List<HREntry> HREntries = new List<HREntry>();

    // Constructs a HeartRates
    public HeartRates(string _fName, string _lName, int _yob, int _cyr)
    {
        // Imports
        fName = _fName;
        lName = _lName;
        yob = _yob;
        cyr = _cyr;

        // Entries
        HREntries.Add(new HREntry(20, 100, 170, 200));
        HREntries.Add(new HREntry(30, 95, 162, 190));
        HREntries.Add(new HREntry(35, 93, 157, 185));
        HREntries.Add(new HREntry(40, 90, 153, 180));
        HREntries.Add(new HREntry(45, 88, 149, 175));
        HREntries.Add(new HREntry(50, 85, 145, 170));
        HREntries.Add(new HREntry(55, 83, 140, 165));
        HREntries.Add(new HREntry(60, 80, 136, 160));
        HREntries.Add(new HREntry(65, 78, 132, 155));
        HREntries.Add(new HREntry(70, 75, 128, 150));
    }

    public int GetAge()
    {
        return cyr - yob;
    }

    public HREntry GetHRE()
    {
        int age = this.GetAge();

        int closest_idx = 0;
        int closest_v = 10000;
        for (int i = 0; i < HREntries.Count; i++)
        {
            int dist = Math.Abs(HREntries[i].age - age);
            if (dist < closest_v)
            {
                closest_idx = i;
                closest_v = dist;
            }
        }
        return HREntries[closest_idx];
    }
}
