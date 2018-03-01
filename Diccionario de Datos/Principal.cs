using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/**********************************************************************************************************************
 * Proyecto:	Diccionario de Datos 
 * Autor:		Héctor Andrey Hernández Alonso	 
 * Creación:	27/Febrero/2018
 * 
 *
 **********************************************************************************************************************/

namespace Diccionario_de_Datos
{
    public partial class Principal : Form
    {
    	//Declaraciones de variables
    	private int posx;
    	private int posy;
    	private Entidad entidad;
        private string _nombre;
        private char[] aux = new char[20];

    	//Constructor de la clase principal
        public Principal()
        {
            InitializeComponent();
            posx = 0;
            posy = 0;
            entidad = new Entidad();
        } 
        #region Configuracion Formulario
        //Metodo que permite mover la ventana con el mouse dando clic
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
        	if(e.Button != MouseButtons.Left){
        		posx = e.X;
        		posy = e.Y;
        	}
        	else{
        		Left = Left + (e.X - posx);
        		Top  = Top  + (e.Y - posy);
        	}
        }
        //Opcion cerrar
        private void Cierrate(object sender, MouseEventArgs e)
        {
            this.Close();
        }
        //Opcion minimizar
        private void minimizate(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void creaEntidad(object sender, EventArgs e)
        {
            
            entidad.nombrate(_nombre);
            entidad.direccionate(70);
            entidad.ponteDireccionAtributo(-1);
            entidad.ponteDireccionRegistro(-1);
            entidad.ponteDireccionSig(-1);
           
            dataGridView1.Rows.Add(Convert.ToString(entidad.dameNombre()),entidad.dameDE(),entidad.dameDA(),entidad.dameDD(),entidad.dameDSIG() );
        }

        private void nombraEntidad(object sender, EventArgs e)
        {
            _nombre = textBox1.Text;
        }
    }
}
