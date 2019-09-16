using Dandi.Model;
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
    public class EventViewModel 
    {
        private ObservableCollection<Model.Event> _events;

        public NetworkManager networkManager = new NetworkManager();


        public async Task SetBusTypeList()
        {
            TResponse<EventResponse> resp;

            resp = await networkManager.GetResponse<EventResponse>("channel-event?channel_id=4", Method.GET, null);

            //if (resp != null && resp.Status == 200 && resp.Data != null)
            //{
            //    try
            //    {
            //        foreach (var item in resp.Data.Types)
            //        {
            //            TypeItems.Add((Model.Bus)item.Clone());
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
