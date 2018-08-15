using System;
using Bluegrams.Periodica.Data;
using System.Collections.Generic;
using System.Globalization;

namespace Bluegrams.Periodica.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a language code for translation (empty for default): ");
            string code = Console.ReadLine();
            var localization = new CultureInfo(code);
            PeriodicTable table;
            try 
            {
                table = PeriodicTable.Load(localization);
                Console.WriteLine("Successfully loaded periodic table.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return;
            }
            loop(table);
        }

        static void loop(PeriodicTable table)
        {
            while (true) {
                Console.Write("Enter an element symbol: ");
                string input = Console.ReadLine();
                Element result = null;
                if (table.Elements.ContainsKey(input)) {
                    result = table[input];
                }
                else if (int.TryParse(input, out int index))
                {
                    if (index > 0 && index <= 118)
                        result = table[index];
                }
                if (result != null)
                    Console.WriteLine(result.ToString().Replace("; ", "\n> ").Insert(0, "> "));
                else Console.WriteLine("Element not found.");
            }
        }
    }
}
