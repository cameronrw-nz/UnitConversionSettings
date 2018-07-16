namespace UnitConversionSettings.Models
{
    public class DistanceUnitModel
    {
        public DistanceUnitModel(string name, string unitSuffix)
        {
            Name = name;
            UnitSuffix = unitSuffix;
        }

        public string Name { get; }

        public string UnitSuffix { get; }
    }
}