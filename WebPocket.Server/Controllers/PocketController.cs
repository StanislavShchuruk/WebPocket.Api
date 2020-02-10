using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPocket.Common.RequestResult;
using WebPocket.Data.ViewModels.PocketViewModels;
using WebPocket.Services.Interfaces;

namespace WebPocket.Web.Controllers
{
    public class PocketController : ApiBaseController
    {
        private readonly IPocketService _pocketService;

        public PocketController(IPocketService pocketService)
        {
            _pocketService = pocketService;
        }

        [HttpGet]
        public async Task<RequestResult<List<PocketViewModel>>> GetAllAsync()
        {
            return await _pocketService.GetAllAsync(UserId);
        }

        [HttpPost]
        public async Task<RequestResult<PocketViewModel>> CreateAsync(string name)
        {
            return await _pocketService.CreateAsync(name, UserId);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<RequestResult<PocketViewModel>> RenameAsync(int id, string name)
        {
            return await _pocketService.RenameAsync(id, name, UserId);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<RequestResult> DeleteAsync(int id)
        {
            return await _pocketService.DeleteAsync(id, UserId);
        }
    }
}
