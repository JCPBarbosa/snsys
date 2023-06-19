using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteSNSYS.Apis.Service;
using TesteSNSYS.Application.Interfaces;
using TesteSNSYS.Domain.Core.Models;
using TesteSNSYS.Domain.Core.Utils;

namespace TesteSNSYS.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserAppService _userAppService;

        public LoginController(ILogger<LoginController> logger, IUserAppService userAppService)
        {
            _logger = logger;
            _userAppService = userAppService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] LoginViewModel loginView)
        {
            try
            {
                var login = await _userAppService.GetUser(loginView.user, loginView.passWord);

                if (login == null)
                    return StatusCode(401, Responses.UnauthorizedErrorMessage());

                var token = TokenService.GenerateToken(login);

                return Ok(new ResultViewModel() { Data = new { user = loginView.user, token = token, userId = login.Id }, Message = "Success", Success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(new Random().Next(), ex, $"Método Post Data Erro {DateTime.Now}", DateTime.Now);
                return StatusCode(500, Responses.ApplicationErrorMessage("Ops! Algo de errado não está certo"));
            }
        }
    }
}
