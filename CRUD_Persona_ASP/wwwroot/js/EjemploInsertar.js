window.onload = inicalizarEvento;

class Persona {
    constructor(nombre, apellidos, telefono, direccion, foto, fechaNacimiento, idDepartamento) {

        this.nombre = nombre;
        this.apellidos = apellidos;
        this.telefono = telefono;
        this.direccion = direccion;
        this.foto = foto;
        this.fechaNacimiento = fechaNacimiento;
        this.idDepartamento = idDepartamento;
    }

}


function inicalizarEvento() {

    document.getElementById("btnLlamada").addEventListener("click", insertar(personaInsertar),false)
}



function insertar(personaInsertar) {

    var personaInsertar = new Persona();
    personaInsertar.nombre = "David";
    personaInsertar.apellidos = "Perea Garcia";
    personaInsertar.telefono = "955667959";
    personaInsertar.direccion = "Islas caleares";
    personaInsertar.foto = "asda";
    personaInsertar.fechaNacimiento = "1923-01-01T00:00:00"
    personaInsertar.idDepartamento = 8;


    var miLlamada = new XMLHttpRequest();

    miLlamada.open("POST", "https://elcrud.azurewebsites.net/api/personasApi/");

    miLlamada.setRequestHeader("Content-Type", "application/json; charset=UTF-8")

    var json = JSON.stringify(personaInsertar);

    // Definicion estados

    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState < 4) {

            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
            alert("Cargando");
        }

        else
            

            if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                alert("Persona insertada con exito");

            }

    };

    miLlamada.send(json);

}