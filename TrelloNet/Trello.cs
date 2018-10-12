using Newtonsoft.Json;
using ShComp.TrelloNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShComp.TrelloNet
{
    public class Trello
    {
        private readonly string _apiKey;
        private readonly string _token;

        public Trello(string apiKey, string token)
        {
            _apiKey = apiKey;
            _token = token;
        }

        public async Task<List<Board>> GetBoardsAsync(string userId)
        {
            var json = await GetAsync($"https://trello.com/1/members/{userId}/boards?key={_apiKey}&token={_token}&fields=name");
            return JsonConvert.DeserializeObject<List<Board>>(json);
        }

        public async Task<List<CustomField>> GetCustomFieldsAsync(string boardId)
        {
            var json = await GetAsync($"https://trello.com/1/boards/{boardId}/customFields?key={_apiKey}&token={_token}");
            return JsonConvert.DeserializeObject<List<CustomField>>(json);
        }

        public async Task<List<List>> GetListsAsync(string boardId)
        {
            var json = await GetAsync($"https://trello.com/1/boards/{boardId}/lists?key={_apiKey}&token={_token}&fields=name");
            return JsonConvert.DeserializeObject<List<List>>(json);
        }

        public async Task<List<Card>> GetCardsAsync(string listId)
        {
            var json = await GetAsync($"https://api.trello.com/1/lists/{listId}/cards?key={_apiKey}&token={_token}&customFieldItems=true");
            return JsonConvert.DeserializeObject<List<Card>>(json);
        }

        public async Task MoveCardAsync(string cardId, string listId, string pos = "bottom")
        {
            await PutAsync($"https://api.trello.com/1/cards/{cardId}?key={_apiKey}&token={_token}&idList={listId}&pos={pos}", null);
        }

        public async Task CloseCardAsync(string cardId)
        {
            await PutAsync($"https://api.trello.com/1/cards/{cardId}/closed?key={_apiKey}&token={_token}&value=true", null);
        }

        public async Task AssignMemberAsync(string cardId, string memberId)
        {
            await PutAsync($"https://api.trello.com/1/cards/{cardId}/idMembers?key={_apiKey}&token={_token}&value={memberId}", null);
        }

        public async Task LabelAsync(string cardId, string labelId)
        {
            await PutAsync($"https://api.trello.com/1/cards/{cardId}/idlabels?key={_apiKey}&token={_token}&value={labelId}", null);
        }

        public async Task SetDueAsync(string cardId, DateTimeOffset due)
        {
            await PutAsync($"https://api.trello.com/1/cards/{cardId}/due?key={_apiKey}&token={_token}&value={due.ToUniversalTime():yyyy-MM-ddTHH:mm:ssZ}", null);
        }

        public async Task CreateCardAsync(string listId, Dictionary<string, object> parameters)
        {
            var sc = new StringContent(JsonConvert.SerializeObject(new { name = "テスト", idList = listId }));
            //parameters["idList"] = listId;
            await PostAsync("https://api.trello.com/1/cards", parameters, sc);
        }

        public async Task PutAsync(string target, Dictionary<string, object> parameters, HttpContent content)
        {
            parameters["key"] = _apiKey;
            parameters["token"] = _token;
            var ps = string.Join("&", parameters.Select(t => t.Key + "=" + Uri.EscapeDataString(t.Value.ToString())));
            var response = await PutAsync(target + "?" + ps, content);
        }

        public async Task PostAsync(string target, Dictionary<string, object> parameters, HttpContent content)
        {
            parameters["key"] = _apiKey;
            parameters["token"] = _token;
            var ps = string.Join("&", parameters.Select(t => t.Key + "=" + Uri.EscapeDataString(t.Value.ToString())));
            var response = await PostAsync(target + "?" + ps, content);
        }

        #region Utils

        private async Task<string> GetAsync(string target)
        {
            using (var hc = new HttpClient())
            {
                return await hc.GetStringAsync(target);
            }
        }

        private async Task<HttpResponseMessage> PutAsync(string target, HttpContent content)
        {
            using (var hc = new HttpClient())
            {
                return await hc.PutAsync(target, content);
            }
        }

        private async Task<HttpResponseMessage> PostAsync(string target, HttpContent content)
        {
            using (var hc = new HttpClient())
            {
                return await hc.PostAsync(target, content);
            }
        }

        #endregion
    }
}
