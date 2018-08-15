using System;

namespace Bluegrams.Periodica.Data
{
    /// <summary>
    /// Represents the electron configuration of an element.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// The symbol of the element the configuration is based on.
        /// </summary>
        public string BasedOn { get; private set; }

        /// <summary>
        /// The orbitals of the configuration.
        /// </summary>
        public Orbital[] Orbitals { get; private set; }

        public Configuration(string basedOn, Orbital[] orbitals)
        {
            BasedOn = basedOn;
            Orbitals = orbitals;
        }

        public override string ToString()
        {
            string basedOnString = String.IsNullOrEmpty(BasedOn) ? "" : String.Format("[{0}] ", BasedOn);
            return String.Format("{0}{1}", basedOnString, String.Join(" ", (object[])Orbitals));
        }
    }
}