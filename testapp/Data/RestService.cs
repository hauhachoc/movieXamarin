using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using testapp.Models.Response;

namespace testapp.Data
{
    public class RestService : IRestService
    {
        public HttpClient client;

        public BaseUser Item { get; private set; }

        public BaseResponse Response { get; private set; }

        public RestService()
        {
            //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            //client.MaxResponseContentBufferSize = 256000;
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
            var uri = new Uri(string.Format(Constants.RestUrl+Constants.register_url, string.Empty));
            //var user = new BaseUser();
            try
            {
                var json = JsonConvert.SerializeObject(item);
                Debug.WriteLine(@"             json:" + json.ToString());
                //var content = new StringContent(json, Encoding.UTF8, "application/json");
                var content = new FormUrlEncodedContent(new[] {
                    new KeyValuePair<string, string>("full_name",item.full_name),
                    new KeyValuePair<string, string>("email", item.email),
                    new KeyValuePair<string, string>("password", item.password)
                });
                content.Headers.Add("app_token", Constants.token);

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
					var data = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(@"             data:" + data.ToString());
                    Response = JsonConvert.DeserializeObject<BaseResponse>(data);
                    if(Response.error){
                        Debug.WriteLine(@"             Failed:" + Response.message.email[0].ToString());
					}else{
                        Debug.WriteLine(@"             Success:" + Response.message);
                    }
                }else{
                    Debug.WriteLine(@""+response.RequestMessage.RequestUri.ToString());
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"             ERROR {0}", ex.Message);
            }
        }

		//public async Task RegisterItemAsync(BaseUser item)
		//{
		//	var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
  //          bool isJson = false;
		//	try
		//	{
		//		var json = JsonConvert.SerializeObject(item);
		//		Debug.WriteLine(@"             json:" + json.ToString());

		//		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
		//		if (isJson)
		//			request.ContentType = "application/json";
		//		else
		//			request.ContentType = "application/x-www-form-urlencoded";
		//		request.Method = "POST";
		//		request.Headers["app_token"] = Constants.token;
		//		var stream = await request.GetRequestStreamAsync();
		//		using (var writer = new StreamWriter(stream))
		//		{
		//			writer.Write(json);
		//			writer.Flush();
		//			writer.Dispose();
		//		}

		//		var response = await request.GetResponseAsync();
		//		var respStream = response.GetResponseStream();

		//		using (StreamReader sr = new StreamReader(respStream))
  //                  Debug.WriteLine(@"             result:"+sr.ReadToEnd());

		//	}
		//	catch (Exception ex)
		//	{
		//		Debug.WriteLine(@"             ERROR {0}", ex.Message);
		//	}
		//}

        public async Task LoginItemAsync(string mail, string pw)
        {
            var uri = new Uri(string.Format(Constants.RestUrl + Constants.login_url, string.Empty));
			try
            {
                var json = JsonConvert.SerializeObject(new { email = mail , password = pw});
				Debug.WriteLine(@"             json:" + json.ToString());
				var content = new FormUrlEncodedContent(new[] {new KeyValuePair<string, string>("email",mail),
					new KeyValuePair<string, string>("password", pw)});
                //content.Headers.Add("Accept", "application/json");
				content.Headers.Add("app_token", Constants.token);

				HttpResponseMessage response = null;

				response = await client.PostAsync(uri, content).ConfigureAwait(false);
                Debug.WriteLine(@"             content:" + response.ToString());

				if (response.IsSuccessStatusCode)
				{
					var data = await response.Content.ReadAsStringAsync();
					Debug.WriteLine(@"             data:" + data.ToString());
					Response = JsonConvert.DeserializeObject<BaseResponse>(data);
					if (Response.error)
					{
						Debug.WriteLine(@"             Failed:" + Response.message.email[0].ToString());
					}
					else
					{
						Debug.WriteLine(@"             Success:" + Response.message);
					}
				}
				else
				{
					Debug.WriteLine(@"" + response.RequestMessage.RequestUri.ToString());
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"             ERROR {0}", ex.Message);
			}
        }
    }
}
