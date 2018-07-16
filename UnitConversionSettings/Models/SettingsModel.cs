using System.Collections.Generic;
using System.Linq;
using UnitConversionSettings.UnitConversion;

namespace UnitConversionSettings.Models
{
    public class SettingsModel
    {
        public SettingsModel()
        {
            MeasurementSystems = TestData.CreateMeasurementSystemData();

            SelectedMeasurementSystem = MeasurementSystems.FirstOrDefault();
        }

        public IList<MeasurementSystemModel> MeasurementSystems { get; set; }

        public MeasurementSystemModel SelectedMeasurementSystem { get; set; }

        public DistanceUnitModel SelectedDistanceUnit { get; set; }

        public AreaModel SelectedArea { get; set; }

        public AreaModel SelectedChargingRateArea { get; set; }

        public AreaModel SelectedInvoiceArea { get; set; }
    }
}
