using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Universidad
/// </summary>
public class Universidad
{
    private List<Materia> _ListaMaterias;
    private List<Alumno> _ListaAlumnos;
    private string _Nombre;
    //Propiedades
    public List<Materia> ListaMaterias
    {
        get { return _ListaMaterias; }
    }
    public List<Alumno> ListaAlumnos
    {
        get { return _ListaAlumnos; }
    }
    public string Nombre
    {
        get { return _Nombre; }
        set { _Nombre = value; }
    }
	public Universidad(string pNombre)
	{
        _ListaAlumnos = new List<Alumno>();
        _ListaMaterias = new List<Materia>();
        Nombre = pNombre;
	}
    public void RegistrarAlumno(Alumno pAlumno)
    {

        _ListaAlumnos.Add(pAlumno);
    }
    public void RegistrarMateria(Materia pMateria)
    {

        _ListaMaterias.Add(pMateria);
    }
    public void RegistrarAlumnoMateria(Alumno pAlumno, Materia pMateria)
    {

        pMateria.RegistrarAlumno(pAlumno);
    }
}