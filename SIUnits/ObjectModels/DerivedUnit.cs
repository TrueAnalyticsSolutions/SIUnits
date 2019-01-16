using SIUnits.Abstracts;
using System.Collections.Generic;
namespace SIUnits {
  /// <summary>
  /// An implementation of an abstract Unit that represents a unit that is an unfactored derivative of a SI Base Unit.
  /// </summary>
  public class DerivedUnit:AUnit {
    /// <summary>
    /// Provides a reference to SI Base and SI Derived Units and their impact on this unit.
    /// </summary>
    public Dictionary<string, DerivationMethods> Sources { get; set; }

    /// <summary>
    /// How the current Derived Unit is effected by the source Unit
    /// </summary>
    public enum DerivationMethods {
      Multiplication = 0,
      Division = 1
    }
    public DerivedUnit() {
      this.Sources = new Dictionary<string, DerivationMethods>();
    }
    public DerivedUnit(string symbol, string name, SIUnits.Types baseQuantity) :base(symbol, name, baseQuantity) {
    }
  }

}
