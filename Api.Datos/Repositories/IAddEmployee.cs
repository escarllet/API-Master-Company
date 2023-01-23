using Api.Entidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Datos.Repositories
{
    public interface IAddEmployee
    {
        void AddEmployed(List<MasterCompanyModel> masteries);
    }
}
