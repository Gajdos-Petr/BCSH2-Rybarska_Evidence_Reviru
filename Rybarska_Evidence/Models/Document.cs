﻿using Rybarska_Evidence.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

    public class Document : ObservableObject
    {

        private bool sticker;
        private DateTime license;
        private PermitType permit;

        public DateTime License {  
            get
            {
                return license;
            }
            
            set
            {
             if (license != value)
                {
                    license = value;
                    OnPropertyChanged(nameof(License));
                }

            }
        
        }
        public bool Sticker {
            get
            {
                return sticker;
            }
            
            set
            {
                if (sticker != value)
                {
                    sticker = value;
                    OnPropertyChanged(nameof (sticker));
                }
            }
                
        }
        public PermitType TypeOfPermit
        {
            get
            {
                return permit;
            }

            set
            {
                if (permit != value)
                {
                    permit = value;
                    OnPropertyChanged(nameof (permit));
                }
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
        public string StickerText
        {
            get { return Sticker ? "Zakoupena" : "Nezakoupena"; }
        }


        public string FormattedDateOfLicense
        {
            get { return License.ToString("dd.MM.yyyy"); }
        }


    }
}
