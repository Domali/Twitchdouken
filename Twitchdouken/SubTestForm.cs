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
    public partial class SubTestForm : Form
    {
        public SubTestForm()
        {
            InitializeComponent();

        }

        private void SubTestMonthsText_Click(object sender, EventArgs e)
        {

        }

        private void SubTestSubmitBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
