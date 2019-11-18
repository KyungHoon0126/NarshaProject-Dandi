using Dandi.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNetwork;
using TNetwork.Data;
using RestSharp;

namespace Dandi.Service
{
    public class ScheduleService
    {
        const string CHANNEL_URL = "channel";
        const string SCHOOL_SCHEDULE_URL = "school/search-school";

        NetworkManager networkManager = new NetworkManager();
        
        public async Task<TResponse<JoinedChannelResponse>> GetJoinedChannel()
        {
            return await networkManager.GetResponse<JoinedChannelResponse>(CHANNEL_URL, Method.GET);
        }

        public async Task<TResponse<SchoolEventsResponse>> GetSchoolScheduleItems()    
        {
            return await networkManager.GetResponse<SchoolEventsResponse>(SCHOOL_SCHEDULE_URL, Method.GET);
        }
    }
}
