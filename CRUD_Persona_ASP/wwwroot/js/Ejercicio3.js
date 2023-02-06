window.onload = inicalizarEvento;


function inicalizarEvento() {
    document.getElementById("btnLlamada").addEventListener("click", pedirDatos, false)
}

function pedirDatos() {
    var divNombre = document.getElementById("nombrePersona")

    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "http://localhost:5277/API/personaApi");

    //Definicion estados
    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState < 4) {

            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
            divNombre.innerHTML = "Cargando...";
        }
        else
            if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                divNombre.innerHTML = "";
                var arrayPersonas = JSON.parse(miLlamada.responseText);

               


                generarTabla(arrayPersonas)
            


            }

    };





    miLlamada.send();
}

function generarTabla(arrayPersonas) {
    var tablaP = document.getElementById("tablaDatos");

    for (var i = 0; i < arrayPersonas.length; i++) {


        // Insertará una fila en la última posición
        var row = tablaP.insertRow(tablaP.rows.length);

        // Se insertará dos columnas en la fila creada
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        var cell3 = row.insertCell(2);

        // Se rellenará el contenido de las celdas de las columnas creadas anteriormente
        cell1.innerHTML = arrayPersonas[i].nombre;
        cell2.innerHTML = arrayPersonas[i].apellidos;
        

    }
}