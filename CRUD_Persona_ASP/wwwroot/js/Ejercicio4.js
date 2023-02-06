window.onload = inicalizarEvento;


function inicalizarEvento() {
    document.getElementById("btnLlamada").addEventListener("click", pedirDatos, false)
}



function pedirDatos() {
    var divNombre = document.getElementById("nombrePersona")
    var inputBorrar = document.getElementById("inpId");
    var miLlamada = new XMLHttpRequest();


    miLlamada.open("Delete", "https://elcrud.azurewebsites.net/api/personasApi/" + inputBorrar.value);


    //Definicion estados
    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState < 4) {

            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
            divNombre.innerHTML = "Cargando...";

        }

        if (miLlamada.readyState == 4 && miLlamada.status == 200) {

  
            if (miLlamada.responseText == 1) {
                divNombre.innerHTML = "Persona borrada con éxito";
            } else if (miLlamada.responseText == 0) {
                divNombre.innerHTML = "Esta persona no existe";
            }
        }
       
    };
    miLlamada.send();


}
