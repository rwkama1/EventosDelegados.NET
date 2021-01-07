using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Alumno
/// </summary>
//definicion del delegado para el evento del alumno----------------
public delegate void InscripcionMateriaEventHandler(object sender,MateriaEventArgs e);
//El primer parametro siempre va ser un alumno, ya que es el alumno el que se inscribe a una materia
//y en el segundo parametro como argumento va a venir incluida la materia a la que se va a inscribir
//Recordar que estos datos no va tener remitente al evento, el cual se lo va a pasar al mensaje que me dice que se provoco el evento
//este se lo pasa al delegado y el delegado se lo pasa al controlador del evento
public class Alumno
{
    //atributo
    private string _Nombre;
    private string _Apellido;
    //propiedades
    public string Nombre
    {
        get { return _Nombre; }
        set { _Nombre = value; }
    }
    public string Apellido
    {
        get { return _Apellido; }
        set { _Apellido = value; }
    }
    //Contructor
	public Alumno(string pNombre,string pApellido)
	{
        Nombre = pNombre;
        Apellido = pApellido;
	}
    public override string ToString()
    {
        return (_Nombre + " " + _Apellido);
    }
    //eventos-defino que eventos se pueden capturar
    //Habra que asignarsele un controlador de eventos
    public event InscripcionMateriaEventHandler InscripcionMateria;
    //que al poner el evento dentro la clase alumno,lo que estamos haciendo, es que cada objeto alumno que se cree,
    //pueda asignarle su propio codigo al evento inscribirse materia
    //el delegado es necesario porque es el que indica la firma del evento y del controlador asociado

    //metodo el alumno que genera el evento
    public void InscribirMateria(Materia pMateria)
    {
        InscripcionMateria(this, new MateriaEventArgs(pMateria));//esta invocacion de evento,hace que el objeto valla a verificar, si para ese evento
        //se le asigna un delegado apuntando a un controlador, en caso de que tenga un delegado apuntando un controlador ejecuta dicho metodo
    }
}

