using Dandi.Model;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNetwork;
using TNetwork.Data;

namespace Dandi.ViewModel
{
    public class EventViewModel : BindableBase
    {
        private ObservableCollection<Event> _eventItems = new ObservableCollection<Event>();
        public ObservableCollection<Event> EventItems
        {
            get => _eventItems;
            set => SetProperty(ref _eventItems, value);
        }


        public NetworkManager networkManager = new NetworkManager();


        public async Task SetEventList()
        {
            TResponse<EventResponse> resp;

#pragma warning disable IDE0059 // Unnecessary assignment of a value
            
            // channel 아이디를 직접 지정해주면 안된다. 생각해보기

            resp = await networkManager.GetResponse<EventResponse>("channel-event?channel_id=4", Method.GET, null);
#pragma warning restore IDE0059 // Unnecessary assignment of a value

            if (resp != null && resp.Status == 200 && resp.Data != null)
            {
                try
                {
                    foreach (var item in resp.Data.Events)
                    {
                        EventItems.Add((Event)item.Clone());
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Event LoadDataAsync ERROR : " + e.Message);
                }
            }
        }
    }
}
