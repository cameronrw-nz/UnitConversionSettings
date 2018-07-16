namespace UnitConversionSettings.Models
{
    public class AreaModel
    {
        public AreaModel(string name, string unitSuffix, double width, DistanceUnitModel distanceUnit)
        {
            Name = name;
            UnitSuffix = unitSuffix;
            Width = width;
            DistanceUnit = distanceUnit;
        }

        public string Name { get; }

        public string UnitSuffix { get; }

        public double Width { get; }

        public DistanceUnitModel DistanceUnit { get; }
    }
}