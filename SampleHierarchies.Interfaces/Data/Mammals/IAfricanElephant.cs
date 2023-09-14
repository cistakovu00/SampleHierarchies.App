using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals
{
    public interface IAfricanElephant : IMammal
    {
        float Height { get; set; }
        float Weight { get; set; }
        float TuskLength { get; set; }
        int LongLifeSpan { get; set; }
        string SocialBehavior { get; set; }
    }
}
