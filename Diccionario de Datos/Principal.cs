using System;
using System.Collections.Generic;
using System.Text;
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
        private bool nuevo, abierto;

        // Variables para uso del archivo
        BinaryWriter bw;
        BinaryReader br;

        // Variable que dice el tamaño del archivo
        BinaryWriter aBw;
        BinaryReader aBr;


        DataGridView grid;
        List<DataGridView> tablas = new List<DataGridView>();
        List<BinaryWriter> registro;

        private int renglon = 0;
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
            // bw.Write(Cab);
            nuevo = false;
            abierto = false;
            registro = new List<BinaryWriter>();


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
            

            atri = new Atributo();
            int cont;
            _nombre = textBox2.Text;
            cont = _nombre.Length;
            for(; cont < 29; cont++)
            {
                _nombre += " ";
            }
            if(atributo.Count == 0 )
            {
                atri.nombrate(_nombre);
                atri.ponteTipo(Convert.ToChar(comboTipo.SelectedItem));
                atri.ponteLongitud(Convert.ToInt32(textBox3.Text));
                atri.direccionate(bw.BaseStream.Length);
                atri.ponteTipoIndice(Convert.ToInt32(comboIndice.SelectedItem));
                atri.ponteDirIndice(-1);
                atri.ponteDirSig(-1);
                
              //  bw.Seek((int)bw.BaseStream.Length, SeekOrigin.Begin);
                bw.Write(atri.dameNombre());
                bw.Write(atri.dameTipo());
                bw.Write(atri.dameLongitud());
                bw.Write(atri.dameDireccion());
                bw.Write(atri.dameTI());
                bw.Write(atri.dameDirIndice());
                bw.Write(atri.dameDirSig());
                
            }
            else
            {
                atri.nombrate(_nombre);
                atri.ponteTipo(Convert.ToChar(comboTipo.SelectedItem));
                atri.ponteLongitud(Convert.ToInt32(textBox3.Text));
                atri.direccionate(bw.BaseStream.Length);
                atri.ponteTipoIndice(Convert.ToInt32(comboIndice.SelectedItem));
                atri.ponteDirIndice(-1);

                atributo[atributo.Count - 1].ponteDirSig(atri.dameDireccion());
                bw.Seek((int)bw.BaseStream.Length-8, SeekOrigin.Begin);
                bw.Write(atri.dameDireccion());
                bw.Write(atri.dameNombre());
                bw.Write(atri.dameTipo());
                bw.Write(atri.dameLongitud());
                bw.Write(atri.dameDireccion());
                bw.Write(atri.dameTI());
                bw.Write(atri.dameDirIndice());
                bw.Write(atri.dameDirSig());

            }
            atributo.Add(atri);
            imprimeAtributo(atributo);
           
            dataGridView3.Columns.Add(enti.dameNombre(), atri.dameNombre());
            dataGridView4.Columns.Add(enti.dameNombre(), atri.dameNombre());

            //tabControl1.TabPages[tablas.Count+1].Controls.Add(tablas[tablas.Count-1]);
            //registro[registro.Count - 1].Write(dataGridView3.Rows.ToString());

            /*
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
            */

        }
        /*************************************************************************************************
         *              Seleccion de entidad para el atributo
         *************************************************************************************************/
        

        private void seleccionaEntidad(object sender, EventArgs e)
        {
            string nEntidad;
            nEntidad = comboBox1.Text;
            nEntidad += ".dat";

            // Ciclo while que limpia el datagrid de los atributos
            while (dataGridView2.RowCount > 0)
                dataGridView2.Rows.Remove(dataGridView2.CurrentRow);

         
            registro.Add(new BinaryWriter(File.Open(nEntidad,FileMode.Create)));
            
            /*
            tabControl1.TabPages.Add(comboBox1.Text);
            tabControl1.TabIndex = entidad.Count;
            grid = new DataGridView();
            grid.Width = 8000;
            tablas.Add(grid);
            */
           




            /*
            bw.Close();
            long tam;
            br = new BinaryReader(File.Open("Entidad.bin", FileMode.Open));
           

   
            tam = 0;
            cabecera.Text = br.ReadInt64().ToString();
            while (tam < br.BaseStream.Length && br.ReadString() != "ALTO")
            {
                enti = new Entidad();

                enti.nombrate(br.ReadString());
                comboBox1.Items.Add(enti.dameNombre());
                enti.direccionate(br.ReadInt64());
                enti.ponteDireccionAtributo(br.ReadInt64());
                enti.ponteDireccionRegistro(br.ReadInt64());
                enti.ponteDireccionSig(br.ReadInt64());
                entidad.Add(enti);
                imprimeLista(entidad);
                tam = br.BaseStream.Position;
            }

            br.Close();
            bw = new BinaryWriter(File.Open("Entidad.bin", FileMode.Open));
            */




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
            button8.Hide();
            long tam;
            long sig;
            if(nuevo)
                bw.Close();
            br = new BinaryReader(File.Open("Entidad.bin", FileMode.Open));
            button7.Hide();
            string swap;
            
            tam = 0;
            cabecera.Text = br.ReadInt64().ToString();
            while (tam < br.BaseStream.Length)
            {
                enti = new Entidad();

                //swap = enti.dameDA
                 
                enti.nombrate(br.ReadString());
                comboBox1.Items.Add(enti.dameNombre());
                enti.direccionate(br.ReadInt64());
                enti.ponteDireccionAtributo(br.ReadInt64());
                enti.ponteDireccionRegistro(br.ReadInt64());
                sig = br.ReadInt64();
                
                if (sig == -1 && tam < br.BaseStream.Length)
                {
                    enti.ponteDireccionSig(sig);
                    entidad.Add(enti);
                    imprimeLista(entidad);
                    abreAtributos(br, tam);
                    break;
                    
                }
                else
                {
                    enti.ponteDireccionSig(sig);
                    entidad.Add(enti);
                    imprimeLista(entidad);
                }
                tam = br.BaseStream.Position;


            }

            br.Close();
            bw = new BinaryWriter(File.Open("Entidad.bin", FileMode.Open));



        }
        private void abreAtributos(BinaryReader br, long tam)
        {
            //tam = br.BaseStream.Position;
            while (tam < br.BaseStream.Length)
            {
                atri = new Atributo();
                atri.nombrate(br.ReadString());
                atri.ponteTipo(br.ReadChar());
                atri.ponteLongitud(br.ReadInt32());
                atri.direccionate(br.ReadInt64());
                atri.ponteTipoIndice(br.ReadInt32());
                atri.ponteDirIndice(br.ReadInt64());
                atri.ponteDirSig(br.ReadInt64());
                atributo.Add(atri);
                
                tam = br.BaseStream.Position;
            }
            imprimeAtributo(atributo);
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        /***********************************************************************************
         * 
         *  Metodo que adquiere el renglon del datagrid y lo manda a uno nuevo ademas de 
         *  guardarlo en un archivo
         * 
         * 
         * *********************************************************************************/
        private void insertarRegistro_Click(object sender, EventArgs e)
        {
            int j;
            long dir;
            dir = -1;
            string _nombre;
            
            dataGridView4.Rows.Add();
            for (j = 0; j <= dataGridView3.Columns.Count; j++)
            {
                if(renglon == 0)
                {
                    dataGridView4.Columns.Add("Direccion Siguiente Registro", "Direccion Siguiente Registro");
                }
                if(j == 0)
                {
                    registro[registro.Count-1].Write(registro[registro.Count - 1].BaseStream.Length);
                    dataGridView4.Rows[renglon].Cells[j].Value = registro[registro.Count-1].BaseStream.Length;
                    
                }
                else if(j >= 1)
                {
                    dataGridView4.Rows[renglon].Cells[j].Value = dataGridView3.Rows[0].Cells[j-1].Value.ToString();
                    registro[registro.Count - 1].Write(dataGridView4.Rows[renglon].Cells[j].Value.ToString());
                    
                }
                
            }
            dataGridView4.Rows[renglon].Cells[j].Value = registro[registro.Count-1].BaseStream.Length;
            renglon++;
            


        }
        
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            registro[registro.Count - 1].Close();
        }

 
        private void nuevoProyecto(object sender, EventArgs e)
        {
            bw = new BinaryWriter(File.Open("Entidad.bin", FileMode.Create));
            bw.Write(Cab);
            nuevo = true;
            button7.Hide();
            button8.Hide();

        }

        //Metodo que elimina la entidad
        private void eliminaEntidad(object sender, EventArgs e)
        {
            _nombre = textBox1.Text;
            int z = _nombre.Length;
            for(;z< 29; z++)
            {
                _nombre += " ";
            }

            string nombre2;

            int i;
            for (i = 0; i < entidad.Count; i++ )
            {
                nombre2 = entidad[i].dameNombre();
                if(i == 0 && nombre2 == _nombre)
                {
                    entidad[i].ponteDireccionSig(-1);
                    entidad[i].direccionate(-1);
                    entidad[i].nombrate("Eliminado");
                    dataGridView1.Rows.RemoveAt(i);
                    break;
                }
                if (nombre2 == _nombre)
                {
                   // MessageBox.Show("Encontrado");
                    entidad[i - 1].ponteDireccionSig(entidad[i].dameDSIG());
                    entidad[i].nombrate("Eliminado");
                    entidad[i].direccionate(-1);
                    entidad[i].ponteDireccionSig(-1);
                    dataGridView1.Rows.RemoveAt(i-1);
                    break;

                    
                }
                
            }
            
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
