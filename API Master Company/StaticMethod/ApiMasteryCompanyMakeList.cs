using Api.Entidad.Models;
using Api.Datos.Controllers;

namespace API_Master_Company
{
    public class ApiMasteryCompanyMakeList
    {
        public static List<EmployeeModel> makelist(IEnumerable<EmployeeModel> all)
        {
            List<EmployeeModel> masteri = new List<EmployeeModel>();
            foreach (var newlist in all)
            {
                masteri.Add(new EmployeeModel()
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

    }
}