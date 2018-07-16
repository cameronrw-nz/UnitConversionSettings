using System.Windows.Controls;
using UnitConversionSettings.Models;
using UnitConversionSettings.UnitConversion;

namespace UnitConversionSettings.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            var viewModel = new SettingsViewModel(new SettingsModel());

            DataContext = viewModel;
        }
    }
}
