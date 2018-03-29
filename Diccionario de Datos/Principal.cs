using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
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
    	//Declaraciones de variables para mover la pantalla
    	private int posx;
    	private int posy;

        // Declaracion de variables para el uso de la Entidad
    	private Entidad enti; 
        private string _nombre;
        private char[] aux = new char[20];
        private List<Entidad> entidad; // Lista de Entidades
        private long Cab, dir;
        private List<int> letras; // Lista de nombre de entidad


        //Variables para la clase Atributo
        private Atributo atri;
        private List<Atributo> atributo;
        private string nombreAtri;

        private bool band, band2;

        // Variables para uso del archivo
        BinaryWriter bw = new BinaryWriter(File.Open("Entidad.bin", FileMode.Create));
        BinaryReader br; 

        

    	//Constructor de la clase principal
        public Principal()
        {
            InitializeComponent();
            posx = 0;
            posy = 0;
           // enti = new Entidad();
            entidad = new List<Entidad>();
            letras = new List<int>();
            Cab = -1;
            atri = new Atributo();
            atributo = new List<Atributo>();
            band = false;
            band2 = false;
            bw.Write(Cab);
            
            
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
            int cont;
            _nombre = textBox1.Text;
            comboBox1.Items.Add(_nombre); //Agrega las entidades al comboBox de atributo
            cont = _nombre.Length;
            for(;cont < 29; cont++)
            {
                _nombre += " ";
            }
            if(entidad.Count == 0)
            {
                enti.nombrate(_nombre);
                enti.direccionate(bw.BaseStream.Length);
                enti.ponteDireccionAtributo(-1);
                enti.ponteDireccionRegistro(-1);
                enti.ponteDireccionSig(-1);

                bw.Seek(0, SeekOrigin.Begin);
                bw.Write(enti.dameDE());
                bw.Write(enti.dameNombre());
                bw.Write(enti.dameDE());
                bw.Write(enti.dameDA());
                bw.Write(enti.dameDD());
                bw.Write(enti.dameDSIG());


            }
            else
            {
                enti.nombrate(_nombre);
                enti.direccionate(bw.BaseStream.Length);
                enti.ponteDireccionAtributo(-1);
                enti.ponteDireccionRegistro(-1);
                enti.ponteDireccionSig(-1);
                entidad[entidad.Count - 1].ponteDireccionSig(enti.dameDE());
                bw.Seek((int)bw.BaseStream.Length-8, SeekOrigin.Begin);

                bw.Write(enti.dameDE());
                bw.Write(enti.dameNombre());
                bw.Write(enti.dameDE());
                bw.Write(enti.dameDA());
                bw.Write(enti.dameDD());
                bw.Write(enti.dameDSIG());
            }
            entidad.Add(enti);
           
            imprimeLista(entidad);
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
            int tam = e.Count;
            Entidad aux = new Entidad();
            //Algoritmo de Ordenación
            letras = ordenaNombre(e, letras);

            for (i = 0; i < tam; i++ )
            {
                //for (j = 0; j < i; j++ )
                //{
                    if (letras[j] > letras[i])
                    {
                      e[i].ponteDireccionSig(e[j].dameDE());
                  
                    }
              //  }


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
        // Metodos para los atributos ******************************************************************
        private void nombraAtributo(object sender, EventArgs e)
        {
            nombreAtri = textBox2.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        /*********************************************************************************
         *      Boton Crear Atributo
         *********************************************************************************/
        private void creaAtributo(object sender, EventArgs e)
        {
            imprimeLista(entidad);
            atri = new Atributo();
            long diraux;
            if (!band2){
                atri.direccionate(enti.dameDE() + 62);
                diraux = atri.dameDireccion();
                band2 = true;
            }
            atri.nombrate(nombreAtri);
            if(band){
                
                atri.ponteDirSig(-1);
                band = false;
            }
            else
            {
                atri.direccionate(atributo[atributo.Count - 1].dameDireccion() + 63);
                atributo[atributo.Count - 1].ponteDirSig(atri.dameDireccion());
            }
            if(atributo.Count > 1)
                atri.direccionate(atributo[atributo.Count - 1].dameDireccion() + 63);
            atri.ponteTipo(char.Parse(comboBox2.Text));
            atri.ponteLongitud(Convert.ToInt32(textBox3.Text));
            atri.ponteTipoIndice(Convert.ToInt32(comboBox3.Text));
            atri.ponteDirIndice(-1);
            atributo.Add(atri);
            imprimeAtributo(atributo);
            
        }
        /*************************************************************************************************
         *              Seleccion de entidad para el atributo
         *************************************************************************************************/
        private void seleccionaEntidad(object sender, EventArgs e)
        {
            string nEntidad;
            int i;
            nEntidad = comboBox1.Text;
            for (i = 0; i < entidad.Count; i++)
            {
                if (nEntidad == entidad[i].dameNombre())
                {

                    if (!band2)
                        entidad[i].ponteDireccionAtributo(entidad[entidad.Count - 1].dameDE() + 62);
                    else
                        entidad[i].ponteDireccionAtributo(atri.dameDireccion()+63);
                    imprimeLista(entidad);
                    
                }
            }
            
            band = true;
           
            
        }
        private void imprimeAtributo(List<Atributo> atri)
        {
            dataGridView2.Rows.Clear();
            foreach (Atributo a in atri){
                dataGridView2.Rows.Add(a.dameNombre(), a.dameTipo(), a.dameLongitud(), a.dameDireccion(), a.dameTI(), a.dameDirIndice(), a.dameDirSig());
            }
        }
        /*****************************************************************************
         * 
         * Metodo que permite abrir el archivo y lo envia a uno nuevo
         * 
         *****************************************************************************/
        private void abreArchivo(object sender, EventArgs e)
        {
            long tam;
            bw.Close();
            br = new BinaryReader(File.Open("Entidad.bin", FileMode.Open));
            
            tam = 0;
            MessageBox.Show(br.ReadInt64().ToString());
            while (tam < br.BaseStream.Length)
            {
                MessageBox.Show(br.ReadString());
                MessageBox.Show(br.ReadInt64().ToString());
                MessageBox.Show(br.ReadInt64().ToString());
                MessageBox.Show(br.ReadInt64().ToString());
                MessageBox.Show(br.ReadInt64().ToString());
                tam += br.BaseStream.Position;
            }



        }

        //Metodo que elimina la entidad
        private void eliminaEntidad(object sender, EventArgs e)
        {
            _nombre = textBox1.Text;
            int i;
            for (i = 0; i < entidad.Count; i++ )
            {

                if (entidad[i].dameNombre() == _nombre)
                {
                    entidad[i - 1].ponteDireccionSig(entidad[i].dameDSIG());
                    entidad[i].direccionate(-1);
                    entidad[i].ponteDireccionSig(-1);
                    break;
                }
                
            }
            dataGridView1.Rows.RemoveAt(i);
            imprimeLista(entidad);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string nn = textBox2.Text;
            int i;
            for (i = 0; i < atributo.Count; i++)
            {
                if (atributo[i].dameNombre() == nn)
                {
                    atributo[i - 1].ponteDirSig(atributo[i].dameDirSig());
                    atributo[i].direccionate(-1);
                    atributo[i].ponteDirSig(-1);
                    break;

                }
            }
            dataGridView2.Rows.RemoveAt(i);
            imprimeAtributo(atributo);
        }   
    }
}
