using Rybarska_Evidence.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.Model
{
    public enum MemberType
    {
        Clen,
        Vedeni

    }
    public class Member : ObservableObject
    {
        private int id;
        private DateTime birthDay;
        private string firstName;
        private string lastName;
        private string adress;
        private MemberType type;

        public int MemberId
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
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged(nameof(firstName));
                }
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged(nameof(lastName));
                }
            }
        }

        public string Adress
        {
            get
            {
                return adress;
            }
            set
            {
                if (adress != value)
                {
                    adress = value;
                    OnPropertyChanged(nameof(adress));
                }
            }
        }


        public DateTime DateOfBirth {
            get
            {
                return birthDay;
            }
            set
            {
                SetProperty(ref birthDay, value);
                OnPropertyChanged(nameof(birthDay));
            }

        }

        public MemberType MemberType
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

        public Document Document
        {
            get; set;
        }


    
        private void SetProperty(ref DateTime property, DateTime value, [CallerMemberName] string propertyName = null)
        {
            if (property != value)
            {
                property = value;
                OnPropertyChanged(propertyName);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Member member &&
                   id == member.id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MemberType);
        }

        public Member()
        {
        }

        public string FormattedDateOfBirth
        {
            get { return DateOfBirth.ToString("dd.MM.yyyy"); }
        }




    }
}
