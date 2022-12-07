using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CRUD_Persona.ViewModel.Utilidades;
using CRUD_Persona_BL;
using CRUD_Persona_Entidades;
using System.Collections.ObjectModel;


namespace CRUD_Persona_Maui.Model.ViewModel.InsertarPersona
{
    public class clsInsertarPersona : clsVMBase
    {

        #region Atributos
        private clsPersona personaAInsertar = new clsPersona();
        private clsDepartamento departamentoRecogido;
        private ObservableCollection<clsDepartamento> litaDepartamentosCompleta; 
        private DelegateCommand insertarPersonaCommand;
        #endregion

        #region Propiedades


        public clsDepartamento DepartamentoRecogido
        {
            get { return departamentoRecogido; }
            set { departamentoRecogido = value; }
        }
        public clsPersona PersonaInsertar
        {
            get
            {

                return personaAInsertar;
            }

            set
            {
                personaAInsertar = value;
                InsertarPersonaCommand.RaiseCanExecuteChanged();
            }
        }



        public ObservableCollection<clsDepartamento> ListaDepartamentosCompleta
        {
            get { return litaDepartamentosCompleta; }
            set { litaDepartamentosCompleta = value; }
        }


        public DelegateCommand InsertarPersonaCommand {
        
            get { return insertarPersonaCommand; } 
            set { insertarPersonaCommand = value; }
        }
        #endregion


        #region Constructor por defecto
        public clsInsertarPersona()
        {

            try
            {
                litaDepartamentosCompleta = new ObservableCollection<clsDepartamento>(clsListaDepartamentoBL.listadoCompletoDepartamentosBL());
            }
            catch(Exception e)
            {
                var toast = Toast.Make("Ocurrió algún problema en la conexión con la base de datos", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            insertarPersonaCommand = new DelegateCommand(insertarPersonaCommand_Execute, insertarPersonaCommand_CanExecute);
        }
        #endregion


        #region Commands
        /// <summary>
        /// Siempre devolverá true
        /// </summary>
        /// <returns></returns>
        private bool insertarPersonaCommand_CanExecute()
        {
            return true;
        }


        /// <summary>
        /// Este método pasa un objeto clsPersona como parámetro al método de la BL
        /// que se encarga de insertar a dicha persona
        /// </summary>
        private void insertarPersonaCommand_Execute()
        {
            int numeroFilasAfectadas;
            NotifyPropertyChanged("PersonaInsertar");
            if (DepartamentoRecogido != null)
            {
                PersonaInsertar.IDDepartamento = DepartamentoRecogido.ID;
            }
    
            try
            {
                numeroFilasAfectadas = clsManejadoraPersonaBL.insertarPersonaBL(PersonaInsertar);

                // Se muestra un mensaje informativo al usuario
                if (numeroFilasAfectadas != 0)
                {

                    var toast = Toast.Make("Se insertó con éxito", ToastDuration.Short).Show();

                }
            }
            catch(Exception e)
            {
                var toast = Toast.Make("Ocurrió algún problema", ToastDuration.Short).Show();

            }


            
        }
        #endregion
    }
}
