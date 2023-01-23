using Api.Entidad.Models;
using API_Master_Company.Controllers;

namespace Api.Negocio
{
    public class EmployeeB
    {
        private static ApiMasteryCompanyController apiMastery = new ApiMasteryCompanyController();
        public List<MasterCompanyModel> GetAll()
        {
            return apiMastery.GetAll();
        }
    }
}