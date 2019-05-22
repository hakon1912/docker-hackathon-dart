using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Models;
using Newtonsoft.Json;

namespace Dartboard.Test.Client
{
    public class PersonServiceClient
    {
        private readonly HttpClient _httpClient;

        public PersonServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<Player>> GetPerson(string id)
        {
            var person = await GetAsync<Player>($"/person/get/{id}");
            return person;
        }

        public async Task<ApiResponse<List<Player>>> GetPersons()
        {
            var persons = await GetAsync<List<Player>>("/person/all");
            return persons;
        }

        public async Task<ApiResponse<string>> Version()
        {
            var version = await GetAsync<string>("api/version");
            return version;
        }

        private async Task<ApiResponse<T>> GetAsync<T>(string path)
        {
            var response = await _httpClient.GetAsync(path);
            var value = await response.Content.ReadAsStringAsync();
            var result = new ApiResponse<T>
            {
                StatusCode = response.StatusCode,
                ResultAsString = value
            };

            try
            {
                result.Result = JsonConvert.DeserializeObject<T>(value);
            }
            catch (Exception)
            {
                // Nothing to do
            }

            return result;
        }
    }
}