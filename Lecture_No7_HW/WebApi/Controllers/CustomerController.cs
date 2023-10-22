using Application.DataTransferObject.ViewModels;
using Application.UseCases.Contracts;
using Microsoft.AspNetCore.Mvc;
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
            IUpdateCustomerUseCase updateCustomerUseCase)
        {
            this.addCustomerUseCase = addCustomerUseCase;
            this.getCustomerByIdUseCase = getCustomerByIdUseCase;
            this.removeCustomerUseCase = removeCustomerUseCase;
            this.updateCustomerUseCase = updateCustomerUseCase;
        }

        [HttpGet("{id}")]   
        public async Task<IActionResult> GetCustomerAsync([FromRoute] int id)
        {
            return Ok(await getCustomerByIdUseCase.EcxecuteAsync(id));
        }

        [HttpPost]   
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CustomerViewModel customer)
        {
            return Ok(await addCustomerUseCase.EcxecuteAsync(customer));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync([FromRoute] int id)
        {
            await removeCustomerUseCase.EcxecuteAsync(id);
            return Ok(new {message = $"Customer with id:{id} has been removed!"});
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerAsync([FromRoute] int id, [FromBody] CustomerViewModel customer)
        {
            customer.Id = id;
            await updateCustomerUseCase.EcxecuteAsync(customer);
            return Ok(new { message = $"Customer with id:{id} has been updated!" });
        }
    }
}