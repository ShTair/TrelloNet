using System.Net.Http;
using System.Threading.Tasks;

namespace ShComp.TrelloNet
{
    public class Trello
    {
        private readonly string _apiKey;
        private readonly string _accessToken;

        public Trello(string apiKey, string accessToken)
        {
            _apiKey = apiKey;
            _accessToken = accessToken;
        }

        #region Utils

        private static async Task<string> GetAsync(string target)
        {
            using (var hc = new HttpClient())
            {
                return await hc.GetStringAsync(target);
            }
        }

        private static async Task PutAsync(string target, HttpContent content)
        {
            using (var hc = new HttpClient())
            {
                var response = await hc.PutAsync(target, content);
            }
        }

        #endregion
    }
}
