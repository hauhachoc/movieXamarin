using System.Collections.Generic;
using System.Threading.Tasks;
using testapp.Models.Response;

namespace testapp
{
	public interface IRestService
	{
        Task<FilmsResponse> GetFilmsItemAsync(string page, string per_page);

        Task<BaseResponse> RegisterItemAsync(BaseUser item);

        Task<BaseResponse> LoginItemAsync(string email, string pw);
    }
}
