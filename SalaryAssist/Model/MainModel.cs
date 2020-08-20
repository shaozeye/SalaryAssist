using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryAssist.Model
{
    public class MainModel:ObservableObject
    {
        private List<string> fullNameList;
        public List<string> FullNameList
        {
            get { return fullNameList; }
            set
            {
                fullNameList = value;
                RaisePropertyChanged(nameof(FullNameList));
            }
        }
    }
}
