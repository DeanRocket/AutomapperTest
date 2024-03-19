using AutoMapper;

namespace AutomapperTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeViewModel>();
            });

            var _employeeList = new List<Employee>() {
                new Employee{ Id=1, Name="Amy", Phone="0911334455", Age=25 },
                new Employee{ Id=2, Name="Tom", Phone="0912554433", Age=28 },
                new Employee{ Id=3, Name="Andy", Phone="0912112299", Age=30 },
            };

            var mapper = new Mapper(config);

            // Sample data for 'a'
            var employeeViewModels = new List<EmployeeViewModel>() {
                new EmployeeViewModel{ Id=1, Address="Taipei" },
                new EmployeeViewModel{ Id=2, Address="Tanan" },
                new EmployeeViewModel{ Id=3, Address="America" },
            };

            var result = from  emp in _employeeList
                         join  b in employeeViewModels on emp.Id equals b.Id
                         select new { Employee = emp, Address = b.Address };


            var mappedResult = mapper.Map<IEnumerable<Employee>>(result.Select(x => x.Employee));

            foreach (var item in mappedResult)
            {
                var address = result.Single(x => x.Employee == item).Address;
                item.Address = address;
            }

            Console.WriteLine("");
        }
    }
}
