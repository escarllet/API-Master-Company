﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Entidad.Models;

namespace Api.Datos.Repositories
{
   public interface IMasterCompanyDatabase
    {
        string PathDataBase();
        List<MasteryCompanymodeljson> ConvertDataToListObjet();
        void AddEmployed(List<MasteryCompanymodeljson> masteries);
        void RemoveEmployed(List<MasteryCompanymodeljson> masteries);

    }
}
