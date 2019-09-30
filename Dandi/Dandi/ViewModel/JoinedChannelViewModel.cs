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
    public class JoinedChannelViewModel : BindableBase
    {
        // 사용자가 가입한 모든 채널 조회
        private List<JoinedChannel> _joinedChannelItems = new List<JoinedChannel>();
        public List<JoinedChannel> JoinedChannelItems
        {
            get => _joinedChannelItems;
            set => SetProperty(ref _joinedChannelItems, value);
        }

        // 채널 조회 후, 사용자가 가입한 모든 채널들의 일정을 넣는 곳
        private ObservableCollection<ChannelSchedule> _allChannelItems = new ObservableCollection<ChannelSchedule>();
        public ObservableCollection<ChannelSchedule> AllChannelItems
        {
            get => _allChannelItems;
            set => SetProperty(ref _allChannelItems, value);
        }

        // AllChannelItems Index 
        //private List<ChannelSchedule> _finalContents = new List<ChannelSchedule>();
        //public List<ChannelSchedule> FinalContents
        //{
        //    get => _finalContents;
        //    set => SetProperty(ref _finalContents, value);
        //}


        // 모든 채널 조회
        public NetworkManager networkManager = new NetworkManager();

        public async Task SetJoinedChannelList()
        {
            TResponse<JoinedChannelResponse> resp = new TResponse<JoinedChannelResponse>();
            //var 
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

            // 사용자가 가입한 채널의 모든 일정 조회 후 Add
            for(int i = 0; i < JoinedChannelItems.Count; i++)
            { // breakpoint
                var res = await networkManager.GetResponse<eventes>("channel-event?channel_id=" + JoinedChannelItems[i].Id, Method.GET, null);

                ChannelSchedule channelSchedule = new ChannelSchedule();

                foreach (var item in res.Data.events)
                {
                    channelSchedule.Content = item.Content;
                    channelSchedule.End_Date = item.End_Date;
                    channelSchedule.Id = item.Id;
                    channelSchedule.Start_Date = item.Start_Date;
                    channelSchedule.Title = item.Title;
                    channelSchedule.Author.UserId = item.Author.UserId;
                    channelSchedule.Author.UserName = item.Author.UserName;

                    // channelSchedule.Clone();
                    // AllChannelItems.Add(channelSchedule);

                    AllChannelItems.Add((ChannelSchedule)channelSchedule.Clone());
                }

                //for (i = AllChannelItems.Count - 5; i < AllChannelItems.Count; i++)
                //{
                //    FinalContents.Add(channelSchedule);
                //}

            } // breakpoint

            //JoinedChannelItems.ForEach(async x =>
            //{
            //    await networkManager.GetResponse<JoinedChannelResponse>("channel-event?" + x.Id, Method.GET, null);
            //});
        }

        //private List<ChannelSchedule> _finalContents = new List<ChannelSchedule>();
        //public List<ChannelSchedule> FinalContents
        //{
        //    get => _finalContents;
        //    set => SetProperty(ref _finalContents, value);
        //}
    }
}