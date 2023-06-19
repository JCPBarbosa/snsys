using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TesteSNSYS.Application.Interfaces;
using TesteSNSYS.Domain.Core.Models;
using TesteSNSYS.Domain.Core.Utils;
using TesteSNSYS.Domain.Entities;

namespace TesteSNSYS.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMapper _mapper;
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ILogger<CustomerController> logger, IMapper mapper, ICustomerAppService customerAppService)
        {
            _logger = logger;
            _mapper = mapper;
            _customerAppService = customerAppService;
        }

        [HttpGet]
        [Authorize(Roles = "guest,admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var customers = await _customerAppService.GetAll();

                if (customers.Count() == 0)
                    return NoContent();

                var customerList = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);

                return Ok(new ResultViewModel() { Data = customerList, Message = "Success", Success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(new Random().Next(), ex, $"Método Get Data Erro {DateTime.Now}", DateTime.Now);
                return StatusCode(500, Responses.ApplicationErrorMessage("Ops! Algo de errado não está certo"));
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "guest,admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var customer = await _customerAppService.GetById(id);

                if (customer == null)
                    return NoContent();

                var customerFound = _mapper.Map<Customer, CustomerViewModel>(customer);

                return Ok(new ResultViewModel() { Data = customerFound, Message = "Success", Success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(new Random().Next(), ex, $"Método Get {id} Data Erro {DateTime.Now}", DateTime.Now);
                return StatusCode(500, Responses.ApplicationErrorMessage("Ops! Algo de errado não está certo"));
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CustomerViewModel customerView)
        {

            try
            {
                var customer = _mapper.Map<CustomerViewModel, Customer>(customerView);
                customer.SetRegisterDate(DateTime.Now);
                
                await _customerAppService.Add(customer);

                var customerCreated = _mapper.Map<Customer, CustomerViewModel>(customer);

                return Created("", new ResultViewModel() { Data = customerCreated, Message = "Success", Success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(new Random().Next(), ex, $"Método Post Data Erro {DateTime.Now}", DateTime.Now);
                return StatusCode(500, Responses.ApplicationErrorMessage("Ops! Algo de errado não está certo"));
            }
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] CustomerViewModel customerView)
        {
            try
            {
                var updateCustomer = await _customerAppService.GetById(customerView.Id);

                if (updateCustomer == null)
                    return NoContent();

                updateCustomer.SetPhone(customerView.Phone);
                updateCustomer.SetEmail(customerView.Email);
                updateCustomer.SetName(updateCustomer.Name);
                updateCustomer.SetUserId(customerView.UserId);
                updateCustomer.SetUpdateDate(DateTime.Now);

                await _customerAppService.Update(updateCustomer);


                return Ok(new ResultViewModel() { Data = "", Message = "Success", Success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(new Random().Next(), ex, $"Método Put Data Erro {DateTime.Now}", DateTime.Now);
                return StatusCode(500, Responses.ApplicationErrorMessage("Ops! Algo de errado não está certo"));
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultViewModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(long id)
        {

            try
            {
                var customer = await _customerAppService.GetById(id);

                if (customer == null)
                    return NoContent();

                await _customerAppService.Remove(customer);
                

                return Ok(new ResultViewModel() { Data = "", Message = "Success", Success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(new Random().Next(), ex, $"Método Delete {id} Data Erro {DateTime.Now}", DateTime.Now);
                return StatusCode(500, Responses.ApplicationErrorMessage("Ops! Algo de errado não está certo"));
            }            
        }
    }
}
