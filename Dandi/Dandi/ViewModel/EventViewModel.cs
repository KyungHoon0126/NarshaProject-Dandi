using Dandi.Model;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNetwork;
using TNetwork.Data;

namespace Dandi.ViewModel
{
    public class EventViewModel : BindableBase
    {
        private ObservableCollection<Model.Event> _events;
        public ObservableCollection<Model.Event> Events
        {
            get => _events;
            set => SetProperty(ref _events, value);
        }


        public NetworkManager networkManager = new NetworkManager();


        public async Task SetEventList()
        {
            TResponse<EventResponse> resp;

#pragma warning disable IDE0059 // Unnecessary assignment of a value
            resp = await networkManager.GetResponse<EventResponse>("channel-event?channel_id=1", Method.GET, null);
#pragma warning restore IDE0059 // Unnecessary assignment of a value

            //if (resp != null && resp.Status == 200 && resp.Data != null)
            //{
            //    try
            //    {
            //        lock (_lock)
            //        {
            //            foreach (var item in resp.Data.Types)
            //            {
            //                TypeItems.Add((Model.Bus)item.Clone());
            //            }
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        Debug.WriteLine("Bus LoadDataAsync ERROR : " + e.Message);
            //    }
            //}
        }
    }
}
