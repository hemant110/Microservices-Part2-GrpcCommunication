using Microsoft.Extensions.Configuration;
using OrderReceive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderReceive.Services
{
    public class QualityCheckService : IQualityCheckService
    {
        private readonly IConfiguration configuration;
        private readonly HttpClient httpClient;
        public QualityCheckService(HttpClient httpClient, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.httpClient = httpClient;
        }

        public async Task<bool> PostQualityCheckData(string orderCode, List<QualityCheck> qcList)
        {
            var dataAsString = JsonSerializer.Serialize(qcList);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PostAsync($"api/QualityCheck/{orderCode}", content);

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            return JsonSerializer.Deserialize<bool>("true", new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            //var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            //return JsonSerializer.Deserialize<bool>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        }
    }
}
