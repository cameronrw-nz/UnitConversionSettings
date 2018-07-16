using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConversionSettings.Converters;
using UnitConversionSettings.Models;
using UnitConversionSettings.UnitConversion;

namespace UnitConversionSettings.Test
{
    [TestClass]
    public class UnitConversionTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var measurementSystemModel = TestData.CreateMeasurementSystemData().FirstOrDefault();
            DistanceUnitConverter distanceUnitConverter = new DistanceUnitConverter();
            AreaUnitConverter areaUnitConverter = new AreaUnitConverter();

            if (measurementSystemModel != null)
            {
                // 5 wa -> 20 sok, 20 sok -> 5 wa
                var wa = measurementSystemModel.DistanceUnits.SingleOrDefault(model => model.Name == "Wa");
                var sok = measurementSystemModel.DistanceUnits.SingleOrDefault(model => model.Name == "Sok");

                var result1 = (double)distanceUnitConverter.Convert(new object[] {wa, sok, 5}, null, null, null);
                var result2 = (double)distanceUnitConverter.Convert(new object[] {sok, wa, 20}, null, null, null);

                Assert.AreEqual(20, result1, result1);
                Assert.AreEqual(5, result2, result2);

                // 20 Rai to sq Wa = 20 * 20 * 20
                var rai = measurementSystemModel.Areas.SingleOrDefault(model => model.Name == "Rai");
                var sqwa = measurementSystemModel.Areas.SingleOrDefault(model => model.Name == "Square Wa");

                var waResult = (double)areaUnitConverter.Convert(new object[] { rai, sqwa, 20}, null, null, null);
                Assert.AreEqual(8000, waResult, waResult);

                // 10 Rai to ngaan = 2 * 2 * 10
                var ngaan = measurementSystemModel.Areas.SingleOrDefault(model => model.Name == "Ngaan");

                var ngaanResult = (double)areaUnitConverter.Convert(new object[] { rai, ngaan, 10 }, null, null, null);
                Assert.AreEqual(40, ngaanResult, ngaanResult);
            }
        }
    }
}
