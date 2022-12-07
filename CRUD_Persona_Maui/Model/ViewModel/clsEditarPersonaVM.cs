using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CRUD_Persona.ViewModel.Utilidades;
using CRUD_Persona_BL;
using CRUD_Persona_Entidades;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Debug = System.Diagnostics.Debug;

namespace CRUD_Persona_Maui.Model.ViewModel.EditarPersona

{
    /// <summary>
    /// Con este comando se recoge el objeto enviado por la otra vista
    /// </summary>
    [QueryProperty(nameof(PersonaRecogida), "personaEnviar")]
    public partial class clsEditarPersonaVM : clsVMBase {


        #region Atributos
        private clsPersona personaRecogida;
        private ObservableCollection<clsDepartamento> litaDepartamentosCompleta = new ObservableCollection<clsDepartamento>(clsListaDepartamentoBL.listadoCompletoDepartamentosBL());
        private DelegateCommand editarPersonaCommand;
        private clsDepartamento departamentoRecogido;
        private int mostrarDepartamento;
        #endregion


        #region Propiedades
        public int MostrarDepartamento
        {
            get { 
                return mostrarDepartamento; }
            set { mostrarDepartamento = value; }
        }
        public clsDepartamento DepartamentoRecogido
        {
            get { return departamentoRecogido; }
            set { departamentoRecogido = value; }
        }
        public clsPersona PersonaRecogida
        {

            get {

                return personaRecogida;
                
            }

            set { 
                personaRecogida = value;
                                                             
                // Se llama al canExecute
                editarPersonaCommand.RaiseCanExecuteChanged();
                mostrarDepartamentoDePersona();
                NotifyPropertyChanged();
            }

        }

        public DelegateCommand EditarPersonaCommand
        {

            get { return editarPersonaCommand; }

            set { editarPersonaCommand = value;
               
            }

        }

        public ObservableCollection<clsDepartamento> ListaDepartamentosCompleta
        {
            get { return litaDepartamentosCompleta; }
            set { litaDepartamentosCompleta = value; }
        }

        #endregion

        #region Constructor por defecto
        public clsEditarPersonaVM() {

          
            // Se inicializa
            editarPersonaCommand = new DelegateCommand(editarPersonaCommand_Execute, editarPersonaCommand_CanExecute); 

           
        }
        #endregion


        #region Commands

        // Este método siempre devuelve true, para que el botón esté siempre activado
        private bool editarPersonaCommand_CanExecute()
        {
            return true;
        }


        /// <summary>
        /// Cuando se ejecuta, actualiza la personaRecogida con los nuevos datos, y luego 
        /// esta persona es enviada al método editarPersonaBL, donde se hará el proceso 
        /// necesario
        /// </summary>
        private void editarPersonaCommand_Execute()
        {
                     
            NotifyPropertyChanged("PersonaRecogida");
            NotifyPropertyChanged("DepartamentoRecogido");
            int numeroFilasAfectadas;
           
            PersonaRecogida.IDDepartamento = DepartamentoRecogido.ID;
            try
            {
                numeroFilasAfectadas = clsManejadoraPersonaBL.editarPersonaBL(PersonaRecogida); 

                // Se muestra un mensaje informativo al usuario
                if (numeroFilasAfectadas != 0)
                {

                    var toast = Toast.Make("Se editó con éxito", ToastDuration.Short).Show();

                }
            }
            catch (Exception e)
            {
                var toast = Toast.Make("Ocurrió algún problema", ToastDuration.Short).Show();

            }


        }


        #endregion



        /// <summary>
        /// Como los ids en la base de datos no están en orden, a veces falla
        /// en el picker. Por lo tanto, para que muestre correctamente el 
        /// departamento de la persona, se recoge en que indice de la lista 
        /// está.
        /// </summary>
      
        public void mostrarDepartamentoDePersona()
        {
            for(int i=0; i < ListaDepartamentosCompleta.Count; i++)
            {
               if(ListaDepartamentosCompleta[i].ID == PersonaRecogida.IDDepartamento+1)
                {
                    MostrarDepartamento = i;
                    NotifyPropertyChanged("MostrarDepartamento");
                }
            }

         

        }


    }
}
