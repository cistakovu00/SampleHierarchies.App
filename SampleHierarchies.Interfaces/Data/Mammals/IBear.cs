using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals
{
    public interface IBear: IMammal
    {
        string KindOf { get; set; }
        int PawSize { get; set; }
        string GoodSenseOfSmeel { get; set; }
        string SharpnessOfTheClaws { get; set; }
    }
}
