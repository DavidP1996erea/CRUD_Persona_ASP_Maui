using CRUD_Persona_Maui.Model.ViewModel.ListadoDepartamento;

namespace CRUD_Persona_Maui.View;

public partial class departamentos : ContentPage
{
	public departamentos()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        ((clsListaDepartamentoVM)(BindingContext)).actualizarListaDepartamentos();
        base.OnAppearing();
    }
}