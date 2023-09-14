using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals
{
    public interface IOrangutan: IMammal
    {
        int Intelligence { get; set; }
        double ClimbingSpeed { get; set; }
        string Diet { get; set; }
        string SocialBehavior { get; set; } 
    }
}
