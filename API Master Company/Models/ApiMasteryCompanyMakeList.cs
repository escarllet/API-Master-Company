using Api.Entidad.Models;
using Api.Datos.Controllers;

namespace API_Master_Company
{
    public class ApiMasteryCompanyMakeList
    {
        public static List<MasterCompanyModel> makelist(IEnumerable<MasterCompanyModel> all)
        {
            List<MasterCompanyModel> masteri = new List<MasterCompanyModel>();
            foreach (var newlist in all)
            {
                masteri.Add(new MasterCompanyModel()
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