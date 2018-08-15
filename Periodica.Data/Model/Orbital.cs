using System;

namespace Bluegrams.Periodica.Data 
{
    /// <summary>
    /// Represents an orbital in an element configuration.
    /// </summary>
    public class Orbital
    {
        /// <summary>
        /// The shell number.
        /// </summary>
        public byte Shell { get; private set; }
        /// <summary>
        /// The orbital type (s, p, d, f).
        /// </summary>
        /// <value></value>
        public char Type { get; private set; }
        /// <summary>
        /// The number of electrons.
        /// </summary>
        public byte Count { get; private set; }

        /// <summary>
        /// Creates a new orbital used for describing the element configuration.
        /// </summary>
        public Orbital(byte shell, char type, byte count)
        {
            Shell = shell;
            Type = type;
            Count = count;
        }

        public override string ToString()
        {
            return String.Format("{0}{1}{2}", Shell, Type, SuperscriptConversion.ToSuperscript(Count));
        }
    }
}