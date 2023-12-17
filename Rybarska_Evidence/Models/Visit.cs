using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.Models
{


    public class Visit
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int? SecondIdOfGround { get; set; }
        public int GroundId { get; set; }

        public DateTime? DateVisit { get; set; }

        public bool Cought { get; set; }

        public Catch? VisitCatchOne { get; set; }
        public Catch? VisitCatchTwo { get; set; }

    }
}
