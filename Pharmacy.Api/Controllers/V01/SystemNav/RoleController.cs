using Contracts.InputModels.DataEntryModels.SystemNav.Role;
using Contracts.InputModels.FilterModels.Base;
using Contracts.InputModels.FilterModels.SystemNav;
using Contracts.Interface.SystemNav;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;

namespace Pharmacy.Api.Controllers.V01.SystemNav
{
 
    public class RoleController : BaseController
    {
        private readonly IRoleService service;
        public RoleController(IRoleService service)
        {
            this.service = service;
        }

        /// <summary>
        /// "نمایش لیست کاربران
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<IActionResult> Get([FromQuery] string filterModel, bool searchAll = true)
        {
            return Ok((searchAll)
           ? await service.GetAll(JsonConvert.DeserializeObject<UserListFilterModel>(filterModel))
           : await service.GetAllByCase(JsonConvert.DeserializeObject<CaseSearchFilter>(filterModel)));
        }

        /// <summary>
        /// نمایش  کابر
        /// </summary>
        [HttpGet("showInfo")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await service.GetInfo(id);
            return Ok(result);
        }
        /// <summary>
        /// user roles
        /// </summary>
        [HttpGet("userRoles")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var result = await service.GetAllByUserId(userId);
            return Ok(result);
        }
        /// <summary>
        /// ایجاد کاربر
        /// </summary>
        [HttpPost("ce")]
        public async Task<IActionResult> Post(RoleInfo personel)
        {
            personel.CreateBy = getCurrentUserId();
            var result = await service.Save(personel);
            return Ok(result);
        }
    }
}