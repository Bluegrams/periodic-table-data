using System;
using System.Reflection;
using System.Linq;

namespace Bluegrams.Periodica.Data
{
    /// <summary>
    /// Represents an element in the periodic table.
    /// </summary>
    public class Element
    {
        #region General
        /// <summary>
        /// The element symbol.
        /// </summary>
        public string Symbol { get; set; }
        /// <summary>
        /// The English name of the element.
        /// </summary>
        public string EnglishName { get; set; }
        /// <summary>
        /// The localized name of the element.
        /// </summary>
        public string LocalizedName { get; set; }

        /// <summary>
        /// The atomic (proton) number of the element.
        /// </summary>
        public int AtomicNumber { get; set; }
        /// <summary>
        /// The element's group in the periodic table (not defined for lanthanoides and actinoides).
        /// </summary>
        public int? Group { get; set; }
        /// <summary>
        /// The element's period in the periodic table.
        /// </summary>
        public int Period { get; set; }
        /// <summary>
        /// The element's block in the periodic table.
        /// </summary>
        public char Block { get; set; }
        /// <summary>
        /// The element category of this element.
        /// </summary>
        public ElementCategory Category { get; set; }
        /// <summary>
        /// The relative atomic mass.
        /// </summary>
        public double AtomicMass { get; set; }

        /// <summary>
        /// The electron configuration.
        /// </summary>
        public Configuration Configuration { get; set; }
        /// <summary>
        /// The number of electrons per shell.
        /// </summary>
        public int[] ShellConfiguration { get; set; }
        #endregion

        #region Physical properties
        /// <summary>
        /// The state of the element at standard conditions.
        /// </summary>
        public StateOfMatter StandardState { get; set; }
        /// <summary>
        /// The density at standard conditions (in g*cm^-3).
        /// </summary>
        [Unit("g/cm³")]
        public double Density { get; set; }
        /// <summary>
        /// The melting point (in K).
        /// </summary>
        [Unit("K")]
        public double? MeltingPoint { get; set; }
        /// <summary>
        /// The boiling point (in K).
        /// </summary>
        [Unit("K")]
        public double? BoilingPoint { get; set; }
        /// <summary>
        /// The specific heat capacity (in J*g^-1*K^-1).
        /// </summary>
        [Unit("J/(g*K)")]
        public double? HeatCapacity { get; set; }
        /// <summary>
        /// The enthalpy of fusion (in kJ/mol).
        /// </summary>
        [Unit("kJ/mol")]
        public double? HeatOfFusion { get; set; }
        /// <summary>
        /// The enthalpy of vaporization (in kJ/mol).
        /// </summary>
        [Unit("kJ/mol")]
        public double? HeatOfVaporization { get; set; }               
        /// <summary>
        /// The molar volume of the element at standard conditions (in cm^3).
        /// </summary>
        [Unit("cm³")]
        public double? MolarVolume { get { return Math.Round(AtomicMass / Density, 2); } }
        /// <summary>
        /// The thermal conductivity of the element (in W*m^-1*K^-1).
        /// </summary>
        [Unit("W/(m*K)")]
        public double? ThermalConductivity { get; set; }
        #endregion
        
        #region Atomic properties
        /// <summary>
        /// The (calculated) atomic radius (in pm).
        /// </summary>
        [Unit("pm")]
        public double? AtomicRadius { get; set; }
        /// <summary>
        /// The (single bond) covalent radius (in pm).
        /// </summary>
        [Unit("pm")]
        public double? CovalentRadius { get; set; }
        /// <summary>
        /// The Van-Der-Waals radius (in pm).
        /// </summary>
        [Unit("pm")]
        public double? VanDerWaalsRadius { get; set; }
        /// <summary>
        /// The element's electronegativity on the Pauling scale.
        /// </summary>
        public double? Electronegativity { get; set; }
        /// <summary>
        /// Some common oxidation states of the element.
        /// </summary>
        public int[] OxidationStates { get; set; }        
        /// <summary>
        /// The first ionization energy (in kJ/mol).
        /// </summary>
        [Unit("kJ/mol")]
        public double? IonizationEnergy { get; set; }
        /// <summary>
        /// The electron affinity of the element (in kJ/mol).
        /// </summary>
        [Unit("kJ/mol")]
        public double? ElectronAffinity { get; set; }
        #endregion

        /// <summary>
        /// The element's abundance in the earth's crust (in mg/kg).
        /// </summary>
        [Unit("mg/kg")]
        public double AbundanceCrust { get; set; }
        /// <summary>
        /// The estimated abundance of the element in the universe (in mass %).
        /// </summary>
        [Unit("%")]
        public double? AbundanceUniverse { get; set; }
        /// <summary>
        /// The year of the first discovery of the element.
        /// (Rough estimations for C, S, Fe, Cu, Zn, As, Ag, Sn, Sb, Au, Hg and Pb.)
        /// </summary>
        public int? Discovery { get; set; }
        /// <summary>
        /// The name(s) of the discoverer(s).
        /// </summary>
        public string DiscoveredBy { get; set; }
        /// <summary>
        /// True if the element is radioactive.
        /// </summary>
        public bool Radioactive { get; set; }

        public override string ToString() 
        {
            string[] props = this.GetType().GetProperties().Select(prop => {
                var val = prop.GetValue(this);
                string s = prop.Name + ": ";
                // Pay special attention to two properties that are int arrays.
                if (prop.PropertyType == typeof(int[]))
                    s += String.Join(",", (int[])val);
                else s += val?.ToString();
                UnitAttribute unit = (UnitAttribute)prop.GetCustomAttributes().Where(v => v is UnitAttribute).FirstOrDefault();
                s += unit == null || String.IsNullOrWhiteSpace(val?.ToString()) ? "" : " " + unit.UnitString;
                return s;
            }).ToArray();
            return String.Join("; ", props);
        }
    }
}
