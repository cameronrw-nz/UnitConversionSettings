namespace UnitConversionSettings.Models
{
    public class UnitModel
    {
        public UnitModel(string name, string unitSuffix)
        {
            Name = name;
            UnitSuffix = unitSuffix;
        }

        public string Name { get; private set; }

        public string UnitSuffix { get; private set; }
    }
}
