using Web.Models;

namespace Web.Services.IServices
{
    public interface IBaseService
    {

        ResponseDto _responseDto { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);

    }
}
