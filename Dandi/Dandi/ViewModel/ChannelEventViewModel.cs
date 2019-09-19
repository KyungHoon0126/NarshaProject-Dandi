using Dandi.Model;
using Dandi.Service.Response;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TNetwork;
using TNetwork.Data;

namespace Dandi.ViewModel
{
    public class ChannelEventViewModel : BindableBase
    {
        private ObservableCollection<ChannelEvent> _eventItems = new ObservableCollection<ChannelEvent>();

        public ObservableCollection<ChannelEvent> EventItems
        {
            get => _eventItems;
            set => SetProperty(ref _eventItems, value);
        }

        //public NetworkManager networkManager = new NetworkManager();

        //public async Task SetChannelEventList()
        //{
        //    TResponse<ChannelEventResponse> resp;

        //    resp = await networkManager.GetResponse<ChannelEventResponse>("channel-event?channel_id=2", Method.GET, null);

        //    if (resp != null && resp.Status == 200 && resp.Data != null)
        //    {
        //        try
        //        {
        //            foreach (var item in resp.Data.Events)
        //            {
        //                EventItems.Add((ChannelEvent)item.Clone());
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.WriteLine("ChannelEvent LoadDataAsync ERROR : " + e.Message);
        //        }
        //    }
        //}
    }
}