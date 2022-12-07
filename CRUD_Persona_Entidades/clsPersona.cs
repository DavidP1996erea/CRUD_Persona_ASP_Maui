using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Persona_Entidades
{
    public class clsPersona
    {

        #region Atributos
            public int ID { get; set; }
            public string Nombre { get; set; }
            public string Apellidos { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
            public string Foto { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public int IDDepartamento { get; set; }

        #endregion

        #region Constructor por defecto
        public clsPersona()
        {

        }
        #endregion

        #region Constructor con parámetros
        public clsPersona(int iD, string nombre, string apellidos, string telefono, string direccion, string foto, DateTime fechaNacimiento, int indDepartamento)
        {
            ID = iD;
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            Direccion = direccion;
            Foto = foto;
            FechaNacimiento = fechaNacimiento;
            IDDepartamento = indDepartamento;
        }
        #endregion
    }
}