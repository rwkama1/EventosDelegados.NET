using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de MateriaEventArgs
/// </summary>
//extiendo la clase de argumentos de eventos

public class MateriaEventArgs:EventArgs
{
    //atributos
    public Materia _LaMateria;
    //propiedades
    public Materia LaMateria
    {
        get { return _LaMateria; }
         
        
    }
    //Contructor
	public MateriaEventArgs(Materia pMateria)
	{
        _LaMateria = pMateria;
	}
}
//Como vamos a usar el criterio de Net Framework para la definicion de los delegados,el segundo
//parametro siempre son los argumentos del evento
//y en nuestro caso como argumento necesitamos una materia, por lo que,creamos una clase que herede 
//EventArgs de la clase base de los argumentos
//de eventos, y le creamos un atributo interno para contener a la materia a la que se quiere inscribir el alumno
//Esta propiedad se hace de solo lectura, ya que la materia no se deberia poder cambiar en medio del procesamiento del evento de inscripcion
