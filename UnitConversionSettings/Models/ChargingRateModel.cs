using UnitConversionSettings.UnitConversion;

namespace UnitConversionSettings.Models
{
    public class ChargingRateModel
    {
        public ChargingRateModel(double price, AreaModel area)
        {
            Price = price;
            Area = area;
        }

        public override string ToString()
        {
            return Price + " THB / " + Area.Name;
        }

        public double Price { get; }

        public AreaModel Area { get; }
    }
}