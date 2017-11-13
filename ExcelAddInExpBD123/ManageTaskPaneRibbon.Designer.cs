using System;
using Microsoft.Office.Tools.Ribbon;

namespace ExcelAddInExpBD123 {
    partial class ManageTaskPaneRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ManageTaskPaneRibbon()
            : base(Globals.Factory.GetRibbonFactory()) {
            InitializeComponent();

        }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageTaskPaneRibbon));
            this.tab2 = this.Factory.CreateRibbonTab();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.toggleButtonLancer = this.Factory.CreateRibbonToggleButton();
            this.toggleButtonAide = this.Factory.CreateRibbonToggleButton();
            this.toggleButtonFermer = this.Factory.CreateRibbonToggleButton();
            this.tab2.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab2
            // 
            this.tab2.Groups.Add(this.group2);
            this.tab2.Label = "SkyNet";
            this.tab2.Name = "tab2";
            // 
            // group2
            // 
            this.group2.Items.Add(this.toggleButtonLancer);
            this.group2.Items.Add(this.separator1);
            this.group2.Items.Add(this.toggleButtonAide);
            this.group2.Items.Add(this.separator2);
            this.group2.Items.Add(this.toggleButtonFermer);
            this.group2.Label = "Utilitaire SkyNet";
            this.group2.Name = "group2";
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // toggleButtonLancer
            // 
            this.toggleButtonLancer.Checked = true;
            this.toggleButtonLancer.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.toggleButtonLancer.Image = ((System.Drawing.Image)(resources.GetObject("toggleButtonLancer.Image")));
            this.toggleButtonLancer.Label = "Utilitaire SkyNet";
            this.toggleButtonLancer.Name = "toggleButtonLancer";
            this.toggleButtonLancer.OfficeImageId = "TaskPanesMenu";
            this.toggleButtonLancer.ScreenTip = "Lancer/Fermer SkyNet";
            this.toggleButtonLancer.ShowImage = true;
            this.toggleButtonLancer.SuperTip = "Cliquer sur le bouton de l\'utilitaire pour lancer ou fermer SkyNet";
            this.toggleButtonLancer.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleButtonLancer_Click);
            // 
            // toggleButtonAide
            // 
            this.toggleButtonAide.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.toggleButtonAide.Label = "Information";
            this.toggleButtonAide.Name = "toggleButtonAide";
            this.toggleButtonAide.OfficeImageId = "Help";
            this.toggleButtonAide.ScreenTip = "À propos";
            this.toggleButtonAide.ShowImage = true;
            this.toggleButtonAide.SuperTip = "Clicker pour obtenir de l\'information à propos de l\'utilitaire";
            this.toggleButtonAide.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleButtonAide_Click);
            // 
            // toggleButtonFermer
            // 
            this.toggleButtonFermer.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.toggleButtonFermer.Label = "Fermer Utilitaire";
            this.toggleButtonFermer.Name = "toggleButtonFermer";
            this.toggleButtonFermer.OfficeImageId = "CloseComparison";
            this.toggleButtonFermer.ScreenTip = "Fermeture de l\'utilitaire";
            this.toggleButtonFermer.ShowImage = true;
            this.toggleButtonFermer.SuperTip = "Clicker pour fermer l\'utilitaire";
            this.toggleButtonFermer.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleButtonFermer_Click);
            // 
            // ManageTaskPaneRibbon
            // 
            this.Name = "ManageTaskPaneRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab2);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ManageTaskPaneRibbon_Load);
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion
        private RibbonTab tab2;
        internal RibbonGroup group2;
        public RibbonToggleButton toggleButtonLancer;
        internal RibbonSeparator separator1;
        public RibbonToggleButton toggleButtonAide;
        internal RibbonSeparator separator2;
        public RibbonToggleButton toggleButtonFermer;
    }

    partial class ThisRibbonCollection {
        internal ManageTaskPaneRibbon ManageTaskPaneRibbon {
            get { return this.GetRibbon<ManageTaskPaneRibbon>(); }
        }
    }
}
