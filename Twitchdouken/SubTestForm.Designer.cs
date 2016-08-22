namespace Twitchdouken
{
    partial class SubTestForm
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
            this.SubTestNameText = new System.Windows.Forms.Label();
            this.SubTestMonthsText = new System.Windows.Forms.Label();
            this.subnameTxtBox = new System.Windows.Forms.TextBox();
            this.monthTxtBox = new System.Windows.Forms.TextBox();
            this.SubTestSubmitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SubTestNameText
            // 
            this.SubTestNameText.AutoSize = true;
            this.SubTestNameText.Location = new System.Drawing.Point(75, 9);
            this.SubTestNameText.Name = "SubTestNameText";
            this.SubTestNameText.Size = new System.Drawing.Size(35, 13);
            this.SubTestNameText.TabIndex = 0;
            this.SubTestNameText.Text = "Name";
            // 
            // SubTestMonthsText
            // 
            this.SubTestMonthsText.AutoSize = true;
            this.SubTestMonthsText.Location = new System.Drawing.Point(68, 49);
            this.SubTestMonthsText.Name = "SubTestMonthsText";
            this.SubTestMonthsText.Size = new System.Drawing.Size(42, 13);
            this.SubTestMonthsText.TabIndex = 1;
            this.SubTestMonthsText.Text = "Months";
            this.SubTestMonthsText.Click += new System.EventHandler(this.SubTestMonthsText_Click);
            // 
            // subnameTxtBox
            // 
            this.subnameTxtBox.Location = new System.Drawing.Point(45, 26);
            this.subnameTxtBox.Name = "subnameTxtBox";
            this.subnameTxtBox.Size = new System.Drawing.Size(100, 20);
            this.subnameTxtBox.TabIndex = 2;
            // 
            // monthTxtBox
            // 
            this.monthTxtBox.Location = new System.Drawing.Point(45, 65);
            this.monthTxtBox.Name = "monthTxtBox";
            this.monthTxtBox.Size = new System.Drawing.Size(100, 20);
            this.monthTxtBox.TabIndex = 3;
            // 
            // SubTestSubmitBtn
            // 
            this.SubTestSubmitBtn.Location = new System.Drawing.Point(57, 91);
            this.SubTestSubmitBtn.Name = "SubTestSubmitBtn";
            this.SubTestSubmitBtn.Size = new System.Drawing.Size(75, 23);
            this.SubTestSubmitBtn.TabIndex = 4;
            this.SubTestSubmitBtn.Text = "Submit";
            this.SubTestSubmitBtn.UseVisualStyleBackColor = true;
            this.SubTestSubmitBtn.Click += new System.EventHandler(this.SubTestSubmitBtn_Click);
            // 
            // SubTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 121);
            this.Controls.Add(this.SubTestSubmitBtn);
            this.Controls.Add(this.monthTxtBox);
            this.Controls.Add(this.subnameTxtBox);
            this.Controls.Add(this.SubTestMonthsText);
            this.Controls.Add(this.SubTestNameText);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubTestForm";
            this.Text = "Subscription Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SubTestNameText;
        private System.Windows.Forms.Label SubTestMonthsText;
        private System.Windows.Forms.Button SubTestSubmitBtn;
        internal System.Windows.Forms.TextBox subnameTxtBox;
        internal System.Windows.Forms.TextBox monthTxtBox;
    }
}