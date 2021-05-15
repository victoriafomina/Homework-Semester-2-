using System;
using System.Windows.Forms;

namespace Clock
{
    /// <summary>
    /// Class that implements a simple clock.
    /// </summary>
    public partial class Clock : Form
    {
        /// <summary>
        /// Initializes an object of the Clock class.
        /// </summary>
        public Clock()
        {
            InitializeComponent();
            TimerTick(null, null);
        }

        private void ClockLoad(object sender, EventArgs e)
        {
            timer.Start();
        }
        
        private void TimerTick(object sender, EventArgs e)
        {
            ClockField.Text = DateTime.Now.ToString("T");
        }
    }
}
