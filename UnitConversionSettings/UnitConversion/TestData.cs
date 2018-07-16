using System.Collections.Generic;
using System.Linq;
using UnitConversionSettings.Models;

namespace UnitConversionSettings.UnitConversion
{
    // Data used for testing the system
    public class TestData
    {
        private static List<MeasurementSystemModel> _measurementSystem;
        private static ChargingRateModel _chargingRate;

        public static List<MeasurementSystemModel> CreateMeasurementSystemData()
        {
            var wa = new DistanceUnitModel("Wa", "wa");
            var sok = new DistanceUnitModel("Sok", "sok");

            var sqWa = new AreaModel("Square Wa", "sqwa", 1, wa);
            var ngaan = new AreaModel("Ngaan", "ngaan", 10, wa);
            var rai = new AreaModel("Rai", "rai", 20, wa);

            var waSok = new UnitConversionRate(wa, sok, 4);

            var measurementSystem = new MeasurementSystemModel
            {
                Name = "Thai Area Measurement System",
                DistanceUnits = new List<DistanceUnitModel> {wa, sok},
                Areas = new List<AreaModel> {sqWa, ngaan, rai},
            };

            AllDistanceUnits = new List<DistanceUnitModel> {wa, sok};
            UnitConversionRates = new List<UnitConversionRate> {waSok};

            _measurementSystem = new List<MeasurementSystemModel> {measurementSystem};

            return _measurementSystem;
        }

        public static List<UnitConversionRate> UnitConversionRates { get; set; }
        public static List<DistanceUnitModel> AllDistanceUnits { get; set; }

        public static ChargingRateModel GetChargingRate()
        {
            if (_chargingRate == null)
            {
                var raiArea = _measurementSystem.SingleOrDefault(model => model.Name == "Thai Area Measurement System")
                    ?.Areas
                    .FirstOrDefault(model => model.Name == "Rai");

                _chargingRate = new ChargingRateModel(100, raiArea);
            }

            return _chargingRate;
        }
    }
}
