using System.Collections.Generic;
using System.Threading.Tasks;
using WebPocket.Services.RequestResults;
using WebPocket.Services.ViewModels.PocketViewModels;

namespace WebPocket.Services.Interfaces
{
    public interface IPocketService
    {
        public Task<RequestResult<PocketViewModel>> CreateAsync(string name, string userId);
        public Task<RequestResult<PocketViewModel>> RenameAsync(int id, string name, string userId);
        public Task<RequestResult> DeleteAsync(int id, string userId);
        public Task<RequestResult<IEnumerable<PocketViewModel>>> GetAllAsync(string userId);
    }
}
