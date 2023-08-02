using Contracts;
using Contracts.Dto.Base;
using Contracts.Dto.Personnel;
using Contracts.Dto.Warehouse;
using Contracts.InputModels.DataEntryModels.Personnel;
using Contracts.InputModels.DataEntryModels.Pharmacy;
using Contracts.InputModels.DataEntryModels.Warehouse;
using Contracts.Interface.Personnel;
using Contracts.Interface.Shared;
using Contracts.Interface.Warehouse;
using Infrastructure.Resources;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Warehouse
{
    public class WarehouseService : GenericService<WarehouseDto, WarehouseInfo>, IWarehouseService, IBaseService
    {

        private readonly IGenericRepository<WarehouseDto, WarehouseInfo> repo;
        private readonly IGenericRepository<ParishDto, ParishDto> parish;
        public WarehouseService(IGenericRepository<WarehouseDto, WarehouseInfo> repository, IGenericRepository<ParishDto, ParishDto> _parish)
        : base(repository, SPNames.Pharmacy_Warehouse_GetAll, SPNames.Pharmacy_Warehouse_ByCase, SPNames.Pharmacy_Warehouse_GetInfo, SPNames.Pharmacy_Warehouse_CU)
        {
            this.repo = repository;
            parish = _parish;
        }
        #region Save
        public override async Task<GSActionResult<object>> Save(object warehouse)
        {
            var result = new GSActionResult<object>();
            try
            {
                var t = (WarehouseInfo)warehouse;
                result.Data = await repo.Insert(SPNames.Pharmacy_Warehouse_CU, new
                {
                    t.Id,
                    t.StartDate,
                    t.FirstName,
                    t.MedicineNumber,
                    t.PersonnelNumber,
                    t.Address,
                    t.Province,
                    t.Mobile,
                    t.Tel
                });

                result.IsSuccess = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message.Substring(0, (ex.Message.Length > 100) ? 100 : ex.Message.Length);
                result.Data = result.Message;
                result.IsSuccess = false;
                return result;

            }

        }

        #endregion
        #region Parish

        public async Task<GSActionResult<IEnumerable<AutocompleteDto>>> GetAllAutoComplete(string term, int cityId)
        {
            var result = new GSActionResult<IEnumerable<AutocompleteDto>>();
            var list = new List<AutocompleteDto>();
            IEnumerable<ParishDto>[] x = (await Task.WhenAll(parish.GetAllSingle(SPNames.Pharmacy_GetParishs, new { term, cityId })));

            foreach (ParishDto item in x[0])
            {
                list.Add(new AutocompleteDto { Id = item.Id, Label = item.ParishName });

            }
         (result.Data) = list;
            result.IsSuccess = true;
            return result;
        }

        #endregion
        #region attachments
        public string getAttachmentProcedure()
        {
            return "GetWarehouseAttachment";
        }

        public string removeAttachmentProcedure()
        {
            return "RemoveWarehouseAttachment";
        }

        public string setAttachmentProcedure()
        {
            return "SetWarehouseAttachment";
        }
        #endregion
    }
}
