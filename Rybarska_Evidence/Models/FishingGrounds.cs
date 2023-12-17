using Rybarska_Evidence.Core;
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

   public class FishingGrounds : ObservableObject
    {
        private int id;
        private int number;
        private string name;
        private int positionNumber;
        private string positionName;
        private GeoundsType type;
        private double size;
        private string desc;



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

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                if (number != value)
                {
                    number = value;
                    OnPropertyChanged(nameof(number));
                }


            }
        }
        public string? Name
        {
            get
            {
                return name;
            }

            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(name));
                }


            }
        }

        public int PositionNumber
        {
            get
            {
                return positionNumber;
            }

            set
            {
                if (positionNumber != value)
                {
                    positionNumber = value;
                    OnPropertyChanged(nameof(positionNumber));
                }


            }
        }

        public string? PositionName
        {
            get
            {
                return positionName;
            }

            set
            {
                if (positionName != value)
                {
                    positionName = value;
                    OnPropertyChanged(nameof(positionName));
                }


            }
        }

        public GeoundsType GeoundsType
        {
            get
            {
                return type;
            }

            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged(nameof(type));
                }


            }
        }

        public double Size
        {
            get
            {
                return size;
            }

            set
            {
                if (size != value)
                {
                    size = value;
                    OnPropertyChanged(nameof(size));
                }


            }
        }

        public string? Description
        {
            get
            {
                return desc;
            }

            set
            {
                if (desc != value)
                {
                    desc = value;
                    OnPropertyChanged(nameof(desc));
                }


            }
        }

        public override string? ToString()
        {
            return Id.ToString() + Name;
        }
    }
}
