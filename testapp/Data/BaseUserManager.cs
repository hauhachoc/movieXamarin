using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace testapp.Data
{
    public class BaseUserManager
      {
        IRestService restService;

		public BaseUserManager(IRestService service)
		{
			restService = service;
		}

            public Task<BaseUser> GetTasksAsync()
		{
			return restService.RefreshDataAsync();
		}

		public Task LoginTaskAsync(string  email, string pw)
		{
            return restService.LoginItemAsync( email, pw);
		}

		public Task RegisterTaskAsync(BaseUser item)
		{
            return restService.RegisterItemAsync(item);
		}
	}
}
