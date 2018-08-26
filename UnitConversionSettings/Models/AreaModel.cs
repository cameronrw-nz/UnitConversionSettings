namespace UnitConversionSettings.Models
{
    public class AreaModel : UnitModel
    {
        public AreaModel(string name, string unitSuffix, double width, DistanceUnitModel distanceUnit) 
            : base(name, unitSuffix)
        {
            Width = width;
            DistanceUnit = distanceUnit;
        }

        public double Width { get; }

        public DistanceUnitModel DistanceUnit { get; }
    }
}