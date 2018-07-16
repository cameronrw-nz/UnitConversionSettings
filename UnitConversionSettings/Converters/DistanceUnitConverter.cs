using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using UnitConversionSettings.Models;
using UnitConversionSettings.UnitConversion;

namespace UnitConversionSettings.Converters
{
    public class DistanceUnitConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var fromDistanceUnit = values[0];
            var toDistanceUnit = values[1];
            double? distance = (double?)values[2];

            UnitConversionRate conversionRate = TestData.UnitConversionRates.SingleOrDefault(rate =>
                rate.FromDistanceUnit == fromDistanceUnit && rate.ToDistanceUnit == toDistanceUnit);

            if (conversionRate != null)
            {
                return distance * conversionRate.ConversionRate;
            }

            conversionRate = TestData.UnitConversionRates.SingleOrDefault(rate =>
                rate.FromDistanceUnit == toDistanceUnit && rate.ToDistanceUnit == fromDistanceUnit);

            if (conversionRate != null)
            {
                return distance / conversionRate.ConversionRate;
            }

            return distance ?? 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
