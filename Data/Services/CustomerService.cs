using Data.Entities;
using Data.Repositories;

namespace Data.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        // Constructor to inject the repository
        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // CREATE - Skapa en ny kund
        public async Task<CustomerEntity> CreateCustomerAsync(CustomerEntity customer)
        {
            return await _customerRepository.CreateAsync(customer);
        }

        // READ - Hämta alla kunder
        public async Task<IEnumerable<CustomerEntity>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        // READ - Hämta en kund baserat på ID
        public async Task<CustomerEntity?> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        // UPDATE - Uppdatera en kund
        public async Task<CustomerEntity?> UpdateCustomerAsync(CustomerEntity updatedCustomer)
        {
            return await _customerRepository.UpdateAsync(updatedCustomer);
        }

        // DELETE - Ta bort en kund
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            return await _customerRepository.DeleteAsync(id);
        }

        public object GetCustomerById(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
