using SIUnits.Abstracts;

namespace SIUnits {
    /// <summary>
    /// An implementation of a Base Unit that can be used to convert derivatives of a SI Base Unit to this new derivative unit
    /// </summary>
    public class FactoredUnit : Abstracts.BaseUnit {
        /// <summary>
        /// Reference to the case-sensitive SI Unit Symbol
        /// </summary>
        public string DerivedFrom { get; set; }
        /// <summary>
        /// Multiplication value to convert the DerivedFrom value to this derivative unit
        /// </summary>
        public decimal Factor { get; set; }

        public FactoredUnit() : base() {

        }
        public FactoredUnit(string shortName, string name, UnitType type) : base(shortName, name, type) {

        }
    }
}