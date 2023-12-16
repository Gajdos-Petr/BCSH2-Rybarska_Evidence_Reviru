﻿using Rybarska_Evidence.Core;
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

        public string LastName { get; set; }

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
