using System;

namespace Bluegrams.Periodica.Data
{
    public class UnitAttribute : Attribute
    {
        public string UnitString { get; private set; }

        public UnitAttribute(string unitString)
        {
            this.UnitString = unitString;
        }
    }
}