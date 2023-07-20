using Contracts.Dto.Pharmacy;
using Contracts.Dto.Warehouse;
using Contracts.InputModels.DataEntryModels.Pharmacy;
using Contracts.InputModels.DataEntryModels.Warehouse;
using Contracts.Interface.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Warehouse
{
    public interface IWarehouseService : IGenericService<WarehouseDto, WarehouseInfo>, IGenericAttachmentService
    {
    }
}
