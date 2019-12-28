using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnitsCore {
    static class Program {
        static void Main(string[] args) {
            IEnumerable<SIUnits.Abstracts.BaseUnit> allUnits = SIUnits.UnitManager.GetUnits();

            Type typDerived = typeof(SIUnits.DerivedUnit);
            Type typFactored = typeof(SIUnits.FactoredUnit);

            string strConvert = "33lb"; // How much the average Koala weighs
            string strTargetUnit = "kg"; // Kilograms

            decimal decKoalaWeight = (decimal)SIUnits.UnitManager.Convert(strConvert, strTargetUnit); // Cast because errors in conversion may return null

            Console.WriteLine("A {0} Koala weighs about {1}{2}", strConvert, Math.Round(decKoalaWeight, 2).ToString(), strTargetUnit);

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
