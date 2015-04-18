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

        public void windowResize(int width, int height)
        {
            this.Width = width + 16;
            this.Height = height + 39;
            flashAlert.Width = width;
            flashAlert.Height = height;
        }
    }
}
