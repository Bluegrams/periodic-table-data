using CsvHelper.Configuration;

namespace Bluegrams.Periodica.Data
{
    /// <summary>
    /// Mapping class for element data.
    /// </summary>
    public sealed class ElementClassMap : CsvClassMap<Element>
    {
        public ElementClassMap()
        {
            Map(m => m.AtomicNumber).Name("AtomicNumber");
            Map(m => m.Symbol).Name("Symbol");
            Map(m => m.EnglishName).Name("EnglishName");
            Map(m => m.Group).Name("Group");
            Map(m => m.Period).Name("Period");
            Map(m => m.Block).Name("Block");
            Map(m => m.Category).Name("Category");
            Map(m => m.AtomicMass).Name("AtomicMass");
            Map(m => m.Configuration).Name("Configuration").TypeConverter<StringToOrbitalConverter>();
            Map(m => m.ShellConfiguration).Name("ShellConfiguration").TypeConverter<StringToIntArrayConverter>();
            Map(m => m.StandardState).Name("StandardState");
            Map(m => m.Density).Name("Density");
            Map(m => m.MeltingPoint).Name("MeltingPoint");
            Map(m => m.BoilingPoint).Name("BoilingPoint");
            Map(m => m.HeatCapacity).Name("HeatCapacity");
            Map(m => m.HeatOfFusion).Name("HeatOfFusion");
            Map(m => m.HeatOfVaporization).Name("HeatOfVaporization");
            Map(m => m.AtomicRadius).Name("AtomicRadius");
            Map(m => m.CovalentRadius).Name("CovalentRadius");
            Map(m => m.VanDerWaalsRadius).Name("VanDerWaalsRadius");
            Map(m => m.Electronegativity).Name("Electronegativity");
            Map(m => m.OxidationStates).Name("OxidationStates").TypeConverter<StringToIntArrayConverter>();
            Map(m => m.IonizationEnergy).Name("IonizationEnergy");
            Map(m => m.ThermalConductivity).Name("ThermalConductivity");
            Map(m => m.ElectronAffinity).Name("ElectronAffinity");
            Map(m => m.AbundanceCrust).Name("AbundanceCrust");
            Map(m => m.AbundanceUniverse).Name("AbundanceUniverse");
            Map(m => m.Discovery).Name("Discovery");
            Map(m => m.DiscoveredBy).Name("DiscoveredBy");
            Map(m => m.Radioactive).Name("Radioactive");
        }
    }
}