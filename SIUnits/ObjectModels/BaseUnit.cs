﻿using SIUnits.Abstracts;
namespace SIUnits {
    /// <summary>
    /// An implementation of an abstract Unit that represents an SI Base Unit
    /// </summary>
    public class BaseUnit : Abstracts.BaseUnit {
        public BaseUnit() : base() {

        }
        public BaseUnit(string shortName, string name, UnitType type) : base(shortName, name, type) {

        }
    }

}
