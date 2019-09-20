using Dandi.Model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dandi.ViewModel
{
    public class SchoolEventsViewModel : BindableBase
    {
        private ObservableCollection<SchoolEvents> _schoolEventsItems = new ObservableCollection<SchoolEvents>();

        public ObservableCollection<SchoolEvents> SchoolEventsItems
        {
            get => _schoolEventsItems;
            set
            {
                SetProperty(ref _schoolEventsItems, value);
            }
        }
    }
}
