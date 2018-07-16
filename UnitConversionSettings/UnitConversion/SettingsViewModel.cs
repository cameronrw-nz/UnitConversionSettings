using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using UnitConversionSettings.Converters;
using UnitConversionSettings.Models;
using UnitConversionSettings.Views;

namespace UnitConversionSettings.UnitConversion
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly SettingsModel _settingsModel;
        private IList<ChargingRateModel> _chargingRates;

        public SettingsViewModel(SettingsModel settingsModel)
        {
            _settingsModel = settingsModel;

            UpdateViewModel();

            CreateMeasurementSystemCommand = new RelayCommand(CreateMeasurementSystem);
        }

        public AreaUnitConverter AreaUnitConverter = new AreaUnitConverter();

        public IList<MeasurementSystemModel> MeasurementSystems
        {
            get => _settingsModel.MeasurementSystems;

            set
            {
                _settingsModel.MeasurementSystems = value;
                OnPropertyChanged(nameof(MeasurementSystems));
            }
        }

        public MeasurementSystemModel SelectedMeasurementSystem
        {
            get => _settingsModel.SelectedMeasurementSystem;

            set
            {
                _settingsModel.SelectedMeasurementSystem = value;
                OnPropertyChanged(nameof(SelectedMeasurementSystem));

                UpdateViewModel();
            }
        }

        public IList<UnitConversionRate> UnitConversionRates { get; set; }

        public IList<DistanceUnitModel> DistanceUnits => SelectedMeasurementSystem?.DistanceUnits ?? new List<DistanceUnitModel>();

        public DistanceUnitModel SelectedDistanceUnit
        {
            get => _settingsModel.SelectedDistanceUnit;
            set
            {
                _settingsModel.SelectedDistanceUnit = value;
                OnPropertyChanged(nameof(SelectedDistanceUnit));
            }
        }

        public IList<AreaModel> Areas => SelectedMeasurementSystem?.Areas ?? new List<AreaModel>();

        public AreaModel SelectedArea
        {
            get => _settingsModel.SelectedArea;
            set
            {
                _settingsModel.SelectedArea = value;
                OnPropertyChanged(nameof(SelectedArea));
            }
        }

        public IList<ChargingRateModel> ChargingRates
        {
            get => _chargingRates;
            set
            {
                _chargingRates = value;
                OnPropertyChanged(nameof(ChargingRates));
            }
        }

        public AreaModel SelectedChargingRateArea
        {
            get => _settingsModel.SelectedChargingRateArea;
            set
            {
                _settingsModel.SelectedChargingRateArea = value;
                OnPropertyChanged(nameof(SelectedChargingRateArea));
            }
        }

        public IList<ChargingRateModel> InvoiceReports
        {
            get => _chargingRates;
            set
            {
                _chargingRates = value;
                OnPropertyChanged(nameof(ChargingRates));
            }
        }

        public AreaModel SelectedInvoiceReportArea
        {
            get => _settingsModel.SelectedInvoiceArea;
            set
            {
                _settingsModel.SelectedInvoiceArea = value;
                OnPropertyChanged(nameof(SelectedInvoiceReportArea));
            }
        }

        public ICommand CreateMeasurementSystemCommand { get; set; }

        private IList<ChargingRateModel> CalculateChargingRatesForAreas()
        {
            var chargingRatesforAreas = new List<ChargingRateModel>();

            foreach (AreaModel area in Areas)
            {
                var thbPrice = (double) AreaUnitConverter.Convert(new object[] {area, TestData.GetChargingRate().Area, (double)100}, null, null, null);
                var chargingRate = new ChargingRateModel(thbPrice, area);
                chargingRatesforAreas.Add(chargingRate);
            }

            return chargingRatesforAreas;
        }

        private void CreateMeasurementSystem()
        {
            var measurementSystemView = new AddNewMeasurementSystemView();
            measurementSystemView.DataContext = new MeasurementSystemViewModel(new MeasurementSystemModel());
            if (measurementSystemView.ShowDialog() == true)
            {
                MeasurementSystems.Add(((MeasurementSystemViewModel)measurementSystemView.DataContext).MeasurementSystem);
            }
        }

        private void UpdateViewModel()
        {
            OnPropertyChanged(nameof(DistanceUnits));
            OnPropertyChanged(nameof(Areas));
            ChargingRates = CalculateChargingRatesForAreas();
            InvoiceReports = CalculateChargingRatesForAreas();

            SelectedDistanceUnit = DistanceUnits.FirstOrDefault();
            SelectedArea = Areas.FirstOrDefault();
            SelectedChargingRateArea = ChargingRates.FirstOrDefault()?.Area;
            SelectedInvoiceReportArea = InvoiceReports.FirstOrDefault()?.Area;
        }
    }
}