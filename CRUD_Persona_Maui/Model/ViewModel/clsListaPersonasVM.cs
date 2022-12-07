using CRUD_Persona_BL;
using CRUD_Persona_Entidades;
using CRUD_Persona.ViewModel.Utilidades;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Ejercicio10_ASP_Ejercicio1.Models.DAL;
using Microsoft.Data.SqlClient;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace CRUD_Persona_Maui.Model.ViewModel.ListadoPersonas
{
    public class clsListaPersonasVM : clsVMBase

    {


        #region Atributos
        private ObservableCollection<clsPersona> listaCompletaPersonasVM;
        private clsPersona personaSeleccionada;
        private DelegateCommand borrarPersonCommand;
        private DelegateCommand irEditarPersonasCommand;
        private DelegateCommand irInsertarPersonasCommand;
        private String buscarPersona;
        #endregion



        #region Propiedades

       
        public String BuscarPersona
        {
            get { return buscarPersona; }
            set { buscarPersona = value;
                buscarPersonaPorNombreYApellido();
            }
        }
        public ObservableCollection<clsPersona> ListaCompletaPersonasVM
        {
            get {
               
                return listaCompletaPersonasVM;
                
            }
            set { listaCompletaPersonasVM= value;
                
            }
        }

        public clsPersona PersonaSeleccionada
        {
            get { return personaSeleccionada; } 
            set {
                
                personaSeleccionada = value;

                // Se llama al método canExecute cuando se selecciona una persona
                NotifyPropertyChanged(nameof(ListaCompletaPersonasVM));
                irEditarPersonasCommand.RaiseCanExecuteChanged();
                borrarPersonCommand.RaiseCanExecuteChanged();
               
            }
        }

        public DelegateCommand IrEditarPersonasCommand
        {

            get { return irEditarPersonasCommand; }

            set { irEditarPersonasCommand = value; }
            
        }

        public DelegateCommand IrInsertarPersonasCommand
        {

            get { return irInsertarPersonasCommand; }

            set { irInsertarPersonasCommand = value; }

        }

        public DelegateCommand BorrarPersonCommand
        {

            get { return borrarPersonCommand; }

            set { borrarPersonCommand = value; }

        }


        #endregion



        #region Constructor por defecto
        public clsListaPersonasVM()
        {

            // Se inicializan los DelegateCommand
            irEditarPersonasCommand = new DelegateCommand(irEditarPersonasCommand_Execute, irEditarPersonasCommand_CanExecute);
            irInsertarPersonasCommand = new DelegateCommand(irInsertarPersonasCommand_Execute, irInsertarPersonasCommand_CanExecute);
            borrarPersonCommand = new DelegateCommand(borrarPersonCommand_Execute, borrarPersonCommand_CanExecute);
        }

       


        #endregion



        #region Commands

        /// <summary>
        /// Este método es llamado cuando se selecciona una persona de la lista, en caso de que no haya ninguna persona seleccionada el botón de editar
        /// aparecerá desactivado, ya que está bindeado al command de irEditarPersonasCommand. Una vez que se selecciona una persona, la variable
        /// bool que se crea y devuelve se pondrá a true, lo que dará via libre al botón para ser activado.
        /// </summary>
        /// <returns></returns>
        private bool irEditarPersonasCommand_CanExecute()
        {
            bool editarPersona=false;

            if ( PersonaSeleccionada!=null)
            {
                editarPersona = true;
            }

            return editarPersona;
        }

        /// <summary>
        /// Con este método iremos a otra vista. Una vez que se selecciona una lista y se pulsa el botón de enviar, se pasará a la vista correspondiente y 
        /// enviará al mismo tiempo la persona seleccionada.
        /// </summary>
        private async void irEditarPersonasCommand_Execute()
        {

            var persona = new Dictionary<string, Object>()
            {
                { "personaEnviar", PersonaSeleccionada}
            };
            await Shell.Current.GoToAsync($"editarPersona", persona);
        }


        /// <summary>
        /// Este command estará siempre activo
        /// </summary>
        /// <returns></returns>
        private bool irInsertarPersonasCommand_CanExecute()
        {
            return true;
        }

        /// <summary>
        /// Cuando se ejecuta el command se viaja a la vista donde se insertará una persona
        /// </summary>
        private async void irInsertarPersonasCommand_Execute()
        {
          
                await Shell.Current.GoToAsync($"insertarPersona");
            
           
        }


        /// <summary>
        /// Para poder ejecutar este command se comprueba que la persona seleccionada no sea null.
        /// Postcondición: Devuelve un booleano.
        /// </summary>
        /// <returns></returns>
        private bool borrarPersonCommand_CanExecute()
        {
            bool borrarPersona = false;

            if (PersonaSeleccionada != null)
            {
                borrarPersona = true;
            }

            return borrarPersona;
        }

        /// <summary>
        /// Este command se encarga de llamar al método de la BL que se encargará de eliminar una persona a través de su id.
        /// </summary>
        private void borrarPersonCommand_Execute()
        {
          
            NotifyPropertyChanged("ListaCompletaPersonasVM");
            int numeroFilasAfectadas;
            
            try
            {
                numeroFilasAfectadas = clsManejadoraPersonaBL.eliminarPersonaBL(PersonaSeleccionada.ID);
                listaCompletaPersonasVM.Remove(PersonaSeleccionada);
                NotifyPropertyChanged("ListaCompletaPersonasVM");
                // Se muestra un mensaje informativo al usuario
                if (numeroFilasAfectadas != 0)
                {

                    var toast = Toast.Make("Se eliminó con éxito", ToastDuration.Short).Show();

                }
            }
            catch (Exception e)
            {
                var toast = Toast.Make("Ocurrió algún problema", ToastDuration.Short).Show();

            }


        }
        #endregion

        /// <summary>
        /// Con este método se comprueba que el contenido del entry no lo contenga los objetos de la lista. Siempre
        /// que no lo contengan serán eliminados de la lista, quedando únicamente aquellos que contienen lo que 
        /// se busca. Cuando no hay nada se muestra la lista completa.
        /// </summary>
        private void buscarPersonaPorNombreYApellido()
        {
            // Para que cuando se borra del entry aparezca las personas que ya hemos borrado, antes del for la lista se rellena
            if(ListaCompletaPersonasVM != null)
            {

           

            for (int i = 0; i < ListaCompletaPersonasVM.Count; i++)
            {

                if (ListaCompletaPersonasVM[i].Nombre.Contains(BuscarPersona) == false && ListaCompletaPersonasVM[i].Apellidos.Contains(BuscarPersona) == false)
                {
                    ListaCompletaPersonasVM.Remove(ListaCompletaPersonasVM[i]);
                    i--;
                }
            }

            if (BuscarPersona == "")
            {
                ListaCompletaPersonasVM = new ObservableCollection<clsPersona>( clsListaPersonasBL.listadoPersonasCompletoBL());
                NotifyPropertyChanged("ListaCompletaPersonasVM");
            }
            }
        }

        /// <summary>
        /// Método que servirá para actualizar la lista cada vez que la pantalla principal está en pantalla
        /// </summary>
        public void actualizarListaPersonas()
        {
            try
            {
                ListaCompletaPersonasVM = new ObservableCollection<clsPersona>(clsListaPersonasBL.listadoPersonasCompletoBL());
            }
            catch(Exception e)
            {
                var toast = Toast.Make("Ocurrió algún problema en la conexión con la base de datos", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            
            NotifyPropertyChanged("ListaCompletaPersonasVM");
        }
    }
}
