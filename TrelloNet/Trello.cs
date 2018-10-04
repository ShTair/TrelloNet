﻿using Newtonsoft.Json;
using ShComp.TrelloNet.Models;
using System.Collections.Generic;
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

        private async Task<List<List>> GetListsAsync(string boardId)
        {
            var json = await GetAsync($"https://trello.com/1/boards/{boardId}/lists?key={_apiKey}&token={_token}&fields=name");
            return JsonConvert.DeserializeObject<List<List>>(json);
        }

        private async Task<List<Card>> GetCardsAsync(string listId)
        {
            var json = await GetAsync($"https://api.trello.com/1/lists/{listId}/cards?key={_apiKey}&token={_token}");
            return JsonConvert.DeserializeObject<List<Card>>(json);
        }

        private async Task MoveCardAsync(string cardId, string listId)
        {
            await PutAsync($"https://api.trello.com/1/cards/{cardId}/idList?key={_apiKey}&token={_token}&value={listId}", null);
        }

        #region Utils

        private async Task<string> GetAsync(string target)
        {
            using (var hc = new HttpClient())
            {
                return await hc.GetStringAsync(target);
            }
        }

        private async Task PutAsync(string target, HttpContent content)
        {
            using (var hc = new HttpClient())
            {
                var response = await hc.PutAsync(target, content);
            }
        }

        #endregion
    }
}
