using Dandi.Model;
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
    public class JoinedChannelViewModel : BindableBase
    {
        private ObservableCollection<JoinedChannel> _joinedChannelItems = new ObservableCollection<JoinedChannel>();

        public ObservableCollection<JoinedChannel> JoinedChannelItems
        {
            get => _joinedChannelItems;
            set
            {
                SetProperty(ref _joinedChannelItems, value);
            }
        }

        public NetworkManager networkManager = new NetworkManager();

        public async Task SetEventList()
        {
            TResponse<EventResponse> resp;

            // channel 아이디를 직접 지정해주면 안된다. 생각해보기

            foreach ()
            {
                resp = await networkManager.GetResponse<EventResponse>("channel-event?channel_id=2", Method.GET, null);
            }

            if (resp != null && resp.Status == 200 && resp.Data != null)
            {
                try
                {
                    foreach (var item in resp.Data.Events)
                    {
                        JoinedChannelItems.Add((JoinedChannel)item.Clone());
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