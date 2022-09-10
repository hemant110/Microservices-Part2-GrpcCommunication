using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Warehouse_Backend.Grpc;

namespace OrderReceive.Services
{
    public class QualityCheckService //: IQualityCheckService
    {
        //private readonly IConfiguration configuration;
        //private readonly HttpClient httpClient;
        //public QualityCheckService(HttpClient httpClient, IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //    this.httpClient = httpClient;
        //}

        //public async Task<bool> PostQualityCheckData(string orderCode, List<QualityCheck> qcList)
        //{
        //    var dataAsString = JsonSerializer.Serialize(qcList);
        //    var content = new StringContent(dataAsString);
        //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    var response = await httpClient.PostAsync($"api/QualityCheck/{orderCode}", content);

        //    if (!response.IsSuccessStatusCode)
        //        throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

        //    return JsonSerializer.Deserialize<bool>("true", new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        //    //var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        //    //return JsonSerializer.Deserialize<bool>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        //}


        //==================================using GRPC ===========================================

        private readonly QCGrpc.QCGrpcClient qCGrpcClient;

        public QualityCheckService(QCGrpc.QCGrpcClient qCGrpcClient)
        {
            this.qCGrpcClient = qCGrpcClient;
        }

        public async Task<bool> PostQualityCheckData(string orderCode, List<QualityCheckForCreation> qcList)
        {
            try
            {
                QualityCheckRequest qualityCheckRequest = new QualityCheckRequest { Ordercode = orderCode };
                foreach (var qcItem in qcList)
                {
                    qualityCheckRequest.QualityCheck.Add(qcItem);
                }

                QualityCheckResponse qualityCheckResponse = await qCGrpcClient.CreateQCRecordsAsync(qualityCheckRequest);

                if (qualityCheckResponse.QualityCheck.Count > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
