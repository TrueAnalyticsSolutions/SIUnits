using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Text.RegularExpressions;
using SIUnits.Abstracts;

namespace SIUnits {
    public static class UnitManager {
        private static List<BaseUnit> _units { get; set; } = new List<BaseUnit>();

        /// <summary>
        /// Gets a list of BaseUnits
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<BaseUnit> GetUnits() {
            if (_units.Any())
                return _units;
            _units.Add(new BasicUnit("kg", "Kilogram", UnitType.Mass));
            _units.Add(new BasicUnit("m", "Meter", UnitType.Length));
            _units.Add(new BasicUnit("s", "Second", UnitType.Time));
            _units.Add(new BasicUnit("mol", "Mole", UnitType.Substance));
            _units.Add(new BasicUnit("A", "Ampere", UnitType.ElectricalCurrent));
            _units.Add(new BasicUnit("K", "Kelvin", UnitType.ThermodynamicTemperature));
            _units.Add(new BasicUnit("cd", "Candela", UnitType.LuminousIntensity));
            _units.Add(new BasicUnit("bit", "Bit", UnitType.DigitalStorage));

            #region DerivedUnits
            _units.Add(new DerivedUnit("m³", "Cubic Meter", UnitType.Volume) {
                Formula = "m³",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "m", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
                }
            });
            _units.Add(new DerivedUnit("m²", "Square Meter", UnitType.Area) {
                Formula = "m²",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "m", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
                }
            });
            _units.Add(new DerivedUnit("m/s", "Meters per Second", UnitType.Velocity) {
                Formula = "m/s",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "m", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
                    { "s", SIUnits.DerivedUnit.DerivationMethods.Division }
                }
            });
            _units.Add(new DerivedUnit("m/s²", "Metric Acceleration", UnitType.Acceleration) {
                Formula = "m/s²",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "s", SIUnits.DerivedUnit.DerivationMethods.Division },
                    { "m/s", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
                }
            });
            _units.Add(new DerivedUnit("N", "Newton", UnitType.Force) {
                Formula = "kg*m/s²",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "kg", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
                    { "m/s²", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
                }
            });
            _units.Add(new DerivedUnit("J", "Joule", UnitType.Energy) {
                Formula = "N*m",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "m", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
                    { "N", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
                }
            });
            _units.Add(new DerivedUnit("kat", "Katal", UnitType.CatalyticActivity) {
                Formula = "mol/s",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "mol", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
                    { "Wb", SIUnits.DerivedUnit.DerivationMethods.Division }
                }
            });
            _units.Add(new DerivedUnit("C", "Coulomb", UnitType.ElectricCharge) {
                Formula = "A*s",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "s", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
                    { "A", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
                }
            });
            _units.Add(new DerivedUnit("degC", "Degrees Celsius", UnitType.CelsiusTemperature) {
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "K", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
                }
            });
            _units.Add(new DerivedUnit("lx", "Lux", UnitType.Illuminance) {
                Formula = "lm/m²",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "m²", SIUnits.DerivedUnit.DerivationMethods.Division },
                    { "lm", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
                }
            });
            _units.Add(new DerivedUnit("Pa", "Pascal", UnitType.Pressure) {
                Formula = "N/m²",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "N", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
                    { "m²", SIUnits.DerivedUnit.DerivationMethods.Division }
                }
            });
            _units.Add(new DerivedUnit("W", "Watt", UnitType.Power) {
                Formula = "J/s",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "J", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
                    { "s", SIUnits.DerivedUnit.DerivationMethods.Division }
                }
            });
            _units.Add(new DerivedUnit("Wb", "Weber", UnitType.MagneticFlux) {
                Formula = "V*s",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "V", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
                    { "s", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
                }
            });
            _units.Add(new DerivedUnit("F", "Farad", UnitType.Capacitance) {
                Formula = "C/V",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "C", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
                    { "V", SIUnits.DerivedUnit.DerivationMethods.Division }
                }
            });
            _units.Add(new DerivedUnit("lm", "Lumen", UnitType.LuminousFlux) {
                Formula = "cd*sr",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "cd", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
                    { "sr", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
                }
            });
            _units.Add(new DerivedUnit("sr", "Steradian", UnitType.SolidAngle) {
                Formula = "m²/m²=1"
            });
            _units.Add(new DerivedUnit("Ω", "Ohm", UnitType.Resistance) {
                Formula = "V/A",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "V", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
                    { "A", SIUnits.DerivedUnit.DerivationMethods.Division }
                }
            });
            _units.Add(new DerivedUnit("V", "Volt", UnitType.Voltage) {
                Formula = "W/A",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "W", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
                    { "A", SIUnits.DerivedUnit.DerivationMethods.Division }
                }
            });
            _units.Add(new DerivedUnit("H", "Henry", UnitType.Inductance) {
                Formula = "Wb/A",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "Wb", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
                    { "A", SIUnits.DerivedUnit.DerivationMethods.Division }
                }
            });
            _units.Add(new DerivedUnit("Bq", "Becquaerel", UnitType.Activity) {
                Formula = "1/s",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "s", SIUnits.DerivedUnit.DerivationMethods.Division }
                }
            });
            _units.Add(new DerivedUnit("Gy", "Gray", UnitType.AbsorbedDose) {
                Formula = "J/kg",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "J", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
                    { "kg", SIUnits.DerivedUnit.DerivationMethods.Division }
                }
            });
            _units.Add(new DerivedUnit("Sv", "Slevert", UnitType.DoseEquivalent) {
                Formula = "J/kg",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "J", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
                    { "kg", SIUnits.DerivedUnit.DerivationMethods.Division }
                }
            });
            _units.Add(new DerivedUnit("Hz", "Hertz", UnitType.Frequency) {
                Formula = "1/s",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "s", SIUnits.DerivedUnit.DerivationMethods.Division }
                }
            });
            _units.Add(new DerivedUnit("T", "Tesla", UnitType.MagneticFluxDensity) {
                Formula = "Wb/m²",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "Wb", SIUnits.DerivedUnit.DerivationMethods.Multiplication },
                    { "m²", SIUnits.DerivedUnit.DerivationMethods.Division }
                }
            });
            _units.Add(new DerivedUnit("S", "Slemens", UnitType.Conductance) {
                Formula = "1/Ω",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "Ω", SIUnits.DerivedUnit.DerivationMethods.Division }
                }
            });
            _units.Add(new DerivedUnit("rad", "Radian", UnitType.PlaneAngle) {
                Formula = "m/m=1"
            });
            _units.Add(new DerivedUnit("byte", "Byte", UnitType.DigitalStorage) {
                Formula = "bit*8",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "bit", DerivedUnit.DerivationMethods.Multiplication }
                }
            });
            _units.Add(new DerivedUnit("bit/s", "Bit per Second", UnitType.DataTransferRate) {
                Formula = "bit/s",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "bit", DerivedUnit.DerivationMethods.Multiplication },
                    { "s", DerivedUnit.DerivationMethods.Division }
                }
            });
            #endregion

            #region FactoredUnits
            _units.Add(new FactoredUnit("kB", "Kilobyte", UnitType.DigitalStorage) {
                Formula = "byte*1000",
                DerivedFrom = "byte",
                Factor = (decimal)Math.Pow(1000, -1)
            });
            _units.Add(new FactoredUnit("kbit/s", "Kilobits per Second", UnitType.DigitalStorage) {
                Formula = "bit/s/1000",
                DerivedFrom = "bit/s",
                Factor = (decimal)Math.Pow(1000, -1)
            });
            _units.Add(new FactoredUnit("MB", "Megabyte", UnitType.DigitalStorage) {
                Formula = "byte*1000²",
                DerivedFrom = "byte",
                Factor = (decimal)Math.Pow(1000, -2)
            });
            _units.Add(new FactoredUnit("Mbit/s", "Megabits per Second", UnitType.DigitalStorage) {
                Formula = "bit/s/1000²",
                DerivedFrom = "bit/s",
                Factor = (decimal)Math.Pow(1000, -2)
            });
            _units.Add(new FactoredUnit("GB", "Gigabyte", UnitType.DigitalStorage) {
                Formula = "byte*1000³",
                DerivedFrom = "byte",
                Factor = (decimal)Math.Pow(1000, -3)
            });
            _units.Add(new FactoredUnit("Gbit/s", "Gigabit per Second", UnitType.DigitalStorage) {
                Formula = "bit/s/1000³",
                DerivedFrom = "bit/s",
                Factor = (decimal)Math.Pow(1000, -3)
            });
            _units.Add(new FactoredUnit("TB", "Terabyte", UnitType.DigitalStorage) {
                Formula = "byte*1000^4",
                DerivedFrom = "byte",
                Factor = (decimal)Math.Pow(1000, -4)
            });
            _units.Add(new FactoredUnit("Tbit/s", "Terabit per Second", UnitType.DigitalStorage) {
                Formula = "bit/s/1000^4",
                DerivedFrom = "bit/s",
                Factor = (decimal)Math.Pow(1000, -4)
            });
            _units.Add(new FactoredUnit("PB", "Petabyte", UnitType.DigitalStorage) {
                Formula = "byte*1000^5",
                DerivedFrom = "byte",
                Factor = (decimal)Math.Pow(1000, -5)
            });
            _units.Add(new FactoredUnit("Pbit/s", "Petabit per Second", UnitType.DigitalStorage) {
                Formula = "bit/s/1000^5",
                DerivedFrom = "bit/s",
                Factor = (decimal)Math.Pow(1000, -5)
            });
            _units.Add(new FactoredUnit("EB", "Exabyte", UnitType.DigitalStorage) {
                Formula = "byte*1000^6",
                DerivedFrom = "byte",
                Factor = (decimal)Math.Pow(1000, -6)
            });
            _units.Add(new FactoredUnit("Ebit/s", "Exabit per Second", UnitType.DigitalStorage) {
                Formula = "bit/s/1000^6",
                DerivedFrom = "bit/s",
                Factor = (decimal)Math.Pow(1000, -6)
            });
            _units.Add(new FactoredUnit("ZB", "Zettabyte", UnitType.DigitalStorage) {
                Formula = "byte*1000^7",
                DerivedFrom = "byte",
                Factor = (decimal)Math.Pow(1000, -7)
            });
            _units.Add(new FactoredUnit("Zbit/s", "Zettabit per Second", UnitType.DigitalStorage) {
                Formula = "bit/s/1000^7",
                DerivedFrom = "bit/s",
                Factor = (decimal)Math.Pow(1000, -7)
            });
            _units.Add(new FactoredUnit("YB", "Yottabyte", UnitType.DigitalStorage) {
                Formula = "byte*1000^8",
                DerivedFrom = "byte",
                Factor = (decimal)Math.Pow(1000, -8)
            });
            _units.Add(new FactoredUnit("Ybit/s", "Yottabit per Second", UnitType.DigitalStorage) {
                Formula = "bit/s/1000^8",
                DerivedFrom = "bit/s",
                Factor = (decimal)Math.Pow(1000, -8)
            });
            _units.Add(new FactoredUnit("in", "Inch", UnitType.Length) {
                DerivedFrom = "m",
                Factor = (decimal)39.3701
            });
            _units.Add(new FactoredUnit("ft", "Foot", UnitType.Length) {
                DerivedFrom = "m",
                Factor = (decimal)3.28084
            });
            _units.Add(new FactoredUnit("in²", "Square Inch", UnitType.Length) {
                DerivedFrom = "m",
                Factor = (decimal)1550
            });
            _units.Add(new FactoredUnit("ft²", "Square Foot", UnitType.Length) {
                DerivedFrom = "m",
                Factor = (decimal)10.7639
            });
            _units.Add(new FactoredUnit("in³", "Cubic Inch", UnitType.Length) {
                DerivedFrom = "m",
                Factor = (decimal)61023.7
            });
            _units.Add(new FactoredUnit("ft³", "Cubic Foot", UnitType.Length) {
                DerivedFrom = "m",
                Factor = (decimal)35.3147
            });
            _units.Add(new FactoredUnit("mm", "Millimeter", UnitType.Length) {
                DerivedFrom = "m",
                Factor = (decimal)1000
            });
            _units.Add(new FactoredUnit("cm", "Centimeter", UnitType.Length) {
                DerivedFrom = "m",
                Factor = (decimal)100
            });
            _units.Add(new FactoredUnit("lb", "Pound", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)2.20462
            });
            _units.Add(new FactoredUnit("oz", "Ounce", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)35.274
            });
            _units.Add(new FactoredUnit("g", "Gram", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)Math.Pow(10, 3)
            });
            _units.Add(new FactoredUnit("mg", "Milligram", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)Math.Pow(10, 6)
            });
            _units.Add(new FactoredUnit("µg", "Microgram", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)Math.Pow(10, 9)
            });
            _units.Add(new FactoredUnit("ng", "Nanogram", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)Math.Pow(10, 12)
            });
            _units.Add(new FactoredUnit("pg", "Picogram", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)Math.Pow(10, 15)
            });
            _units.Add(new FactoredUnit("fg", "femtogram", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)Math.Pow(10, 18)
            });
            _units.Add(new FactoredUnit("ag", "Attogram", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)Math.Pow(10, 21)
            });
            _units.Add(new FactoredUnit("zg", "Zeptogram", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)Math.Pow(10, 24)
            });
            _units.Add(new FactoredUnit("yg", "Yoctogram", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)Math.Pow(10, 27)
            });
            _units.Add(new FactoredUnit("Mg", "Megagram", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)Math.Pow(10, 3)
            });
            _units.Add(new FactoredUnit("Gg", "Gigagram", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)Math.Pow(10, 6)
            });
            _units.Add(new FactoredUnit("Tg", "Teragram", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)Math.Pow(10, 9)
            });
            _units.Add(new FactoredUnit("Pg", "Petagram", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)Math.Pow(10, 12)
            });
            _units.Add(new FactoredUnit("Eg", "Exagram", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)Math.Pow(10, 15)
            });
            _units.Add(new FactoredUnit("Zg", "Zettagram", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)Math.Pow(10, 18)
            });
            _units.Add(new FactoredUnit("Yg", "Yottagram", UnitType.Mass) {
                DerivedFrom = "kg",
                Factor = (decimal)Math.Pow(10, 21)
            });
            _units.Add(new FactoredUnit("zJ", "Zeptojoule", UnitType.Energy) {
                DerivedFrom = "J",
                Factor = (decimal)Math.Pow(10, -21)
            });
            _units.Add(new FactoredUnit("pJ", "Picojoule", UnitType.Energy) {
                DerivedFrom = "J",
                Factor = (decimal)Math.Pow(10, -12)
            });
            _units.Add(new FactoredUnit("nJ", "Nanojoule", UnitType.Energy) {
                DerivedFrom = "J",
                Factor = (decimal)Math.Pow(10, -9)
            });
            _units.Add(new FactoredUnit("μJ", "Microjoule", UnitType.Energy) {
                DerivedFrom = "J",
                Factor = (decimal)Math.Pow(10, -6)
            });
            _units.Add(new FactoredUnit("mJ", "Millijoule", UnitType.Energy) {
                DerivedFrom = "J",
                Factor = (decimal)Math.Pow(10, -3)
            });
            _units.Add(new FactoredUnit("kJ", "Kilojoule", UnitType.Energy) {
                DerivedFrom = "J",
                Factor = (decimal)Math.Pow(10, 3)
            });
            _units.Add(new FactoredUnit("MJ", "Megajoule", UnitType.Energy) {
                DerivedFrom = "J",
                Factor = (decimal)Math.Pow(10, 6)
            });
            _units.Add(new FactoredUnit("GJ", "Gigajoule", UnitType.Energy) {
                DerivedFrom = "J",
                Factor = (decimal)Math.Pow(10, 9)
            });
            _units.Add(new FactoredUnit("TJ", "Terajoule", UnitType.Energy) {
                DerivedFrom = "J",
                Factor = (decimal)Math.Pow(10, 12)
            });
            _units.Add(new FactoredUnit("PJ", "Petajoule", UnitType.Energy) {
                DerivedFrom = "J",
                Factor = (decimal)Math.Pow(10, 15)
            });
            _units.Add(new FactoredUnit("EJ", "Exajoule", UnitType.Energy) {
                DerivedFrom = "J",
                Factor = (decimal)Math.Pow(10, 18)
            });
            _units.Add(new FactoredUnit("ZJ", "Zettajoule", UnitType.Energy) {
                DerivedFrom = "J",
                Factor = (decimal)Math.Pow(10, 21)
            });
            _units.Add(new FactoredUnit("YJ", "Kilojoule", UnitType.Energy) {
                DerivedFrom = "J",
                Factor = (decimal)Math.Pow(10, 24)
            });
            #endregion
            _units.Add(new DerivedUnit("Wh", "Watt Hour", UnitType.Energy) {
                Formula = "J*3.6*10E+3",
                Sources = new Dictionary<string, SIUnits.DerivedUnit.DerivationMethods>(){
                    { "J", SIUnits.DerivedUnit.DerivationMethods.Multiplication }
                }
            });
            _units.Add(new FactoredUnit("kW", "Kilowatt", UnitType.Power) {
                DerivedFrom = "W",
                Factor = (decimal)Math.Pow(10, -3)
            });
            _units.Add(new FactoredUnit("kWh", "Kilowatt Hour", UnitType.Power) {
                DerivedFrom = "Wh",
                Factor = (decimal)Math.Pow(10, 3)
            });

            return _units;
        }

        /// <summary>
        /// Gets the first unit by the given name
        /// </summary>
        /// <param name="name">Name of the unit</param>
        /// <returns>Unit</returns>
        public static SIUnits.Abstracts.BaseUnit GetUnit(string name) {
            return GetUnits().FirstOrDefault(o => o.Name == name);
        }

        /// <summary>
        /// Converts a unit expression from one unit to another. For example: "33lb" to target unit symbol "kg"
        /// </summary>
        /// <param name="expression">Unit expression to convert. For example: "33lb"</param>
        /// <param name="targetSymbol">Unit symbol to convert to. For example: "kg"</param>
        /// <returns>Converted value</returns>
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

        /// <summary>
        /// Converts a unit value from the source terms to the target terms.
        /// </summary>
        /// <param name="val">Decimal value of the source terms</param>
        /// <param name="sourceSymbol">Unit symbol of the source value</param>
        /// <param name="targetSymbol">Unit symbol of the target value</param>
        /// <returns>Converted value</returns>
        public static decimal? Convert(decimal val, string sourceSymbol, string targetSymbol) {
            IEnumerable<SIUnits.Abstracts.BaseUnit> units = SIUnits.UnitManager.GetUnits();
            SIUnits.Abstracts.BaseUnit source = units.FirstOrDefault(o => o.Symbol == sourceSymbol);
            SIUnits.Abstracts.BaseUnit target = units.FirstOrDefault(o => o.Symbol == targetSymbol);

            if (source == null) {
                throw new Exception("Couldn't determine appropriate source unit from '" + sourceSymbol + "'.");
            } else if (target == null) {
                throw new Exception("Couldn't determine appropriate target unit from '" + targetSymbol + "'.");
            }
            return Convert(val, source, target);
        }

        /// <summary>
        /// Converts a unit value from the source terms to the target terms.
        /// </summary>
        /// <param name="val">Decimal value of the source terms</param>
        /// <param name="source">Unit of the source value</param>
        /// <param name="target">Unit of the target value</param>
        /// <returns></returns>
        public static decimal? Convert(decimal val, SIUnits.Abstracts.BaseUnit source, SIUnits.Abstracts.BaseUnit target) {
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

        public static System.Xml.XmlDocument ToXML(this IEnumerable<SIUnits.Abstracts.BaseUnit> units) {
            XmlDocument xDoc = new XmlDocument();

            XmlNode xRoot = xDoc.AppendChild(xDoc.CreateElement("SIUnits.Abstracts.AUnits"));
            Type derivedType = typeof(DerivedUnit);
            Type factoredType = typeof(FactoredUnit);
            foreach (SIUnits.Abstracts.BaseUnit unit in units) {
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
