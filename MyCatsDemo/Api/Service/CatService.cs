using System;
using System.Net.Http;
using System.Threading.Tasks;
using MyCatsDemo.Api.Contract;
using Newtonsoft.Json;

namespace MyCatsDemo.Api.Service
{
    public class CatService : ICatService
    {
        public const string KEY = "cats";

        private readonly IHttpClientProvider _httpClientProvider;

        public CatService(IHttpClientProvider httpClientProvider)
        {
            _httpClientProvider = httpClientProvider;
        }

        private HttpClient GetHttpClient()
        {
            return _httpClientProvider.GetHttpClient(KEY);
        }

        public async Task<CatBreedDto[]> GetCatBreeds()
        {
            var response = await GetHttpClient().GetAsync("/v1/breeds").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<CatBreedDto[]>(result);
        }

        public async Task<CatBreedDetailDto> GetCatBreedById(string id)
        {
            var response = await GetHttpClient().GetAsync($"/v1/images/search?breed_ids={id}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<CatBreedDetailDto[]>(result)?[0];
        }
    }
}
