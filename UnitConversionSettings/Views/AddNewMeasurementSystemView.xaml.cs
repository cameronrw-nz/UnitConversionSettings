using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UnitConversionSettings.Views
{
    /// <summary>
    /// Interaction logic for AddNewMeasurementSystemView.xaml
    /// </summary>
    public partial class AddNewMeasurementSystemView : Window
    {
        public AddNewMeasurementSystemView()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            // Need to change this to handle double values correctly
            Regex regex = new Regex("^[0-9]\\.?[0-9]$");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
