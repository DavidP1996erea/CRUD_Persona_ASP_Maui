using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CRUD_Persona.ViewModel.Utilidades;
using CRUD_Persona_BL;
using CRUD_Persona_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Persona_Maui.Model.ViewModel.InsertarDepartamento
{
    public class clsInsertarDepartamentoVM : clsVMBase
    {
        #region Atributos
        private clsDepartamento departamentoInsertar = new clsDepartamento();
        private DelegateCommand insertarDepartamentoCommand;
        #endregion

        #region Propiedades
        public clsDepartamento DepartamentoInsertar
        {
            get { return departamentoInsertar; }
            set { departamentoInsertar = value;
                InsertarDepartamentoCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand InsertarDepartamentoCommand { 
            
            get { return insertarDepartamentoCommand;} 
            set { insertarDepartamentoCommand = value;}
        }
        #endregion


        #region Constructor por defecto
        public clsInsertarDepartamentoVM()
        {
            insertarDepartamentoCommand = new DelegateCommand(insertarDepartamentoCommand_Execute, insertarDepartamentoCommand_CanExecute);
        }
        #endregion

        #region Commands

        private bool insertarDepartamentoCommand_CanExecute()
        {
            return true;
        }

        private void insertarDepartamentoCommand_Execute()
        {
            NotifyPropertyChanged("DepartamentoInsertar");
        
            int numeroFilasAfectadas;
           
            try
            {
                numeroFilasAfectadas = clsManejadoraDepartamentosBL.insertarDepartamentoBL(DepartamentoInsertar);

                // Se muestra un mensaje informativo al usuario
                if (numeroFilasAfectadas != 0)
                {

                    var toast = Toast.Make("Se insertó con éxito", ToastDuration.Short).Show();

                }
            }
            catch (Exception e)
            {
                var toast = Toast.Make("Ocurrió algún problema", ToastDuration.Short).Show();

            }
        }
        #endregion


    }
}
