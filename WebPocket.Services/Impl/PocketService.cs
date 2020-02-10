using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPocket.Common.RequestResult;
using WebPocket.Data.Entities.PocketEntities;
using WebPocket.Data.ViewModels.PocketViewModels;
using WebPocket.Repo.UnitOfWork;
using WebPocket.Services.Interfaces;
using WebPocket.Common.Logging;

namespace WebPocket.Services.Impl
{
    public class PocketService : IPocketService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger _logger;

        public PocketService(IUnitOfWork uow, ILoggerFactory loggerFactory)
        {
            _uow = uow;
            _logger = loggerFactory.CreateLogger(GetType());
        }

        public async Task<RequestResult<PocketViewModel>> CreateAsync(string name, string userId)
        {
            var result = new RequestResult<PocketViewModel>();

            try
            {
                var pocket = new Pocket()
                {
                    Name = name,
                    UserId = userId
                };

                pocket = _uow.Repository<Pocket>().Create(pocket);
                await _uow.SaveChangesAsync();

                result.Obj = new PocketViewModel().SetFrom(pocket);
                result.SetStatusOK();
            }
            catch (Exception ex)
            {
                result.SetInternalServerError();
                _logger.LogException(ex);
            }

            return result;
        }

        public async Task<RequestResult<PocketViewModel>> RenameAsync(int id, string name, string userId)
        {
            var result = new RequestResult<PocketViewModel>();

            try
            {
                var pocket = await _uow.Repository<Pocket>().GetAsync(id);

                if (pocket == null || pocket.UserId != userId)
                {
                    result.Errors = new[] { "Pocket not found." };
                    return result;
                }

                pocket.Name = name;
                pocket = _uow.Repository<Pocket>().Update(pocket);
                await _uow.SaveChangesAsync();

                result.Obj = new PocketViewModel().SetFrom(pocket);
                result.SetStatusOK();
            }
            catch (Exception ex)
            {
                result.SetInternalServerError();
                _logger.LogException(ex);
            }

            return result;
        }

        public async Task<RequestResult> DeleteAsync(int id, string userId)
        {
            var result = new RequestResult();

            try
            {
                var pocket = await _uow.Repository<Pocket>().GetAsync(id);

                if (pocket == null || pocket.UserId != userId)
                {
                    result.Errors = new[] { "Pocket not found." };
                    return result;
                }

                _uow.Repository<Pocket>().Delete(pocket);
                await _uow.SaveChangesAsync();

                result.SetStatusOK();
            }
            catch (Exception ex)
            {
                result.SetInternalServerError();
                _logger.LogException(ex);
            }

            return result;
        }

        public async Task<RequestResult<List<PocketViewModel>>> GetAllAsync(string userId)
        {
            var result = new RequestResult<List<PocketViewModel>>();

            try
            {
                List<PocketViewModel> pockets = await _uow.Repository<Pocket>().AsQueryable()
                    .Where(p => p.UserId == userId)
                    .Select(p => new PocketViewModel().SetFrom(p))
                    .ToListAsync();

                result.Obj = pockets;
                result.SetStatusOK();
            }
            catch (Exception ex)
            {
                result.SetInternalServerError();
                _logger.LogException(ex);
            }

            return result;
        }
    }
}
