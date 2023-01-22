using Api.Entidad.Models;
using Microsoft.AspNetCore.Mvc;
using Api.Datos.Controllers;
using Api.Datos.Repositories;

namespace API_Master_Company.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class ApiMasteryCompanyController : ControllerBase
    {
        private readonly ILogger<ApiMasteryCompanyController> _logger;

        public ApiMasteryCompanyController(ILogger<ApiMasteryCompanyController> logger)
        {
            _logger = logger;

        }

        [HttpGet("GetAll")]

        public List<MasteryCompanymodeljson> GetAll()
        {
            IMasterCompanyDatabase masteryCompanyData = new MasteryCompanyActivateJsonControllers();
            
            List<MasteryCompanymodeljson> masteries = masteryCompanyData.ConvertDataToListObjet();
            
            var all = from masterie in masteries
                                select masterie;


            return ModelEmployee.makelist(all);
            //utilizamos if

        }
        [HttpGet("GetDistinct")]
        public List<MasteryCompanymodeljson> Get()
        {
            IMasterCompanyDatabase masteryCompanyData = new MasteryCompanyActivateJsonControllers();

            List<MasteryCompanymodeljson> masteries = masteryCompanyData.ConvertDataToListObjet();

            var AllDistinct = (from masterie in masteries
                                 select masterie).Distinct();



            return ModelEmployee.makelist(AllDistinct);
            //utilizamos if

        }
        [HttpGet("GetEmployeeSalaryIncrease")]
        public List<MasteryCompanymodeljson> GetEmployeeSalaryIncrease()
        {
            IMasterCompanyDatabase masteryCompanyData = new MasteryCompanyActivateJsonControllers();

            List<MasteryCompanymodeljson> masteries = masteryCompanyData.ConvertDataToListObjet();

            var EmployeeSalaryIncrease = (from SalaryIncrease in masteries
                                     select new
                                     {
                                         SalaryIncrease.Name,
                                         SalaryIncrease.LastName,
                                         SalaryIncrease.Document,
                                         Salary = new Func<double?>(() =>
                                         {
                                             try
                                             {
                                                 if (SalaryIncrease.Salary >= 100000)
                                                 {
                                                     double? Salaryy = SalaryIncrease.Salary + (SalaryIncrease.Salary * 0.25);
                                                     return Salaryy;
                                                 }
                                                 else
                                                 {
                                                     double? Salaryy = SalaryIncrease.Salary + (SalaryIncrease.Salary * 0.3);
                                                     return Salaryy;
                                                 }

                                             }
                                             catch
                                             {
                                                 //si ocurre un error
                                                 return 0;
                                             }
                                         }
                                                     )
                                    (),
                                         SalaryIncrease.Gender,
                                         SalaryIncrease.Position,
                                         SalaryIncrease.StartDate
                                     }).Distinct();

            List<MasteryCompanymodeljson> masteri = new List<MasteryCompanymodeljson>();
            foreach (var newlist in EmployeeSalaryIncrease)
            {
                masteri.Add(new MasteryCompanymodeljson()
                {
                    Name = newlist.Name,
                    LastName = newlist.LastName,
                    Document = newlist.Document,
                    Salary = newlist.Salary,
                    Gender = newlist.Gender,
                    Position = newlist.Position,
                    StartDate = newlist.StartDate,
                });
            }
            return masteri;

        }
        [HttpGet("GetEmployeesProportionByGender")]
        public List<string> GetEmployeesProportionByGender()
        {
            IMasterCompanyDatabase masteryCompanyData = new MasteryCompanyActivateJsonControllers();

            List<MasteryCompanymodeljson> masteries = masteryCompanyData.ConvertDataToListObjet();
            var male = ((from masculine in Get() where masculine.Gender == "M" select masculine).Distinct().Count() * 100) / Get().Count();
            var female = ((from feminine in Get() where feminine.Gender == "F" select feminine).Distinct().Count() * 100) / Get().Count();

            List<string> a = new List<string>();
            a.Add("Masculino: " + male + "%");
            a.Add("Femenino: " + female + "%");
            return a;

        }
        [HttpGet("GetEmployeeBySalaryRange")]
        public List<MasteryCompanymodeljson> GetEmployeeBySalaryRange(int inicio, int final)
        {
            IMasterCompanyDatabase masteryCompanyData = new MasteryCompanyActivateJsonControllers();

            List<MasteryCompanymodeljson> masteries = masteryCompanyData.ConvertDataToListObjet();


            var BySalaryRange = (from SalaryRange in masteries
                                 where SalaryRange.Salary >= inicio && SalaryRange.Salary <= final
                                 select SalaryRange).Distinct();


            return ModelEmployee.makelist(BySalaryRange);

        }
        [HttpPost("DeleteEmployee")]
        public List<MasteryCompanymodeljson> DeleteEmployee(string Document)
        {
            IMasterCompanyDatabase masteryCompanyData = new MasteryCompanyActivateJsonControllers();
            IAddEmployee masteryCompanyDataDeactive = new MasteryCompanyDeactiveJsonControllers();

            List<MasteryCompanymodeljson> masteries = masteryCompanyData.ConvertDataToListObjet();


            var EmployeeByDocument = from Employee in masteries
                                where Employee.Document == Document
                                select Employee;
            if (EmployeeByDocument != null)
            {             
                masteries = masteries.Except(ModelEmployee.makelist(EmployeeByDocument)).ToList();
               
            }
           
            masteryCompanyDataDeactive.AddEmployed(new HashSet<MasteryCompanymodeljson>(ModelEmployee.makelist(EmployeeByDocument)).ToList());
            masteryCompanyData.RemoveEmployed(masteries);
            return masteries;



        }
        [HttpPost("InsertEmployee")]
        public List<MasteryCompanymodeljson> InsertEmployee(MasteryCompanymodeljson empleado)
        {
            IAddEmployee masteryCompanyDataActive = new MasteryCompanyActivateJsonControllers();
            

            IMasterCompanyDatabase MasterCompanyDatabase = new MasteryCompanyActivateJsonControllers();

            List<MasteryCompanymodeljson> masteries = MasterCompanyDatabase.ConvertDataToListObjet();

            masteries.Add(new MasteryCompanymodeljson() { 
                Name = empleado.Name,
                LastName= empleado.LastName,
                Document= empleado.Document,
                Salary= empleado.Salary,
                Gender= empleado.Gender,
                Position= empleado.Position,
                StartDate= empleado.StartDate
            }
            );
            masteryCompanyDataActive.AddEmployed(masteries);
            return masteries;
        }
    }
}

