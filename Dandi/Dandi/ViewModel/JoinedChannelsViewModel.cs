using Dandi.Model;
using Dandi.Service.Response;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TNetwork;
using TNetwork.Data;

namespace Dandi.ViewModel
{
    public class JoinedChannelsViewModel : BindableBase
    {
        private List<JoinedChannel> _joinedChannelItems = new List<JoinedChannel>();

        public List<JoinedChannel> JoinedChannelItems
        {
            get => _joinedChannelItems;
            set
            {
                SetProperty(ref _joinedChannelItems, value);
            }
        }


        private ObservableCollection<ChannelEvents> _channelEventItems = new ObservableCollection<ChannelEvents>();
        public ObservableCollection<ChannelEvents> ChannelEventItems
        {
            get => _channelEventItems;
            set => SetProperty(ref _channelEventItems, value);
        }


        public NetworkManager networkManager = new NetworkManager();

        public async Task SetJoinedChannelList()
        {
            TResponse<JoinedChannelResponse> resp;

            resp = await networkManager.GetResponse<JoinedChannelResponse>("channel", Method.GET, null);

            if (resp != null && resp.Status == 200 && resp.Data != null)
            {
                try
                {
                    foreach (var item in resp.Data.JoinedChannel)
                    {
                        JoinedChannelItems.Add((JoinedChannel)item.Clone());
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("JoinedChannelsEvent LoadDataAsync ERROR : " + e.Message);
                }
            }

            for(int i = 0; i < JoinedChannelItems.Count; i++)
            {
                // Line 62 : breakpoint
                var res = await networkManager.GetResponse<ChannelEventsResponse>("channel-event?channel_id=" + JoinedChannelItems[i].Id, Method.GET, null);
                // ChannelEventItems.Add((ChannelEvent)_channelEventItems.Clone());
            }

            //JoinedChannelItems.ForEach(async x =>
            //{
            //    await networkManager.GetResponse<JoinedChannelResponse>("channel-event?" + x.Id, Method.GET, null);
            //});
        }
    }
}