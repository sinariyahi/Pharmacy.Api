using Contracts.InputModels.FilterModels.Base;
using Contracts.Interface.Shared;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Shared
{
    public abstract class GenericService<T, U> : IGenericService<T, U> where T : class where U : class
    {
        private readonly IGenericRepository<T, U> listRepo;
        protected readonly string spSearchAll;
        protected readonly string spSearchCase;
        protected readonly string spGetInfo;
        protected readonly string spSave;

        public GenericService(IGenericRepository<T, U> repository, string spSearchAll, string spSearchCase, string spGetInfo, string spSave)
        {
            this.listRepo = repository;
            this.spGetInfo = spGetInfo;
            this.spSave = spSave;
            this.spSearchCase = spSearchCase;
            this.spSearchAll = spSearchAll;
        }

        public async Task<GSActionResult<IEnumerable<T>>> GetAll(BaseFilter filters)
        {
            var result = new GSActionResult<IEnumerable<T>>();
            try
            {
                (result.Data, result.RowCount) = await listRepo.GetAll(spSearchAll, filters);
                result.Message = filters.ToString();
                result.IsSuccess = true;
                result.Page = filters.PageNumber;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message.Substring(1, 100);
                result.IsSuccess = false;
                return result;

            }
        }
        public async Task<GSActionResult<IEnumerable<T>>> GetAll(SimpleBaseFilter filters)
        {
            var result = new GSActionResult<IEnumerable<T>>();

            try
            {
                (result.Data, result.RowCount) = await listRepo.GetAll(spSearchAll, filters);
                result.Message = filters.ToString();
                result.IsSuccess = true;
                result.Page = filters.PageNumber;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message.Substring(1, 100);
                result.IsSuccess = false;
                return result;

            }
        }
        public async Task<GSActionResult<IEnumerable<T>>> GetAllByCase(CaseSearchFilter filters)
        {
            var result = new GSActionResult<IEnumerable<T>>();

            try
            {
                (result.Data, result.RowCount) = await listRepo.GetAll(spSearchCase, filters);
                result.Message = filters.ToString();
                result.IsSuccess = true;
                result.Page = filters.PageNumber;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message.Substring(1, 100);
                result.IsSuccess = false;
                return result;

            }


        }
        public async Task<GSActionResult<IEnumerable<T>>> GetAllByCaseWithUser(CaseSearchFilterWithUser filters)
        {
            var result = new GSActionResult<IEnumerable<T>>();

            try
            {
                (result.Data, result.RowCount) = await listRepo.GetAll(spSearchCase, filters);
                result.Message = filters.ToString();
                result.IsSuccess = true;
                result.Page = filters.PageNumber;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message.Substring(1, 100);
                result.IsSuccess = false;
                return result;

            }


        }
        public async Task<GSActionResult<U>> GetInfo(dynamic id)
        {
            var result = new GSActionResult<U>();

            try
            {
                result.Data = await listRepo.Get(spGetInfo, new { id });
                result.Message = id.ToString();
                result.IsSuccess = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message.Substring(1, 100);
                result.IsSuccess = false;
                return result;

            }
        }


        public virtual async Task<GSActionResult<object>> Save(object obj)
        {
            var result = new GSActionResult<object>();
            result.Data = await listRepo.Insert(spSave, obj);
            try
            {
                result.Data = await listRepo.Insert(spSave, obj);
                result.Message = obj.ToString();
                result.IsSuccess = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message.Substring(1, 100);
                result.IsSuccess = false;
                return result;

            }
        }
        public virtual async Task<GSActionResult<object>> SaveNew(object obj)
        {
            var result = new GSActionResult<object>();
            try
            {
                result.Data = await listRepo.Insert(spSave, obj);
                result.Message = obj.ToString();
                result.IsSuccess = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message.Substring(1, 100);
                result.IsSuccess = false;
                return result;

            }

        }

    }



}
