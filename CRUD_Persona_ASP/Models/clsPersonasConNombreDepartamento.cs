using CRUD_Persona_Entidades;

namespace CRUD_Persona_ASP.Models
{
    public class clsPersonasConNombreDepartamento : clsPersona 
    {

        public String nombreDepartamento { get; set; }


        public clsPersonasConNombreDepartamento() { }

        public clsPersonasConNombreDepartamento(int iD, string nombre, string apellidos, string telefono, string direccion, string foto, DateTime fechaNacimiento, string nombreDepartamento)
        {
            ID = iD;
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            Direccion = direccion;
            Foto = foto;
            FechaNacimiento = fechaNacimiento;
            this.nombreDepartamento = nombreDepartamento;
        }
    }
}
