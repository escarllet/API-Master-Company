using Api.Entidad.Models;
using Api.Datos.Controllers;

namespace API_Master_Company
{
    public class ModelEmployee
    {
        public static List<MasteryCompanymodeljson> makelist(IEnumerable<MasteryCompanymodeljson> all)
        {
            List<MasteryCompanymodeljson> masteri = new List<MasteryCompanymodeljson>();
            foreach (var newlist in all)
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

    }
}