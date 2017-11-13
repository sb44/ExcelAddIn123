namespace ExcelAddInExpBD123.PRES {
    partial class UserControlFMSkyNet {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl12 = new ExcelAddInExpBD123.PRES.UserControlWPFSkyNet();
            this.SuspendLayout();
            // 
            // elementHost2
            // 
            this.elementHost2.Location = new System.Drawing.Point(0, 0);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(765, 480);
            this.elementHost2.TabIndex = 1;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.userControl12;
            // 
            // UserControlFMSkyNet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.elementHost2);
            this.Name = "UserControlFMSkyNet";
            this.Size = new System.Drawing.Size(765, 480);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private ExcelAddInExpBD123.PRES.UserControlWPFSkyNet userControl12;
    }
}
