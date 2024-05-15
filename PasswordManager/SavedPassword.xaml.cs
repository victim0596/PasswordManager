using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using PasswordManager.Classes;
using PasswordManager.Components.Commands;
using PasswordManager.GVariable;
using PasswordManager.Components.Queries;
using PasswordManager.Domain;
using OfficeOpenXml;
using System.IO;
using System.Drawing;

namespace PasswordManager
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
                globalVar.listPsw = CalculateEntropyEveryPsw(new GetAllSavedPswQueryHandler().Retrieve());
                //savedPswDB.ItemsSource = globalVar.listPsw;
                ColorChanger colorChanger = new ColorChanger();
                colorChanger.applyFontSavPsw(this);
                fontSize fontSize = new fontSize();
                fontSize.applyFontSizeSavPsw(this);
                savedPswDB.ItemsSource = globalVar.listPsw;
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
                result.Add(new AccountDetailWithEntropy { Username = item.Username, Appname = item.Appname, Entropy = entropyValue, Password = item.Password, Id = item.Id });
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
        private void CopyPsw()
        {
            //info per password
            var cellInfoPassword = savedPswDB.SelectedCells[2];
            var contentPassword = (cellInfoPassword.Column.GetCellContent(cellInfoPassword.Item) as TextBlock).Text;
            Clipboard.SetText(contentPassword);
            MessageBox.Show(LangString.pswCopied);
        }


        private void showPsw()
        {

            var cellInfo = savedPswDB.SelectedCells[2];
            var contentColor = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Foreground;
            if (contentColor.ToString() == "#00FFFFFF") (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Foreground = new SolidColorBrush(Colors.Black);
            else (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Foreground = new SolidColorBrush(Colors.Transparent);
        }

        private void savedPswDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedColum = savedPswDB.CurrentColumn.DisplayIndex;
            switch (selectedColum)
            {
                case 4:
                    {
                        showPsw();
                        break;
                    }
                case 5:
                    {
                        EditRow();
                        break;
                    }
                case 6:
                    {
                        CopyPsw();
                        break;
                    }
                case 7:
                    {
                        DeleteRow();
                        break;
                    }
            }
        }

        private void EditRow()
        {
            //info per appname
            var cellInfoAppName = savedPswDB.SelectedCells[0];
            var contentAppName = (cellInfoAppName.Column.GetCellContent(cellInfoAppName.Item) as TextBlock).Text;
            //info per username
            var cellInfoUsername = savedPswDB.SelectedCells[1];
            var contentUsername = (cellInfoUsername.Column.GetCellContent(cellInfoUsername.Item) as TextBlock).Text;
            //info per password
            var cellInfoPassword = savedPswDB.SelectedCells[2];
            var contentPassword = (cellInfoPassword.Column.GetCellContent(cellInfoPassword.Item) as TextBlock).Text;


            globalVar.appNameDetail = contentAppName;
            globalVar.passwordDetail = contentPassword;
            globalVar.usernameDetail = contentUsername;
            globalVar.idRowDetail = globalVar.listPsw.Where(x => x.Appname == contentAppName).FirstOrDefault().Id;
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

        private void DeleteRow()
        {
            MessageBoxResult result = MessageBox.Show(LangString.messageDelete, "", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                //info per appname
                var cellInfoAppName = savedPswDB.SelectedCells[0];
                var contentAppName = (cellInfoAppName.Column.GetCellContent(cellInfoAppName.Item) as TextBlock).Text;

                var idDetail = globalVar.listPsw.Where(x => x.Appname == contentAppName).FirstOrDefault().Id;
                new DeleteDetailCommandHandler().Execute(new DeleteDetailCommand { Id = idDetail });
                this.NavigationService.Navigate(new SavedPassword());
            }
        }

        private void exportExcelGrid(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage pck = new ExcelPackage())
            {
                try
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Password");
                    DataTable dt = new DataTable("Dettaglio Password");
                    dt.Columns.Add("AppName", typeof(string));
                    dt.Columns.Add("Username", typeof(string));
                    dt.Columns.Add("Password", typeof(string));
                    var listaPsw = savedPswDB.ItemsSource;
                    foreach (AccountDetailWithEntropy psw in listaPsw)
                    {
                        DataRow row = dt.NewRow();
                        row["AppName"] = psw.Appname;
                        row["Password"] = psw.Password;
                        row["Username"] = psw.Username;
                        dt.Rows.Add(row);
                    }
                    ws.Cells["A1"].LoadFromDataReader(dt.CreateDataReader(), true);
                    //configurazione
                    ws.Cells["A1:C1"].AutoFilter = true;
                    ws.Cells["A1:C1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Cells["A1:C1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.RoyalBlue);
                    ws.Cells["A1:C1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
                    ws.Cells["A1:C1"].Style.Font.Bold = true;
                    ws.Column(1).Width = 50;
                    ws.Column(2).Width = 50; 
                    ws.Column(3).Width = 50;


                    Stream s = new MemoryStream(pck.GetAsByteArray());
                    var fileStream = File.Create(globalVar.excelPath + "\\pswExcel.xlsx");
                    s.Seek(0, SeekOrigin.Begin);
                    s.CopyTo(fileStream);
                    fileStream.Close();
                    MessageBox.Show("Done");
                }catch(Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                
            }
        }

    }
}
