using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;

namespace Bank.View
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private Deposit _deposit { get; set; }
        public AuthorizationWindow(Deposit deposit)
        {
            InitializeComponent();
            _deposit = deposit;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var db = Model.Singleton.GetContext();
            var user = db.Users.Where(x => x.Login == loginField.Text && x.Password == passwordField.Password).FirstOrDefault();
            if (user != null)
            {
                WordHelper wordHelper = new WordHelper("Шаблон договора.docx");
                string fullName = $"{user.Surname} {user.Name} {user.Patronymic}"; // <FIO> <FIO2>
                string contractNumber = db.Contract.ToList().Count.ToString(); // <CONTRACTNUMBER>
                string day = DateTime.Now.Day.ToString(); // <DAY>
                string month = DateTime.Now.Month.ToString(); // <MONTH>
                string year = DateTime.Now.Year.ToString(); // <YEAR>
                string sum = $"{_deposit.Sum} Руб."; // <SUM>
                string term = $"{_deposit.Term} дней"; // <TERM>
                string depositEndDate = DateTime.Now.AddDays(_deposit.Term).ToString();
                string percent = _deposit.InterestRate.ToString() + " %";
                string numberDeposit = db.BankAccounts.Where(x => x.UserID == user.UserID).FirstOrDefault().NumberAccount;
                string address = user.Adress;
                string email = user.E_Mail;
                string serires = user.Series;
                string number = user.Number;
                string issued = user.Issued;
                string dateIssue = user.Issued;
                string dateBirth = user.DateOfBirth.ToString();
                string placeBirth = user.PlaceOfBirth.ToString();

                var items = new Dictionary<string, string>
                {
                    { "<CONTRACTNUMBER>", contractNumber},
                    { "<DAY>", day},
                    { "<MONTH>", month},
                    { "<YEAR>", year},
                    { "<FIO>", fullName},
                    { "<SUM>", sum},
                    { "<TERM>", term},
                    { "<DEPOSITENDDATE>", depositEndDate},
                    { "<PERCENT>", percent},
                    { "<NUMBERDEPOSIT>", numberDeposit},
                    { "<FIO2>", fullName},
                    { "<ADDRESS>", address},
                    { "<EMAIL>", email},
                    { "<SERIES>", serires},
                    { "<NUMBER>", number},
                    { "<ISSUED>", issued},
                    { "<DATEISSUE>", dateIssue},
                    { "<DATEBIRTH>",dateBirth },
                    { "<PLACEBIRTH>",placeBirth }
                };
                wordHelper.Process(items);
                
             
            }
            else
            {
                MessageBox.Show("Такого пользователя не сущестует");
            }
        }
    }
}
