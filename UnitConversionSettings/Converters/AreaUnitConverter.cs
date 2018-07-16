using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UnitConversionSettings.Models;
using UnitConversionSettings.UnitConversion;

namespace UnitConversionSettings.Converters
{
    public class AreaUnitConverter : IMultiValueConverter
    {
        private readonly DistanceUnitConverter _distanceUnitConverter;

        public AreaUnitConverter()
        {
            _distanceUnitConverter = new DistanceUnitConverter();
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            AreaModel fromArea = (AreaModel)values[0];
            AreaModel toArea = (AreaModel)values[1];
            double areaValue = (double)values[2];
            
            // Area * converted width squared
            var fromWidth = (double) _distanceUnitConverter.Convert(
                new object[] {fromArea.DistanceUnit, toArea.DistanceUnit, fromArea.Width}, null, null, null);
            return areaValue * Math.Pow(fromWidth / toArea.Width, 2);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
