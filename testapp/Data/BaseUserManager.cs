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

		public Task RegisterTaskAsync(BaseUser item)
		{
            return restService.RegisterItemAsync(item);
		}
	}
}
