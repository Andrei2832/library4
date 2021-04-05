using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class MainViewModel : ViewModelBase
    {
        public static string LoginCust;
        public ObservableCollection<Lecture1> pers { get; set; }

            public MainViewModel()
            {
                pers = new ObservableCollection<Lecture1>(DataBase.GetLectures());
            }

        
    }
}
