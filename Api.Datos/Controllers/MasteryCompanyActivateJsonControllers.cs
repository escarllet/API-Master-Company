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
    public class MasteryCompanyActivateJsonControllers : IMasterCompanyDatabase, IConvertDataToString, IAddEmployee
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
        public  List <MasterCompanyModel> ConvertDataToListObjet()
        {        
            var deserializedjson = JsonConvert.DeserializeObject<List<MasterCompanyModel>>(TextDataBase())!;
                     
            return deserializedjson;
        }
        public  void AddEmployed(List<MasterCompanyModel> masteries)
        {
            string output = JsonConvert.SerializeObject(masteries);
            System.IO.File.WriteAllText(PathDataBase(), output);

        }

        public void RemoveEmployed(List<MasterCompanyModel> masteries)
        {
            string output = JsonConvert.SerializeObject(masteries);        
            System.IO.File.WriteAllText(PathDataBase(), output);
        }
    }

}
