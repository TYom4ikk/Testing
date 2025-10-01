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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PhoneNumberValidatorLibrary;

namespace PhoneNumberValidatorProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string phoneNumber;
        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            phoneNumber = PhoneNumberTextBox.Text;
            if (PhoneNumberValidator.IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show($"Ваш номер \"{phoneNumber}\" прошёл проверку!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            MessageBox.Show($"Ваш номер \"{phoneNumber}\" неверный!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
