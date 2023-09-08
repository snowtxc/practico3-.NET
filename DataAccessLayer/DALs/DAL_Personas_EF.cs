using DataAccessLayer.EFModels;
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
            Personas? personaFind = _dbContext.Personas.FirstOrDefault(p => p.Documento == documento);
            if (personaFind == null)
            {
                return;
            }
            _dbContext.Personas.Remove(personaFind);
            _dbContext.SaveChanges();
        }

        public List<Persona> Get()
        {
            List<Persona> personas =  _dbContext.Personas
                             .Select(p => new Persona { Documento = p.Documento, Nombre = p.Nombres })
                             .ToList();

            return personas;
        }

        public Persona? Get(string documento)
        {
            Personas? personaFind = _dbContext.Personas.FirstOrDefault(p => p.Documento ==  documento);
            if (personaFind == null)
            {
                return null;
            }
            Persona persona = new Persona { Nombre = personaFind.Nombres, Documento = personaFind.Documento, Direccion = personaFind.Documento, FechaDeNacimiento = personaFind.FechaDeNacimiento };
            return persona;
        }

        public void Insert(Persona persona)
        {
            Personas newPerson = new Personas { Nombres = persona.Nombre, Direccion = persona.Direccion, FechaDeNacimiento = persona.FechaDeNacimiento , Documento = persona.Documento};
            _dbContext.Personas.Add(newPerson);
            _dbContext.SaveChanges();
        }

        public void Update(Persona persona)
        {
            Personas? personaFind = _dbContext.Personas.FirstOrDefault(p => p.Documento == persona.Documento);
            if(personaFind == null)
            {
                return;
            }
            personaFind.Nombres = persona.Nombre;
            personaFind.Documento = persona.Documento;
            personaFind.Direccion = persona.Direccion;
            personaFind.FechaDeNacimiento = persona.FechaDeNacimiento;

            _dbContext.Update(personaFind);
            _dbContext.SaveChanges();

        }

      
    }
}
