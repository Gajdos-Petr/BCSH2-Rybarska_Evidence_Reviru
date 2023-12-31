using Rybarska_Evidence.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.Models
{
    public class GeoLocation : ObservableObject
    {
        private double latitude;
        private double longitude;

        public double Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                if (latitude != value)
                {
                    latitude = value;
                    OnPropertyChanged(nameof(latitude));
                }


            }


        }
        public double Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                if (longitude != value)
                {
                    longitude = value;
                    OnPropertyChanged(nameof(longitude));
                }


            }
        }

        public override string ToString()
        {
            return $"{Latitude.ToString("0.#####", System.Globalization.CultureInfo.InvariantCulture)},{Longitude.ToString("0.#####", System.Globalization.CultureInfo.InvariantCulture)}";
        }
    }
}
