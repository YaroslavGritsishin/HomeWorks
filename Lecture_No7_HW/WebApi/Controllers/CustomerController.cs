using Application.DataTransferObject.ViewModels;
using Application.Errors;
using Application.UseCases.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly IAddCustomerUseCase addCustomerUseCase;
        private readonly IGetCustomerByIdUseCase getCustomerByIdUseCase;
        private readonly IRemoveCustomerUseCase removeCustomerUseCase;
        private readonly IUpdateCustomerUseCase updateCustomerUseCase;

        public CustomerController(IAddCustomerUseCase addCustomerUseCase, 
            IGetCustomerByIdUseCase getCustomerByIdUseCase,
            IRemoveCustomerUseCase removeCustomerUseCase,
            IUpdateCustomerUseCase updateCustomerUseCase,
            IGet)
        {
            this.addCustomerUseCase = addCustomerUseCase;
            this.getCustomerByIdUseCase = getCustomerByIdUseCase;
            this.removeCustomerUseCase = removeCustomerUseCase;
            this.updateCustomerUseCase = updateCustomerUseCase;
        }

        [HttpGet("{id}")]   
        public async Task<IActionResult> GetCustomerAsync([FromRoute] int id)
        {
            try
            {
                return Ok(await getCustomerByIdUseCase.EcxecuteAsync(id));
            }
            catch (CustomerNotFoundExeption ex) { return NotFound(ex.Message); }
            catch (Exception) { return Problem(statusCode: 500, detail: "���������� ������ �������!"); }
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            try
            {
                return Ok(await getCustomerByIdUseCase.EcxecuteAsync(id));
            }
            catch (CustomerNotFoundExeption ex) { return NotFound(ex.Message); }
            catch (Exception) { return Problem(statusCode: 500, detail: "���������� ������ �������!"); }
        }

        [HttpPost]   
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CustomerViewModel customer)
        {
            try
            {
                await addCustomerUseCase.EcxecuteAsync(customer);
                return Ok($"������������ : {customer.Firstname} {customer.Lastname} ������� ��������!");
            }
            catch (CustomerConflictException ex) { return Conflict(ex.Message); }
            catch (Exception) { return Problem(statusCode: 500, detail: "���������� ������ �������!"); }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync([FromRoute] int id)
        {
            try
            {
                await removeCustomerUseCase.EcxecuteAsync(id);
                return Ok($"������������ � ��������������� �{id} ������� ������!");
            }
            catch (CustomerNotFoundExeption ex) { return NotFound(ex.Message); }
            catch (Exception) { return Problem(statusCode: 500, detail: "���������� ������ �������!"); }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerAsync([FromRoute] int id, [FromBody] CustomerViewModel customer)
        {
            try
            {
                customer.Id = id;
                await updateCustomerUseCase.EcxecuteAsync(customer);
                return Ok($"������������ � ��������������� �{id} ������� �������!");
            }
            catch (CustomerNotFoundExeption ex) { return NotFound(ex.Message); }
            catch (Exception) { return Problem(statusCode: 500, detail: "���������� ������ �������!"); }
        }
    }
}