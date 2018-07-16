using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Data;
using UnitConversionSettings.UnitConversion;

namespace UnitConversionSettings.Models
{
    public class MeasurementSystemModel : ViewModelBase 
    {
        public MeasurementSystemModel()
        {
            DistanceUnits = new List<DistanceUnitModel>();
            Areas = new List<AreaModel>();
        }

        public string Name { get; set; }

        public IList<DistanceUnitModel> DistanceUnits { get; set; }

        public IList<AreaModel> Areas { get; set; }
    }
}