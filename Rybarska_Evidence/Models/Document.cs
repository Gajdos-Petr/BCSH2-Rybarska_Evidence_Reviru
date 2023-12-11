using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.Model
{
    public enum PermitType
    {
        Zadna,
        Mistni,
        Celosvazova,
        Krajska
    }

    public class Document
    {
        public DateTime License {  get; set; }
        public bool Sticker { get; set; }
        public PermitType TypeOfPermit { get; set; }







        
    }
}
