using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Xml;

namespace SIUnits {
  using System.Text.RegularExpressions;
  public enum Types {
    Mass = 0,
    Length = 1,
    Time = 2,
    Substance = 3,
    ElectricalCurrent = 4,
    ThermodynamicTemperature = 5,
    LuminousIntensity = 6,
    Volume = 7,
    Area = 8,
    Velocity = 9,
    Acceleration = 10,
    Force = 11,
    Energy = 12,
    CatalyticActivity = 13,
    ElectricCharge = 14,
    CelsiusTemperature = 15,
    Illuminance = 16,
    Pressure = 17,
    Power = 18,
    MagneticFlux = 19,
    Capacitance = 20,
    LuminousFlux = 21,
    AbsorbedDose = 22,
    Activity = 23,
    Inductance = 24,
    Voltage = 25,
    Resistance = 26,
    SolidAngle = 27,
    DoseEquivalent = 28,
    Frequency = 29,
    MagneticFluxDensity = 30,
    Conductance = 31,
    PlaneAngle = 32,
    DigitalStorage = 33,
    DataTransferRate = 34
  }
  public static class UnitManager{

    public static List<SIUnits.Abstracts.AUnit> GetUnits() {
      List<SIUnits.Abstracts.AUnit> units = new List<SIUnits.Abstracts.AUnit>();

      units.Add(new BaseUnit("kg", "Kilogram", Types.Mass));
      units.Add(new BaseUnit("m", "Meter", Types.Length));
      units.Add(new BaseUnit("s", "Second", Types.Time));
      units.Add(new BaseUnit("mol", "Mole", Types.Substance));
      units.Add(new BaseUnit("A", "Ampere", Types.ElectricalCurrent));
      units.Add(new BaseUnit("K", "Kelvin", Types.ThermodynamicTemperature));
      units.Add(new BaseUnit("cd", "Candela", Types.LuminousIntensity));
      units.Add(new BaseUnit("bit", "Bit", Types.DigitalStorage));

      units.Add(new DerivedUnit("m³", "Cubic Meter", Types.Volume) {
        Formula = "m³",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "m", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
        }
      });
      units.Add(new DerivedUnit("m²", "Square Meter", Types.Area) {
        Formula = "m²",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "m", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
        }
      });
      units.Add(new DerivedUnit("m/s", "Meters per Second", Types.Velocity) {
        Formula = "m/s",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "m", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
          { "s", SIUnits.DerivedUnit.DerivationMethods.Division }
        }
      });
      units.Add(new DerivedUnit("m/s²", "Metric Acceleration", Types.Acceleration) {
        Formula = "m/s²",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "s", SIUnits.DerivedUnit.DerivationMethods.Division },
          { "m/s", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
        }
      });
      units.Add(new DerivedUnit("N", "Newton", Types.Force) {
        Formula = "kg*m/s²",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "kg", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
          { "m/s²", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
        }
      });
      units.Add(new DerivedUnit("J", "Joule", Types.Energy) {
        Formula = "N*m",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "m", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
          { "N", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
        }
      });
      units.Add(new DerivedUnit("kat", "Katal", Types.CatalyticActivity) {
        Formula = "mol/s",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "mol", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
          { "Wb", SIUnits.DerivedUnit.DerivationMethods.Division }
        }
      });
      units.Add(new DerivedUnit("C", "Coulomb", Types.ElectricCharge) {
        Formula = "A*s",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "s", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
          { "A", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
        }
      });
      units.Add(new DerivedUnit("degC", "Degrees Celsius", Types.CelsiusTemperature) {
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "K", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
        }
      });
      units.Add(new DerivedUnit("lx", "Lux", Types.Illuminance) {
        Formula = "lm/m²",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "m²", SIUnits.DerivedUnit.DerivationMethods.Division },
          { "lm", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
        }
      });
      units.Add(new DerivedUnit("Pa", "Pascal", Types.Pressure) {
        Formula = "N/m²",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "N", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
          { "m²", SIUnits.DerivedUnit.DerivationMethods.Division }
        }
      });
      units.Add(new DerivedUnit("W", "Watt", Types.Power) {
        Formula = "J/s",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "J", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
          { "s", SIUnits.DerivedUnit.DerivationMethods.Division }
        }
      });
      units.Add(new DerivedUnit("Wb", "Weber", Types.MagneticFlux) {
        Formula = "V*s",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "V", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
          { "s", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
        }
      });
      units.Add(new DerivedUnit("F", "Farad", Types.Capacitance) {
        Formula = "C/V",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "C", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
          { "V", SIUnits.DerivedUnit.DerivationMethods.Division }
        }
      });
      units.Add(new DerivedUnit("lm", "Lumen", Types.LuminousFlux) {
        Formula = "cd*sr",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "cd", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
          { "sr", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
        }
      });
      units.Add(new DerivedUnit("sr", "Steradian", Types.SolidAngle) {
        Formula = "m²/m²=1"
      });
      units.Add(new DerivedUnit("Ω", "Ohm", Types.Resistance) {
        Formula = "V/A",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "V", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
          { "A", SIUnits.DerivedUnit.DerivationMethods.Division }
        }
      });
      units.Add(new DerivedUnit("V", "Volt", Types.Voltage) {
        Formula = "W/A",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "W", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
          { "A", SIUnits.DerivedUnit.DerivationMethods.Division }
        }
      });
      units.Add(new DerivedUnit("H", "Henry", Types.Inductance) {
        Formula = "Wb/A",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "Wb", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
          { "A", SIUnits.DerivedUnit.DerivationMethods.Division }
        }
      });
      units.Add(new DerivedUnit("Bq", "Becquaerel", Types.Activity) {
        Formula = "1/s",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "s", SIUnits.DerivedUnit.DerivationMethods.Division }
        }
      });
      units.Add(new DerivedUnit("Gy", "Gray", Types.AbsorbedDose) {
        Formula = "J/kg",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "J", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
          { "kg", SIUnits.DerivedUnit.DerivationMethods.Division }
        }
      });
      units.Add(new DerivedUnit("Sv", "Slevert", Types.DoseEquivalent) {
        Formula = "J/kg",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "J", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
          { "kg", SIUnits.DerivedUnit.DerivationMethods.Division }
        }
      });
      units.Add(new DerivedUnit("Hz", "Hertz", Types.Frequency) {
        Formula = "1/s",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "s", SIUnits.DerivedUnit.DerivationMethods.Division }
        }
      });
      units.Add(new DerivedUnit("T", "Tesla", Types.MagneticFluxDensity) {
        Formula = "Wb/m²",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "Wb", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
          { "m²", SIUnits.DerivedUnit.DerivationMethods.Division }
        }
      });
      units.Add(new DerivedUnit("S", "Slemens", Types.Conductance) {
        Formula = "1/Ω",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "Ω", SIUnits.DerivedUnit.DerivationMethods.Division }
        }
      });
      units.Add(new DerivedUnit("rad", "Radian", Types.PlaneAngle) {
        Formula = "m/m=1"
      });
      units.Add(new DerivedUnit("byte", "Byte", Types.DigitalStorage) {
        Formula = "bit*8",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "bit", DerivedUnit.DerivationMethods.Multiplication }
        }
      });
      units.Add(new DerivedUnit("bit/s", "Bit per Second", Types.DataTransferRate) {
        Formula = "bit/s",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "bit", DerivedUnit.DerivationMethods.Multiplication },
          { "s", DerivedUnit.DerivationMethods.Division }
        }
      });
      units.Add(new FactoredUnit("kB", "Kilobyte", Types.DigitalStorage) {
        Formula = "byte*1000",
        DerivedFrom = "byte",
        Factor = (decimal)Math.Pow(1000, -1)
      });
      units.Add(new FactoredUnit("kbit/s", "Kilobits per Second", Types.DigitalStorage) {
        Formula = "bit/s/1000",
        DerivedFrom = "bit/s",
        Factor = (decimal)Math.Pow(1000, -1)
      });
      units.Add(new FactoredUnit("MB", "Megabyte", Types.DigitalStorage) {
        Formula = "byte*1000²",
        DerivedFrom = "byte",
        Factor = (decimal)Math.Pow(1000, -2)
      });
      units.Add(new FactoredUnit("Mbit/s", "Megabits per Second", Types.DigitalStorage) {
        Formula = "bit/s/1000²",
        DerivedFrom = "bit/s",
        Factor = (decimal)Math.Pow(1000, -2)
      });
      units.Add(new FactoredUnit("GB", "Gigabyte", Types.DigitalStorage) {
        Formula = "byte*1000³",
        DerivedFrom = "byte",
        Factor = (decimal)Math.Pow(1000, -3)
      });
      units.Add(new FactoredUnit("Gbit/s", "Gigabit per Second", Types.DigitalStorage) {
        Formula = "bit/s/1000³",
        DerivedFrom = "bit/s",
        Factor = (decimal)Math.Pow(1000, -3)
      });
      units.Add(new FactoredUnit("TB", "Terabyte", Types.DigitalStorage) {
        Formula = "byte*1000^4",
        DerivedFrom = "byte",
        Factor = (decimal)Math.Pow(1000, -4)
      });
      units.Add(new FactoredUnit("Tbit/s", "Terabit per Second", Types.DigitalStorage) {
        Formula = "bit/s/1000^4",
        DerivedFrom = "bit/s",
        Factor = (decimal)Math.Pow(1000, -4)
      });
      units.Add(new FactoredUnit("PB", "Petabyte", Types.DigitalStorage) {
        Formula = "byte*1000^5",
        DerivedFrom = "byte",
        Factor = (decimal)Math.Pow(1000, -5)
      });
      units.Add(new FactoredUnit("Pbit/s", "Petabit per Second", Types.DigitalStorage) {
        Formula = "bit/s/1000^5",
        DerivedFrom = "bit/s",
        Factor = (decimal)Math.Pow(1000, -5)
      });
      units.Add(new FactoredUnit("EB", "Exabyte", Types.DigitalStorage) {
        Formula = "byte*1000^6",
        DerivedFrom = "byte",
        Factor = (decimal)Math.Pow(1000, -6)
      });
      units.Add(new FactoredUnit("Ebit/s", "Exabit per Second", Types.DigitalStorage) {
        Formula = "bit/s/1000^6",
        DerivedFrom = "bit/s",
        Factor = (decimal)Math.Pow(1000, -6)
      });
      units.Add(new FactoredUnit("ZB", "Zettabyte", Types.DigitalStorage) {
        Formula = "byte*1000^7",
        DerivedFrom = "byte",
        Factor = (decimal)Math.Pow(1000, -7)
      });
      units.Add(new FactoredUnit("Zbit/s", "Zettabit per Second", Types.DigitalStorage) {
        Formula = "bit/s/1000^7",
        DerivedFrom = "bit/s",
        Factor = (decimal)Math.Pow(1000, -7)
      });
      units.Add(new FactoredUnit("YB", "Yottabyte", Types.DigitalStorage) {
        Formula = "byte*1000^8",
        DerivedFrom = "byte",
        Factor = (decimal)Math.Pow(1000, -8)
      });
      units.Add(new FactoredUnit("Ybit/s", "Yottabit per Second", Types.DigitalStorage) {
        Formula = "bit/s/1000^8",
        DerivedFrom = "bit/s",
        Factor = (decimal)Math.Pow(1000, -8)
      });
      units.Add(new FactoredUnit("in", "Inch", Types.Length) {
        DerivedFrom = "m",
        Factor = (decimal)39.3701
      });
      units.Add(new FactoredUnit("ft", "Foot", Types.Length) {
        DerivedFrom = "m",
        Factor = (decimal)3.28084
      });
      units.Add(new FactoredUnit("in²", "Square Inch", Types.Length) {
        DerivedFrom = "m",
        Factor = (decimal)1550
      });
      units.Add(new FactoredUnit("ft²", "Square Foot", Types.Length) {
        DerivedFrom = "m",
        Factor = (decimal)10.7639
      });
      units.Add(new FactoredUnit("in³", "Cubic Inch", Types.Length) {
        DerivedFrom = "m",
        Factor = (decimal)61023.7
      });
      units.Add(new FactoredUnit("ft³", "Cubic Foot", Types.Length) {
        DerivedFrom = "m",
        Factor = (decimal)35.3147
      });
      units.Add(new FactoredUnit("mm", "Millimeter", Types.Length) {
        DerivedFrom = "m",
        Factor = (decimal)1000
      });
      units.Add(new FactoredUnit("cm", "Centimeter", Types.Length) {
        DerivedFrom = "m",
        Factor = (decimal)100
      });
      units.Add(new FactoredUnit("lb", "Pound", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)2.20462
      });
      units.Add(new FactoredUnit("oz", "Ounce", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)35.274
      });
      units.Add(new FactoredUnit("g", "Gram", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)Math.Pow(10, 3)
      });
      units.Add(new FactoredUnit("mg", "Milligram", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)Math.Pow(10, 6)
      });
      units.Add(new FactoredUnit("µg", "Microgram", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)Math.Pow(10, 9)
      });
      units.Add(new FactoredUnit("ng", "Nanogram", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)Math.Pow(10, 12)
      });
      units.Add(new FactoredUnit("pg", "Picogram", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)Math.Pow(10, 15)
      });
      units.Add(new FactoredUnit("fg", "femtogram", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)Math.Pow(10, 18)
      });
      units.Add(new FactoredUnit("ag", "Attogram", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)Math.Pow(10, 21)
      });
      units.Add(new FactoredUnit("zg", "Zeptogram", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)Math.Pow(10, 24)
      });
      units.Add(new FactoredUnit("yg", "Yoctogram", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)Math.Pow(10, 27)
      });
      units.Add(new FactoredUnit("Mg", "Megagram", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)Math.Pow(10, 3)
      });
      units.Add(new FactoredUnit("Gg", "Gigagram", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)Math.Pow(10, 6)
      });
      units.Add(new FactoredUnit("Tg", "Teragram", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)Math.Pow(10, 9)
      });
      units.Add(new FactoredUnit("Pg", "Petagram", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)Math.Pow(10, 12)
      });
      units.Add(new FactoredUnit("Eg", "Exagram", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)Math.Pow(10, 15)
      });
      units.Add(new FactoredUnit("Zg", "Zettagram", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)Math.Pow(10, 18)
      });
      units.Add(new FactoredUnit("Yg", "Yottagram", Types.Mass) {
        DerivedFrom = "kg",
        Factor = (decimal)Math.Pow(10, 21)
      });
      units.Add(new FactoredUnit("zJ", "Zeptojoule", Types.Energy) {
        DerivedFrom = "J",
        Factor = (decimal)Math.Pow(10, -21)
      });
      units.Add(new FactoredUnit("pJ", "Picojoule", Types.Energy) {
        DerivedFrom = "J",
        Factor = (decimal)Math.Pow(10, -12)
      });
      units.Add(new FactoredUnit("nJ", "Nanojoule", Types.Energy) {
        DerivedFrom = "J",
        Factor = (decimal)Math.Pow(10, -9)
      });
      units.Add(new FactoredUnit("μJ", "Microjoule", Types.Energy) {
        DerivedFrom = "J",
        Factor = (decimal)Math.Pow(10, -6)
      });
      units.Add(new FactoredUnit("mJ", "Millijoule", Types.Energy) {
        DerivedFrom = "J",
        Factor = (decimal)Math.Pow(10, -3)
      });
      units.Add(new FactoredUnit("kJ", "Kilojoule", Types.Energy) {
        DerivedFrom = "J",
        Factor = (decimal)Math.Pow(10, 3)
      });
      units.Add(new FactoredUnit("MJ", "Megajoule", Types.Energy) {
        DerivedFrom = "J",
        Factor = (decimal)Math.Pow(10, 6)
      });
      units.Add(new FactoredUnit("GJ", "Gigajoule", Types.Energy) {
        DerivedFrom = "J",
        Factor = (decimal)Math.Pow(10, 9)
      });
      units.Add(new FactoredUnit("TJ", "Terajoule", Types.Energy) {
        DerivedFrom = "J",
        Factor = (decimal)Math.Pow(10, 12)
      });
      units.Add(new FactoredUnit("PJ", "Petajoule", Types.Energy) {
        DerivedFrom = "J",
        Factor = (decimal)Math.Pow(10, 15)
      });
      units.Add(new FactoredUnit("EJ", "Exajoule", Types.Energy) {
        DerivedFrom = "J",
        Factor = (decimal)Math.Pow(10, 18)
      });
      units.Add(new FactoredUnit("ZJ", "Zettajoule", Types.Energy) {
        DerivedFrom = "J",
        Factor = (decimal)Math.Pow(10, 21)
      });
      units.Add(new FactoredUnit("YJ", "Kilojoule", Types.Energy) {
        DerivedFrom = "J",
        Factor = (decimal)Math.Pow(10, 24)
      });
      units.Add(new DerivedUnit("Wh", "Watt Hour", Types.Energy) {
        Formula = "J*3.6*10E+3",
        Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
          { "J", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
        }
      });
      units.Add(new FactoredUnit("kW", "Kilowatt", Types.Power) {
        DerivedFrom = "W",
        Factor = (decimal)Math.Pow(10, -3)
      });
      units.Add(new FactoredUnit("kWh", "Kilowatt Hour", Types.Power) {
        DerivedFrom = "Wh",
        Factor = (decimal)Math.Pow(10, 3)
      });

      return units;
    }

    public static SIUnits.Abstracts.AUnit GetUnit(string name){
      return GetUnits().FirstOrDefault(o => o.Name == name);
    }
    public static decimal? Convert(string expression, string targetSymbol) {
      Regex reg = new Regex(@"(\d+)(.*)");
      if (reg.IsMatch(expression)) {
        Match match = reg.Match(expression);
        decimal val;
        if (decimal.TryParse(match.Groups[1].Value, out val)) {
          return Convert(val, match.Groups[2].Value, targetSymbol);
        } else {
          throw new Exception("Couldn't extract numeric value from expression.");
        }
      } else {
        throw new Exception("Expression could not be extracted from given string.");
      }
    }
    public static decimal? Convert(decimal val, string sourceSymbol, string targetSymbol) {
      List<SIUnits.Abstracts.AUnit> units = SIUnits.UnitManager.GetUnits();
      SIUnits.Abstracts.AUnit source = units.FirstOrDefault(o => o.Symbol == sourceSymbol);
      SIUnits.Abstracts.AUnit target = units.FirstOrDefault(o => o.Symbol == targetSymbol);

      if (source == null) {
        throw new Exception("Couldn't determine appropriate source unit from '" + sourceSymbol + "'.");
      } else if (target == null) {
        throw new Exception("Couldn't determine appropriate target unit from '" + targetSymbol + "'.");
      }
      return Convert(val, source, target);
    }
    public static decimal? Convert(decimal val, SIUnits.Abstracts.AUnit source, SIUnits.Abstracts.AUnit target) {
      decimal output = 0;
      if (source.Base == target.Base) {
        decimal baseValue = 0;
        string from = "",
          to = "",
          bas = "";
        if (source != null) {
          if (source.GetType().IsAssignableFrom(typeof(FactoredUnit))) {
            baseValue = val / (source as FactoredUnit).Factor;
            bas = (source as FactoredUnit).DerivedFrom;
            from = source.Symbol;
          } else {
            baseValue = val;
            bas = source.Symbol;
            from = source.Symbol;
          }
        } else {
          throw new Exception("Source unit cannot be null.");
        }

        if (target != null) {
          if (target.GetType().IsAssignableFrom(typeof(FactoredUnit))) {
            if ((target as FactoredUnit).DerivedFrom == bas) {
              to = target.Symbol;
              output = baseValue * (target as FactoredUnit).Factor;
            } else {
              throw new Exception("Both units must come from the same derivation.");
            }
          } else {
            if (target.Symbol == bas) {
              to = target.Symbol;
              output = baseValue;
            } else {
              throw new Exception("Both units must come from the same derivation.");
            }
          }
        } else {
          throw new Exception("Target unit cannot be null.");
        }
        if (string.IsNullOrEmpty(from)
         || string.IsNullOrEmpty(to)
         || string.IsNullOrEmpty(bas)) {
          throw new Exception("Cannot convert items that are not derived from the same base unit.");
        }
      } else {
        throw new Exception("Source and Target units must be within the same unit class (ie. " + source.Base.ToString() + " or " + target.Base.ToString() + ")");
      }
      return output;
    }

    public static System.Xml.XmlDocument ToXML(this IEnumerable<SIUnits.Abstracts.AUnit> units) {
      XmlDocument xDoc = new XmlDocument();

      XmlNode xRoot = xDoc.AppendChild(xDoc.CreateElement("SIUnits.Abstracts.AUnits"));
      Type derivedType = typeof(DerivedUnit);
      Type factoredType = typeof(FactoredUnit);
      foreach (SIUnits.Abstracts.AUnit unit in units) {
        XmlNode unitNode;
        Type unitType = unit.GetType();
        if (unitType.IsAssignableFrom(derivedType)) {
          unitNode = xRoot.AppendChild(xDoc.CreateElement("DerivedUnit"));
          DerivedUnit derivedUnit = unit as DerivedUnit;
          if (derivedUnit.Sources != null && derivedUnit.Sources.Count > 0) {
            XmlNode xSources = unitNode.AppendChild(xDoc.CreateElement("Sources"));
            foreach (KeyValuePair<string, SIUnits.DerivedUnit.DerivationMethods> kv in derivedUnit.Sources) {
              XmlNode xSource = xSources.AppendChild(xDoc.CreateElement("Source"));
              xSource.AppendChild(xDoc.CreateElement("ShortName")).InnerText = kv.Key;
              xSource.AppendChild(xDoc.CreateElement("DerivationType")).InnerText = kv.Value.ToString();
            }
          }
        } else if (unitType.IsAssignableFrom(factoredType)) {
          unitNode = xRoot.AppendChild(xDoc.CreateElement("FactoredUnit"));
          FactoredUnit factoredUnit = unit as FactoredUnit;
          unitNode.AppendChild(xDoc.CreateElement("DerivedFrom")).InnerText = factoredUnit.DerivedFrom;
          unitNode.AppendChild(xDoc.CreateElement("Factor")).InnerText = factoredUnit.Factor.ToString();
        } else {
          unitNode = xRoot.AppendChild(xDoc.CreateElement("SIUnits.Abstracts.AUnit"));
        }
        unitNode.AppendChild(xDoc.CreateElement("ShortName")).InnerText = unit.Symbol;
        unitNode.AppendChild(xDoc.CreateElement("Name")).InnerText = unit.Name;
        unitNode.AppendChild(xDoc.CreateElement("UnitType")).InnerText = unit.Base.ToString();
        unitNode.AppendChild(xDoc.CreateElement("Formula")).InnerText = unit.Formula;
      }
      units.First().GetType().IsSubclassOf(derivedType);

      return xDoc;
    }
  }

}
