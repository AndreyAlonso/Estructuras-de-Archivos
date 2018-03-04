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
    	private Entidad enti; // Instancia de objeto de la clase entidad
        private string _nombre;
        private char[] aux = new char[20];
        private List<Entidad> entidad; // Lista de Entidades
        private long Cab, dir;
        private List<int> letras; // Lista de nombre de entidad

    	//Constructor de la clase principal
        public Principal()
        {
            InitializeComponent();
            posx = 0;
            posy = 0;
           // enti = new Entidad();
            entidad = new List<Entidad>();
            letras = new List<int>();
            Cab = 8;
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
            enti = new Entidad();
            
            /***********************************************
             * 
             * Condicional donde  si la lista está vacia se toman los valores por default y si no está 
             * vacia se hace un algoritmo de ordenación
             * 
             ***********************************************/
            enti.nombrate(_nombre);
            if (entidad.Count == 0)
            {
                enti.direccionate(Cab);
                enti.ponteDireccionAtributo(-1);
                enti.ponteDireccionRegistro(-1);
                enti.ponteDireccionSig(-1);
                dir = Cab + 62;
                entidad.Add(enti);
                
            }
            else
            {
              //  entidad[entidad.Count - 1].ponteDireccionSig(dir);
                
                enti.direccionate(dir);
                enti.ponteDireccionAtributo(-1);
                enti.ponteDireccionRegistro(-1);
                enti.ponteDireccionSig(-1); 
                entidad.Add(enti);
                dir = dir + 62;
                entidad = ordenate(entidad, dir, letras);
                
            }
           
            
            imprimeLista(entidad);
        }

        private void nombraEntidad(object sender, EventArgs e)
        {
            _nombre = textBox1.Text;
        }

        // Metodo que muestra la lista en el datagrid
        private void imprimeLista(List<Entidad> enti)
        {
            // Limpia el datagrid para una nueva inserción
            dataGridView1.Rows.Clear(); 
            //Ciclo que inserta las entidades en el datagrid
            foreach(Entidad i in enti){
                dataGridView1.Rows.Add(i.dameNombre(),i.dameDE(),i.dameDA(),i.dameDD(),i.dameDSIG());
            }
        }
        //Metodo que ordena la lista
        private List<Entidad> ordenate(List<Entidad> e, long dir, List<int> letras)
        {
            int j, i;
            j = 0;
            Entidad aux = new Entidad();
            //Algoritmo de Ordenación
            letras = ordenaNombre(e, letras);

            for (i = 0; i < e.Count; i++ )
            {
                for (j = 0; j < i; j++)
                {
                    if (letras[j] > letras[i])
                    {
                        aux.direccionate(e[j].dameDE());
                        e[j].direccionate(e[i].dameDE());
                       e[i].direccionate(aux.dameDE());
                    }
                }

            }
            return e;
        }

        //Metodo que hace una lista con el valor numerico de la primer letra de cada entidad
        private List<int> ordenaNombre(List<Entidad> e, List<int> c)
        {
            
            int nombre;
            foreach (Entidad i in e)
            {
                nombre = Encoding.ASCII.GetBytes(i.dameNombre())[0];
                c.Add(nombre);
            }
            return c;

        }
    }
}
