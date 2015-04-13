using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitchdouken
{
    public partial class AlertWindow : Form
    {
        private Twitchdouken parent;
        public AlertWindow(Twitchdouken parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void AlertWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.menuWindowsAlert.Checked = false;

            this.Hide();
            e.Cancel = true;
        }
    }
}
