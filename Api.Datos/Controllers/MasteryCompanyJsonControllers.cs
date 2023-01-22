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
    public class MasteryCompanyJsonControllers : IMasterCompanyDatabase
    {
        public string PathDataBase()
        {
            string filename = File.ReadAllText("../masterycompany.json");

            return filename;
        }
        public  List <MasteryCompanymodeljson> ConvertDataToListObjet()
        {        
            var deserializedjson = JsonConvert.DeserializeObject<List <MasteryCompanymodeljson>>(PathDataBase())!;
                     
            return deserializedjson;
        }
        public  void AddEmployed(List<MasteryCompanymodeljson> masteries)
        {
            string output = JsonConvert.SerializeObject(masteries);
            string path = @"../masterycompany.json";
            System.IO.File.WriteAllText(path, output);

        }


    }

}
