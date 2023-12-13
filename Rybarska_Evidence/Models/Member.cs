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

        private DateTime birthDay;

        public int MemberId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth {
            get
            {
                return birthDay;
            }
            set
            {
                SetProperty(ref birthDay, value);
                OnPropertyChanged(nameof(FormattedDateOfBirth));
            }
        
        }

        private void SetProperty(ref DateTime property, DateTime value, [CallerMemberName] string propertyName = null)
        {
            if (property != value)
            {
                property = value;
                OnPropertyChanged(propertyName);
            }
        }

        public MemberType MemberType { get; set; }

        public Document Document { get; set; }


        public string FormattedDateOfBirth
        {
            get { return DateOfBirth.ToString("dd.MM.yyyy"); }
        }

    }
}
