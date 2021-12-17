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

namespace Облікування_Мобільних_Пристроїв.Windows
{
    /// <summary>
    /// Логика взаимодействия для TutorialWindow.xaml
    /// </summary>
    public partial class TutorialWindow : Window
    {
        LoginWindow Father;

        public TutorialWindow(LoginWindow wnd)
        {
            InitializeComponent();
            Father = wnd;
        }

        private void TutorialWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            Предмети.Children.Add(new Label() { Content = "Admin - Admin" });
            Предмети.Children.Add(new Label() { Content = "User - User" });
            Предмети.Children.Add(new Label() { Content = "Operator - Operator" });

            Left = Father.Left + Father.Width - 5;
            Top = Father.Top;
            Height = Father.Height;
        }
    }
}
