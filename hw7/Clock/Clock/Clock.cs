using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Clock : Form
    {
        public Clock()
        {
            InitializeComponent();
        }

        private void Clock_Load(object sender, EventArgs e)
        {
            timer.Start();
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            ClockField.Text = DateTime.Now.ToString("T");
        }
    }
}
