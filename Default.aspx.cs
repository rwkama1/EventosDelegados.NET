using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page 
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Universidad _unaUniversidad = null;
            if (!IsPostBack)
            {
                //como es el primer ingreso al sitio web
                //1) Universidad
                _unaUniversidad = new Universidad("Bios");
                //2) Materia
                _unaUniversidad.RegistrarMateria(new Materia("App Distribuidas"));
                _unaUniversidad.RegistrarMateria(new Materia("Base de datos"));
                //Guardo en la sesion
                Session["MiUniversidad"] = _unaUniversidad;
                //Cargo Listbox de despliegue
                LbAlumnos.DataSource = _unaUniversidad.ListaAlumnos;
                LbAlumnos.DataTextField = "Apellido";
                LbAlumnos.DataBind();
                LbMaterias.DataSource = _unaUniversidad.ListaMaterias;
                LbMaterias.DataTextField = "Nombre";
                LbMaterias.DataBind();
            }
        }
        catch (Exception ex)
        {

            LblError.Text = ex.Message;
        }

        
  
    }

    protected void BtnAgregarAlumno_Click(object sender, EventArgs e)
    {
        try
        {
            Universidad _miUniversidad = (Universidad)Session["MiUniversidad"];
            //creo un alumno y le asigno el controlador de eventos para Inscripcion
            Alumno _unAlumno = new Alumno(TxtNom.Text.Trim(), TxtApe.Text.Trim());

            _unAlumno.InscripcionMateria += new InscripcionMateriaEventHandler(InscribirAlumnoMateria);
            _miUniversidad.RegistrarAlumno(_unAlumno);
            TxtNom.Text = "";
            TxtApe.Text = "";
            //refresco la lista
            LbAlumnos.Items.Clear();
            LbAlumnos.DataSource = _miUniversidad.ListaAlumnos;
            LbAlumnos.DataBind();


        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
        
    }

    protected void BtnInscribir_Click(object sender, EventArgs e)
    {
        try
        {
            Universidad _miUniversidad = (Universidad)Session["MiUniversidad"];
            //obtengo el alumno
            Alumno _unAlumno = _miUniversidad.ListaAlumnos[LbAlumnos.SelectedIndex];
            //obtengo materia
            Materia _unMateria = _miUniversidad.ListaMaterias[LbMaterias.SelectedIndex];
            //invoco metodo del alumno que genera el evento
            _unAlumno.InscribirMateria(_unMateria);
         LbAlumnoInscripto.DataSource = _miUniversidad.ListaAlumnos;
            LbAlumnoInscripto.DataTextField = "Apellido";
            LbAlumnoInscripto.DataBind();
        }
        catch (Exception ex)
        {
            LblError.Text=ex.Message;
        }
    }
    //controlador del evento del alumno
    private void InscribirAlumnoMateria(object sender, MateriaEventArgs e)
    {
        try
        {
            Universidad _miUniversidad = (Universidad)Session["MiUniversidad"];
            _miUniversidad.RegistrarAlumnoMateria((Alumno)sender, e.LaMateria);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //Los parametros que recibe mi controlador, se los da el delegado y recordar que al delegado se los da el mensaje resultado de provocar el evento
    //

    protected void btnAgregarMateria_Click(object sender, EventArgs e)
    {
        try
        {
            Universidad _miUniversidad = (Universidad)Session["MiUniversidad"];
            //creo un alumno y le asigno el controlador de eventos para Inscripcion
            Materia _unaMateria = new Materia(TxtNom.Text.Trim());

            _unaMateria.InscripcionMateria += new InscripcionMateriasEventHandler(InscribirAlumnoMateria);
            _miUniversidad.RegistrarMateria(_unaMateria);
            TxtNom.Text = "";
            
            //refresco la lista
            LbMaterias.Items.Clear();
          LbMaterias.DataSource = _miUniversidad.ListaMaterias;
            LbMaterias.DataBind();


        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
}
