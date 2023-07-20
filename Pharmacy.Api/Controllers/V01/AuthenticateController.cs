using Contracts.Dto.SystemNav.Users;
using Contracts.Entities.Security;
using Contracts.Interface.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service.Security;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace Pharmacy.Api.Controllers.V01
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("GSAPI")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService authenticateService;
    public AuthenticateController(IAuthenticateService authenticateService)
    {
        this.authenticateService = authenticateService;
    }
    [HttpPost]
    public async Task<IActionResult> Post(UserLoginModel model)
    {
        var result = await authenticateService.Login(model);
        return Ok(result);
    }

    [HttpPost("Refresh")]
    public async Task<IActionResult> Refresh(UserRefreshModel model)
    {
        var result = await authenticateService.Refresh(model);
        return Ok(result);
    }
    [Authorize]
    [HttpPost("LogOut")]
    public async Task<IActionResult> LogOut()
    {
        var userId = new Guid(User.Claims.FirstOrDefault().Value);
        authenticateService.Logout(userId);
        return Ok();
    }
}

}
