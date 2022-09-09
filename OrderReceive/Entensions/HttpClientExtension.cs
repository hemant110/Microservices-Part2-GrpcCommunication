using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderReceive.Entensions
{
    public static class HttpClientExtension
    {
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage reaponse)
        {
            if (!reaponse.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong when calling the API : {reaponse.ReasonPhrase}");

            var dataAsString = await reaponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
