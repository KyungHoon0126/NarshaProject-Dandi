using Dandi.Model;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TNetwork;

namespace Dandi.ViewModel
{
    public class channelViewModel : BindableBase
    {
        private ObservableCollection<channel> _channelItems = new ObservableCollection<channel>();
        public ObservableCollection<channel> ChannelItems
        {
            get => _channelItems;
            set => SetProperty(ref _channelItems, value);
        }
    }
}