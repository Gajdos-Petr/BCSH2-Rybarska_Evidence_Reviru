using Rybarska_Evidence.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.Models
{
    public class Catch : ObservableObject
    {
        private int id;
        private int memberId;

        private DateTime visit;
        private int groundNumber;

        public Carry? FishOne { get; set; }
        public Carry? FishTwo { get; set; }
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(id));
                }


            }
        }
        public int MemberId
        {
            get
            {
                return memberId;
            }

            set
            {
                if (memberId != value)
                {
                    memberId = value;
                    OnPropertyChanged(nameof(memberId));
                }


            }
        }
        public DateTime Visit
        {
            get
            {
                return visit;
            }

            set
            {
                if (visit != value)
                {
                    visit = value;
                    OnPropertyChanged(nameof(visit));
                }


            }
        }
        public int GroundNumber
        {
            get
            {
                return groundNumber;
            }

            set
            {
                if (groundNumber != value)
                {
                    groundNumber = value;
                    OnPropertyChanged(nameof(groundNumber));
                }


            }
        }


    }
}
