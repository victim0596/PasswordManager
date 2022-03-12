using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PasswordManagerWPF.Classes;
using PasswordManagerWPF.Components.Commands;
using PasswordManagerWPF.DBModels;
using PasswordManagerWPF.GVariable;
using PasswordManagerWPF.Components.Queries;
using PasswordManagerWPF.Domain;

namespace PasswordManagerWPF
{
    /// <summary>
    /// Logica di interazione per SavedPassword.xaml
    /// </summary>
    public partial class SavedPassword : Page
    {
        public SavedPassword()
        {
            InitializeComponent();
            try
            {
                globalVar.listPsw = new GetAllSavedPswQueryHandler().Retrieve();
                //savedPswDB.ItemsSource = globalVar.listPsw;
                ColorChanger colorChanger = new ColorChanger();
                colorChanger.applyFontSavPsw(this);
                fontSize fontSize = new fontSize();
                fontSize.applyFontSizeSavPsw(this);
                savedPswDB.ItemsSource = CalculateEntropyEveryPsw(globalVar.listPsw);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private List<AccountDetailWithEntropy> CalculateEntropyEveryPsw(List<GetAllSavedPswQueryResult> listPsw)
        {
            List<AccountDetailWithEntropy> result = new List<AccountDetailWithEntropy>();
            foreach (var item in listPsw)
            {
                string entropyValue = new EntropyCalc().entropyByPassword(item.Password);
                result.Add(new AccountDetailWithEntropy { Username = item.Username, Appname = item.Appname, Entropy = entropyValue });
            }
            return result;
        }

        //back Button
        private void backBtn(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HomePage());
        }
        //addpassword btn
        private void insertPassword(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginForm loginForm = new LoginForm();
                loginForm.isValidPsw(appNameText.Text, passwordText.Password.ToString(), usernameText.Text);
                new InsertPasswordCommandHandler().Execute(new InsertPasswordCommand { Appname = appNameText.Text, Username = usernameText.Text, Password = passwordText.Password.ToString() });
                MessageBox.Show(LangString.pswAdded);
                this.NavigationService.Navigate(new SavedPassword());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Logout btn
        private void Logout(object sender, RoutedEventArgs e)
        {
            globalVar.userLogged = false;
            MessageBox.Show("Logged Out");
            this.NavigationService.Navigate(new HomePage());
        }
        //copy function
        private void CopyPsw(int index)
        {
            Clipboard.SetText(globalVar.listPsw[index].Password);
            MessageBox.Show(LangString.pswCopied);
        }


        private void showPsw(int rows, int column)
        {

            var cellInfo = savedPswDB.SelectedCells[column - 2];
            var content = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;

            if (content == string.Empty) (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text = globalVar.listPsw[rows].Password;
            else (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text = string.Empty;
        }

        private void savedPswDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = savedPswDB.SelectedIndex;
            int selectedColum = savedPswDB.CurrentColumn.DisplayIndex;
            switch (selectedColum)
            {
                case 4:
                    {
                        showPsw(selectedIndex, selectedColum);
                        break;
                    }
                case 5:
                    {
                        EditRow(selectedIndex);
                        break;
                    }
                case 6:
                    {
                        CopyPsw(selectedIndex);
                        break;
                    }
                case 7:
                    {
                        DeleteRow(selectedIndex);
                        break;
                    }
            }
        }

        private void EditRow(int selectedIndex)
        {
            //info per appname
            var cellInfoAppName = savedPswDB.SelectedCells[0];
            var contentAppName = (cellInfoAppName.Column.GetCellContent(cellInfoAppName.Item) as TextBlock).Text;
            //info per username
            var cellInfoUsername = savedPswDB.SelectedCells[1];
            var contentUsername = (cellInfoUsername.Column.GetCellContent(cellInfoUsername.Item) as TextBlock).Text;

            globalVar.appNameDetail = contentAppName;
            globalVar.passwordDetail = globalVar.listPsw[selectedIndex].Password;
            globalVar.usernameDetail = contentUsername;
            globalVar.idRowDetail = globalVar.listPsw[selectedIndex].Id;
            EditDetail editDetail = new EditDetail();
            editDetail.ShowDialog();
        }

        private void findFunc(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchText.Text)) savedPswDB.ItemsSource = globalVar.listPsw;
            else
            {
                savedPswDB.ItemsSource = globalVar.listPsw.Where(x => Regex.Match(x.Appname, searchText.Text, RegexOptions.IgnoreCase).Success).ToList();
            }
        }

        private void DeleteRow(int selectedIndex)
        {
            MessageBoxResult result = MessageBox.Show(LangString.messageDelete, "", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                new DeleteDetailCommandHandler().Execute(new DeleteDetailCommand { Id = globalVar.listPsw[selectedIndex].Id });
                this.NavigationService.Navigate(new SavedPassword());
            }
        }

    }
}
