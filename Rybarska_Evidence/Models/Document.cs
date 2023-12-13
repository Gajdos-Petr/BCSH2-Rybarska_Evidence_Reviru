using Rybarska_Evidence.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        
        public DateTime License {  
            get
            {
                return license;
            }
            
            set
            {
                //SetProperty(ref license, value);
                OnPropertyChanged(nameof(FormattedDateOfLicense));

            }
        
        }
        public bool Sticker {
            get
            {
                return sticker;
            }
            
            set
            {
                //SetProperty(ref sticker, value);
                OnPropertyChanged(nameof(StickerText));
            }
                
                }
        public PermitType TypeOfPermit { get; set; }



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
