using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace Облікування_Мобільних_Пристроїв
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly string defaultSettingsFile = "onStartup.ini";
        private static readonly string DBstring = "DBofGadget.mdb";
        private static readonly string keyOfSettings = "120598";
        private static readonly List<string> settingsList = new List<string>();
        readonly SplashScreen splashScreen;

        public MainWindow()
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
                Close();
            splashScreen = new SplashScreen("media/splashscreenlogo.png");
            splashScreen.Show(true, true);
            InitializeComponent();
        }

        private void MainWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(defaultSettingsFile))
                IfExist();
            else
                IfDontExist();
        }

        private void IfExist()
        {
            settingsList.Clear();
            foreach (string str in File.ReadAllLines(defaultSettingsFile))
                settingsList.Add(str);
            if (settingsList[0] == keyOfSettings)
                Initialize();
            else
                MessageBox.Show("Файл конфігурації пошкоджений");
        }

        private void IfDontExist()
        {
            if (MessageBox.Show("Файл конфігурації не знайдений, бажаєте створити новий?",
                 "Увага",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                settingsList.Clear();
                settingsList.Add(keyOfSettings); // key
                settingsList.Add("1"); // true for open launcher
                settingsList.Add(DBstring); // dataBase path
                File.WriteAllLines(defaultSettingsFile, settingsList);
                IfExist();
            }
        }

        private void Initialize()
        {
            LabelOfDB.Content = $"База данних: {settingsList[2]}";
        }

        private void DefaultDBSet_Click(object sender, RoutedEventArgs e)
        {
            IfExist();
        }

        private void ChangeDB_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog
            {
                Filter = "Файли баз даних (*.mdb)|*.mdb",
                Title = "Оберіть базу даних",
                InitialDirectory = ""
            };
            if (file.ShowDialog() == false)
                return;
            settingsList[2] = file.FileName;
            LabelOfDB.Content = $"База данних: {settingsList[2].Split('\\')[settingsList[2].Split('\\').Length - 1]}";
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            new Windows.LoginWindow().Show();
            Close();
        }
    }
}
