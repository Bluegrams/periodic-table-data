using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;
using System.Reflection;
using System.Globalization;

namespace Bluegrams.Periodica.Data
{
    /// <summary>
    /// Represents a periodic table.
    /// </summary>
    public class PeriodicTable : IEnumerable
    {
        /// <summary>
        /// The dictionary holding the element data.
        /// </summary>
        public Dictionary<string, Element> Elements { get; private set; }
        /// <summary>
        /// The element symbols ordered by position in the periodic table.
        /// </summary>
        public string[] ElementSymbols { get; private set; }
        /// <summary>
        /// The localized language of this periodic table.
        /// </summary>
        public CultureInfo Localization { get; private set; }

        private PeriodicTable() { Localization = CultureInfo.InvariantCulture; }

        /// <summary>
        /// Returns the element with the specified symbol from the periodic table.
        /// </summary>
        public Element this[string symbol] {
            get { return Elements[symbol]; }
        }

        /// <summary>
        /// Returns the element with the specified atomic number from the periodic table.
        /// </summary>
        public Element this[int number] {
            get { return Elements[ElementSymbols[number-1]]; }
        }

        /// <summary>
        /// Loads the element data from file and applies the specified translation.
        /// </summary>
        /// <param name="localization">The culture info of the localization that should be loaded.</param>
        /// <returns>A localized periodic table object with the loaded data.</returns>
        public static PeriodicTable Load(CultureInfo localization)
        {
            PeriodicTable table = Load();
            table.Localization = localization;
            if (localization.TwoLetterISOLanguageName == "iv") return table;
            // Check if localization is supported.
            Assembly assembly = typeof(PeriodicTable).GetTypeInfo().Assembly;
            string streamName = String.Format("Bluegrams.Periodica.Data.Data.ElementData_{0}.csv", 
                                                localization.TwoLetterISOLanguageName);
            bool hasSupport = Array.IndexOf(assembly.GetManifestResourceNames(), streamName) > -1;
            // Fall back to english if localization is not supported.
            if (localization.TwoLetterISOLanguageName == "en" || !hasSupport)
            {
                foreach (Element elem in table)
                    elem.LocalizedName = elem.EnglishName;
                return table;
            }
            // Read local names from stream.
            using (StreamReader sr = new StreamReader(assembly.GetManifestResourceStream(streamName)))
            {
                CsvReader reader = new CsvReader(sr);
                while (reader.Read())
                {
                    var symbol = reader.GetField("Symbol");
                    var name = reader.GetField("LocalName");
                    table[symbol].LocalizedName = name;
                }
            }
            return table;
        }

        /// <summary>
        /// Loads the element data from file and creates a new periodic table.
        /// </summary>
        /// <returns>A periodic table object with the loaded data.</returns>
        public static PeriodicTable Load()
        {
            var dict = new Dictionary<string, Element>();
            string[] symbols = new string[118];
            Assembly assembly = typeof(PeriodicTable).GetTypeInfo().Assembly;
            using (StreamReader sr = new StreamReader(assembly.GetManifestResourceStream("Bluegrams.Periodica.Data.Data.ElementData.csv")))
            {
                CsvReader reader = new CsvReader(sr);
                reader.Configuration.CultureInfo = CultureInfo.InvariantCulture;
                reader.Configuration.RegisterClassMap<ElementClassMap>();
                var items = reader.GetRecords<Element>();
                foreach(Element item in items)
                {
                    dict.Add(item.Symbol, item);
                    symbols[item.AtomicNumber-1] = item.Symbol;
                }
            }
            PeriodicTable table = new PeriodicTable() { Elements = dict, ElementSymbols = symbols };
            return table;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in Elements)
            {
                yield return item.Value;
            }
        }
    }
}
