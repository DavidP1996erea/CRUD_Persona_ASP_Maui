window.onload = inicalizarEvento;


function inicalizarEvento() {
    document.getElementById("btnLlamada").addEventListener("click", pedirDatosPersonaPorID, false)
  
    pedirDatos();
}

function pedirDatos() {
 
    let miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "http://localhost:5277/Api/departamentosApi");
   
    //Definicion estados
    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState < 4) {

            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
            divNombre.innerHTML = "Cargando...";
        }
        else
            if (miLlamada.readyState == 4 && miLlamada.status == 200) {

               
                arrayDepartamentos = JSON.parse(miLlamada.responseText);

                
            }

    };

    miLlamada.send();
}

function pedirDatosPersonas() {
   
    var divNombre = document.getElementById("nombrePersona")

    let miLlamada = new XMLHttpRequest();
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
                arrayPersonas = JSON.parse(miLlamada.responseText);




                generarTabla(arrayPersonas)



            }

    };


    miLlamada.send();
}



function pedirDatosPersonaPorID() {

    var divNombre = document.getElementById("nombrePersona")

    let miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "http://localhost:5277/API/personaApi/67");

    //Definicion estados
    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState < 4) {

            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
            divNombre.innerHTML = "Cargando...";
        }
        else
            if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                divNombre.innerHTML = "";
                arrayPersonas = JSON.parse(miLlamada.responseText);




                
                divNombre.innerHTML = arrayPersonas.nombre;
                divNombre.innerHTML += " " + arrayPersonas.apellidos;

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
        cell3.innerHTML = generarDepartamentos((arrayPersonas[i].idDepartamento)+1);


    }
}



function generarDepartamentos(idDepartamento) {

    var nombreDepartamento;


    for (var i = 0; i < arrayDepartamentos.length; i++) {

        if (idDepartamento == arrayDepartamentos[i].id) {

            nombreDepartamento = arrayDepartamentos[i].nombre;
        }

    }


    return nombreDepartamento;
}