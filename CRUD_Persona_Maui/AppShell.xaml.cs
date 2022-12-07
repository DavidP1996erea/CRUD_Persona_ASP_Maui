namespace CRUD_Persona_Maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		// Se crea los enlaces para viajar a las vistas que están fuera del shell
		Routing.RegisterRoute("editarPersona", typeof(View.editarPersonas));
		Routing.RegisterRoute("insertarPersona", typeof(View.insertarPersona));
        Routing.RegisterRoute("editarDepartamento", typeof(View.editarDepartamento));
        Routing.RegisterRoute("insertarDepartamento", typeof(View.insertarDepartamento));
    }
}
