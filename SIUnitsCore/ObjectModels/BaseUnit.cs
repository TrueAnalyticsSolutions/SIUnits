using SIUnits.Abstracts;

namespace SIUnits {
    /// <summary>
    /// An implementation of an abstract Unit that represents an SI Base Unit
    /// </summary>
    public class BasicUnit : Abstracts.BaseUnit {
        public BasicUnit() : base() {

        }
        public BasicUnit(string shortName, string name, UnitType type) : base(shortName, name, type) {

        }
    }

}
