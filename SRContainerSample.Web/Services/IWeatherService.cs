using Microsoft.Extensions.Options;
using SRContainerSample.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SRContainerSample.Web.Services
{
    public interface IWeatherService
    {
        Task<List<ViewModels.PostalCodeItem>> GetMexicoLocationsByPostalCodeAsync(string postalCode);
    }

    public class AccuweatherService : IWeatherService
    {
        private readonly AccuweatherSettings _settings;
        private readonly HttpClient _client;

        public AccuweatherService(HttpClient client, IOptionsMonitor<AccuweatherSettings> optionsMonitor)
        {
            _settings = optionsMonitor.CurrentValue;
            _client = client;
            _client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip,deflate");
            _client.BaseAddress = new Uri(_settings.ApiUrl);
        }

        public async Task<List<ViewModels.PostalCodeItem>> GetMexicoLocationsByPostalCodeAsync(string postalCode)
        {
            var result = new List<ViewModels.PostalCodeItem>();
            var response = await _client.GetFromJsonAsync<IEnumerable<Models.Accuweather.PostalCodeSearchResultItem>>($"locations/v1/postalcodes/MX/search?apikey={_settings.ApiKey}&q={postalCode}");
            if (response.Any())
            {
                result = response.Select(item => new ViewModels.PostalCodeItem(item)).ToList();
            }
            return result;

        }
    }
}
