using CRUD_Persona_Maui.Model.ViewModel.ListadoPersonas;

namespace CRUD_Persona_Maui.View;

public partial class personas : ContentPage
{


	public personas()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        ((clsListaPersonasVM)(BindingContext)).actualizarListaPersonas();
        base.OnAppearing();
    }
}

