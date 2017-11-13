using ExcelAddInExpBD123.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExcelAddInExpBD123.PRES {
    /// <summary>
    /// Interaction logic for UserControlWPFSkyNet.xaml
    /// </summary>
    public partial class UserControlWPFSkyNet : UserControl {

        private SkyNetExoEntities db = new SkyNetExoEntities();

        // SqlConnection connexion;
        // string chaineDeConnexion = "Data Source=ServeurSQL;Initial Catalog = SkyNet;User Id = TEST;Password=AAAaaa111";

        public UserControlWPFSkyNet() {
            InitializeComponent();
        }

        private void buttonAffEmployesDsList_Click(object sender, RoutedEventArgs e) {

            Globals.ThisAddIn.Application.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait;

            var lstEmpl = db.employe.ToList();
            this.listBoxEmployes.ItemsSource = lstEmpl; // les champs affichés définis dans XAML

            Globals.ThisAddIn.Application.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault;

            // Pour une liste stubbé AVANT création (testing de la présentatiON)
            /* var items = new List<Employe>();

              items.Add(new Employe() { id = 1, id_departement = 45, nom = "blah" });
              items.Add(new Employe() { id = 2, id_departement = 155, nom = "hell" });
              items.Add(new Employe() { id = 3, id_departement = 195, nom = "what" });
            */
        }

        private void lblMAJ_Unloaded(object sender, RoutedEventArgs e) {
            //déconnecté la BD
            //      connexion.Close();

            db = null;
        }

        private void lblMAJ_Loaded(object sender, RoutedEventArgs e) {
            //connecté la bd
            //          connexion = new SqlConnection(chaineDeConnexion);
            //         connexion.Open();

        }

        private void buttonMAJEmploye_Click(object sender, RoutedEventArgs e) {
            lblMAJ.Content = "";

            // VALIDATION
            if (lblIDdepSelectionne.Content.ToString() == "" || lblIDdepSelectionne.Content.ToString() == "-") { // SI ID_DEPARTEMENT EST PRÉSENT
                MessageBox.Show("Erreur. Le ID département n'existe pas.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtNomDepartement.Text.Trim() == "") { // SI NOM DEP EST SAISIE
                // Style et message d'erreur
                txtNomDepartement.Background = System.Windows.Media.Brushes.Red;
                MessageBox.Show("Veuillez saisir un nom de département.", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Error);
                txtNomDepartement.Background = System.Windows.Media.Brushes.White;
                txtNomDepartement.Text = "";
                lblMAJ.Content = "Veuillez saisir un nom de département.";
                return;
            }
            if (txtVille.Text.Trim() == "") { // SI VILLE DEP EST SAISIE
                // Style et message d'erreur
                txtVille.Background = System.Windows.Media.Brushes.Red;
                MessageBox.Show("Veuillez saisir un nom de ville pour ce département.", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Error);
                txtVille.Background = System.Windows.Media.Brushes.White;
                txtVille.Text = "";
                lblMAJ.Content = "Veuillez saisir un nom de ville pour ce département.";
                return;
            }
            int idDep; // VÉRIFIER SI LE LABEL CONTIENT UN ID DEP.
            if (!int.TryParse(lblIDdepSelectionne.Content.ToString().Trim(), out idDep)) {
                return;
            }
            var dep = db.departement.Find(idDep);

            // FIN VALIDATION
            try {
                int nbRecords = 0;
                if (dep != null) {
                    var departSaisie = new departement { id = idDep, nom = txtNomDepartement.Text.Trim(), ville = txtVille.Text.Trim() };
                    db.Entry(dep).CurrentValues.SetValues(departSaisie);
                    db.Entry(dep).State = System.Data.Entity.EntityState.Modified;
                    nbRecords = db.SaveChanges();
                }

                if (nbRecords != 0) {
                    this.buttonAffEmployesDsList_Click(sender, e); //Actualiser
                    lblMAJ.Content = "Mise à jour réussi!";
                }
            } catch (RetryLimitExceededException) {

                lblMAJ.Content = "Erreur avec la BD. Contacter votre administrateur.";
            }

        }

        private void listBoxEmployes_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var buff = sender as ListBox;
            var sel = (employe)buff.SelectedItem;

            if (sel != null)
                lblIDdepSelectionne.Content = (sel.id_departement > 0) ? sel.id_departement.ToString() : "";
            txtVille.Text = (sel.id_departement > 0) ? sel.departement.ville.ToString() : "";
            txtNomDepartement.Text = (sel.id_departement > 0) ? sel.departement.nom.ToString() : "";
        }
    }
}










/*
public UserControlWPFSkyNet() {
    InitializeComponent();
    setValeursInitiaux();
    activerEvents();
}


private void activerEvents() {
    // événéments :
    // -palier
    cmbPalier.SelectionChanged += cmbPalier_SelectionChanged;
    // -textBoxs
    txtRevAnnuel.TextChanged += handleChange;
    txtImpotFed.TextChanged += handleChange;
    txtImpotQc.TextChanged += handleChange;
    txtREER.TextChanged += handleChange;

    txtRevAnnuel.LostFocus += handleCurrencyFormatting;
    txtImpotFed.LostFocus += handleCurrencyFormatting;
    txtImpotQc.LostFocus += handleCurrencyFormatting;
    txtREER.LostFocus += handleCurrencyFormatting;

    txtRevAnnuel.KeyDown += handleTextBoxKeyDown;
    txtImpotFed.KeyDown += handleTextBoxKeyDown;
    txtImpotQc.KeyDown += handleTextBoxKeyDown;
    txtREER.KeyDown += handleTextBoxKeyDown;

    // -sliders
    sldRevenuBrutAnnuel.ValueChanged += sldRevenuBrutAnnuel_ValueChanged;
    sldImpotFed.ValueChanged += sldImpotFed_ValueChanged;
    sldImpotProv.ValueChanged += sldImpotProv_ValueChanged;
    sldcotisREER.ValueChanged += sldcotisREER_ValueChanged;
}

private void handleTextBoxKeyDown(object sender, KeyEventArgs e) {
    if (e.Key == Key.Return)
        handleCurrencyFormatting(sender, e);

}

private void handleCurrencyFormatting(object sender, RoutedEventArgs e) {
    //if (!txtBoxFormatCurrency(sender)) {
    adjustTextBoxEvent(sender, false); // deactivate évènement du text box changé
    formatTxtBoxCurrency(sender);      // formatter la saisie en argent
    adjustTextBoxEvent(sender, true);  // reactivate évènement du text box changé
    //}
}

private void setValeursInitiaux() {
    // valeurs initiales :
    txtRevAnnuel.Text = String.Format("{0:C}", 0);
    txtImpotFed.Text = String.Format("{0:C}", 0);
    txtImpotQc.Text = String.Format("{0:C}", 0);
    txtREER.Text = String.Format("{0:C}", 0);
}
private enum Palier {
    Provincial,
    Federal,
    Combine
}
private enum VariableMonetaire {
    RevenuAnnuel,
    ImpotFederal,
    ImpotQuebec,
    CotisationReer
}
// Sliders
private void sldRevenuBrutAnnuel_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
    txtRevAnnuel.Text = String.Format("{0:C}", (sldRevenuBrutAnnuel.Value * 10000));
}

private void sldImpotFed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
    txtImpotFed.Text = String.Format("{0:C}", (sldImpotFed.Value * 10000));
}

private void sldImpotProv_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
    txtImpotQc.Text = String.Format("{0:C}", (sldImpotProv.Value * 10000));
}

private void sldcotisREER_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
    txtREER.Text = String.Format("{0:C}", (sldcotisREER.Value * 10000));
}

// Changement de palier
private void cmbPalier_SelectionChanged(object sender, SelectionChangedEventArgs e) {
    evalChange();

}
// Changements aux textboxs
private void handleChange(object sender, TextChangedEventArgs e) {

    if (!valeurValid(sender)) {

        return;
    }



    adjustSliderEvents(sender, false); // deactivate évènements des paliers
    adjustSliderValue(sender);
    adjustSliderEvents(sender, true);  // reactivate évènements des paliers

    evalChange();

}

//private bool txtBoxFormatCurrency(object sender)
//{
//    var txtBox = sender as TextBox;
//    if (txtBox != null)
//    {
//        if (txtBox.Text[txtBox.Text.Length-1] != '$' || txtBox.Text[txtBox.Text.Length - 2] != ' ' || txtBox.Text[txtBox.Text.Length - 5] != ',')
//        {
//            return false;
//        }

//    }
//    return true;
//}

private void adjustTextBoxEvent(object sender, bool enable) {
    var txtBox = sender as TextBox;
    if (txtBox != null) {
        if (enable)
            txtBox.TextChanged += handleChange;
        else
            txtBox.TextChanged -= handleChange;
    }
}

private void adjustSliderValue(object sender) {
    var txtBox = sender as TextBox;
    if (txtBox != null) {
        switch (txtBox.Name) {
            case "txtRevAnnuel":
                sldRevenuBrutAnnuel.Value = double.Parse(txtBox.Text.Trim('$').Trim()) / 10000;
                break;
            case "txtImpotFed":
                sldImpotFed.Value = double.Parse(txtBox.Text.Trim('$').Trim()) / 10000;
                break;
            case "txtImpotQc":
                sldImpotProv.Value = double.Parse(txtBox.Text.Trim('$').Trim()) / 10000;
                break;
            case "txtREER":
                sldcotisREER.Value = double.Parse(txtBox.Text.Trim('$').Trim()) / 10000;
                break;
            default:
                break;
        }
    }
}

private void adjustSliderEvents(object sender, bool enable) {
    var txtBox = sender as TextBox;
    if (txtBox != null) {
        switch (txtBox.Name) {
            case "txtRevAnnuel":
                if (enable)
                    sldRevenuBrutAnnuel.ValueChanged +=
                        sldRevenuBrutAnnuel_ValueChanged;
                else
                    sldRevenuBrutAnnuel.ValueChanged -=
                        sldRevenuBrutAnnuel_ValueChanged;
                break;
            case "txtImpotFed":
                if (enable)
                    sldImpotFed.ValueChanged +=
                        sldImpotFed_ValueChanged;
                else
                    sldImpotFed.ValueChanged -=
                        sldImpotFed_ValueChanged;
                break;
            case "txtImpotQc":
                if (enable)
                    sldImpotProv.ValueChanged +=
                        sldImpotProv_ValueChanged;
                else
                    sldImpotProv.ValueChanged -=
                        sldImpotProv_ValueChanged;
                break;
            case "txtREER":
                if (enable)
                    sldcotisREER.ValueChanged +=
                        sldcotisREER_ValueChanged;
                else
                    sldcotisREER.ValueChanged -=
                        sldcotisREER_ValueChanged;
                break;
            default:
                break;
        }

    }
}

private void formatTxtBoxCurrency(object sender) {
    var txtBox = sender as TextBox;
    if (txtBox == null) return; // Vérifier si le controls est nul:

    txtBox.Text = String.Format("{0:C}", double.Parse(txtBox.Text.Trim('$').Trim()));

}

private bool valeurValid(object sender) {

    var txtBox = sender as TextBox;
    if (txtBox == null) return false; // Vérifier si les controls sont nuls:

    if (txtBox.Text.Trim().Length == 0) {
        txtBox.Text = String.Format("{0:C}", 0); //réinitialise à 0,00$ si la valeur est nul
        return false;
    }

    // si valeurs non numériques
    decimal valTxtBox;
    if (!decimal.TryParse(txtBox.Text.Trim('$').Trim(), out valTxtBox) || valTxtBox < 0) {
        // Style et message d'erreur
        txtBox.Background = System.Windows.Media.Brushes.Red;
        MessageBox.Show("Saisie invalide : Entier seulement", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Error);
        txtBox.Background = System.Windows.Media.Brushes.White;
        txtBox.Text = String.Format("{0:C}", 0); //réinitialise à 0,00$ si la valeur est négative
        return false;
    }

    return true;

}

private void evalChange() // on evalue le remboursement ou le montant d'impot à payer
{
    // Evaluer l'impôt possible et afficher le résultat dans lblImpotPossible :
    //	Si le remboursement est au Québec, on mettra l’information sur l’impôt possible en Bleu 
    //  sinon en Rouge si c’est l’impôt fédéral. ...
    //  sur les deux paliers, on mettra l’information en VIOLET. 
    switch (cmbPalier.SelectedIndex) {
        case (byte)Palier.Provincial:

            double evalImpProv = evalImpotProv();
            lblImpotPossible.Content = String.Format("{0:C}", evalImpProv);
            lblPallier.Content = (evalImpProv > 0) ? "IMPOT POSSIBLE QUÉBEC" : "REMBOURSEMENT POSSIBLE QUÉBEC";

            lblImpotPossible.Foreground = System.Windows.Media.Brushes.Blue;

            break;
        case (byte)Palier.Federal:

            double evalImpFed = evalImpotFed();
            lblImpotPossible.Content = String.Format("{0:C}", evalImpFed);
            lblPallier.Content = (evalImpFed > 0) ? "IMPOT POSSIBLE FÉDÉRAL" : "REMBOURSEMENT POSSIBLE FÉDÉRAL";
            lblImpotPossible.Foreground = System.Windows.Media.Brushes.Red;

            break;
        case (byte)Palier.Combine:

            double evalImpCombine = evalImpotCombine();
            lblImpotPossible.Content = String.Format("{0:C}", evalImpCombine);
            lblPallier.Content = (evalImpCombine > 0) ? "IMPOT POSSIBLE COMBINÉ" : "REMBOURSEMENT POSSIBLE COMBINÉ";
            lblImpotPossible.Foreground = System.Windows.Media.Brushes.Violet;

            break;
        default:
            break;
    }
}

private double evalImpotFed() {
    //Féderal
    //-	Si salaire>=200001 alors impot=46317+33 %*(salaire-200000)
    //-	Si salaire >=140389 et <=200000 alors impot=29327+29%(salaire-140388)
    //-	Si salaire >=90564 et <=140388 alors impot=16075+26%(salaire-90563)
    //-	Si salaire >=45283 et <=90563 alors impot=6792+20.5%(salaire-45282)
    //-	Si salaire <=42282 alors impot=15% salaire
    //Une fois l’impot calculé, on retire le montant de base*15%, si négatif. Il pourrait y avoir un remboursement 
    // Montant de base au fédéral 11474   
    double totImpotFed;

    double salaire = double.Parse(txtRevAnnuel.Text.Trim('$').Trim());
    double impotFedPay = double.Parse(txtImpotFed.Text.Trim('$').Trim());
    double cotisReer = double.Parse(txtREER.Text.Trim('$').Trim());

    double montantBaseFed = 11474d;

    salaire -= cotisReer;

    if (salaire >= 200001)
        totImpotFed = 46317.0 + 0.33 * (salaire - 200000);
    else if (salaire >= 140389)
        totImpotFed = 29327.0 + 0.29 * (salaire - 140388);
    else if (salaire >= 90564)
        totImpotFed = 16075.0 + 0.26 * (salaire - 90563);
    else if (salaire >= 45283)
        totImpotFed = 6792.0 + 0.205 * (salaire - 45282);
    else
        totImpotFed = 0.15 * (salaire);


    totImpotFed -= montantBaseFed * 0.15;


    // On ajuste le calcul du remboursement ou l'impôt restante à payer selon la saisie utilisateur 
    totImpotFed = ajustementSaisie(totImpotFed, impotFedPay);

    return totImpotFed;
}

private double evalImpotProv() {
    //Provincial

    //-	Si salaire>=130151 alors impot=19689+25.75 %*(salaire-103150)
    //-	Si salaire >=84781 et <=103150 alors impot=15260+24%(salaire-84780)
    //-	Si salaire >=42391 et <=84780 alors impot=6782+20%(salaire-42390)

    //-	Si salaire <=42390 alors impot=16% salaire
    //Une fois l’impot calculé, on retire le montant de base*20%, si négatif. Il pourrait y avoir un remboursement 
    // Montant de base au provincial 11550
    double totImpotProv;

    double salaire = double.Parse(txtRevAnnuel.Text.Trim('$').Trim());
    double impotQcPay = double.Parse(txtImpotQc.Text.Trim('$').Trim());
    double cotisReer = double.Parse(txtREER.Text.Trim('$').Trim());

    double montantBaseQc = 11550d;

    salaire -= cotisReer;

    if (salaire >= 130151)
        totImpotProv = 19689.0 + 0.2575 * (salaire - 103150);
    else if (salaire >= 84781)
        totImpotProv = 15260.0 + 0.24 * (salaire - 84780);
    else if (salaire >= 42391)
        totImpotProv = 6782.0 + 0.20 * (salaire - 42390);
    else
        totImpotProv = 0.16 * (salaire);


    totImpotProv -= montantBaseQc * 0.2;


    // On ajuste le calcul du remboursement ou l'impôt restante à payer selon la saisie utilisateur 
    totImpotProv = ajustementSaisie(totImpotProv, impotQcPay);

    return totImpotProv;
}

private double ajustementSaisie(double totImpotProvOuFed, double impotQcOuFedPay) {
    return totImpotProvOuFed - impotQcOuFedPay;
}

private double evalImpotCombine() {
    return (evalImpotProv() + evalImpotFed());
}
*/




