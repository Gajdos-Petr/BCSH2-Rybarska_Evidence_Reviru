using Rybarska_Evidence.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.Models
{
    public class Carry : ObservableObject
    {

        private string? fishName;
        private int? lenght;
        private double? weight;
        public string? FishName
        {
            get
            {
                return fishName;
            }

            set
            {
                if (fishName != value)
                {
                    fishName = value;
                    OnPropertyChanged(nameof(fishName));
                }


            }


        }
        public int? Lenght
        {
            get
            {
                return lenght;
            }

            set
            {
                if (lenght != value)
                {
                    lenght = value;
                    OnPropertyChanged(nameof(lenght));
                }


            }
        }
        public double? Weight
        {
            get
            {
                return weight;
            }

            set
            {
                if (weight != value)
                {
                    weight = value;
                    OnPropertyChanged(nameof(weight));
                }


            }
        }

       
    }
}
