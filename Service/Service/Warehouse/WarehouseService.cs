using Contracts.Dto.Personnel;
using Contracts.Dto.Warehouse;
using Contracts.InputModels.DataEntryModels.Personnel;
using Contracts.InputModels.DataEntryModels.Warehouse;
using Contracts.Interface.Personnel;
using Contracts.Interface.Shared;
using Contracts.Interface.Warehouse;
using Infrastructure.Resources;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Warehouse
{
    public class WarehouseService : GenericService<WarehouseDto, WarehouseInfo>, IWarehouseService, IBaseService
    {

        private readonly IGenericRepository<WarehouseDto, WarehouseInfo> repo;
        public WarehouseService(IGenericRepository<WarehouseDto, WarehouseInfo> repository)
        : base(repository, SPNames.Pharmacy_Warehouse_GetAll, SPNames.Pharmacy_Warehouse_ByCase, SPNames.Pharmacy_Warehouse_GetInfo, SPNames.Pharmacy_Warehouse_CU)
        {
            this.repo = repository;
        }
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
