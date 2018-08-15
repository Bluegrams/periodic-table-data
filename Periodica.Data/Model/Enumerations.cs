namespace Bluegrams.Periodica.Data
{
    /// <summary>
    /// Defines the possible states of matter of an element.
    /// </summary>
    public enum StateOfMatter
    {
        Gas = 0,
        Liquid = 1,
        Solid = 2
    }

    /// <summary>
    /// Specifies the element categories on the peridic table.
    /// </summary>
    public enum ElementCategory 
    {
        Nonmetal = 0,
        AlkaliMetal = 1,
        AlkalineEarthMetal = 2,
        TransitionMetal = 3,
        PostTransitionMetal = 4,
        Metalloid = 5,
        Halogen = 6,
        NobleGas = 7,
        Lanthanoid = 8,
        Actinoid = 9
    }
}