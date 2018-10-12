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
            AutoMap();
            Map(m => m.Configuration).Name("Configuration").TypeConverter<StringToOrbitalConverter>();
            Map(m => m.ShellConfiguration).Name("ShellConfiguration").TypeConverter<StringToIntArrayConverter>();
            Map(m => m.OxidationStates).Name("OxidationStates").TypeConverter<StringToIntArrayConverter>();
            Map(m => m.LocalizedName).Ignore();
        }
    }
}