using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using UnitConversionSettings.Converters;
using UnitConversionSettings.Models;

namespace UnitConversionSettings.UnitConversion
{
    public class MeasurementSystemViewModel : ViewModelBase
    {
        private string _distanceName;
        private double? _conversionRate;
        private string _selectedToDistanceUnit;
        private double? _areaWidth;
        private string _areaName;
        private string _selectedAreaDistance;
        private string _distanceSuffix;
        private string _areaSuffix;

        public DistanceUnitConverter DistanceUnitConverter = new DistanceUnitConverter();

        public MeasurementSystemViewModel(MeasurementSystemModel measurementSystem)
        {
            MeasurementSystem = measurementSystem;

            AddDistanceCommand = new RelayCommand(AddDistance, CanAddDistance);
            AddAreaCommand = new RelayCommand(AddArea, CanAddArea);
        }

        public MeasurementSystemModel MeasurementSystem { get; }

        public string MeasurementSystemName
        {
            get => MeasurementSystem.Name;
            set => MeasurementSystem.Name = value;
        }

        public string DistanceName
        {
            get => _distanceName;
            set
            {
                _distanceName = value;
                OnPropertyChanged(nameof(DistanceName));
            }
        }

        public string DistanceSuffix
        {
            get => _distanceSuffix;
            set
            {
                _distanceSuffix = value;
                OnPropertyChanged(nameof(DistanceSuffix));
            }
        }

        public double? ConversionRate
        {
            get => _conversionRate;
            set
            {
                _conversionRate = value;
                OnPropertyChanged(nameof(ConversionRate));
            }
        }

        public ICommand AddDistanceCommand { get; set; }

        public ICommand AddAreaCommand { get; set; }

        // Have to use name as editting the selectedItem and Source creates concurrency 
        // issues so this will create a new list on each property changed
        // TODO Replace with better structure in the future
        public IList<string> Distances => MeasurementSystem.DistanceUnits.Select(model => model.Name).ToList();

        public IList<string> AllDistances => TestData.AllDistanceUnits.Select(model => model.Name).ToList();
        
        public string SelectedToDistanceUnit
        {
            get => _selectedToDistanceUnit;
            set
            {
                _selectedToDistanceUnit = value;
                OnPropertyChanged(nameof(SelectedToDistanceUnit));
            }
        }

        public string AreaName
        {
            get => _areaName;
            set
            {
                _areaName = value;
                OnPropertyChanged(nameof(AreaName));
            }
        }

        public double? AreaWidth
        {
            get => _areaWidth;
            set
            {
                _areaWidth = value;
                OnPropertyChanged(nameof(AreaWidth));
            }
        }

        public string AreaSuffix
        {
            get => _areaSuffix;
            set
            {
                _areaSuffix = value;
                OnPropertyChanged(nameof(AreaSuffix));
            }
        }

        public string SelectedAreaDistance
        {
            get => _selectedAreaDistance;
            set
            {
                _selectedAreaDistance = value; 
                OnPropertyChanged(nameof(SelectedAreaDistance));
            }
        }

        public IList<string> Areas => MeasurementSystem.Areas.Select(area => area.Name).ToList();

        public IList<string> UnitConversions
        {
            get
            {
                var displayedUnitConversions = TestData.UnitConversionRates.Select(rate =>
                    rate.FromDistanceUnit.Name + " = " + rate.ConversionRate + " " + rate.ToDistanceUnit.Name).ToList();

                return displayedUnitConversions;
            }
        }

        private void AddDistance()
        {
            var newDistanceUnit = new DistanceUnitModel(DistanceName, DistanceSuffix);
            var selectedDistanceUnit = TestData.AllDistanceUnits.FirstOrDefault(model => model.Name == SelectedToDistanceUnit);

            MeasurementSystem.DistanceUnits.Add(newDistanceUnit);
            TestData.AllDistanceUnits.Add(newDistanceUnit);

            var newConversionRate = new UnitConversionRate(newDistanceUnit, selectedDistanceUnit, ConversionRate ?? 0);
            TestData.UnitConversionRates.Add(newConversionRate);

            foreach (DistanceUnitModel distanceUnit in TestData.AllDistanceUnits.Where(unit =>
                unit.Name != DistanceName && unit.Name != SelectedToDistanceUnit))
            {
                var conversionRate = (double)DistanceUnitConverter.Convert(
                    new object[] {selectedDistanceUnit, distanceUnit, ConversionRate}, null, null, null);

                TestData.UnitConversionRates.Add(new UnitConversionRate(newDistanceUnit, distanceUnit, conversionRate));
            }

            SelectedToDistanceUnit = null;
            ConversionRate = null;
            DistanceName = null;
            DistanceSuffix = null;

            OnPropertyChanged(nameof(Distances));
            OnPropertyChanged(nameof(AllDistances));
            OnPropertyChanged(nameof(UnitConversions));
        }

        // Need to change the check for Distance name because can exceute only triggers when losing focus on text box
        private bool CanAddDistance(object obj)
        {
             return !string.IsNullOrEmpty(DistanceName) && !string.IsNullOrEmpty(DistanceSuffix) &&
                    ConversionRate != null && !string.IsNullOrEmpty(SelectedToDistanceUnit);
        }

        private void AddArea()
        {
            var selectedAreaDistance =
                MeasurementSystem.DistanceUnits.FirstOrDefault(unit => unit.Name == SelectedAreaDistance);
            MeasurementSystem.Areas.Add(new AreaModel(AreaName, "23", 0, selectedAreaDistance));

            AreaName = null;
            AreaWidth = null;
            SelectedAreaDistance = null;

            OnPropertyChanged(nameof(Areas));
        }

        private bool CanAddArea(object obj)
        {
            return !string.IsNullOrEmpty(AreaName) && !string.IsNullOrEmpty(AreaSuffix) && AreaWidth != null &&
                   !string.IsNullOrEmpty(SelectedAreaDistance);
        }
    }
}
