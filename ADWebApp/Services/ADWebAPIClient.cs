using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ADWebApp.Services
{
    public class ADWebAPIClient
    {
        //  HttpClient _httpClient = new HttpClient();
        private HttpClient _httpClient;
        private IConfiguration _configuration;
        public ADWebAPIClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44370/");
          

        }
        internal async Task<string> GetValuesAsync()
        {
            try
            {
                var result = await _httpClient.GetStringAsync("api/Values");
                return result;
            }
            catch (Exception ex)
            {

                throw ex ;
            }
           
        }
        internal async Task Initialize()
        {
            var authority = _configuration["AzureAd:Instance"] + _configuration["AzureAd:TenantId"];
            var authContext = new AuthenticationContext(authority);
            var Credencials = new ClientCredential(_configuration["AzureAd:ClientId"], "1UgNIHwKxa3pAAkFb7DC6umfkojs4bjdZBunz2bZ2UQ=");

            var authResult = await authContext.AcquireTokenAsync("https://myresturantdomain.onmicrosoft.com/ADWebAPI", Credencials);


            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer" , authResult.AccessToken);
        }
    }
}
