using UnitConversionSettings.UnitConversion;

namespace UnitConversionSettings.Models
{
    public class UnitConversionRate
    {
        public UnitConversionRate(DistanceUnitModel fromDistanceUnit, DistanceUnitModel toDistanceUnit, double conversionRate)
        {
            FromDistanceUnit = fromDistanceUnit;
            ToDistanceUnit = toDistanceUnit;
            ConversionRate = conversionRate;
        }

        public DistanceUnitModel FromDistanceUnit { get; set; }

        public DistanceUnitModel ToDistanceUnit { get; set; }
        
        public double ConversionRate { get; set; }
    }
}