using Data.Services;
using Data.Entities;

namespace ConsoleApp_Presentation
{
    public class MenuDialogs
    {
        private readonly CustomerService _customerService;
        private readonly ProjectService _projectService;

        public MenuDialogs(CustomerService customerService, ProjectService projectService)
        {
            _customerService = customerService;
            _projectService = projectService;
        }

        // Detta är alla alternativ i menyn
        public async Task MenuOptions()
        {
            while (true)
            {
                Console.WriteLine("1. Create New Customer");
                Console.WriteLine("2. Create New Project");
                Console.WriteLine("3. Get All Customers");
                Console.WriteLine("4. Get All Projects");
                Console.WriteLine("5. Get Customer");
                Console.WriteLine("6. Get Project");
                Console.WriteLine("7. Update Customer");
                Console.WriteLine("8. Update Project");
                Console.WriteLine("9. Delete Customer");
                Console.WriteLine("10. Delete Project");
                Console.WriteLine("0. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await CreateNewCustomer();
                        break;
                    case "2":
                        await CreateNewProject();
                        break;
                    case "3":
                        await GetAllCustomers();
                        break;
                    case "4":
                        await GetAllProjects();
                        break;
                    case "5":
                        _ = GetCustomer();
                        break;
                    case "6":
                        await GetProject();
                        break;
                    case "7":
                        await UpdateCustomer();
                        break;
                    case "8":
                        await UpdateProject();
                        break;
                    case "9":
                        await DeleteCustomer();
                        break;
                    case "10":
                        await DeleteProject();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }


        
        private async Task CreateNewCustomer()
        {

            Console.Clear();
            Console.WriteLine("Enter Customer Name:");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Customer Name cannot be empty.");
                return;
            }

            Console.WriteLine("Enter Customer Email:");
            var email = Console.ReadLine();
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Customer Email cannot be empty.");
                return;
            }

            Console.WriteLine("Enter Customer Phone Number:");
            var phoneNumber = Console.ReadLine();
            if (string.IsNullOrEmpty(phoneNumber))
            {
                Console.WriteLine("Customer Phone Number cannot be empty.");
                return;
            }


            

            



            var newCustomer = new CustomerEntity
            {
                CustomerName = name,
                CustomerEmail = email,
                CustomerPhoneNumber = phoneNumber
            };

            var createdCustomer = await _customerService.CreateCustomerAsync(newCustomer);
            Console.WriteLine($"Customer {createdCustomer.CustomerName} created successfully.");
        }

        private async Task CreateNewProject()
        {
            Console.Clear();
            Console.WriteLine("Enter Project Title:");
            var projectName = Console.ReadLine();
            if (string.IsNullOrEmpty(projectName))
            {
                Console.WriteLine("Project Title is required!");
                return;
            }

            Console.WriteLine("Enter Project Description:");
            var projectDescription = Console.ReadLine();

            var newProject = new ProjectEntity
            {
                Title = projectName,
                Description = projectDescription
            };

            var createdProject = await _projectService.CreateAsync(newProject);
            Console.WriteLine($"Project {createdProject.Title} created successfully.");
        }

        private async Task GetAllCustomers()
        {
            Console.Clear();
            var customers = await _customerService.GetAllCustomersAsync();
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.CustomerName}, Email: {customer.CustomerEmail}, Phone: {customer.CustomerPhoneNumber}");
            }
        }

        private async Task GetAllProjects()
        {
            Console.Clear();
            var projects = await _projectService.GetAllAsync();
            foreach (var project in projects)
            {
                Console.WriteLine($"ID: {project.Id}, Title: {project.Title}, Description: {project.Description}");
            }
        }

        private async Task GetCustomer()
        {
            Console.Clear();
            Console.WriteLine("Enter Customer ID:");

            if (int.TryParse(Console.ReadLine(), out var customerId))
            {
                var customer = await _customerService.GetCustomerByIdAsync(customerId); 
                if (customer != null)
                {
                    Console.WriteLine($"ID: {customer.Id}, Name: {customer.CustomerName}, Email: {customer.CustomerEmail}, Phone: {customer.CustomerPhoneNumber}");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format. Please enter a valid number.");
            }
        }


        private async Task GetProject()
        {
            Console.Clear();
            Console.WriteLine("Enter Project ID:");
            if (int.TryParse(Console.ReadLine(), out var projectId))
            {
                var project = await _projectService.GetByIdAsync(projectId);
                if (project != null)
                {
                    Console.WriteLine($"ID: {project.Id}, Title: {project.Title}, Description: {project.Description}");
                }
                else
                {
                    Console.WriteLine("Project not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format. Please enter a valid number.");
            }
        }

        private async Task UpdateCustomer()
        {
            Console.Clear();
            Console.WriteLine("Enter Customer ID to Update:");

            if (int.TryParse(Console.ReadLine(), out var customerId))
            {
                var customer = await _customerService.GetCustomerByIdAsync(customerId); 
                if (customer != null)
                {
                    Console.WriteLine("Enter New Name:");
                    var newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        customer.CustomerName = newName;
                    }
                    else
                    {
                        Console.WriteLine("Name cannot be empty.");
                        return;
                    }

                    Console.WriteLine("Enter New Email:");
                    var newEmail = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newEmail))
                    {
                        customer.CustomerEmail = newEmail;
                    }
                    else
                    {
                        Console.WriteLine("Email cannot be empty.");
                        return;
                    }

                    Console.WriteLine("Enter New Phone Number:");
                    var newPhoneNumber = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newPhoneNumber))
                    {
                        customer.CustomerPhoneNumber = newPhoneNumber;
                    }
                    else
                    {
                        Console.WriteLine("Phone number cannot be empty.");
                        return;
                    }

                    var updatedCustomer = await _customerService.UpdateCustomerAsync(customer);
                    if (updatedCustomer != null)
                    {
                        Console.WriteLine("Customer updated successfully.");
                    }
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format. Please enter a valid number.");
            }
        }



        private async Task UpdateProject()
        {
            Console.Clear();
            Console.WriteLine("Enter Project ID to Update:");
            if (int.TryParse(Console.ReadLine(), out var projectId))
            {
                var project = await _projectService.GetByIdAsync(projectId);
                if (project != null)
                {
                    Console.WriteLine("Enter New Project Title:");
                    var newTitle = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newTitle))
                    {
                        project.Title = newTitle;
                    }
                    else
                    {
                        Console.WriteLine("Project title cannot be empty.");
                        return;
                    }

                    Console.WriteLine("Enter New Project Description:");
                    var newDescription = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newDescription))
                    {
                        project.Description = newDescription;
                    }
                    else
                    {
                        Console.WriteLine("Project description cannot be empty.");
                        return;
                    }

                    var updatedProject = await _projectService.UpdateAsync(project);
                    if (updatedProject != null)
                    {
                        Console.WriteLine("Project updated successfully.");
                    }
                }
                else
                {
                    Console.WriteLine("Project not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format. Please enter a valid number.");
            }
        }


        private async Task DeleteCustomer()
        {
            Console.Clear();
            Console.WriteLine("Enter Customer ID to Delete:");
            if (int.TryParse(Console.ReadLine(), out var customerId))
            {
                var success = await _customerService.DeleteCustomerAsync(customerId);
                if (success)
                {
                    Console.WriteLine("Customer deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format. Please enter a valid number.");
            }
        }

        private async Task DeleteProject()
        {
            Console.Clear();
            Console.WriteLine("Enter Project ID to Delete:");
            if (int.TryParse(Console.ReadLine(), out var projectId))
            {
                var success = await _projectService.DeleteAsync(projectId);
                if (success)
                {
                    Console.WriteLine("Project deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Project not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format. Please enter a valid number.");
            }
        }
    }
}

