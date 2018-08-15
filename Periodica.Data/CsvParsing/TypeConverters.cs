using System;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Bluegrams.Periodica.Data
{
    class StringToIntArrayConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(TypeConverterOptions options, string text)
        {
            string[] vals = text.Split(',');
            List<int> results = new List<int>();
            foreach (var val in vals)
            {
                if(!String.IsNullOrEmpty(val)) results.Add(int.Parse(val));
            }
            return results.ToArray();
        }

        public override bool CanConvertFrom( Type type ) => type == typeof(string);
    }

    class StringToOrbitalConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(TypeConverterOptions options, string text)
        {
            string[] vals = text.Split(' ');
            List<Orbital> orbitals = new List<Orbital>();
            string basedOn = "";
            foreach (var val in vals)
            {
                if (val.StartsWith("["))
                {
                    basedOn = val.Substring(1, val.Length-2);
                    continue;
                }
                var shell = byte.Parse(val.Substring(0, 1));
                var type = char.Parse(val.Substring(1, 1));
                var count = byte.Parse(val.Substring(2));
                orbitals.Add(new Orbital(shell, type, count));
            }
            return new Configuration(basedOn, orbitals.ToArray());
        }

        public override bool CanConvertFrom( Type type ) => type == typeof(string);
    }
}