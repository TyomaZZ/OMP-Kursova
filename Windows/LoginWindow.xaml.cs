using System;
using System.Collections.Generic;
using System.Data;
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
using Облікування_Мобільних_Пристроїв.Classes;

namespace Облікування_Мобільних_Пристроїв.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        DBDataSet.КористувачіDataTable usersTable;
        DBDataSetTableAdapters.КористувачіTableAdapter usersTableAdapter;

        List<User> userList;
        TutorialWindow tutorWind;

        public LoginWindow()
        {
            InitializeComponent();
            userList = new List<User>();
        }

        private void LoginWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            loadUsersFromDB();
            getListOfUsers();

            tutorWind = new TutorialWindow(this);
            tutorWind.Show();
        }

        private void AutorisationButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (User user in userList)
            {
                if (user.login == LoginBox.Text)
                {
                    if (user.password == PassBox.Password)
                    {
                        new MenuWindow(user).Show();
                        if (tutorWind != null)
                            tutorWind.Close();
                        Close();
                        return;
                    }
                }
            }
            MessageBox.Show("Невірний логін або пароль");
            
        }

        private void loadUsersFromDB()
        {
            usersTable = new DBDataSet.КористувачіDataTable();
            usersTableAdapter = new DBDataSetTableAdapters.КористувачіTableAdapter();
            usersTableAdapter.Fill(usersTable);
        }

        private void getListOfUsers()
        {
            userList.Clear();
            foreach (DataRow row in usersTable)
                userList.Add(new User(row[1].ToString(), row[2].ToString(), Convert.ToInt32(row[3])));
        }

        private void LoginWindow1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tutorWind != null)
                tutorWind.Close();
        }
    }
}
