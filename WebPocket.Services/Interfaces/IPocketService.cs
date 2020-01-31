using System.Collections.Generic;
using System.Threading.Tasks;
using WebPocket.Common.RequestResult;
using WebPocket.Data.ViewModels.PocketViewModels;

namespace WebPocket.Services.Interfaces
{
    public interface IPocketService
    {
        public Task<RequestResult<PocketViewModel>> CreateAsync(string name);
        public Task<RequestResult<PocketViewModel>> RenameAsync(int id, string name);
        public Task<RequestResult> DeleteAsync(int id);
        public Task<RequestResult<List<PocketViewModel>>> GetAllAsync();
    }
}
