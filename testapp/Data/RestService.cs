using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace testapp.Data
{
    public class RestService : IRestService
    {
        public HttpClient client;

        public BaseUser Item { get; private set; }

        public RestService()
        {
            //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        async Task<BaseUser> IRestService.RefreshDataAsync()
        {
            Item = new BaseUser();

            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Item = JsonConvert.DeserializeObject<BaseUser>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"             ERROR {0}", ex.Message);
            }

            return Item;
        }

        public async Task RegisterItemAsync(BaseUser item)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            //var user = new BaseUser();
            try
            {
                var json = JsonConvert.SerializeObject(item);
                Debug.WriteLine(@"             json:" + json.ToString());
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                content.Headers.Add("app_token", Constants.token);
                Debug.WriteLine(@"             content:" + content.ToString());

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
					var data = await response.Content.ReadAsStringAsync();
					Item = JsonConvert.DeserializeObject<BaseUser>(data);
                    Debug.WriteLine(@"             Register successfully saved."+data.ToString());
                }else{
                    Debug.WriteLine(@""+response.RequestMessage.RequestUri.ToString());
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"             ERROR {0}", ex.Message);
            }
        }
    }
}
