using Api.Datos.Controllers;
using Api.Datos.Repositories;
using Api.Entidad.Models;
using Api.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Master_Company.Controllers
{
    [ApiController]
    [Route("API/Employee")]
    public class ApiMasteryCompanyController : ControllerBase
    {
        private readonly IMasterCompanyDatabase masteryCompanyData;

        public ApiMasteryCompanyController(IMasterCompanyDatabase masteryCompanyData)
        {
            this.masteryCompanyData = masteryCompanyData;
        }
        
        [HttpGet("GetDistinct")]
        public ActionResult<List<EmployeeModel>> Get()
        {
            try
            {


                List<EmployeeModel> masteries = masteryCompanyData.ConvertDataToListObjet();

                var AllDistinct = (from masterie in masteries
                                   select masterie).Distinct();



                return ApiMasteryCompanyMakeList.makelist(AllDistinct);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }

        }
        [HttpGet("GetEmployeeSalaryIncrease")]
        public ActionResult<List<EmployeeModel>> GetEmployeeSalaryIncrease()
        {
            try
            {


                List<EmployeeModel> masteries = masteryCompanyData.ConvertDataToListObjet().Distinct().ToList();
                masteries.ForEach(masterie =>
                {
                    masterie.Salary = masterie.Salary >= 100000 ? masterie.Salary + (masterie.Salary * 0.25) : masterie.Salary + (masterie.Salary * 0.3);
                });
                
                return masteries;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }

        }
        [HttpGet("GetEmployeesProportionByGender")]
        public ActionResult<ProportionListModel> GetEmployeesProportionByGender()
        {
            try
            {
                
                List<EmployeeModel> masteries = masteryCompanyData.ConvertDataToListObjet();
                var employees = (from masterie in masteries
                                 select masterie).Distinct();

                
                var male = ((from masculine in employees where masculine.Gender == "M" select masculine).Distinct().Count() * 100) / employees.Count();
                var female = ((from feminine in employees where feminine.Gender == "F" select feminine).Distinct().Count() * 100) / employees.Count();

                
                ProportionListModel listModel = new ProportionListModel
                {
                    Masculine = male + "%",
                    Feminine = female + "%"
                };

                return listModel;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }

        }
        [HttpGet("GetEmployeeBySalaryRange")]
        public ActionResult<List<EmployeeModel>> GetEmployeeBySalaryRange(int begin, int end)
        {
            try
            {


                List<EmployeeModel> masteries = masteryCompanyData.ConvertDataToListObjet();


                var BySalaryRange = (from SalaryRange in masteries
                                     where SalaryRange.Salary >= begin && SalaryRange.Salary <= end
                                     select SalaryRange).Distinct();


                return ApiMasteryCompanyMakeList.makelist(BySalaryRange);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }

        }
        [HttpDelete("DeleteEmployee")]
        public ActionResult<List<EmployeeModel>> DeleteEmployee(string Document)
        {
            try
            {


                IAddEmployee masteryCompanyDataDeactive = new MasteryCompanyDeactiveJsonControllers();

                List<EmployeeModel> masteries = masteryCompanyData.ConvertDataToListObjet();


                var EmployeeByDocument = from Employee in masteries
                                         where Employee.Document == Document
                                         select Employee;
                if (EmployeeByDocument != null)
                {
                    masteries = masteries.Except(ApiMasteryCompanyMakeList.makelist(EmployeeByDocument)).ToList();

                }

                masteryCompanyDataDeactive.AddEmployed(new HashSet<EmployeeModel>(ApiMasteryCompanyMakeList.makelist(EmployeeByDocument)).ToList());
                masteryCompanyData.RemoveEmployed(masteries);
                return masteries;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }


        }
        [HttpPost("InsertEmployee")]
        public ActionResult<List<EmployeeModel>> InsertEmployee(EmployeeModel empleado)
        {
            try
            {
                IAddEmployee masteryCompanyDataActive = new MasteryCompanyActivateJsonControllers();




                List<EmployeeModel> masteries = masteryCompanyData.ConvertDataToListObjet();

                masteries.Add(new EmployeeModel()
                {
                    Name = empleado.Name,
                    LastName = empleado.LastName,
                    Document = empleado.Document,
                    Salary = empleado.Salary,
                    Gender = empleado.Gender,
                    Position = empleado.Position,
                    StartDate = empleado.StartDate
                }
                );
                masteryCompanyDataActive.AddEmployed(masteries);
                return masteries;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}

