using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace ExcelAddInExpBD123 {
    public partial class ManageTaskPaneRibbon {

        // public static Microsoft.Office.Tools.Ribbon.OfficeRibbon rUI = null;

        private void ManageTaskPaneRibbon_Load(object sender, RibbonUIEventArgs e) {
            this.RibbonUI.ActivateTab("tab2");
            //rUI = ((Microsoft.Office.Tools.Ribbon.OfficeRibbon)sender).Ribbon;
            //rUI.RibbonUI.ActivateTab("tab2");
            //this.tab1.RibbonUI.ActivateTab("TabAddIns");
        }
        // this.tab1.RibbonUI.ActivateTab("TabAddIns"); // Activer la tab sur le ruban au lancement


        private void toggleButtonLancer_Click(object sender, RibbonControlEventArgs e) {
            Globals.ThisAddIn.TaskPaneSkyNet.Visible = ((RibbonToggleButton)sender).Checked;
        }



        private void toggleButtonFermer_Click(object sender, RibbonControlEventArgs e) {

            DialogResult dlgResult = System.Windows.Forms.MessageBox.Show("Voulez-vous vraiment fermer l'utilitaire SkyNet?\n\nSélectionner Oui pour confirmer.", "Fermeture de SkyNet", MessageBoxButtons.YesNo);
            if (dlgResult == DialogResult.Yes) {
                Globals.ThisAddIn.QuitAddIn(); // globabl method defined in THisAddIn cl.
            } else {
                toggleButtonFermer.Checked = false;
            }


        }

        private void toggleButtonAide_Click(object sender, RibbonControlEventArgs e) {
            System.Windows.Forms.MessageBox.Show("Bienvenu dans l'application SkyNet!\n\nLancer l'utilitaire avec le bouton ci-présent SkyNet!\n\nSasha Howell Bouchard");
            toggleButtonAide.Checked = false;
        }
    }

}
