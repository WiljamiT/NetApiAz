using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiReact.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public DataController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("customers", Name = "GetCustomers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _dbContext.Customers
                .Take(1000)
                .ToListAsync();

            return Ok(customers);
        }

        [HttpPost("addcustomer", Name = "AddCustomer")]
        public async Task<ActionResult<Customer>> AddCustomer([FromBody] CustomerInputModel customerInput)
        {
            if (customerInput == null)
            {
                return BadRequest("Invalid input");
            }

            var newCustomer = new Customer
            {
                FirstName = customerInput.FirstName,
                LastName = customerInput.LastName,
                Email = customerInput.Email
            };

            _dbContext.Customers.Add(newCustomer);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomers), new { id = newCustomer.CustomerID }, newCustomer);
        }

        [HttpDelete("deletecustomer/{id}", Name = "DeleteCustomer")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customerToDelete = await _dbContext.Customers.FindAsync(id);

            if (customerToDelete == null)
            {
                return NotFound($"Customer with ID {id} not found");
            }

            _dbContext.Customers.Remove(customerToDelete);
            await _dbContext.SaveChangesAsync();

            return Ok($"Customer with ID {id} deleted successfully");
        }

        [HttpPut("updatecustomer/{id}", Name = "UpdateCustomer")]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id, [FromBody] CustomerInputModel updatedCustomerInput)
        {
            if (updatedCustomerInput == null)
            {
                return BadRequest("Invalid input");
            }

            var existingCustomer = await _dbContext.Customers.FindAsync(id);

            if (existingCustomer == null)
            {
                return NotFound($"Customer with ID {id} not found");
            }
            existingCustomer.FirstName = updatedCustomerInput.FirstName;
            existingCustomer.LastName = updatedCustomerInput.LastName;
            existingCustomer.Email = updatedCustomerInput.Email;

            await _dbContext.SaveChangesAsync();

            return Ok(existingCustomer);
        }
    }

    public class CustomerInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}