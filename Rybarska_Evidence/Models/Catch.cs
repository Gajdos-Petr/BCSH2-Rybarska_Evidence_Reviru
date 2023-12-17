using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.Models
{
 public class Catch
    {
   
            public int CatchId { get; set; }
            public int MemberId { get; set; }
            public string? FishName { get; set; }
            public int? Lenght { get; set; }
            public double? Weight { get; set; }
    }
}
