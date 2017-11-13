using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using Microsoft.Win32;
using System.Windows.Forms;

namespace ExcelAddInExpBD123 {
    // Cette classe contient logique de présentation.
    public partial class ThisAddIn {
        public static string NameOfAddin = "ExcelAddInExpBD123";

        private static int FloatingCTPOverlapForHeight = 45;
        private static int FloatingCTPOverlapForWidth = 15;

        public PRES.UserControlFMSkyNet myUserControlFromFM;

        private Microsoft.Office.Tools.CustomTaskPane myCustomTaskPaneSkyNet; // https://msdn.microsoft.com/en-ca/library/bb772076.aspx https://msdn.microsoft.com/en-ca/library/bb384311.aspx //UserControl2.cs //UserControl1.xaml //// ajouter WPF Usercontrol type WPF, faire du drag and drop avec les outils, générer projet, ajouter usercontrol windows forms, mettre le code pour le taskpane, drag and drop de usercontrol wpf à usercontrol windowsforms
        public Microsoft.Office.Tools.CustomTaskPane TaskPaneSkyNet {
            get {
                if (myCustomTaskPaneSkyNet == null) // chargement de l'utilitaire si requis.
                    this.initSkyNetTP();

                return myCustomTaskPaneSkyNet;
            }
        }

        private int ctPaneWidth = 780;
        private int ctPaneHeight = 525;

        // Cette méthode va appeler : ThisAddIn_Shutdown
        internal void QuitAddIn() {
            Microsoft.Office.Core.COMAddIns adds = Globals.ThisAddIn.Application.COMAddIns;
            foreach (Microsoft.Office.Core.COMAddIn addIn in adds) {
                if (addIn.ProgId == ThisAddIn.NameOfAddin && addIn.Connect) {   // ThisAddIn.NameOfAddin => static string manually definned in ThisAddin cl
                    addIn.Connect = false;
                    break;
                }
            }
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e) {
            initSkyNetTP(); // chargement initial de l'utilitaire
        }

        // Méthode pour inititialiser et afficher la fenêtre
        private void initSkyNetTP() {
            myUserControlFromFM = new PRES.UserControlFMSkyNet(); // UserControlFMSkyNet.cs
            int width = myUserControlFromFM.Width;
            int height = myUserControlFromFM.Height;

            myCustomTaskPaneSkyNet = this.CustomTaskPanes.Add(myUserControlFromFM, "SkyNet - Employés et départements");

            myCustomTaskPaneSkyNet.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionFloating;
            myCustomTaskPaneSkyNet.Height = height + FloatingCTPOverlapForHeight;
            myCustomTaskPaneSkyNet.Width = width + FloatingCTPOverlapForWidth;

            myCustomTaskPaneSkyNet.DockPositionRestrict = Office.MsoCTPDockPositionRestrict.msoCTPDockPositionRestrictNoChange;

            myCustomTaskPaneSkyNet.Control.SizeChanged += new EventHandler(Control_SizeChanged);

            myCustomTaskPaneSkyNet.Visible = true;
            myCustomTaskPaneSkyNet.VisibleChanged += new EventHandler(myCustomTaskPaneSkyNet_VisibleChanged);
        }

        private void myCustomTaskPaneSkyNet_VisibleChanged(object sender, EventArgs e) {

            Globals.Ribbons.ManageTaskPaneRibbon.toggleButtonLancer.Checked = myCustomTaskPaneSkyNet.Visible;

            // Retirer l'utilitaire de la mémoire si non visible.
            if (!myCustomTaskPaneSkyNet.Visible) {
                CustomTaskPanes.Remove(myCustomTaskPaneSkyNet);
                myCustomTaskPaneSkyNet = null;
            }

            //ManageTaskPaneRibbon.rUI.RibbonUI.ActivateTab("TabAddIns");
            Globals.Ribbons.ManageTaskPaneRibbon.RibbonUI.ActivateTab("tab2");

        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e) {

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Office\\Excel\\Addins\\ExcelAddInExpBD123", true);

            if (registryKey != null) {
                registryKey.SetValue("LoadBehavior", 2);
            }
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup() {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion

        //Méthode pour empêcher le redimensionnement
        //Méthode pour empêcher le redimensionnement
        private void Control_SizeChanged(object sender, EventArgs e) {

            var userControl = sender as System.Windows.Forms.UserControl;

            if (userControl.Height + FloatingCTPOverlapForHeight > ctPaneHeight && userControl.Width + FloatingCTPOverlapForWidth > ctPaneWidth) {
                Globals.ThisAddIn.Application.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait;
                SendKeys.Send("{ESC}");

                Globals.ThisAddIn.TaskPaneSkyNet.Height = ctPaneHeight;
                Globals.ThisAddIn.TaskPaneSkyNet.Width = ctPaneWidth;

                Globals.ThisAddIn.Application.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault;
            } else if (userControl.Height + FloatingCTPOverlapForHeight > ctPaneHeight) {
                Globals.ThisAddIn.Application.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait;
                SendKeys.Send("{ESC}");

                Globals.ThisAddIn.TaskPaneSkyNet.Height = ctPaneHeight;

                Globals.ThisAddIn.Application.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault;
            } else if (userControl.Width + FloatingCTPOverlapForWidth > ctPaneWidth) {
                Globals.ThisAddIn.Application.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait;
                SendKeys.Send("{ESC}");

                Globals.ThisAddIn.TaskPaneSkyNet.Width = ctPaneWidth;

                Globals.ThisAddIn.Application.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault;
            }
        }
    }
}