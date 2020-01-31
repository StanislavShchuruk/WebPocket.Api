using System.Collections.Generic;
using System.Threading.Tasks;
using WebPocket.Common.RequestResult;
using WebPocket.Data.ViewModels.PocketViewModels;
using WebPocket.Services.Interfaces;

namespace WebPocket.Services.Impl
{
    public class PocketService : IPocketService
    {
        public async Task<RequestResult<PocketViewModel>> CreateAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<RequestResult<PocketViewModel>> RenameAsync(int id, string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<RequestResult> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<RequestResult<List<PocketViewModel>>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
