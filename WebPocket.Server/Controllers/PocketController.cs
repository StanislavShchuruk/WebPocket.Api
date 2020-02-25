using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPocket.Services.RequestResults;
using WebPocket.Services.ViewModels.PocketViewModels;
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
        public async Task<RequestResult<IEnumerable<PocketViewModel>>> GetAllAsync()
        {
            return await _pocketService.GetAllAsync(UserId);
        }

        [HttpPost]
        public async Task<RequestResult> CreateAsync([FromBody] PocketViewModel pocket)
        {
            if (!ModelState.IsValid)
            {
                return GetModelStateErrorsRequestResult();
            }
            return await _pocketService.CreateAsync(pocket.Name, UserId);
        }

        [HttpPut]
        public async Task<RequestResult> RenameAsync([FromBody] PocketViewModel pocket)
        {
            if (!ModelState.IsValid)
            {
                return GetModelStateErrorsRequestResult();
            }
            return await _pocketService.RenameAsync(pocket.Id, pocket.Name, UserId);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<RequestResult> DeleteAsync(int id)
        {
            return await _pocketService.DeleteAsync(id, UserId);
        }
    }
}
