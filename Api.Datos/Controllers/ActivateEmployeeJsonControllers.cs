using Api.Entidad.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Api.Datos.Repositories;

namespace Api.Datos.Controllers
{
    public class ActivateEmployeeJsonControllers : IMasterCompanyDatabase, IConvertDataToString, IAddEmployee
    {
        public string PathDataBase() {
            string path = @"../MasteryCompanyActiveEmployee.txt";
            return path;
        }
        public string TextDataBase()
        {
            string filename = File.ReadAllText("../MasteryCompanyActiveEmployee.txt");

            return filename;
        }
        public  List <EmployeeModel> ConvertDataToListObjet()
        {        
            var deserializedjson = JsonConvert.DeserializeObject<List<EmployeeModel>>(TextDataBase())!;
                     
            return deserializedjson;
        }
        public  void AddEmployed(List<EmployeeModel> masteries)
        {
            string output = JsonConvert.SerializeObject(masteries);
            System.IO.File.WriteAllText(PathDataBase(), output);

        }

        public void RemoveEmployed(List<EmployeeModel> masteries)
        {
            string output = JsonConvert.SerializeObject(masteries);        
            System.IO.File.WriteAllText(PathDataBase(), output);
        }
    }

}
