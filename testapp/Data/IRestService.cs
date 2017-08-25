using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace testapp
{
	public interface IRestService
	{
        Task<BaseUser> RefreshDataAsync();

        Task RegisterItemAsync(BaseUser item);

        Task LoginItemAsync(string email, string pw);
	}
}
