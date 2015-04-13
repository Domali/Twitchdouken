namespace Twitchdouken
{
    partial class AlertWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertWindow));
            this.flashAlert = new AxShockwaveFlashObjects.AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this.flashAlert)).BeginInit();
            this.SuspendLayout();
            // 
            // flashAlert
            // 
            this.flashAlert.Enabled = true;
            this.flashAlert.Location = new System.Drawing.Point(1, 1);
            this.flashAlert.Name = "flashAlert";
            this.flashAlert.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flashAlert.OcxState")));
            this.flashAlert.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.flashAlert.Size = new System.Drawing.Size(400, 571);
            this.flashAlert.TabIndex = 1;
            // 
            // AlertWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(404, 574);
            this.Controls.Add(this.flashAlert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlertWindow";
            this.Text = "Twitchdouken - AlertWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlertWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.flashAlert)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public AxShockwaveFlashObjects.AxShockwaveFlash flashAlert;


    }
}