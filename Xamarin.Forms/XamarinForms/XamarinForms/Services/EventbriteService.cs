using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinForms.Eventbrite.Models;

namespace XamarinForms.Services
{
    public class EventbriteService
    {
        /// <summary>
        /// Get another token from:
        /// https://www.eventbrite.co.uk/myaccount/apps/new/
        /// </summary>
        private const string Token = "B2F4U57TXVC4F66GI2LK";

        /// <summary>
        /// Gets events from eventbrite API.
        /// Documentation: https://www.eventbrite.com/developer/v3/endpoints/events/
        /// </summary>
        /// <returns></returns>
        public async Task<EventbriteEvents> GetEventsAsync()
        {
            var url = "http://www.eventbriteapi.com/v3/events/search/?"
                        + "token=" + Token
                        + "&expand=venue&location.within=10km"
                        + "&location.address=london"
                        + "&sort_by=distance"
                        + "&categories=103";

            var httpClient = new HttpClient();
           
            try
            {
                var json = await httpClient.GetStringAsync(url);

                var eventbriteEvents = JsonConvert.DeserializeObject<EventbriteEvents>(json);

                return eventbriteEvents;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}
