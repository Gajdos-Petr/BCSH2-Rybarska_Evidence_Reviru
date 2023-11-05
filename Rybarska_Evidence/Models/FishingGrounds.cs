using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.Models
{
    public enum GeoundsType
    {
        Pstruhovy,
        Mimopstruhovy
    }

    class FishingGrounds
    {
        public int Number { get; set; }
        public string? Name { get; set; }

        public int? PositionNumber { get; set; }
        public string? PositionName { get; set; }

        public GeoundsType GeoundsType { get; set; }

        public double Size { get; set; }

        public string? Description { get; set; }
    }
}
