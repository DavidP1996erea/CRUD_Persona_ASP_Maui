window.onload = inicalizarEvento;

class Persona {
    constructor(nombre, apellidos, telefono, direccion, foto, fechaNacimiento, idDepartamento) {
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.telefono = telefono;
        this.direccion = direccion;
        this.foto = foto;
        this.fechaNacimiento = fechaNacimiento;
        this.idDepartamento = idDepartamento
    }
}

function inicalizarEvento() {
    let personaInsertar = new Persona();
    personaInsertar.nombre = "Ruben";
    personaInsertar.apellidos = "Londres Javier Muletas";
    personaInsertar.telefono = "11112222";
    personaInsertar.direccion = "calle Hernán Cortéz 37";
    personaInsertar.foto = "cerrejo azulado";
    personaInsertar.fechaNacimiento = "2015-03-14T00:00:00";
    personaInsertar.idDepartamento = 8;

    document.getElementById("btnLlamada").addEventListener("click", insertar(personaInsertar), false)
}




function insertar(Persona) {

    var miLlamada = new XMLHttpRequest();
  
    miLlamada.open("PUT", "http://localhost:5277/API/personaApi/97/");

  
    miLlamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');

    var json = JSON.stringify(Persona);
    // Definicion estados

    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState < 4) {

            //aquí se puede poner una imagen de un reloj o un texto “Cargando”

        }

        else

            if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                alert("Persona insertada con exito");

            }

    };

    miLlamada.send(json);

}