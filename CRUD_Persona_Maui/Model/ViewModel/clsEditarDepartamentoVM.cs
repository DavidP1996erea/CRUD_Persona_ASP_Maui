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

namespace CRUD_Persona_Maui.Model.ViewModel.EditarDepartamento
{

    /// <summary>
    /// Con este comando se recoge el objeto enviado por la otra vista, también hay que implementar
    /// la clase IQueryAttributable para usar el objeto
    /// </summary>
    [QueryProperty (nameof(clsDepartamento), "departamentoEnviado")]
    public class clsEditarDepartamentoVM : clsVMBase, IQueryAttributable
    {

        #region Atributos
        private clsDepartamento departamentoRecogido;
        private DelegateCommand editarDepartamentoCommand;
        #endregion


        #region Propiedades

        public clsDepartamento DepartamentoRecogido
        {
            get { return departamentoRecogido; }
            set { departamentoRecogido= value;
                editarDepartamentoCommand.RaiseCanExecuteChanged();
            }
        }


        public DelegateCommand EditarDepartamentoCommand
        {
            get { return editarDepartamentoCommand; }
            set { editarDepartamentoCommand= value; }
        }

        #endregion


        #region Constructor por defecto

        public clsEditarDepartamentoVM()
        {
            // Se inicializa
            editarDepartamentoCommand = new DelegateCommand(editarDepartamentoCommand_Execute, editarDepartamentoCommand_CanExecute);

        }
        #endregion

        #region Commands
        /// <summary>
        /// Siempre devuelve true
        /// </summary>
        /// <returns></returns>
        private bool editarDepartamentoCommand_CanExecute()
        {
            return true;
        }

        /// <summary>
        /// Se introduce el departamento modificado en el método de la BL que hará lo necesario
        /// para que los cambios se hagan.
        /// </summary>
        private void editarDepartamentoCommand_Execute()
        {
            NotifyPropertyChanged("DepartamentoRecogido");
           

            int numeroFilasAfectadas;

            try
            {
                numeroFilasAfectadas = clsManejadoraDepartamentosBL.editarDepartamentoBL(departamentoRecogido);

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
        /// Método que viene de la interfaz IQueryAttributable, que recogerá el departamento enviado
        /// por la otra vista.
        /// </summary>
        /// <param name="query"></param>
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            DepartamentoRecogido = query["departamentoEnviado"] as clsDepartamento;
            NotifyPropertyChanged("DepartamentoRecogido");
        }
    }
    



    
}
