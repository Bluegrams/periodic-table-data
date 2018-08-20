# Periodica.Data

[![NuGet](https://img.shields.io/nuget/v/Periodica.Data.svg)](https://www.nuget.org/packages/Periodica.Data/)

This repository contains data of all chemical elements in the periodic table, wrapped for .NET.
It is originally created for usage in the [Periodica](https://www.microsoft.com/store/apps/9PB2TD7P6DT3) Windows 10 app and the [ElemenTable](https://elementable.sourceforge.io) Windows Desktop app.

## Usage

```csharp
using Bluegrams.Periodica.Data;
// ...
// Load the element data
var table = PeriodicTable.Load();
// Access elements by symbol or atomic number.
Element helium = table["He"];
Element uranium = table[92];
// Access some data for an element
int atomicNumber = helium.AtomicNumber;
int[] shellConfig = helium.ShellConfiguration;
bool radioactive = uranium.Radioactive;
// Output all available data
Debug.WriteLine(uranium.ToString());
```

## The Data
The data of the elements is stored in CSV format in the file [Periodica.Data/Data/ElementData.csv](Periodica.Data/Data/ElementData.csv). Additionally, the names of the elements are translated to several languages. Currently these are:
- English (default)
- German
- Spanish
- French

All data is parsed using the [CsvHelper](https://github.com/JoshClose/CsvHelper) library.

#### Example data

```
> Symbol: O
> EnglishName: Oxygen
> LocalizedName: Sauerstoff
> AtomicNumber: 8
> Group: 16
> Period: 2
> Block: p
> Category: Nonmetal
> AtomicMass: 15.999
> Configuration: [He] 2s² 2p4
> ShellConfiguration: 2,6
> StandardState: Gas
> Density: 0.001429 g/cm³
> MeltingPoint: 54.36 K
> BoilingPoint: 90.2 K
> HeatCapacity: 0.918 J/(g*K)
> HeatOfFusion: 0.444 kJ/mol
> HeatOfVaporization: 6.82 kJ/mol
> MolarVolume: 11195.94 cm³
> ThermalConductivity: 0.02658 W/(m*K)
> AtomicRadius: 48 pm
> CovalentRadius: 73 pm
> VanDerWaalsRadius: 152 pm
> Electronegativity: 3.44
> OxidationStates: -2
> IonizationEnergy: 1313.9 kJ/mol
> ElectronAffinity: 140.976 kJ/mol
> AbundanceCrust: 461000 mg/kg
> AbundanceUniverse: 1 %
> Discovery: 1771
> DiscoveredBy: W. Scheele
> Radioactive: False
```

## Contribute

This dataset is not complete and probably also not 100% correct. If you find additional or more correct information, please open an issue or contribute it directly to the data file.

## License

See [LICENSE](LICENSE).

## Sources

- WebElements, https://www.webelements.com/
- http://www.rsc.org/periodic-table
- English Wikipedia (e.g. https://en.wikipedia.org/wiki/List_of_chemical_elements)
