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
    public class MasteryCompanyJsonControllers : IMasterCompanyDatabase, IConvertToText
    {
        public string PathDataBase() {
            string path = @"../masterycompany.txt";
            return path;
        }
        public string TextDataBase()
        {
            string filename = File.ReadAllText("../masterycompany.txt");

            return filename;
        }
        public  List <MasteryCompanymodeljson> ConvertDataToListObjet()
        {        
            var deserializedjson = JsonConvert.DeserializeObject<List <MasteryCompanymodeljson>>(TextDataBase())!;
                     
            return deserializedjson;
        }
        public  void AddEmployed(List<MasteryCompanymodeljson> masteries)
        {
            string output = JsonConvert.SerializeObject(masteries);
            System.IO.File.WriteAllText(PathDataBase(), output);

        }

        public void RemoveEmployed(List<MasteryCompanymodeljson> masteries)
        {
            string output = JsonConvert.SerializeObject(masteries);        
            System.IO.File.WriteAllText(PathDataBase(), output);
        }
    }

}
