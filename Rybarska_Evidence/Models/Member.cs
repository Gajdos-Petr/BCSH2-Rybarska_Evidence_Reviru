using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.Model
{
    public enum MemberType
    {
        Regular,
        Chairman,
        Leader

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

        public MemberType MemberType { get; set; }

        public Document Document { get; set; }


        public string FormattedDateOfBirth
        {
            get { return DateOfBirth.ToString("dd.MM.yyyy"); }
        }

    }
}
