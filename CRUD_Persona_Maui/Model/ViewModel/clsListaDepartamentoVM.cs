using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CRUD_Persona.ViewModel.Utilidades;
using CRUD_Persona_BL;
using CRUD_Persona_Entidades;
using System.Collections.ObjectModel;


namespace CRUD_Persona_Maui.Model.ViewModel.ListadoDepartamento
{
    public class clsListaDepartamentoVM : clsVMBase
    {
        #region Atributos
        private ObservableCollection<clsDepartamento> listaCompletaDepartamentoVM;
        private clsDepartamento departamentoSeleccionado;
        private DelegateCommand irEditarDepartamentoCommand;
        private DelegateCommand irInsertarDepartamentoCommand;
        private DelegateCommand borrarDepartamentoCommand;
        private String buscarDepartamento;
        #endregion

        #region Propiedades
        public String BuscarDepartamento
        {
            get { return buscarDepartamento; }
            set { buscarDepartamento = value;
                buscarDepartamentoPorNombre();
            }
        }
        public ObservableCollection<clsDepartamento> ListaCompletaDepartamentoVM
        {
            get { return listaCompletaDepartamentoVM; }
            set { listaCompletaDepartamentoVM = value;}

        }

        public clsDepartamento DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado;}
            set { departamentoSeleccionado= value;
                irEditarDepartamentoCommand.RaiseCanExecuteChanged();
                irInsertarDepartamentoCommand.RaiseCanExecuteChanged();
                borrarDepartamentoCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand IrEditarDepartamentoCommand
        {
            get { return irEditarDepartamentoCommand; }
            set { irEditarDepartamentoCommand = value; }
        }


        public DelegateCommand IrInsertarDepartamentoCommand
        {
            get { return irInsertarDepartamentoCommand; }
            set { irInsertarDepartamentoCommand = value; }
        }

        public DelegateCommand BorrarDepartamentoCommand
        {
            get { return borrarDepartamentoCommand; }
            set { borrarDepartamentoCommand = value;}
        }
        #endregion


        #region Constructor por defecto
        public clsListaDepartamentoVM()
        {
            irEditarDepartamentoCommand = new DelegateCommand(irEditarDepartamentoCommand_Execute, irEditarDepartamentoCommand_CanExecute);
            irInsertarDepartamentoCommand = new DelegateCommand(irInsertarDepartamentoCommand_Execute, irInsertarDepartamentoCommand_CanExecute);
            borrarDepartamentoCommand = new DelegateCommand(borrarDepartamentoCommand_Execute, borrarDepartamentoCommand_CanExecute);
        }

        #endregion


        #region Commands
        /// <summary>
        /// Método que devuelve un bool, en caso de que el departamento seleccionado sea null
        /// devolverá true y sino devolverá false.
        /// </summary>
        /// <returns></returns>
        private bool irEditarDepartamentoCommand_CanExecute()
        {
            bool editarDepartamento = false;

            if (DepartamentoSeleccionado != null)
            {
                editarDepartamento = true;
            }

            return editarDepartamento;
        }

        /// <summary>
        /// Con este command se coge el departamento seleccionado por el usuario y cuando pulsa el botón 
        /// se envía a otra vista
        /// </summary>
        private async void irEditarDepartamentoCommand_Execute()
        {
            var departamento = new Dictionary<string, Object>()
            {
                { "departamentoEnviado", DepartamentoSeleccionado}
            };
            await Shell.Current.GoToAsync($"editarDepartamento", departamento);
        }


        /// <summary>
        /// Este método siempre estará activo, para que el usuario pueda insertar un nuevo departamento
        /// </summary>
        /// <returns></returns>
        private bool irInsertarDepartamentoCommand_CanExecute()
        {
             bool editarDepartamento = false;

            if (DepartamentoSeleccionado != null)
            {
                editarDepartamento = true;
            }

            return editarDepartamento;
        }

        private async void irInsertarDepartamentoCommand_Execute()
        {
            await Shell.Current.GoToAsync($"insertarDepartamento");
        }



        /// <summary>
        /// Devuelve un booleano que servirá para activar el botón
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool borrarDepartamentoCommand_CanExecute()
        {
            bool editarDepartamento = false;

            if (DepartamentoSeleccionado != null)
            {
                editarDepartamento = true;
            }

            return editarDepartamento;
        }
        /// <summary>
        /// Método que recoge el id de un departamento para pasarlo como parámetro a otro método 
        /// que se encargará de borrarlo
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void borrarDepartamentoCommand_Execute()
        {
            NotifyPropertyChanged("ListaCompletaDepartamentoVM");
            int numeroFilasAfectadas;

            try
            {
                numeroFilasAfectadas = clsManejadoraDepartamentosBL.eliminarDepartamentoBL(DepartamentoSeleccionado.ID);

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
        private void buscarDepartamentoPorNombre()
        {
            // Para que cuando se borra del entry aparezca las personas que ya hemos borrado, antes del for la lista se rellena
            if (ListaCompletaDepartamentoVM != null) { 

            for (int i = 0; i < ListaCompletaDepartamentoVM.Count; i++)
            {

                if (ListaCompletaDepartamentoVM[i].Nombre.Contains(BuscarDepartamento) == false)
                {
                    ListaCompletaDepartamentoVM.Remove(ListaCompletaDepartamentoVM[i]);
                    i--;
                }
            }

            if (BuscarDepartamento == "")
            {
                ListaCompletaDepartamentoVM = new ObservableCollection<clsDepartamento>(clsListaDepartamentoBL.listadoCompletoDepartamentosBL());
                NotifyPropertyChanged("ListaCompletaDepartamentoVM");
            }
            }
        }


        /// <summary>
        /// Método que servirá para actualizar la lista cada vez que la pantalla principal está en pantalla
        /// </summary>
        public void actualizarListaDepartamentos()
        {
            try
            {
                ListaCompletaDepartamentoVM = new ObservableCollection<clsDepartamento>(clsListaDepartamentoBL.listadoCompletoDepartamentosBL());
            }catch(Exception e)
            {
                var toast = Toast.Make("Ocurrió algún problema en la conexión con la base de datos", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            NotifyPropertyChanged("ListaCompletaDepartamentoVM");
        }
    }
}
