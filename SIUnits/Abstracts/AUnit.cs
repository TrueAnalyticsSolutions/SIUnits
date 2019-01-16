namespace SIUnits.Abstracts {
  public abstract class AUnit {
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
    public Types Base { get; set; }
    /// <summary>
    /// Basic representation of the formula
    /// </summary>
    public string Formula { get; set; }

    public AUnit() {
    }
    public AUnit(string symbol, string name, Types baseQuantity) : this() {
      this.Symbol = symbol;
      this.Name = name;
      this.Base = baseQuantity;
    }
  }

}
