using SIUnits.Abstracts;
namespace SIUnits {
  /// <summary>
  /// An implementation of an abstract Unit that represents an SI Base Unit
  /// </summary>
  public class BaseUnit : AUnit {
    public BaseUnit() : base() {

    }
    public BaseUnit(string shortName, string name, Types type) : base(shortName, name, type) {

    }
  }

}
