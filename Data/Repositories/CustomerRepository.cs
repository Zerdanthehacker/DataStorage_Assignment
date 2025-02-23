using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        // CREATE - Skapa en ny kund
        public async Task<CustomerEntity> CreateAsync(CustomerEntity customer)
        {
            if (string.IsNullOrWhiteSpace(customer.CustomerPhoneNumber) ||
                customer.CustomerPhoneNumber.Any(c => !char.IsDigit(c)) ||
                customer.CustomerPhoneNumber.Length != 10)
            {
                throw new ArgumentException("Phone number is invalid. Please enter only digits with a length of 10 characters.");
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        // READ - Hämta alla kunder
        public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        // READ - Hämta en kund baserat på ID
        public async Task<CustomerEntity?> GetByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        // UPDATE - Uppdatera en kund
        public async Task<CustomerEntity?> UpdateAsync(CustomerEntity updatedCustomer)
        {
            if (updatedCustomer == null)
                throw new ArgumentNullException(nameof(updatedCustomer), "Updated customer cannot be null.");

            if (updatedCustomer.Id <= 0)
                throw new ArgumentException("Invalid customer ID.", nameof(updatedCustomer.Id));

            var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == updatedCustomer.Id);

            if (existingCustomer == null)
                return null; // Kunden finns inte

            // Validera telefonnummer
            if (string.IsNullOrWhiteSpace(updatedCustomer.CustomerPhoneNumber) ||
                updatedCustomer.CustomerPhoneNumber.Any(c => !char.IsDigit(c)) ||
                updatedCustomer.CustomerPhoneNumber.Length != 10)
            {
                throw new ArgumentException("Phone number is invalid. Please enter only digits with a length of 10 characters.");
            }

            // Uppdatera fält
            existingCustomer.CustomerName = updatedCustomer.CustomerName;
            existingCustomer.CustomerEmail = updatedCustomer.CustomerEmail;
            existingCustomer.CustomerPhoneNumber = updatedCustomer.CustomerPhoneNumber;

            // Markera entiteten som ändrad och spara
            _context.Entry(existingCustomer).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return existingCustomer;
        }


        // DELETE - Ta bort en kund
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                _context.Customers.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CustomerEntity?> GetById(int id)
        {
            // Hämta kunden baserat på ID från databasen
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);

            // Returnera kunden om den finns, annars null
            return customer;
        }

    }
}

