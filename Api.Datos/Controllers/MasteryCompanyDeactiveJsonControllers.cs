using Api.Datos.Repositories;
using Api.Entidad.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Datos.Controllers
{
    public class MasteryCompanyDeactiveJsonControllers :  IAddEmployee
    {
        public void AddEmployed(List<MasterCompanyModel> masteries)
        {
            string output = JsonConvert.SerializeObject(masteries);
            using (StreamWriter sw = File.AppendText("../MasteryCompanyDeactiveEmployee.txt"))
            {
                sw.WriteLine(output);
            }

            
        }

    }
}
