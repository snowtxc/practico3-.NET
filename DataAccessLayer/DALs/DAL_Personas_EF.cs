using DataAccessLayer.IDALs;
using Microsoft.Data.SqlClient;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs
{
    public class DAL_Personas_EF : IDAL_Personas
    {
        private DBContextCore _dbContext;

        public DAL_Personas_EF(DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string documento)
        {
            throw new NotImplementedException();
        }

        public List<Persona> Get()
        {
            return _dbContext.Personas
                             .Select(p => new Persona { Documento = p.Documento, Nombre = p.Nombres })
                             .ToList();
        }

        public Persona Get(string documento)
        {
            throw new NotImplementedException();
        }

        public void Insert(Persona persona)
        {
            throw new NotImplementedException();
        }

        public void Update(Persona persona)
        {
            throw new NotImplementedException();
        }
    }
}
