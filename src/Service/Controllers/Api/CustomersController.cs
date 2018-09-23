using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Common.Data;
using Common.Models.Domain;
using Common.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers.Api
{
    public class CustomersController : Controller
    {
        private const string GetCustomerById = "GetCustomerById";

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Route("api/customers")]
        public async Task<ActionResult> GetCustomers()
        {
            var customers = await _unitOfWork.Customers.GetAllAsync();
            IList<CustomerDto> dtoCustomers = new List<CustomerDto>(customers.Count);
            foreach (var customer in customers)
            {
                dtoCustomers.Add(_mapper.Map<Customer, CustomerDto>(customer));
            }

            return Ok(dtoCustomers);
        }

        [HttpGet]
        [Route("api/customers/{id}", Name = GetCustomerById)]
        public async Task<ActionResult> GetCustomer(int id)
        {
            var customer = await _unitOfWork.Customers.GetAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(_mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        [Route("api/customers")]
        public async Task<ActionResult> CreateCustomer([FromBody] CustomerDto customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerToBeSaved = _mapper.Map<CustomerDto, Customer>(customer);

            _unitOfWork.Customers.Add(customerToBeSaved);

            await _unitOfWork.CompleteAsync();

            return CreatedAtRoute(GetCustomerById, new { id = customerToBeSaved.Id }, customerToBeSaved);
        }

        [HttpPut]
        [Route("api/customers/{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, [FromBody] CustomerDto customer)
        {
            // Todo: Implementation need to be changed

            if (!ModelState.IsValid)
                return BadRequest();

            var cstmr = await _unitOfWork.Customers.GetAsync(id);
            if (cstmr == null)
                return NotFound();

            _mapper.Map(customer, cstmr);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("api/customers/{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var cstmr = await _unitOfWork.Customers.GetAsync(id);
            if (cstmr == null)
                return NotFound();

            _unitOfWork.Customers.Remove(cstmr);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}


