using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Materia
/// </summary>
 public delegate void InscripcionMateriasEventHandler(object sender,MateriaEventArgs e);
public class Materia
{
    //atributos
    private string _Nombre;
    private List<Alumno> _ListaAlumnos;
    //propiedades
    public string Nombre
    {
        get{return _Nombre;}
        set{_Nombre=value;}
    }
    public List<Alumno> ListaAlumnos
    {
        get{return _ListaAlumnos;}
       
    }
    //contructor
	public Materia(string pMateria)
	{
        Nombre=pMateria;
        _ListaAlumnos=new List<Alumno>();
		
	}
    //operaciones
    public void RegistrarAlumno(Alumno pAlumno)
    {
        foreach (Alumno A in this._ListaAlumnos)
        {
            if(A.ToString()==pAlumno.ToString())
                throw new Exception("Alumno ya inscripto en la Materia");
        }

        _ListaAlumnos.Add(pAlumno);
    }
    public event InscripcionMateriasEventHandler InscripcionMateria;
    public void InscribirMateria(Materia pMateria)
    {
        InscripcionMateria(this, new MateriaEventArgs(pMateria));//esta invocacion de evento,hace que el objeto valla a verificar, si para ese evento
        //se le asigna un delegado apuntando a un controlador, en caso de que tenga un delegado apuntando un controlador ejecuta dicho metodo
    }
}