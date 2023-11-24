using System.Text;
using EmployeeManagement.Api.Models;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.IntegrationTests.TestSettings;
using Newtonsoft.Json;

namespace EmployeeManagement.IntegrationTests
{
    [TestFixture]
    public class EmployeesTests
    {
        TestingWebAppFactory<Program> _factory;

        [SetUp]
        public void Setup()
        {
            _factory = new TestingWebAppFactory<Program>();
        }


        [Test]
        public async Task GetDirectors()
        {
            await AddEmployees();

            var response = await _factory.CreateClient().GetAsync("/api/employee/directors");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var directors = JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(responseString);

            Assert.That(directors.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetEmployeesByManager()
        {
            await AddEmployees();

            var response = await _factory.CreateClient().GetAsync("/api/employee/directors");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var directors = JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(responseString);

            Assert.That(directors.Count(), Is.EqualTo(1));

            var director = directors.First();

            response = await _factory.CreateClient().GetAsync($"/api/employee/manager/{director.Id}");

            response.EnsureSuccessStatusCode();

            responseString = await response.Content.ReadAsStringAsync();

            var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(responseString);

            Assert.That(employees.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetEmployeesByRole()
        {
            await AddEmployees();

            var roles = await GetRoles();

            var directorRole = roles.First(x => x.Name == "Director");
            
            var response = await _factory.CreateClient().GetAsync($"/api/employee/role/{directorRole.Id}");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(responseString);

            Assert.That(employees.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task GetEmployees()
        {
            await AddEmployees();

            var response = await _factory.CreateClient().GetAsync("/api/employee");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(responseString);

            Assert.That(employees.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetEmployeeById()
        {
            await AddEmployees();

            var response = await _factory.CreateClient().GetAsync("/api/employee");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(responseString);

            Assert.That(employees.Count(), Is.EqualTo(2));

            var employee = employees.First();

            response = await _factory.CreateClient().GetAsync($"/api/employee/{employee.Id}");

            response.EnsureSuccessStatusCode();

            responseString = await response.Content.ReadAsStringAsync();

            var employeeById = JsonConvert.DeserializeObject<EmployeeModel>(responseString);

            Assert.That(employeeById.Id, Is.EqualTo(employee.Id));
        }

        [Test]
        public async Task UpdateEmployee()
        {
            await AddEmployees();

            var response = await _factory.CreateClient().GetAsync("/api/employee");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(responseString);

            Assert.That(employees.Count(), Is.EqualTo(2));

            var employee = employees.First();

            var newFirstName = "Jane";
            var newLastName = "Doe";

            response = await _factory.CreateClient().PutAsync($"/api/employee/{employee.Id}", new StringContent(JsonConvert.SerializeObject(new EditEmployeeModel
            {
                FirstName = newFirstName,
                LastName = newLastName
            }), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            response = await _factory.CreateClient().GetAsync($"/api/employee/{employee.Id}");

            response.EnsureSuccessStatusCode();

            responseString = await response.Content.ReadAsStringAsync();

            var employeeById = JsonConvert.DeserializeObject<EmployeeModel>(responseString);

            Assert.That(employeeById.FirstName, Is.EqualTo(newFirstName));
            Assert.That(employeeById.LastName, Is.EqualTo(newLastName));
        }

        [Test]
        public async Task AddEmployee()
        {
            await AddEmployees();

            var response = await _factory.CreateClient().GetAsync("/api/employee");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(responseString);

            Assert.That(employees.Count(), Is.EqualTo(2));

            var roles = await GetRoles();

            var directorRole = roles.First(x => x.Name == "Director");
            var accountantRole = roles.First(x => x.Name == "Accounting");

            var response1 = await _factory.CreateClient().PostAsync("/api/employee", new StringContent(JsonConvert.SerializeObject(new NewEmployeeModel
            {
                FirstName = "John",
                LastName = "Doe",
                ManagerId = null,
                Roles = new List<Guid>()
                {
                    directorRole.Id
                }
            }), Encoding.UTF8, "application/json"));

            response1.EnsureSuccessStatusCode();

            var responseString1 = await response1.Content.ReadAsStringAsync();

            var newEmployee = JsonConvert.DeserializeObject<CreatedEmployee>(responseString1);

            response = await _factory.CreateClient().GetAsync("/api/employee");

            response.EnsureSuccessStatusCode();

            responseString = await response.Content.ReadAsStringAsync();

            employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(responseString);

            Assert.That(employees.Count(), Is.EqualTo(3));

            response = await _factory.CreateClient().GetAsync($"/api/employee/{newEmployee.Id}");

            response.EnsureSuccessStatusCode();

            responseString = await response.Content.ReadAsStringAsync();

            var employeeById = JsonConvert.DeserializeObject<EmployeeModel>(responseString);

            Assert.That(employeeById.Id, Is.EqualTo(newEmployee.Id));
            Assert.That(employeeById.FirstName, Is.EqualTo("John"));
            Assert.That(employeeById.LastName, Is.EqualTo("Doe"));
        }

        private async Task AddEmployees()
        {
            var roles = await GetRoles();

            var directorRole = roles.First(x => x.Name == "Director");
            var accountantRole = roles.First(x => x.Name == "Accounting");

            var response = await _factory.CreateClient().PostAsync("/api/employee", new StringContent(JsonConvert.SerializeObject(new NewEmployeeModel
            {
                FirstName = "John",
                LastName = "Doe",
                ManagerId = null,
                Roles = new List<Guid>()
                {
                    directorRole.Id
                }
            }), Encoding.UTF8, "application/json"));

            var responseString1 = await response.Content.ReadAsStringAsync();

            var newEmployee = JsonConvert.DeserializeObject<CreatedEmployee>(responseString1);

            response = await _factory.CreateClient().PostAsync("/api/employee", new StringContent(JsonConvert.SerializeObject(new NewEmployeeModel
            {
                FirstName = "Jane",
                LastName = "Doe",
                ManagerId = newEmployee.Id,
                Roles = new List<Guid>()
                {
                    accountantRole.Id
                }
            }), Encoding.UTF8, "application/json"));
        }

        private async Task<IEnumerable<Role>?> GetRoles()
        {
            var resp = await _factory.CreateClient().GetAsync("/api/Role");

            var responseString = await resp.Content.ReadAsStringAsync();

            var roles = JsonConvert.DeserializeObject<IEnumerable<Role>>(responseString);
            return roles;
        }
    }
}