using Web.Models;

namespace Web.Services.IServices
{
    public interface IBaseService 
    {

        ResponseDto responseDto { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);

    }
}
