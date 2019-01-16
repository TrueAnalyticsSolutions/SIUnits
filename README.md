# SIUnits
A library to help utilize and implement SI Units. This is not currently intended to be a direct reflection of the International System of Units.

## Getting Started
A static set of units have been hardcoded into the library to help get you started.

```c#
List<SIUnits.Abstracts.AUnit> allUnits = SIUnits.UnitManager.GetUnits(); // Returns a list of all hardcoded SI Base, Derivitive, and Factored Units
```

You can iterate through each unit and understand more information about each one:

```c#
Type typDerived = typeof(SIUnits.DerivedUnit);
Type typFactored = typeof(SIUnits.FactoredUnit);

string strTableFormat = "{0,20}{1,20}{2,20}";

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine(strTableFormat, "Name", "Symbol", "Base Unit");
foreach (SIUnits.Abstracts.AUnit unit in allUnits) {
  Type typThisUnit = unit.GetType();
  if (typThisUnit.IsAssignableFrom(typFactored)) { // Is custom factored unit
    Console.ForegroundColor = ConsoleColor.Yellow;
  } else if (typThisUnit.IsAssignableFrom(typDerived)) { // Is SI Derived Unit
    Console.ForegroundColor = ConsoleColor.Blue;
  } else { // Is SI Base Unit
    Console.ForegroundColor = ConsoleColor.Green;
  }
  Console.WriteLine(strTableFormat, unit.Name, unit.Symbol, unit.Base.ToString());
}
```

You can also try to convert basic text into a converted measurement:

```c#
string strConvert = "33lb"; // How much the average Koala weighs
string strTargetUnit = "kg"; // Kilograms

decimal decKoalaWeight = (decimal)SIUnits.UnitManager.Convert(strConvert, strTargetUnit); // Cast because errors in conversion may return null

Console.WriteLine("A {0} Koala weighs about {1}{2}", strConvert, Math.Round(decKoalaWeight, 2).ToString(), strTargetUnit);
```

