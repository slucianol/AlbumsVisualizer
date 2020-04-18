using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Visualizer.Infrastructure.Exceptions;

namespace Visualizer.Infrastructure.Helpers {
    public class HttpRequestHelper {
        public static string GetJsonFromUri(string serviceUrl) {
            try {
                using (HttpClient httpClient = new HttpClient()) {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Core Application");
                    string responseMessage = httpClient.GetStringAsync(serviceUrl).GetAwaiter().GetResult();
                    if (string.IsNullOrEmpty(responseMessage)) {
                        throw new BadUrlException($"Url '{serviceUrl}' does not provide and 'HTTP 200 OK' response.");
                    }
                    return responseMessage;
                }
            } catch (HttpRequestException) {
                throw new ConnectionException($"An error occured while connecting to the service URL '{serviceUrl}'. Please check with the system administrator.");
            } catch (Exception) {
                throw;
            }
        }
    }
}
