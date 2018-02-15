using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealHighAgeCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dtp.MaxDate = System.DateTime.Now;
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            DateTime now = System.DateTime.Now;
            DateTime selected = dtp.Value;
            int OldMonth, year = 0, Month = 0, Day = 0;
            OldMonth = now.Month;
            while (OldMonth == now.Month)
            {
                now = now.AddDays(-1);
                selected = selected.AddDays(-1);

            }
            while (now.CompareTo(selected) >= 0)
            {
                year++;
                now = now.AddYears(-1);

            }
            year--;
            now = now.AddYears(1);
            OldMonth = now.Month;
            while (now.CompareTo(selected) >= 0)
            {
                Day++;
                now = now.AddDays(-1);
                if (OldMonth != now.Month && now.CompareTo(selected) >= 0)
                {
                    Month++;
                    Day = 0;
                    OldMonth = now.Month;
                }
            }
            now = now.AddDays(1);
            Day--;
            TimeSpan dif = now.Subtract(selected);

            
            lbl.Text = "The Difference Is " + year + " Years " + Month + " Month " + Day + " Days ";
           


        }
    }
}
