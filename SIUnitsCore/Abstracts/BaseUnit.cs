namespace SIUnits.Abstracts {
    /// <summary>
    /// Base definition of a SI Unit
    /// </summary>
    public abstract class BaseUnit {
        /// <summary>
        /// SI Unit Symbol
        /// </summary>
        public string Symbol { get; set; }
        /// <summary>
        /// Common Unit Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// SI Base Quantity
        /// </summary>
        public UnitType Base { get; set; }
        /// <summary>
        /// Basic representation of the formula
        /// </summary>
        public string Formula { get; set; }

        public BaseUnit() {
        }

        public BaseUnit(string symbol, string name, UnitType baseQuantity) : this() {
            this.Symbol = symbol;
            this.Name = name;
            this.Base = baseQuantity;
        }
    }

}
