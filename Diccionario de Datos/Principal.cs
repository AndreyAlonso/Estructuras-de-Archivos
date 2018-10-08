using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Linq;
/****************************************************************************************************************
* Proyecto:	    Diccionario de Datos                                                                            *
* Autor:		Héctor Andrey Hernández Alonso	                                                                *
* Creación:	    27/Febrero/2018                                                                                 *
* Clases:       Principal, Entidad, Atributo, Archivo.                                                          *
*****************************************************************************************************************/

namespace Diccionario_de_Datos
{
    public partial class Principal : Form
    {
        #region Variables Globales
        // VARIABLE ARCHIVO
        public string nArchivo;
        public long posicion;
        public long pSig;
        public int posArchivo = 0;

        List<string> datos = new List<string>();
        List<string> indi = new List<string>();



        public int TR;

        /*  VARIABLE PARA INDICES SECUNDARIOS */
        int valor = 0;
        List<string> secundarios = new List<string>();
        List<int> iSecundarios = new List<int>();

        ListaSecundario indiceSec;
        List<ListaSecundario> ListSec = new List<ListaSecundario>();



        /****************************************************************************************************
         *                                                                                  INDICE SECUNDARIO
         ****************************************************************************************************/
         long[,] indiceSecundario;
         int topeClave;
         int[] tope;
        //bool primero;
         int pos;
         int cont;


         int poSI = 0;
        /*****************************************************************************************************/

        /*****************************************************************************************************
         *                                                                                  ARBOL B+
         *****************************************************************************************************/
         private Arbol nodo;
         private Arbol arbol = new Arbol();
         private List<Arbol> Arbol = new List<Arbol>();
         int cont2 = 0;



         public struct TNodo
         {
            public int cp;
            public long dir;
        }

        /*****************************************************************************************************/
        private int Col;
        private int Ren;




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


        private List<string> listaAtributos = new List<string>();

        //Variables para la clase Atributo
        private Atributo atri;
        private List<Atributo> atributo;
        private string nombreAtri;
        private int longi;

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
        List<BinaryWriter> indice;

        private int renglon = 0;
        private int contador;
        //Constructor de la clase principal

        // variable para detectar los tipos de indices
        private int tipoIndice;
        List<string> reg = new List<string>();
        List<string> registros = new List<string>();
        List<indices> listaIndices = new List<indices>();
        // Lista de claves para enviar a los indices
        List<indicep> claves;
        string nombre_indice;
        public struct indices
        {
            public int val;
            public int tipo;
        }

        BinaryWriter fRegistro;
        BinaryWriter fIndice;

        // VARIABLES PARA ENLAZAR ATRIBUTOS CON SU ENTIDAD
        bool nuevoAtributo;
        bool botonAtributo;
        string sEntidad;

        // Estructura de tipo indice primario
        public struct indicep
        {
            public int clave;
            public long dir;
        }
        private indicep temp;

        //   VARIABLES PARA EL MANEJO DEL ARBOL B+

        private int tam;


        //
        int[] claveSecundario;
        // long[,] indiceSecundario;
        int iRen;
        int iCol;
        int iCol2;

        #endregion
        public int primero;
        #region Lista Registro
        Registro regi;
        List<Registro> lRegistro;
        #endregion
        #region Constructor
        /***********************************************************************************************************
     *  CONSTRUCTOR DE LA CLASE PRINCIPAL   
     ***********************************************************************************************************/
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
        longi = 0;
        contador = 0;
        nuevoAtributo = false;
        botonAtributo = false;
        indice = new List<BinaryWriter>();
        tipoIndice = 0;
        tam = 0;
        primero = 0;
        lRegistro = new List<Registro>();


    }
        #endregion
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
        #region Algoritmos Entidad
private void creaEntidad(object sender, EventArgs e)
{
    enti = new Entidad();
    List<string> nombresOrdenados = new List<string>();
    long Cab = -1;
    long dir = -1;
    pSig = -1;
    int cont;
    _nombre = textBox1.Text;
          //  comboBox1.Items.Add(_nombre); //Agrega las entidades al comboBox de atributo

    cont = _nombre.Length;
    for (; cont < 29; cont++){
        _nombre += " ";
    }
    cEntidadRegistro.Items.Add(_nombre);
            //comboBox6.Items.Add(_nombre);
    if (entidad.Count == 0)
    {
        enti.nombrate(_nombre);
        enti.direccionate(bw.BaseStream.Length);
        enti.ponteDireccionAtributo(-1);
        enti.ponteDireccionRegistro(-1);
        enti.ponteDireccionSig(-1);

        bw.Seek(0, SeekOrigin.Begin);
                bw.Write(enti.dameDE()); // Cabecera
                cabecera.Text = enti.dameDE().ToString();
                Cab = enti.dameDE();
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
                dir = buscaEntidad(enti.dameNombre()); // Se obtiene la dirección de la entidad siguiente
                enti.ponteDireccionSig(dir);
                //MessageBox.Show("Valor de dir: " + dir);

                if (posicion == 1) // Actualización de Cabecera
                {
                    bw.Seek(0, SeekOrigin.Begin);
                    cabecera.Text = enti.dameDE().ToString();
                    Cab = enti.dameDE();
                    bw.Write(Cab);
                }
                //MessageBox.Show("pSig: " + pSig);
                // entidad[entidad.Count - 1].ponteDireccionSig(pSig);
                bw.Seek((int)bw.BaseStream.Length, SeekOrigin.Begin); //Posiciona al final del Archivo 

             //   bw.Write(enti.dameDE());
                bw.Write(enti.dameNombre());
                bw.Write(enti.dameDE());
                bw.Write(enti.dameDA());
                bw.Write(enti.dameDD());
                bw.Write(enti.dameDSIG());
            }
            entidad.Add(enti);

            imprimeLista(entidad);

        }
        public long buscaEntidad(string entidad)
        {
            // Variables locales 
            long aux = -1; // apuntador que recorrera el archivo
            long TAM;
            long dirEntidad = 0;
            long sigEntidad = 0;
            long principio;
            string nEntidad;
            int compara;
            long antA = 0;
            long sigA;


            //Se cierra el archivo de escritura
            bw.Close();

            //Se crea un objeto de lectura
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));

            TAM = br.BaseStream.Length;  // tamaño del archivo
            //Lectura de la cabecera del archivo
            aux = br.ReadInt64();
            br.BaseStream.Position = aux;
            principio = aux;
            while( aux < TAM )
            {
                if(sigEntidad != -1)
                {
                    nEntidad = br.ReadString();     // Formato 
                    dirEntidad = br.ReadInt64();    //   de
                    br.ReadInt64();                 //   la
                    br.ReadInt64();                 // entidad 
                    sigEntidad = br.ReadInt64();    //
                   // MessageBox.Show("Entidad: "+ nEntidad + "\nSiguiente Entidad: " + sigEntidad);
                    

                    if(dirEntidad == aux)
                    {
                        compara = entidad.CompareTo(nEntidad);
                        switch(compara)
                        {
                            case -1:
                            
                               // MessageBox.Show(entidad + " es antes que " + nEntidad);
                            br.Close();
                            bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
                            if(antA > 0)
                            {
                                bw.BaseStream.Position = antA + 54;
                                bw.Write(bw.BaseStream.Length);
                            }

                            
                            bw.Close();
                               // br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
                            bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
                            if (principio == aux )
                            {
                                posicion = 1;
                            }
                            else
                            {
                                posicion = -1;
                            }
                            return dirEntidad;
                            break;
                            case 0:
                               // br.BaseStream.Position = sigEntidad;
                               // aux = sigEntidad;
                            break;
                            case 1:
                               // MessageBox.Show(entidad + " es despues que " + nEntidad);
                            
                               // br.Close();
                            antA = dirEntidad;
                            sigA = sigEntidad;
                            
                            if (sigEntidad == -1)
                            {
                                    //MessageBox.Show("Dentro de if");
                                
                                br.Close();
                                bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
                                bw.BaseStream.Position = antA + 54;
                                bw.Write(bw.BaseStream.Length);
                                bw.BaseStream.Position = bw.BaseStream.Length;
                                bw.Close();
                                posicion = -1;
                                bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
                                return sigEntidad;
                                

                            }
                            else
                            {
                             
                                br.BaseStream.Position = sigEntidad;
                                aux = sigEntidad;
                                
                                
                                    //Se llamara a la función ordenaAnterior
                                   // ordenaAnterior(antA, sigA, entidad);
                                   // MessageBox.Show("Direccion: " + antA + "\nSiguiente: " + sigA);
                            }
                            


                            break;
                        }
                    }
                    else
                    {
                        br.BaseStream.Position = sigEntidad;
                        aux = sigEntidad;
                       // MessageBox.Show("Siguiente Entidad: "  + sigEntidad );
                      //  br.BaseStream.Seek(aux, SeekOrigin.Begin);
                    }

                }
                
            }


            return -1;
        }


        // Metodo que muestra la lista en el datagrid
        private void imprimeLista(List<Entidad> entidad)
        {
            comboBox1.Items.Clear();
            comboBox6.Items.Clear();
            long pos = -1;
            long DSIG = 0;
            string n = "";
            
            
            int totalEntidad = 0;
            // Limpia el datagrid para una nueva inserción
            dataGridView1.Rows.Clear();
            entidad.Clear();
            
            bw.Close();

            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                enti = new Entidad();
                enti.nombrate(br.ReadString());
                enti.direccionate(br.ReadInt64());
                enti.ponteDireccionAtributo(br.ReadInt64());
                enti.ponteDireccionRegistro(br.ReadInt64());
                enti.ponteDireccionSig(br.ReadInt64());
                entidad.Add(enti);
                if (enti.dameDSIG() != -1)
                {
                    br.BaseStream.Position = enti.dameDSIG();
                }
                else
                break;

                
            }
            br.Close();
            foreach (Entidad i in entidad)
            {
                dataGridView1.Rows.Add(i.dameNombre(), i.dameDE(), i.dameDA(), i.dameDD(), i.dameDSIG());
            }
            foreach (Entidad i in entidad)
            {
                comboBox1.Items.Add(i.dameNombre());
            }
            foreach (Entidad i in entidad)
            {
                comboBox6.Items.Add(i.dameNombre());
            }

            bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
            /*
            // 1. Se lee la cabecera del Archivo
            pos = br.ReadInt64();
            cabecera.Text = pos.ToString(); // Se muestra en el textbox

            // 2. Se posiciona el apuntador 
            br.BaseStream.Position = pos;
            while (br.BaseStream.Position <= br.BaseStream.Length)
            {
                n = br.ReadString();
                if(n == "NULL                          ")
                {
                   // MessageBox.Show("Dentro de if ");
                    br.BaseStream.Position -= 30;
                    br.BaseStream.Position += 63;
                    br.ReadString(); 
                }
                br.ReadInt64();
                br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                totalEntidad++;
                if (DSIG == -1)
                {
                    break;
                }
                br.BaseStream.Position = DSIG;
            }
            br.BaseStream.Seek((int)8, SeekOrigin.Begin);
           // MessageBox.Show("Total Entidades: " + totalEntidad);
            for (int i = 0; i < totalEntidad; i++)
            {
                enti = new Entidad();
                enti.nombrate(br.ReadString());
                if (enti.dameNombre() == "NULL                          ")
                {
                    br.BaseStream.Position += 31;
                    enti.nombrate(br.ReadString());
                }
                comboBox1.Items.Add(enti.dameNombre());
                comboBox6.Items.Add(enti.dameNombre());
                enti.direccionate(br.ReadInt64());
                enti.ponteDireccionAtributo(br.ReadInt64());
                enti.ponteDireccionRegistro(br.ReadInt64());
                enti.ponteDireccionSig(br.ReadInt64());
                entidad.Add(enti);
            }
            br.Close();
            bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
            //Ciclo que inserta las entidades en el datagrid
            foreach (Entidad i in entidad)
            {
                if (i.dameNombre() == "NULL")
                {
                    continue;
                }
                else if (i.dameNombre() == "NULL                          ")
                {
                    continue;
                }
                else
                {
                    dataGridView1.Rows.Add(i.dameNombre(), i.dameDE(), i.dameDA(), i.dameDD(), i.dameDSIG());
                }

            }

         //   foreach(Entidad i in entidad)
          //  {
          //      comboBox1.Items.Add(i.dameNombre());
          //  }
          */
        }

        #endregion
        #region Algoritmos Atributo
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
         *      Cuando se añade un atributo al archivo, se agrega de igual forma
         *      a un datagrid que permitirá agregar los registros.
         *      
         *********************************************************************************/
         private void creaAtributo(object sender, EventArgs e)
         {
            
            //bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
            atri = new Atributo();              // Objeto de la clase atributo
            int cont;                           // Variable contador      
            _nombre = textBox2.Text;            // Se asigna a la variable nombre, el nombre del atributo dada por el textBox2
            /**********************************************
             * ciclo for que sucede mientras el nombre
             * del atributo tenga una longitud menor a 30
             **********************************************/
             cont = _nombre.Length;
             for (; cont <= 29; cont++)
             {
                _nombre += " ";
            }
            // comboBox5.Items.Add(_nombre);
            /**********************************************************************************
             * Si no hay ningun atributo, entonces se agrega con valores principales en -1
             * SI NO entonces, se añade al final y se acomodan los apuntadores
             **********************************************************************************/
             if (atributo.Count == 0)
             {
                atri.nombrate(_nombre);
                atri.ponteTipo(Convert.ToChar(comboTipo.SelectedItem));
                atri.ponteLongitud(Convert.ToInt32(textBox3.Text));
                atri.direccionate((long)bw.BaseStream.Length);
                atri.ponteTipoIndice((int)tipoIndice);
                atri.ponteDirIndice((long)-1);
                atri.ponteDirSig((long)-1);
                bw.Seek((int)bw.BaseStream.Length, SeekOrigin.Begin);
                bw.Write(atri.dameNombre());
                bw.Write(atri.dameTipo());
                bw.Write(atri.dameLongitud());
                bw.Write(atri.dameDireccion());
                bw.Write(atri.dameTI());
                bw.Write(atri.dameDirIndice());
                bw.Write(atri.dameDirSig());
                //nuevoAtributo = false;

            }
            else
            {
                atri.nombrate(_nombre);
                atri.ponteTipo(Convert.ToChar(comboTipo.SelectedItem));
                atri.ponteLongitud(Convert.ToInt32(textBox3.Text));
                atri.direccionate((long)bw.BaseStream.Length);
                atri.ponteTipoIndice((int)tipoIndice);
                atri.ponteDirIndice((long)-1);
                atri.ponteDirSig((long)-1);
                /*
                if(!nuevoAtributo)
                {
                    atributo[atributo.Count - 1].ponteDirSig(atri.dameDireccion());
                    bw.Seek((int)bw.BaseStream.Length - 8, SeekOrigin.Begin); //actualiza dirección siguiente
                    bw.Write((long)atributo[atributo.Count - 1].dameDirSig());
                }
                */
                bw.BaseStream.Position = bw.BaseStream.Length;
                bw.Write(atri.dameNombre());
                bw.Write(atri.dameTipo());
                bw.Write(atri.dameLongitud());
                bw.Write(atri.dameDireccion());
                bw.Write(atri.dameTI());
                bw.Write(atri.dameDirIndice());
                bw.Write(atri.dameDirSig());

            }
            atributo.Add(atri);     //Se añanade el atributo a la lista de atributos
            
            actualizaEntidad(atri.dameDireccion());
            imprimeLista(entidad);
            imprimeAtributo(atributo);// Se accede al metodo que muestra en el datagrid la lista de atributos
            
            /****************************************************************************************
             * Métodos que agregan en el datagrid para la creación de registros, usar los atributos *
             ****************************************************************************************/
            //   dataGridView3.Columns.Add(enti.dameNombre(), atri.dameNombre());
            // dataGridView4.Columns.Add(enti.dameNombre(), atri.dameNombre());

            //       if(atri.dameTI() == 2)
            //     {
            //      claves = new List<indicep>();
            //    nombre_indice = atri.dameNombre();
            // }
            // if(atri.dameTI() == 3)
            // {
            //   nombre_indice = atri.dameNombre();
            // }
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
            /*
            botonAtributo = true;
            // Condicional que comprara si se creo un atributo y se  selecciono una entidad nueva
            if (nuevoAtributo == true)
            {
                ponteAtributo(atri);
                nuevoAtributo = false;
            }
            */
        }
        public void actualizaEntidad(long dAtributo)
        {
            string nEntidad = comboBox1.Text;
            string n = " ";
            long DSIG = 0;
            long DSIGA = 0;
            long DA = 0;
            long pos = 0;
            bw.Close();
            br = new BinaryReader(File.Open(nArchivo,FileMode.Open));
            br.BaseStream.Position = br.ReadInt64(); //cabecera
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                if(DSIG != -1)
                {
                    n = br.ReadString();
                    br.ReadInt64();
                    pos = br.BaseStream.Position;
                    DA = br.ReadInt64();
                    br.ReadInt64();
                    DSIG = br.ReadInt64();
                    if (DSIG != -1)
                    br.BaseStream.Position = DSIG;

                }
                
                if(n == nEntidad)
                {
                    if(DA != -1)            // Si tiene algun atributo
                    {
                        br.BaseStream.Position = DA;
                        while(DSIGA != -1)
                        {
                            br.ReadString();
                            br.ReadChar();
                            br.ReadInt32();
                            br.ReadInt64();
                            br.ReadInt32();
                            br.ReadInt64();
                            pos = br.BaseStream.Position;
                            DSIGA = br.ReadInt64();
                            if(DSIGA == -1)
                            {
                                br.Close();
                                bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
                                bw.BaseStream.Position = pos;
                                bw.Write(dAtributo);
                                bw.Close();

                                br.Close();
                                br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
                                DSIGA = -1;
                                

                            }
                            else
                            br.BaseStream.Position = DSIGA;
                        }
                        break;
                        
                        

                    }
                    else  // si no tiene atributo
                    {
                        br.Close();
                        bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
                        bw.BaseStream.Position = pos;
                        bw.Write(dAtributo);
                        bw.Close();

                        br.Close();
                        br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
                        br.BaseStream.Position = br.BaseStream.Length;
                        break;
                    }
                }
               // br.BaseStream.Position = DSIG;  
            }


            br.Close();
            bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
        }

        /*******************************************************************
         * Metodo encargado de agregar la direccion del atributo a la entidad 
         *******************************************************************/
         private void ponteAtributo(Atributo atri)
         {
            // Declaración de variables locales
            long cab, sigEntidad;
            long pos = 0;
            string nombreEntidad, n;
            nombreEntidad = comboBox1.Text;
            bw.Close();
            long apuntador = 8; // se inicia desde la posición de la cabecera 
            
            int tam;
            tam = comboBox1.Text.Length;
            string tempNombre;
            tempNombre = comboBox1.Text;

            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));

            
            cab = br.ReadInt64();
            br.BaseStream.Position = cab;
            sigEntidad = 0;

            while (cab < br.BaseStream.Length)
            {
                if(sigEntidad != -1)
                {
                    
                    n = br.ReadString();
                    br.ReadInt64();
                    pos = br.BaseStream.Position;
                    br.ReadInt64();
                    br.ReadInt64();
                    sigEntidad = br.ReadInt64();
                    if(n == nombreEntidad)
                    {
                        br.Close();
                        bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
                        bw.BaseStream.Position = pos;
                        bw.Write(atri.dameDireccion());
                        bw.Close();
                        imprimeLista(entidad);
                        bw.Close();
                        br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
                        br.Close();
                        break;
                    }
                    br.BaseStream.Position = sigEntidad;
                    cab = sigEntidad;

                }
                


            }
            br.Close();
            bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));



        }


        /*************************************************************************************************
         *              Seleccion de entidad para el atributo
         *************************************************************************************************/


         private void seleccionaEntidad(object sender, EventArgs e)
         {
            contador = 0;
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            dataGridView4.Columns.Clear();
            renglon = 0;
            dataGridView4.Columns.Add("Dirección del Registro", "Dirección del Registro");
            nuevoAtributo = true;
            imprimeAtributo(atributo);

            string n;
            string nombre;
            long DSIG = 0;
            
            
            




            // Ciclo while que limpia el datagrid de los atributos
         //   while (dataGridView2.RowCount > 0)
          //  {
               // dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
          //  }
            //   while (dataGridView3.RowCount > 0)
            // {
            //    dataGridView3.Rows.Remove(dataGridView3.CurrentRow);

            // }
            //    while (dataGridView4.RowCount > 0)
            ///    {
            //     dataGridView4.Rows.Remove(dataGridView4.CurrentRow);

            // }


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
        /***********************************************************************************************
         * Método encargado de mostrar en el datagrid los atributos
         ***********************************************************************************************/
         private void imprimeAtributo(List<Atributo> atributo)
         {
            string n = comboBox1.Text;
            string nEntidad = "";
            long DA = 0;
            long DSIG = 0;
            bw.Close();
            br.Close();
            atributo.Clear();
            dataGridView2.Rows.Clear();
            br.Close();
            br.Close();
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                nEntidad = br.ReadString();
                br.ReadInt64();
                DA = br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if(nEntidad == n)
                {
                    if(DA != -1)
                    {
                        br.BaseStream.Position = DA;
                        while (br.BaseStream.Position < br.BaseStream.Length)
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
                            if (atri.dameDirSig() != -1)
                            br.BaseStream.Position = atri.dameDirSig();
                            else
                            break;
                        }

                    }
                    
                }
                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;
            }

            br.Close();
            bw.Close();
            bw = new BinaryWriter(File.Open(nArchivo,FileMode.Open));
            foreach(Atributo a in atributo)
            {
             dataGridView2.Rows.Add(a.dameNombre(), a.dameTipo(), a.dameLongitud(), a.dameDireccion(), a.dameTI(), a.dameDirIndice(), a.dameDirSig());

         }

     }
        /******************************************************************************************************************************************************************
         *                              M E T O D O    E L I M I N A      A T R I B U T O
         ******************************************************************************************************************************************************************/

         private void button4_Click(object sender, EventArgs e)
         {
            bw.Close();
            long dAtributo, dEntidad, dir, dSig, anterior;
            string nEntidad, nAtributo;
            string n;
            List<string> entidades = new List<string>();

            foreach(Entidad i in entidad)
            {
                entidades.Add(i.dameNombre());
            }

            EliminaAtributo eliminaAtributo = new EliminaAtributo(entidades, nArchivo);
            if(eliminaAtributo.ShowDialog() ==  DialogResult.OK)
            {
                dAtributo   = eliminaAtributo.dAtributo;
                nAtributo   = eliminaAtributo.nAtributo;
                nEntidad    = eliminaAtributo.nEntidad;

                br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
                br.BaseStream.Position = br.ReadInt64();
                dEntidad = buscaDirEntidad(nEntidad);
                br.BaseStream.Position = dEntidad;
                br.ReadString(); // nombre
                br.ReadInt64();  // dir
                dir = br.ReadInt64();  
                br.ReadInt64();
                dSig = br.ReadInt64();
                if(dir == dAtributo) // Es el primer atributo
                {
                    //Archivo de lectura abierto
                    br.BaseStream.Position = dir;
                    br.ReadString(); // nombre
                    br.ReadChar();   // tipo
                    br.ReadInt32();  // longitud
                    br.ReadInt64();  // dirección
                    br.ReadInt32();  // tipo indice
                    br.ReadInt64();  // dirección indice
                    dSig = br.ReadInt64();  // dirección sig
                    if(dSig == -1) // Solo hay un atributo
                    {
                        eliminaPrimero(dEntidad);
                        bw.BaseStream.Position = dAtributo;
                        string temp = "NULL";
                        while (temp.Length <= 29)
                        temp += " ";

                        bw.Write(temp);

                    }
                    else // Hay mas de un atributo
                    {
                        br.Close();
                        bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open)); 
                        bw.BaseStream.Position = dAtributo;
                        string temp = "NULL";
                        while (temp.Length <= 29)
                        temp += " ";

                        bw.Write(temp);
                        
                        bw.BaseStream.Position = dEntidad + 38;
                        bw.Write(dSig);
                    }
                    
                }
                else // Es cualquier otro 
                {
                    br.Close();
                    bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
                    bw.BaseStream.Position = dAtributo;
                    string temp = "NULL";
                    while (temp.Length <= 29)
                    temp += " ";
                    
                    bw.Write(temp);
                    
                    dSig = dAtributo + 55; //54 ;
                                           //bw.BaseStream.Seek(dAtributo -8, SeekOrigin.Begin);
                                           //  bw.BaseStream.Position = dAtributo - 8;

                    anterior = obtenAtributoAnterior(dAtributo, dEntidad);
                    bw.BaseStream.Position = anterior + 55;
                    dSig = obtenAtributoSiguiente(dSig);
                    bw.BaseStream.Position = anterior + 55;
                    bw.Write(dSig);
                    imprimeLista(entidad);
                    imprimeAtributo(atributo); 
                }


                // bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
                // bw.BaseStream.Position = dAtributo;


            }
            imprimeLista(entidad);
            imprimeAtributo(atributo);


        }
        #region MetodosELiminaAtributo
        public void eliminaPrimero(long dir)
        {
            br.Close();
            bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
            bw.BaseStream.Position = dir +  38; //nombre + dir + atributo + dd + sig

            bw.Write((long)-1);
            //bw.Close();
            //br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            imprimeLista(entidad);
            nuevoAtributo = true;
        }
        /*****************************************************************************
         * Metodo encargado de recorrer la lista de atributos y obtener la dirección
         * del atributo que apunta al que se va a eliminar
         *****************************************************************************/
         public long obtenAtributoAnterior(long dAtributo, long dEntidad)
         {
            long dir, DSIG = 0;
            int totalEntidad;
            string n;
            bw.Close();

            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = dEntidad; // posiciona en la direccion de la entidad
            n = br.ReadString();
            br.ReadInt64();
            br.BaseStream.Position = br.ReadInt64();
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                br.ReadChar();
                br.ReadInt32();
                dir = br.ReadInt64();
                br.ReadInt32();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if(DSIG != -1)
                {
                    br.BaseStream.Position = DSIG;
                }
                if (DSIG == dAtributo)
                {
                    br.Close();
                    bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
                    return dir;
                }
                else
                break;

            }
            br.Close();
            bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
            return -1;
        }
        public long obtenAtributoSiguiente(long dSig)
        {
            long dir = -1;
            bw.Close();
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = dSig;
            dir = br.ReadInt64();

            br.Close();
            bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
            return dir;
        }
        #endregion
        public long buscaDirEntidad(string nEntidad)
        {
            long pos;
            string n;
            long dEntidad;
            long DSIG = 0;
            br.BaseStream.Seek(0, SeekOrigin.Begin);

            br.BaseStream.Position = br.ReadInt64();
            pos = br.BaseStream.Position;

            while(DSIG != -1)
            {
                n = br.ReadString();
                dEntidad = br.ReadInt64();
                br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if (n == nEntidad)
                {
                    return dEntidad;
                }
                if (DSIG != -1)
                br.BaseStream.Position = DSIG;

            }
            return -1;
        }

        #endregion
        #region Apertura del Archivo
        /*****************************************************************************
         * 
         * Metodo que permite abrir el archivo y lo envia a uno nuevo
         * 
         *****************************************************************************/
         private void abreArchivo(object sender, EventArgs e)
         {
            string nombre = " ";
            string n;
            int totalEntidad = 0;
            long apuntadorAtributo = 0;
            long pos = 0;
            long DSIG = 0;
            button1.Enabled = true;
            modificar.Enabled = true;
            button3.Enabled = true;
            textBox1.Enabled = true;
            Archivo archivo = new Archivo(nombre);
            if (nuevo)
            {
                bw.Close();
            }

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                nombre = archivo.nombre + ".bin";
                nArchivo = nombre;
                if (File.Exists(nombre))
                {
                    br = new BinaryReader(File.Open(nombre, FileMode.Open));
                    nuevo = true;
                    button7.Hide(); // Se oculta boton Nuevo
                    button8.Hide(); // Se oculta boton Abrir
                    /********************************************/

                    // 1. Se lee la cabecera del Archivo
                    pos = br.ReadInt64();
                    cabecera.Text = pos.ToString(); // Se muestra en el textbox

                    // 2. Se posiciona el apuntador 
                    br.BaseStream.Position = pos;
                    while(br.BaseStream.Position < br.BaseStream.Length)
                    {
                        br.ReadString();
                        br.ReadInt64();
                        br.ReadInt64();
                        br.ReadInt64();
                        DSIG = br.ReadInt64();
                        totalEntidad++;
                        if (DSIG == -1){
                            break;
                        }
                        br.BaseStream.Position = DSIG;
                    }
                   // MessageBox.Show("Total de entidades: " + totalEntidad);
                    br.BaseStream.Position = 8;
                    for(int i=0; i < totalEntidad; i++)
                    {
                        enti = new Entidad();
                      //  MessageBox.Show("Posición " + br.BaseStream.Position);
                        enti.nombrate(br.ReadString());
                        if(enti.dameNombre() == "NULL                          ")
                        {
                            br.BaseStream.Position  = br.BaseStream.Position + 31;                    
                            enti.nombrate(br.ReadString());
                        }
                        comboBox1.Items.Add(enti.dameNombre());
                        comboBox6.Items.Add(enti.dameNombre());
                        enti.direccionate(br.ReadInt64());
                        enti.ponteDireccionAtributo(br.ReadInt64());
                        enti.ponteDireccionRegistro(br.ReadInt64());
                        enti.ponteDireccionSig(br.ReadInt64());
                        entidad.Add(enti);
                    }
                    
                    /********************************************/
                    
                    br.Close();
                    bw = new BinaryWriter(File.Open(nombre, FileMode.Open));
                    imprimeLista(entidad);
                    imprimeAtributo(atributo);
                    
                }
                else
                {
                    MessageBox.Show("El proyecto no existe!");
                }

            }


            /*

            button8.Hide();
            long tam;
            long sig;
            
            
            br = new BinaryReader(File.Open("Entidad.bin", FileMode.Open));
            button7.Hide();
            string swap;
            
            tam = 0;
            cabecera.Text = br.ReadInt64().ToString();
            while (tam < br.BaseStream.Length)
            {
                MessageBox.Show("apuntador : " + tam);
                enti = new Entidad();
                enti.nombrate(br.ReadString());
                comboBox1.Items.Add(enti.dameNombre());
                enti.direccionate(br.ReadInt64());
                enti.ponteDireccionAtributo(br.ReadInt64());
                enti.ponteDireccionRegistro(br.ReadInt64());
                sig = br.ReadInt64();
                if (sig == -2)
                {

                    enti.ponteDireccionSig(-2);
                    entidad.Add(enti);
                    break;
                  
                }
                else
                {
                    enti.ponteDireccionSig(sig);
                    entidad.Add(enti);
                }
                
                
                tam = br.BaseStream.Position;
               // break;
                // if (sig == -1 && tam < br.BaseStream.Length)
                // {
                //   enti.ponteDireccionSig(sig);
                //    entidad.Add(enti);
                //     imprimeLista(entidad);
                //     abreAtributos(br, tam);
                //    break;

                // }
                //  else
                //  {

                //  }



            }
            imprimeLista(entidad);

            br.Close();
            bw = new BinaryWriter(File.Open("Entidad.bin", FileMode.Open));
            nuevo = true;
            */

        }

        #endregion
        /**************************************************************************************************************
         * 
         * dat          ->  nombre del arhivo .dat
         * aClave       ->  Atributo que tiene la clave de búsqueda
         * nEntidad     ->  nombre de la Entidad en el combobox6
         * nRegistro    ->  nombre del registro a insertar
         * DR           ->  direccion del nuevo registro
         * 
         * 
         * 
         * Metodo encargado de obtener la direccion a la cual apuntara el nuevo registro
         * 
         ****************************************************************************************************************/ 
         
         private long dameDireccionSiguienteRegistro(string dat,Atributo  aClave,string nEntidad,string nRegistro,long DR)
         {
            return -1;
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
         *  contador      ---> variable que cuenta las columnas de una entidad para  los registros
         *  datagridView3 ---> Tabla de inserción de registros
         *  datagridView4 ---> Tabla de índice primario
         * 
         * *********************************************************************************/
         private void insertarRegistro_Click(object sender, EventArgs e)
         {
            br.Close();
            bw.Close();
            char tipo = ' '; 
            int tamC = 0, TAM = 0;

            List<int> pos2 = new List<int>();
            string dat = comboBox6.Text + ".dat";
            string indi = comboBox6.Text + ".idx";
            string celda = "";
            Atributo aClave, tempAtributo;
            int pos = 0;
            int posprimario = 0;
            int posSecundario = 0;
            int posArbol = 0;
            Atributo iPrimario;
            Atributo iSecundario;
            Atributo iArbol;
            string nRegistro = " ";
            long DR = 0, DSIGR = 0, DREGI = 0;
            br.Close();
            bw.Close();

            long anterior = 0;
            /*Para saber que onda con el datagrid dinamico, debemos hacer un ciclo for  */
            //dataGridView4.Columns.Add("","");

            aClave = dameClaveBusqueda(dat);
            iPrimario = dameIndicePrimario(comboBox6.Text);
            iSecundario = dameIndiceSecundario(comboBox6.Text);
            iArbol = dameIndiceArbol(comboBox6.Text);
            secundarios = buscaSecundarios(comboBox6.Text);
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                if (aClave != null)
                {
                    if (dataGridView3.Columns[i].Name == aClave.dameNombre()) /* Encuentra la columna para realizar el ordenamiento*/
                    {
                        pos = i;
                        break;
                    }
                }
                
            }

            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                if(iPrimario != null)
                {
                    if (dataGridView3.Columns[i].Name == iPrimario.dameNombre()) /* Encuentra la columna para realizar el ordenamiento*/
                    {
                        posprimario = i;
                        break;
                    }
                }
                
            }
            int j = 0;
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                if(iSecundario != null)
                {
                    if (dataGridView3.Columns[i].Name == secundarios[j]) /* Encuentra la columna para realizar el ordenamiento*/
                    {
                        pos2.Add(i);// = i;
                        j++;
                    }
                }
                
            }
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                if (iArbol != null)
                {
                    if (dataGridView3.Columns[i].Name == iArbol.dameNombre()) /* Encuentra la columna para realizar el ordenamiento*/
                    {
                        posArbol = i;
                        break;
                    }
                }

            }

            foreach (string arch in datos)
            {
                if (arch == dat)
                {
                    bw = new BinaryWriter(File.Open(dat, FileMode.Open));
                    break;
                }
            }

            bw.BaseStream.Position = bw.BaseStream.Length;

            

            DR = bw.BaseStream.Length;
            bw.Write(DR);
            
            primero = 8;
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                bw.Close();
                br.Close();
                tipo = buscaTipo(comboBox6.Text,dataGridView3.Columns[i].Name);
                bw.Close();
                br.Close();
                celda = dataGridView3.Rows[0].Cells[i].Value.ToString(); 
                bw.Close();
                br.Close();
                bw = new BinaryWriter(File.Open(dat, FileMode.Open));
                if (tipo == 'E')
                {
                    bw.BaseStream.Position = bw.BaseStream.Length;
                    bw.Write(Convert.ToInt32(celda));
                    primero += 4;
                }
                
                else if(tipo == 'C')
                {
                    tamC = buscaTam(comboBox6.Text,dataGridView3.Columns[i].Name);
                    while(celda.Length < tamC-1)
                    {
                        celda += " ";
                    }
                    if(pos == i)
                    {
                        nRegistro = celda;
                    }
                    bw.Close();
                    br.Close();
                    bw = new BinaryWriter(File.Open(dat, FileMode.Open));
                    bw.BaseStream.Position = bw.BaseStream.Length;
                    bw.Write(celda);
                    primero += celda.Length+1;
                    
                }

            }
            primero += 8;
            bw.Write((long)-1);
            if (primero < bw.BaseStream.Length)
            {
                /*ACTUALIZAR DIRECCIONES SEGUN EL TIPO DE INDICE  */
                /*Obtención de clave de búsqueda! */
                bw.Close();
                br.Close();
                /* Si el tipo es una cadena utilizar el compareTo, si es numerico utilizar <,>,== */
                if (aClave != null)
                {
                    bw.Close();
                    br.Close();
                    if (aClave.dameTipo() == 'C')
                    {
                        //tempAtributo = dameAtributo(dat);
                        bw.Close();
                        br.Close();
                        DSIGR = siguienteRegistro(dat, aClave, primero, comboBox6.Text, nRegistro, DR);
                        //DSIGR = dameDireccionSiguienteRegistro(dat, aClave, comboBox6.Text, nRegistro, DR);
                        br.Close();
                        bw.Close();
                        bw.Close();
                        bw.Close();
                        bw = new BinaryWriter(File.Open(dat, FileMode.Open));
                        bw.BaseStream.Position = bw.BaseStream.Length - 8;
                        bw.Write(DSIGR);
                        //ordenaRegistro(dat, aClave);


                    }
                    else if (aClave.dameTipo() == 'E')
                    {
                        
                    }

                }
                else
                {

                    bw = new BinaryWriter(File.Open(comboBox6.Text+".dat",FileMode.Open)); 
                    bw.BaseStream.Position = bw.BaseStream.Length - 8-primero;
                    DSIGR = DR;
                    
                    bw.Write(DSIGR);

                }

                
                
            }
            else if(primero == bw.BaseStream.Length)
            {
                
                ponteRegistro(comboBox6.Text,DR);
            }
            
            bw.Close();
            /*Ahora se leera el archivo para llenar el datagrid*/
            br.Close();
            imprimeRegistro(dat);
            br.Close();
            bw.Close();
            if (iPrimario != null)
            insertaPrimario(indi,iPrimario, posprimario);
            if (iArbol != null)
            insertaNodo(comboBox6.Text + ".idx", iArbol, posArbol);
            //if(iSecundario != null)
            //insertaSecundario(indi, iSecundarios);
            bw.Close();
            br.Close();
        }
        public List<string> buscaSecundarios(string nEntidad)
        {
            string n = " ";
            long DSIG, DA, DSIGA;
            string cSEC;
            int tipo;
            br.Close();
            bw.Close();
            List<string> sec = new List<string>();
            br = new BinaryReader(File.Open(nArchivo,FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                br.ReadInt64();
                DA = br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if(n == nEntidad)
                {
                    br.BaseStream.Position = DA;
                    while(br.BaseStream.Position < br.BaseStream.Length)
                    {
                        cSEC = br.ReadString();
                        br.ReadChar();
                        br.ReadInt32();
                        br.ReadInt64();
                        tipo = br.ReadInt32();
                        br.ReadInt64();
                        DSIGA = br.ReadInt64();
                        if (tipo == 3)
                        sec.Add(cSEC);
                        if (DSIGA != -1)
                        br.BaseStream.Position = DSIGA;
                        else
                        break;
                    }
                }
                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;
            }
            br.Close();
            return sec;
        }
        private void insertaNodo(string arch, Atributo iArbol, int posArbol)
        {
            br.Close();
            bw.Close();
            bool lleno = false;
            bool existeIntermedio = false;
            List<int> nodos = new List<int>();
            List<int> direcciones = new List<int>();
            List<int> tempClaves;// = new List<int>();
            List<long> tempDir;
            for (int i = 0; i < dataGridView4.Rows.Count - 2; i++)
            {
                nodos.Add(Convert.ToInt32(dataGridView4.Rows[i].Cells[posArbol + 1].Value));
                direcciones.Add(Convert.ToInt32(dataGridView4.Rows[i].Cells[0].Value));
            }
            /* AQUI LA LISTA YA FUNCIONA DE ENTEROS */
          //  bw = new BinaryWriter(File.Open(comboBox6.Text + ".idx", FileMode.Open));

            Arbol arbol = new Arbol();
            Nodo anterior = new Nodo();

            Nodo nuevo;// = new Nodo();
            long dirRaiz = 0;
            nuevo = new Nodo();
            for (int i = 0; i < nodos.Count; i++)
            {
                dirRaiz = arbol.dameRaiz();
                if (dirRaiz == -1)
                {
                    if (lleno == false)
                    {
                        if (arbol.Count == 0)
                        {

                            nuevo = arbol.creaNodo(nuevo, 0);
                            arbol.Add(nuevo);
                            lleno = arbol.agregaDato(nuevo.dirNodo, nodos[i], direcciones[i]);
                        }
                        else
                        {
                            lleno = arbol.agregaDato(nuevo.dirNodo, nodos[i], direcciones[i]);
                            anterior = nuevo;
                        }
                    }
                    if (lleno == true)
                    {

                        nuevo = new Nodo();
                        nuevo = arbol.creaNodo(nuevo, arbol[arbol.Count-1].dirNodo+65); //se asigna dirección al nodo
                        anterior.sig = nuevo.dirNodo;                                   //se apunta el anterior al siguiente
                        arbol.Add(nuevo);
                        tempClaves = new List<int>();
                        tempDir = new List<long>();


                        for (int aux = 2; aux < anterior.clave.Count; aux++)
                        {
                            tempClaves.Add(anterior.clave[aux]);

                            tempDir.Add(anterior.direccion[aux]);

                        }

                        /*Remueve los ultimos 2 elementos del nodo porque se pasaron a uno nuevo*/
                        anterior.clave.RemoveAt(3);
                        anterior.clave.RemoveAt(2);
                        anterior.direccion.RemoveAt(3);
                        anterior.direccion.RemoveAt(2);
                        /*Se añanade a una lista de 5 datos el nuevo a insertar*/
                        tempClaves.Add(nodos[i]);
                        tempDir.Add(direcciones[i]);
                        arbol.ordenaCinco(tempClaves, tempDir);
                        /*Se agregan los ultimos 3 datos al nuevo nodo */
                        for (int aux = 0; aux < tempClaves.Count; aux++)
                        {
                            lleno = arbol.agregaDato(nuevo.dirNodo, tempClaves[aux], tempDir[aux]);
                        }
                        /*Crear nodo raiz */
                        anterior = nuevo;
                        nuevo = new Nodo();
                        nuevo = arbol.creaNodo(nuevo, anterior.dirNodo + 65);
                        nuevo.tipo = 'R';
                        nuevo.direccion.Add(arbol[arbol.Count - 2].dirNodo);
                        nuevo.clave.Add(tempClaves[0]);
                        nuevo.direccion.Add(arbol[arbol.Count - 1].dirNodo);
                        arbol.Add(nuevo);
                    }

                }
                else // EXISTE RAIZ /**************************************************************************************************************************/
                {
                    long dir = arbol.buscaNodo(nodos[i]);                   // funcion que te dice en que nodo se insertara la clave
                    long raiz = arbol.dameRaiz();                           // Dirección de raiz    
                    Nodo actual = arbol.dameNodo(dir);                      // Nodo que se va a modificar
                    
                    lleno = arbol.agregaDato(dir, nodos[i], direcciones[i]);  // NODO LLENO
                    
                    if (lleno == true)  // se crea nuevo nodo y se agrega a raiz
                    {
                        long dirAnt;
                        dirAnt = actual.dirNodo;
                        nuevo = new Nodo();
                        nuevo = arbol.creaNodo(nuevo, arbol[arbol.Count-1].dirNodo + 65);         //se asigna dirección al nodo
                        nuevo.sig = actual.sig;
                        actual.sig = nuevo.dirNodo;                         // se apunta el anterior al siguiente
                        arbol.Add(nuevo);
                        tempClaves = new List<int>();
                        tempDir = new List<long>();
                        for (int aux = 2; aux < actual.clave.Count; aux++)
                        {
                            tempClaves.Add(actual.clave[aux]);
                            tempDir.Add(actual.direccion[aux]);
                        }
                        /*Remueve los ultimos 2 elementos del nodo porque se pasaron a uno nuevo*/
                        actual.clave.RemoveAt(3);
                        actual.clave.RemoveAt(2);
                        actual.direccion.RemoveAt(3);
                        actual.direccion.RemoveAt(2);
                        /*Se añanade a una lista de 5 datos el nuevo a insertar*/
                        tempClaves.Add(nodos[i]);
                        tempDir.Add(direcciones[i]);
                        arbol.ordenaCinco(tempClaves, tempDir);
                        /*Se agregan los ultimos 3 datos al nuevo nodo */
                        for (int aux = 0; aux < tempClaves.Count; aux++){
                            lleno = arbol.agregaDato(nuevo.dirNodo, tempClaves[aux], tempDir[aux]);
                        }
                        /* AGREGAR A RAIZ O A NODO INTERMEDIO */
                        existeIntermedio = arbol.existeIntermedio();
                        if(existeIntermedio == false)
                        {
                            lleno = arbol.agregaDato(raiz, tempClaves[0], arbol[arbol.Count-1].dirNodo); // 0 PORQUE ES EL VALOR CENTRAL, QUE VA A RAIZ
                            arbol.ordenaRaiz();
                            if (lleno == true) //RAIZ llena 
                            {
                                int nDato = tempClaves[0];
                                long dDato = tempDir[0];
                                //MessageBox.Show("La raiz esta llena!!");
                                raiz = arbol.dameRaiz();
                                Nodo nRaiz = arbol.dameNodo(raiz);
                                tempClaves = new List<int>();
                                tempDir = new List<long>();
                                foreach (int n in nRaiz.clave){
                                    tempClaves.Add(n);
                                }
                                foreach (long l in nRaiz.direccion){
                                    tempDir.Add(l);
                                }
                                tempClaves.Add(nDato);
                                tempDir.Add(dDato);
                                arbol.ordenaCinco(tempClaves, tempDir);
                                /************** LISTO PARA ASIGNAR Y QUITAR CLAVES A LA RAIZ  ************************/
                                /*crear nuevo nodo  */
                                Nodo intermedio = new Nodo();
                                intermedio = arbol.creaNodo(intermedio, arbol[arbol.Count - 1].dirNodo + 65);
                                intermedio.tipo = 'I';
                                nRaiz.tipo = 'I';
                                nRaiz.sig = intermedio.dirNodo;
                                arbol.Add(intermedio);

                                intermedio.clave.Add(tempClaves[3]);
                                intermedio.clave.Add(tempClaves[4]);
                                intermedio.direccion.Add(tempDir[3]);
                                intermedio.direccion.Add(tempDir[4]);
                                intermedio.direccion.Add(tempDir[5]);

                                /*Remueve los ultimos 2 elementos del nodo porque se pasaron a uno nuevo*/

                                nRaiz.clave.RemoveAt(3);
                                nRaiz.clave.RemoveAt(2);
                                nRaiz.direccion.RemoveAt(4);
                                nRaiz.direccion.RemoveAt(3);
                                /*Se agregan los ultimos 3 datos al nuevo nodo */
                                Nodo Cab = new Nodo();
                                Cab = arbol.creaNodo(Cab, arbol[arbol.Count - 1].dirNodo + 65);
                                Cab.tipo = 'R';
                                Cab.clave.Add(tempClaves[2]);
                                Cab.direccion.Add(nRaiz.dirNodo);
                                Cab.direccion.Add(intermedio.dirNodo);
                                arbol.Add(Cab);
                            }
                        }
                        // existeIntermedio = arbol.existeIntermedio();

                        if (existeIntermedio == true) // Si existe intermedio
                        {
                            long dirIntermedio = arbol.dameIntermedio(tempClaves[0]);
                            Nodo inter;
                            lleno = arbol.agregaDato(dirIntermedio, tempClaves[0], arbol[arbol.Count - 1].dirNodo);
                            if(lleno == true)
                            {
                                int nDato = tempClaves[0];
                                long dDato = arbol[arbol.Count - 1].dirNodo;
                                tempClaves = new List<int>();
                                tempDir = new List<long>();
                                
                                tempClaves.Add(nDato);
                                tempDir.Add(dDato);
                                arbol.ordenaCinco(tempClaves, tempDir);
                                /************** LISTO PARA ASIGNAR Y QUITAR CLAVES A LA RAIZ  ************************/


                                inter = arbol.dameNodo(dirIntermedio);
                                
                                /*crear nuevo nodo  */
                                Nodo intermedio = new Nodo();
                                intermedio = arbol.creaNodo(intermedio, arbol[arbol.Count - 1].dirNodo + 65);
                                intermedio.tipo = 'I';
                                inter.sig = intermedio.dirNodo;
                                arbol.Add(intermedio);

                                intermedio.clave.Add(inter.clave[3]);
                                intermedio.clave.Add(inter.clave[2]);


                                intermedio.direccion.Add(inter.direccion[4]);
                                intermedio.direccion.Add(inter.direccion[3]);
                                intermedio.direccion.Add(inter.direccion[2]);

                                /* QUITAR CLAVES  2,3 4 DEL INTERMEDIO ANTERIOR*/
                                //inter.clave.RemoveAt(4);
                                inter.clave.RemoveAt(3);
                                inter.clave.RemoveAt(2);
                                inter.direccion.RemoveAt(4);
                                inter.direccion.RemoveAt(3);
                               // inter.direccion.RemoveAt(3);

                                /*Agregar intermedio a raiz*/

                                long dR = arbol.dameRaiz();
                                Nodo nR = arbol.dameNodo(dR);
                                nR.direccion.Add(inter.dirNodo);
                                nR.clave.Add(tempClaves[0]);
                                nR.direccion.Add(intermedio.dirNodo);
                            }
                            
                        }
                        /*****************************************************************************
                         * RAIZ LLENA
                         * agregar todas las claves de la raiz a temClaves + la nueva clave que se iba a insertar
                         * agregar todas las direcciones de raiz a temDir + la nueva direccion a insertar 
                         *****************************************************************************/
                         
                     }
                 }                
             }            
             imprimeArbol(arbol);
            // METODO PARA GUARDAR EN ARCHIVO
             guardaArbol();
         }
         public void guardaArbol()
         {
            bw.Close();
            br.Close();
            bw = new BinaryWriter(File.Open(comboBox6.Text+".idx",FileMode.Create));
            bw.BaseStream.Position = 0;
            for(int i = 0; i < tablaArbol.Rows.Count-1;i++)
            {
                for(int j = 0; j < tablaArbol.Columns.Count; j++)
                {
                    if(j == 0)
                    {
                        bw.Write(Convert.ToInt64(tablaArbol.Rows[i].Cells[j].Value));
                    }
                    else if(j == 1)
                    {
                        bw.Write(Convert.ToChar(tablaArbol.Rows[i].Cells[j].Value));
                    }
                    else if(j %2  == 0)
                    {
                        bw.Write(Convert.ToInt64(tablaArbol.Rows[i].Cells[j].Value));
                    }
                    else if(j %2 != 0)
                    {
                        bw.Write(Convert.ToInt32(tablaArbol.Rows[i].Cells[j].Value));
                    }
                    
                    
                }
            }
            bw.Close();
            br.Close();

        }
        private void imprimeArbol(Arbol arbol)
        {
            int k = 0;
            int i = 0;
            tablaArbol.Rows.Clear();
            foreach (Nodo nodo in arbol)
            {
                k = 0;
                tablaArbol.Rows.Add();
                for (int j = 0; j < tablaArbol.Columns.Count; j++)
                {
                    if (j == 0)
                    {
                        tablaArbol.Rows[i].Cells[j].Value = nodo.dirNodo;
                    }
                    if(j == 1)
                    {
                        tablaArbol.Rows[i].Cells[j].Value = nodo.tipo;

                    }
                    if (j > 1 && j < tablaArbol.Columns.Count - 1 )
                    {                         
                        if( k < nodo.direccion.Count)
                        tablaArbol.Rows[i].Cells[j].Value = nodo.direccion[k];
                        j++;
                        if(k < nodo.clave.Count)
                        tablaArbol.Rows[i].Cells[j].Value = nodo.clave[k];
                        k++;
                    }
                    if (j == tablaArbol.Columns.Count - 1)
                    tablaArbol.Rows[i].Cells[j].Value = nodo.sig;
                    



                }
                
                i++;

            }


            
        }
        private void insertaSecundario(string indi, List<int> iSecundarios)
        {
            int posSecundario = 0;
            br.Close();
            bw.Close();
            Secundario s;
            int pos = 0;
            poSI = 0;
            int j = 0;
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                if(dataGridView3.Columns[i].Name == secundarios[j])
                {
                    iSecundarios.Add(i);
                    if(secundarios[j] == comboSecundario.Text)
                    poSI = (j + 1) * 1000;
                    j++;
                }
            }

            indiceSec = new ListaSecundario();
            indiceSec.nombre = comboSecundario.Text;
            indiceSec.posTabla = pos;
            indiceSec.posTabla = posSecundario;




            List<List<Secundario>> listaSecundario = new List<List<Secundario>>();
            List<Secundario> secundario = new List<Secundario>();
            j = 0;
            foreach(string nn in secundarios)
            {
                if(comboSecundario.Text == nn)
                {
                    posSecundario = iSecundarios[j];
                }
                j++;
            }




            for(int i = 0; i < dataGridView4.Rows.Count-2;i++)
            {
                s = new Secundario();
                if( i == 0)
                {
                    s.clave = Convert.ToString(dataGridView4.Rows[i].Cells[posSecundario + 1].Value);
                    s.direccion.Add(Convert.ToInt64(dataGridView4.Rows[i].Cells[0].Value));
                    secundario.Add(s);

                }
                else
                {
                    s.clave = Convert.ToString(dataGridView4.Rows[i].Cells[posSecundario + 1].Value);
                    Secundario existe = secundario.Find(x => x.clave.Equals(s.clave));
                    if(existe != null)
                    {
                        foreach(Secundario aux in secundario)
                        {
                            if(aux.clave == s.clave)
                            {
                                aux.direccion.Add(Convert.ToInt64(dataGridView4.Rows[i].Cells[0].Value));
                            }
                        }
                        
                    }
                    else
                    {
                        s.direccion.Add(Convert.ToInt64(dataGridView4.Rows[i].Cells[0].Value));
                        secundario.Add(s);
                    }

                }

            }






            secundario = secundario.OrderBy(x => x.clave).ToList();
            foreach(Secundario ss in secundario)
            {
                ss.direccion.OrderBy(x => x).ToList();
            }

            listaSecundario.Add(secundario);
            


            bw.Close();
            br.Close();
            bw = new BinaryWriter(File.Open(indi+".idx",FileMode.Open));
            bw.BaseStream.Position = poSI;
            foreach(Secundario sec in secundario)
            {
                bw.Write(sec.clave);
                foreach(long p in sec.direccion)
                {
                    bw.Write(p);
                }
            }
            bw.Close();
            int u = 0;
            int t = 0;
            //tablaSecundario.Rows.Add();
            //tablaSecundario.Rows.Add();
            foreach (Secundario sec in secundario)
            {

                tablaSecundario.Rows.Add();
                tablaSecundario.Rows[u].Cells[0].Value = sec.clave;
                t = 1;
                foreach(long p in sec.direccion)
                {
                    if (t >= tablaSecundario.Columns.Count)
                    {
                        tablaSecundario.Columns.Add("direccion", "direccion");
                    }
                    tablaSecundario.Rows[u].Cells[t].Value = p;
                    
                    t++;
                }
                u++;
            }
          //  imprimeSecundario(comboBox6.Text);
            
            
            

        }
        public void imprimeSecundario(string indi)
        {
            br.Close();
            bw.Close();
            br = new BinaryReader(File.Open(indi += ".idx", FileMode.Open));
            br.BaseStream.Position = poSI;
            tablaSecundario.Rows.Clear();

            while (br.BaseStream.Position < br.BaseStream.Length)
            {
             
                tablaSecundario.Rows.Add(br.ReadInt64(),br.ReadInt32());

            }
            br.Close();
        }
        private void insertaPrimario(string indi, Atributo iPrimario, int posPrimario)
        {
            br.Close();
            bw.Close();
            Primario p;
            
            List<Primario> primario = new List<Primario>();

            for(int i = 0; i < dataGridView4.Rows.Count-2; i++)
            {
                p = new Primario();
                
                p.dirVal = Convert.ToInt64(dataGridView4.Rows[i].Cells[0].Value);
                p.val = Convert.ToInt32(dataGridView4.Rows[i].Cells[posPrimario+1].Value);
                primario.Add(p);
                
            }
            primario = primario.OrderBy(x => x.val).ToList();
            bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
            bw.BaseStream.Position = iPrimario.dameDireccion() + 30 + 1 + 4 + 8 + 5;
            bw.Write(primario[0].dirVal);
            bw.Close();
            imprimeAtributo(atributo);
            bw.Close();
            br.Close();
            bw = new BinaryWriter(File.Open(indi, FileMode.Create));
            foreach(Primario prim in primario)
            {
                bw.Write(prim.val);
                bw.Write(prim.dirVal);
            }
            bw.Close();
            br.Close();
            imprimePrimario(comboBox6.Text);







        }
        public int calculaTamRegistro(string nEntidad)
        {
            br.Close();
            bw.Close();
            int tam = 0;
            long DA = 0;
            int longitud = 0;
            long DSIG = 0;
            long DSIGA = 0;
            string n = "";
            br = new BinaryReader(File.Open(nArchivo,FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                br.ReadInt64();
                DA = br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if(n == nEntidad)
                {
                    br.BaseStream.Position = DA;
                    while(br.BaseStream.Position < br.BaseStream.Length)
                    {
                        br.ReadString();
                        br.ReadChar();
                        longitud = br.ReadInt32();
                        tam = tam + longitud;
                        br.ReadInt64();
                        br.ReadInt32();
                        br.ReadInt64();
                        DSIGA = br.ReadInt64();
                        if (DSIGA != -1)
                        br.BaseStream.Position = DSIGA;
                        else
                        break;
                    }
                }
                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;

            }
            br.Close();
            return (tam + 16);




            return 0;
        }
        public void imprimePrimario(string indi)
        {
            br.Close();
            bw.Close();
            br.Close();
            br.Close();
            br = new BinaryReader(File.Open(indi + ".idx", FileMode.Open));
            indicePrimario.Rows.Clear();
            int clave;
            int j = 0;
            long dir;
            long TAM = (dataGridView4.Rows.Count) * 12;
            while(br.BaseStream.Position < TAM)
            {
                try
                {
                    //dir = br.ReadInt64();
                    indicePrimario.Rows.Add(br.ReadInt32(), br.ReadInt64());
                    
                    j++;

                }
                catch
                {
                    break;
                }
                
                
            }
            br.Close();
        }
        private Atributo dameIndiceArbol(string nEntidad)
        {
            long DE, DA, DSIG;
            DE = 0;
            DA = 0;
            DSIG = 0;
            string n = "";
            Atributo temp = new Atributo();
            br.Close();
            bw.Close();
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                DE = br.ReadInt64();
                DA = br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if (n == nEntidad)
                {
                    if (DA != -1)
                    {
                        br.BaseStream.Position = DA;
                        while (br.BaseStream.Position < br.BaseStream.Length)
                        {
                            temp.nombrate(br.ReadString());
                            temp.ponteTipo(br.ReadChar());
                            temp.ponteLongitud(br.ReadInt32());
                            temp.direccionate(br.ReadInt64());
                            temp.ponteTipoIndice(br.ReadInt32());
                            temp.ponteDirIndice(br.ReadInt64());
                            temp.ponteDirSig(br.ReadInt64());
                            if (temp.dameTI() == 4)
                            {
                                br.Close();
                                return temp;
                            }
                            if (temp.dameDirSig() != -1)
                            br.BaseStream.Position = temp.dameDirSig();
                            else
                            break;

                        }
                    }

                }
                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;
            }

            br.Close();
            return null;

        }
        private Atributo dameIndiceSecundario(string nEntidad)
        {
            long DE, DA, DSIG;
            DE = 0;
            DA = 0;
            DSIG = 0;
            string n = "";
            Atributo temp = new Atributo();
            br.Close();
            bw.Close();
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                DE = br.ReadInt64();
                DA = br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if (n == nEntidad)
                {
                    if(DA != -1)
                    {
                        br.BaseStream.Position = DA;
                        while (br.BaseStream.Position < br.BaseStream.Length)
                        {
                            temp.nombrate(br.ReadString());
                            temp.ponteTipo(br.ReadChar());
                            temp.ponteLongitud(br.ReadInt32());
                            temp.direccionate(br.ReadInt64());
                            temp.ponteTipoIndice(br.ReadInt32());
                            temp.ponteDirIndice(br.ReadInt64());
                            temp.ponteDirSig(br.ReadInt64());
                            if (temp.dameTI() == 3)
                            {
                                br.Close();
                                return temp;
                            }
                            if (temp.dameDirSig() != -1)
                            br.BaseStream.Position = temp.dameDirSig();
                            else
                            break;

                        }
                    }
                    
                }
                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;
            }

            br.Close();
            return null;
        }
        private Atributo dameIndicePrimario(string nEntidad)
        {
            long DE, DA, DSIG;
            DE = 0;
            DA = 0;
            DSIG = 0;
            string n = "";
            Atributo temp = new Atributo();
            br.Close();
            bw.Close();
            br = new BinaryReader(File.Open(nArchivo,FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                DE = br.ReadInt64();
                DA = br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if(n == nEntidad)
                {
                    if(DA != -1)
                    {
                        br.BaseStream.Position = DA;
                        while (br.BaseStream.Position < br.BaseStream.Length)
                        {
                            temp.nombrate(br.ReadString());
                            temp.ponteTipo(br.ReadChar());
                            temp.ponteLongitud(br.ReadInt32());
                            temp.direccionate(br.ReadInt64());
                            temp.ponteTipoIndice(br.ReadInt32());
                            temp.ponteDirIndice(br.ReadInt64());
                            temp.ponteDirSig(br.ReadInt64());
                            if (temp.dameTI() == 2)
                            {
                                br.Close();
                                return temp;
                            }
                            if (temp.dameDirSig() != -1)
                            br.BaseStream.Position = temp.dameDirSig();
                            else
                            break;

                        }

                    }
                    
                }
                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;
            }

            br.Close();
            return null;
        }
        public void calculaTam(string dat)
        {
            br.Close();
            string nEntidad = comboBox6.Text;
            bw.Close();
            primero = 0;
            long DE = 0, DSIG = 0;
            long DA = 0, DSIGA = 0;
            char tipo = ' ';
            int longitud = 0;
            string n = "", nA = "";
            br = new BinaryReader(File.Open(nArchivo,FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                DE = br.ReadInt64();
                DA = br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if(n == nEntidad)
                {
                    if(DA != -1)
                    {
                        br.BaseStream.Position = DA;
                        while (br.BaseStream.Position < br.BaseStream.Length)
                        {
                            nA = br.ReadString();
                            tipo = br.ReadChar();
                            longitud = br.ReadInt32();
                            DA = br.ReadInt64();
                            br.ReadInt32();
                            br.ReadInt64();
                            DSIGA = br.ReadInt64();

                            primero += longitud;

                            if (DSIGA != -1)
                            br.BaseStream.Position = DSIGA;
                            else
                            break;
                        }

                    }
                    
                }
                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;
            }
            primero += 16;
            


        }
        /****************************************************************************
         * Metodo encargado de actualizar la dirección del Registro en la Entidad.
         * Parametros:
         * nEntidad --> nombre de la Entidad que se modificará
         * DR       --> Dirección del Registro que alfabeticamente será el primero.
         ****************************************************************************/
         public void ponteRegistro(string nEntidad, long DR)
         {
            long DE = 0;
            bw.Close();
            
            foreach(Entidad e in entidad)
            {
                if(nEntidad == e.dameNombre())
                {
                    DE = e.dameDE();
                    break;
                }
            }
            bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
            bw.BaseStream.Position = DE + 46;
            bw.Write(DR);
            bw.Close();
            imprimeLista(entidad);
            bw.Close();

            
        }
        private long siguienteRegistro(string dat, Atributo aClave, int TAM, string nEntidad,string nClave,long DREGI)
        {
            long DIR = 0;
            
            long DSIG = -1;
            long sigE = 0;
            long ANT = 0;
            long DR = 0;
            string n = "";
            char tipo = ' ';
            int compara = 0;
            long p = 0;
            string nomb = " ";
            /* Se obtendra la posición del datagrid el que corresponda a la clave de búsqueda*/
            int pos;
            pos = 0;
            bw.Close();
            br.Close();
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                if (dataGridView3.Columns[i].Name == aClave.dameNombre()) /* Encuentra la columna para realizar el ordenamiento*/
                {
                    pos = i;
                    break;
                }
            }
            br.Close();
            br = new BinaryReader(File.Open(nArchivo,FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                br.ReadInt64();
                br.ReadInt64();
                DR = br.ReadInt64();
                sigE = br.ReadInt64();
                if(n == nEntidad)
                {
                    break;
                }
                if (sigE != -1)
                br.BaseStream.Position = sigE;
                else
                break;
            }
            
            br.Close();
            br.Close();
            br = new BinaryReader(File.Open(dat,FileMode.Open));
            br.BaseStream.Position = DR; // se obtiene la cabecera del registro
            p = DR;
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                ANT = br.ReadInt64();
                for(int i = 0; i < dataGridView3.Columns.Count; i++)
                {
                    long actual = br.BaseStream.Position;
                    br.Close();
                    tipo = buscaTipo(nEntidad,dataGridView3.Columns[i].Name);

                    br = new BinaryReader(File.Open(dat, FileMode.Open));
                    br.BaseStream.Position = actual;
                    if (tipo == 'E')
                    {
                        br.ReadInt32();
                    }
                    else if(tipo == 'C')
                    {
                        nomb = br.ReadString();
                        
                    }
                    if(i == pos)
                    {
                        compara = nClave.CompareTo(nomb);
                        switch(compara)
                        {
                            case -1:
                                //MessageBox.Show("nomb" + nomb + "\nClave: " + nClave);
                                //MessageBox.Show("ANT: " + ANT + "\n DIR: " + DIR);
                            br.Close();
                            if (ANT == p)
                            {
                                
                                ponteRegistro(comboBox6.Text, DREGI);
                                bw.Close();
                                return ANT;

                            }
                            else
                            {
                                registroAnterior(DIR, DREGI, dat, TAM);
                                br.Close();
                                return ANT;
                            }

                            
                            break;
                            case 0:
                            break;
                            case 1:

                            break;
                        }

                    }
                    
                }
                DIR = ANT;
                DSIG = br.ReadInt64();

                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                {
                    registroAnterior(DIR, DREGI, dat, TAM);
                    br.Close();

                    return -1;
                }
                
            }



            br.Close();
            return DSIG;


        }
        public void registroAnterior(long ant,long reg,string dat, int TAM)
        {
            br.Close();
            bw.Close();
            bw = new BinaryWriter(File.Open(dat, FileMode.Open));
            bw.BaseStream.Position = ant;
            bw.BaseStream.Position += TAM - 8;
            bw.Write(reg);
            bw.Close();
        }
        private void ordenaRegistro(string dat, Atributo aClave)
        {
            /* Se obtendra la posición del datagrid el que corresponda a la clave de búsqueda*/
            int pos;
            pos = 0;

            for(int i =0; i < dataGridView3.Columns.Count; i++)
            {
                if(dataGridView3.Columns[i].Name == aClave.dameNombre()) /* Encuentra la columna para realizar el ordenamiento*/
                {
                    pos = i;
                    break;
                }
            }
            

        }
        private Atributo dameClaveBusqueda(string dat)
        {
            string ent, n;
            long DSIG = 0, DSIGA = 0, DA = 0;
            List<string> atributos = new List<string>();
            List<Atributo> tempAtributo = new List<Atributo>();
            Atributo aClave;
            ent = dat.Replace(".dat", "");
            br.Close();
            bw.Close();
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                br.ReadInt64();
                DA = br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if (n == ent)
                {
                    br.BaseStream.Position = DA;
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        atri = new Atributo();
                        atri.nombrate(br.ReadString());
                        atri.ponteTipo(br.ReadChar());
                        atri.ponteLongitud(br.ReadInt32());
                        atri.direccionate(br.ReadInt64());
                        atri.ponteTipoIndice(br.ReadInt32());
                        atri.ponteDirIndice(br.ReadInt64());
                        DSIGA = br.ReadInt64();
                        atri.ponteDirSig(DSIGA);
                        tempAtributo.Add(atri);
                        
                        if (DSIGA != -1)
                        br.BaseStream.Position = DSIGA;
                        else
                        break;
                    }
                }
                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;


            }
            br.Close();
            foreach(Atributo a in tempAtributo)
            {
                if(a.dameTI() == 1)
                {
                    aClave = a;
                    return aClave;
                }
            }
            return null;
        }
        /*Metodo encargado de leer el archivo, y mostrar los registros en el datagrid*/
        public void imprimeRegistro(string dat)
        {
            br.Close();
            bw.Close();
            string ent, n;
            long DSIG = 0, DSIGA = 0, DA = 0;
            List<string> atributos = new List<string>();
            List<Atributo> tempAtributo = new List<Atributo>();
            ent = dat.Replace(".dat", "");
            br.Close();
            bw.Close();
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                n    = br.ReadString();
                br.ReadInt64();
                DA   = br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if(n == ent)
                {
                    if(DA != -1)
                    {
                        br.BaseStream.Position = DA;
                        while (br.BaseStream.Position < br.BaseStream.Length)
                        {
                            atri = new Atributo();
                            atri.nombrate(br.ReadString());
                            atri.ponteTipo(br.ReadChar());
                            atri.ponteLongitud(br.ReadInt32());
                            atri.direccionate(br.ReadInt64());
                            atri.ponteTipoIndice(br.ReadInt32());
                            atri.ponteDirIndice(br.ReadInt64());
                            DSIGA = br.ReadInt64();
                            atri.ponteDirSig(DSIGA);
                            tempAtributo.Add(atri);
                            if (DSIGA != -1)
                            br.BaseStream.Position = DSIGA;
                            else
                            break;
                        }

                    }
                    
                }
                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;


            }
            br.Close();
            bw.Close();
            registro.Clear();

            int i = 0;
            int j = 0;
            
            dataGridView4.Rows.Clear();
            dataGridView4.Columns.Clear();
            dataGridView4.Columns.Add("Dirección Registro", "Dirección Registro");
            foreach (Atributo a in tempAtributo)
            {
                dataGridView4.Columns.Add(a.dameNombre(), a.dameNombre());
            }
            dataGridView4.Columns.Add("Dirección Siguiente", "Dirección Siguiente");
            
            br = new BinaryReader(File.Open(dat,FileMode.Open));
            long cab;
            long DSIGR = 0;
            cab = dameDireccionRegistro(comboBox6.Text);
            br = new BinaryReader(File.Open(dat, FileMode.Open));
            dataGridView4.Rows.Add();
            if (cab != -1)
            br.BaseStream.Position = cab;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                dataGridView4.Rows.Add();
                while (i < tempAtributo.Count+2)
                {
                    dataGridView4.Rows[j].Cells[i].Value = br.ReadInt64();
                    
                    i++;
                    foreach (Atributo a in tempAtributo)
                    {
                        if (a.dameTipo() == 'E')
                        {
                            dataGridView4.Rows[j].Cells[i].Value = br.ReadInt32();

                        }
                        else if (a.dameTipo() == 'C')
                        {
                            dataGridView4.Rows[j].Cells[i].Value = br.ReadString();
                        }
                        
                        i++;
                    }
                    DSIGR = br.ReadInt64();
                    dataGridView4.Rows[j].Cells[i].Value  = DSIGR;
                    break;

                }
                if (DSIGR != -1)
                br.BaseStream.Position = DSIGR;
                else
                break;

                
                i = 0;
                j++;
            }
            
            br.Close();
            bw.Close();


        }
        public long dameDireccionRegistro(string nEntidad)
        {
            long DREGISTRO = -1;
            long DSIG = 0;
            string n;
            bw.Close();
            br.Close();
            br = new BinaryReader(File.Open(nArchivo,FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                br.ReadInt64();
                br.ReadInt64();
                DREGISTRO = br.ReadInt64();
                DSIG = br.ReadInt64();
                if(n == nEntidad)
                {
                    br.Close();
                    return DREGISTRO;
                }
                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;
            }
            return DREGISTRO;
        }
        public int buscaTam(string nEntidad, string nAtributo)
        {
            char tipo;
            string n = "";
            string na = "";
            long DSIG = 0, DSIGA = 0;
            int tam  = 0;
            long DA = 0;
            bw.Close();
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                br.ReadInt64();
                DA = br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                if (n == nEntidad)
                {
                    br.BaseStream.Position = DA;
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        
                        na = br.ReadString(); //nombre
                        tipo = br.ReadChar(); //tipo
                        tam = br.ReadInt32();       //longitud
                        br.ReadInt64();       // direccion
                        br.ReadInt32();      // tipo indice
                        br.ReadInt64();       //direccion indice
                        DSIGA = br.ReadInt64();      // dirección siguiente
                        if (na == nAtributo)
                        {
                            br.Close();
                            return tam;
                        }
                        if (DSIGA != -1)
                        br.BaseStream.Position = DSIGA;
                        else
                        break;
                        

                    }



                }
                if (DSIG == -1)
                break;

            }

            br.Close();
            
            return 0;
        }
        public char buscaTipo(string nEntidad,string nAtributo)
        {
            char tipo;
            string n = "";
            string na = "";
            long DSIG = 0, DSIGA = 0;
            
            long DA = 0;
            bw.Close();
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                br.ReadInt64();
                DA = br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                if(n == nEntidad)
                {
                    br.BaseStream.Position = DA;
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        
                        na = br.ReadString(); //nombre
                        tipo = br.ReadChar(); //tipo
                        br.ReadInt32();       //longitud
                        br.ReadInt64();       // direccion
                        br.ReadInt32();      // tipo indice
                        br.ReadInt64();       //direccion indice
                        DSIGA = br.ReadInt64();      // dirección siguiente
                        if (na == nAtributo)
                        {
                            br.Close();
                            //bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
                            return tipo;
                        }
                        if (DSIGA != -1)
                        br.BaseStream.Position = DSIGA;
                        else
                        break;
                        
                        
                    }
                    


                }
                if (DSIG == -1)
                break;
                
            }

            br.Close();
            //bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
            return ' ';
        }
        public int buscaLongitud(string nombre)
        {
            int tipo = 0;
            long final = 0;
            string nombreEntidad = comboBox6.SelectedItem.ToString();
            bw.Close();
            br = new BinaryReader(File.Open("Entidad.bin", FileMode.Open));
            long apuntador;
            apuntador = br.ReadInt64();
            string n;
            long pAtributo = 0;
            string nApuntador;
            while (apuntador < br.BaseStream.Length)
            {
                n = br.ReadString();
                br.ReadInt64();//direccion entidad
                pAtributo = br.ReadInt64(); // direccion atributo  
                br.ReadInt64(); // direccion del registro
                br.ReadInt64(); // direccion siguiente
                if (nombreEntidad == n)
                {
                    br.BaseStream.Position = pAtributo;
                    apuntador = br.BaseStream.Position;
                    

                    while (final != -3)
                    {

                        nApuntador = br.ReadString();
                        br.ReadChar();//tipo   
                        if (nombre == nApuntador)
                        {
                            tipo = br.ReadInt32(); // Longitud
                        }
                        else
                        {
                            br.ReadInt32();
                        }
                        br.ReadInt64(); // direccion atributo
                        br.ReadInt32(); // TIPO DE INDICE
                        br.ReadInt64(); // direccion indice
                        final = br.ReadInt64(); // direccion siguiente
                        //MessageBox.Show("final ->" + final);
                    }

                }
                apuntador = br.BaseStream.Position;
            }
            br.Close();
            bw = new BinaryWriter(File.Open("Entidad.bin", FileMode.Open));
            return tipo;
        }
        public int buscaTipoIndice(string nombre)
        {
            int tipo = 0;
            long final = 0;
            string nombreEntidad = comboBox6.SelectedItem.ToString();
            bw.Close();
            br = new BinaryReader(File.Open("Entidad.bin", FileMode.Open));
            long apuntador;
            apuntador = br.ReadInt64();
            string n;
            string nAtributo = "";
            long pAtributo;
            while (apuntador < br.BaseStream.Length)
            {
                n = br.ReadString();
                br.ReadInt64();//direccion entidad
                pAtributo = br.ReadInt64(); // direccion atributo  
                br.ReadInt64(); // direccion del registro
                br.ReadInt64(); // direccion siguiente
                if (nombreEntidad == n)
                {
                    //apuntador = br.BaseStream.Position;
                    apuntador = pAtributo;
                    //MessageBox.Show("Dirección atributo : " + pAtributo);
                    br.BaseStream.Position = pAtributo;
                    while (final != -3)
                    {

                        nAtributo = br.ReadString(); // nombre
                        br.ReadChar();//tipo
                        br.ReadInt32();// longitud
                        br.ReadInt64(); // direccion atributo
                        if (nombre == nAtributo)
                        {
                            tipo = br.ReadInt32(); // TIPO DE INDICE
                        }
                        else
                        {
                            br.ReadInt32();
                        }
                        br.ReadInt64(); // direccion indice
                        final = br.ReadInt64(); // direccion siguiente
                        //MessageBox.Show("final ->" + final);
                    }

                }
                apuntador = br.BaseStream.Position;
            }
            br.Close();
            bw = new BinaryWriter(File.Open("Entidad.bin", FileMode.Open));
            return tipo;

        }
        /**************************************************************************************************************************************
         * METODO BUSCA TIPO DE DATO
         * PARAMETRO : Recibe el nombre del atributo para obtener su tipo  
         **************************************************************************************************************************************/
         public  char buscaTipoDato(string nombre)
         {
            char tipo = ' ';
            long final = 0;
            string nombreEntidad = comboBox6.SelectedItem.ToString();
            bw.Close();
            br = new BinaryReader(File.Open("Entidad.bin", FileMode.Open));
            long apuntador;
            apuntador = br.ReadInt64();
            string n;
            string nAtributo = "";
            long pAtributo;
            while (apuntador < br.BaseStream.Length)
            {
                n = br.ReadString();
                br.ReadInt64();//direccion entidad
                pAtributo = br.ReadInt64(); // direccion atributo  
                br.ReadInt64(); // direccion del registro
                br.ReadInt64(); // direccion siguiente
                if (nombreEntidad == n)
                {
                    //apuntador = br.BaseStream.Position;
                    apuntador = pAtributo;
                   // MessageBox.Show("Dirección atributo : " + pAtributo);
                    br.BaseStream.Position = pAtributo;
                    while (final != -3)
                    {

                        nAtributo = br.ReadString(); // nombre
                        if (nombre == nAtributo)
                        {
                           tipo = br.ReadChar(); // TIPO
                       }
                       else
                       {
                            br.ReadChar();//tipo
                        }
                        br.ReadInt32();// longitud
                        br.ReadInt64(); // direccion atributo
                        br.ReadInt32();
                        br.ReadInt64(); // direccion indice
                        final = br.ReadInt64(); // direccion siguiente
                        //MessageBox.Show("final ->" + final);
                    }

                }
                apuntador = br.BaseStream.Position;
            }
            br.Close();
            bw = new BinaryWriter(File.Open("Entidad.bin", FileMode.Open));
            return tipo;
        }

        public void busca()
        {
            List<string> nomb = new List<string>();
            int i = 0;
            
            while(i < registros.Count)
            {
                foreach (Atributo a in atributo)
                {
                    if (registros[i] == a.dameNombre())
                    {
                        indices ax;
                        ax.val = i;
                        ax.tipo = a.dameTI();
                        listaIndices.Add(ax);
                        break;
                    }
                }
                i++;
            }
        }
        


        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            registro[registro.Count - 1].Close();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            foreach(BinaryWriter arch in indice)
            {
                arch.Close();
            }
        }
        

        /************************************************************************************
         * Selección del tipo de índice
         * Aquí sucede todos los movimientos necesarios para los indices
         * TIPO DE INDICE
         * 0 -- sin tipo
         * 1 -- clave de búsqueda 
         * 2 -- indice primario
         * 3 -- índice secundario
         * 4 -- árbol b+
         * 5 -- multilistas
         ************************************************************************************/
         private void comboIndice_SelectedIndexChanged(object sender, EventArgs e)
         {

            switch(comboIndice.SelectedItem.ToString())
            {
                case "Sin tipo":
                tipoIndice = 0;
                
                break;
                case "Clave de búsqueda":
                tipoIndice = 1;   
                break;
                case "Índice primario":
                tipoIndice = 2;
                break;
                case "Índice secundario":
                tipoIndice = 3;
                
                break;
                case "Árbol B+":
                tipoIndice = 4;    
                break;
                case "Multilistas":
                tipoIndice = 5;
                
                break; 
            }
        }
        
        /*******************************************************************************
         * Selecciona el atributo para mostrar el indice
         *******************************************************************************/
         private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
         {
            string nombreAtributo;
            nombreAtributo = comboBox5.Text;
            foreach(Atributo tipo in atributo)
            {
                if(nombreAtributo == tipo.dameNombre())
                {
                    textoIndice.Text = tipo.dameTI().ToString();                
                }
            }
            switch(textoIndice.Text)
            {
                case "0":
                textoIndice.Text = "Sin tipo";
                break;
                case "1":
                textoIndice.Text = "Clave de búsqueda";
                break;
                case "2":
                textoIndice.Text = "Índice Primario";
                break;
                case "3":
                textoIndice.Text = "Índice Secundario";
                break;
                case "4":
                textoIndice.Text = "Árbol B+";
                break;
                case "5":
                textoIndice.Text = "Multilistas";
                break;
            }
        }

        private void cEntidadRegistro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombre;
            string n;
            long apuntador;
            long final = 0;
            nombre = cEntidadRegistro.Text;
            
            bw.Close();
            // Se manda llamar a la apertura del archivo
            br = new BinaryReader(File.Open("Entidad.bin", FileMode.Open));
            apuntador = br.ReadInt64();
            while(apuntador < br.BaseStream.Length)
            {
                n = br.ReadString();
                br.ReadInt64();//direccion entidad
                br.ReadInt64(); // direccion atributo  
                br.ReadInt64(); // direccion del registro
                br.ReadInt64(); // direccion siguiente
                if(nombre == n)
                {
                    MessageBox.Show("Nombre Entidad ->" + n);
                    apuntador = br.BaseStream.Position;
                    MessageBox.Show("Apuntador a atributo ->" + apuntador); 
                    while(final != -3)
                    {
                        comboBox5.Items.Add(br.ReadString()); // nombre atributo
                        MessageBox.Show("Nombre -> " +comboBox5.Text);
                        MessageBox.Show("tipo ->" +br.ReadChar());//tipo
                        MessageBox.Show("longitud ->" +br.ReadInt32());// longitud
                        MessageBox.Show("direccion atributo ->" + br.ReadInt64()); // direccion atributo
                        MessageBox.Show("tipo indice ->" + br.ReadInt32()); // tipo de indice
                        MessageBox.Show("direccion indice ->" + br.ReadInt64()); // direccion indice
                        final = br.ReadInt64(); // direccion siguiente
                        MessageBox.Show("final ->" + final);
                       // if (final == -3)
                      //  {
                        //    break;
                       // }
                    }

                    break;
                }
                apuntador = br.BaseStream.Position;
            }
            br.Close();
            bw = new BinaryWriter(File.Open("Entidad.bin", FileMode.Open));
            foreach(Entidad i in entidad)
            {
                if(i.dameDA() == apuntador)
                {

                }
            }

        }
        /****************************************************************************************
         * CONTROL DE ARCHIVOS .IDX Y .DAT
         ****************************************************************************************/
         public BinaryWriter cargaRegistro(string nRegistro)
         {
            BinaryWriter arch;
            if (File.Exists(nRegistro))
            {
                arch = new BinaryWriter(File.Open(nRegistro, FileMode.Create));

            }
            else
            {
                //MessageBox.Show("Se creo " + nRegistro);
                arch = new BinaryWriter(File.Open(nRegistro, FileMode.Create));
            }
            return arch;
        }
        // Selecciona Entidad
        
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dato = "", indice= "";
            foreach (Entidad aux in entidad)
            {
                dato = aux.dameNombre() + ".dat";
                indice = aux.dameNombre() + ".idx";
                datos.Add(dato);
                indi.Add(indice);
            }
            TR = calculaTamRegistro(comboBox6.Text);
            Atributo iPrimario = dameIndicePrimario(comboBox6.Text);
            Atributo iSecundario = dameIndiceSecundario(comboBox6.Text);
            secundarios = buscaSecundarios(comboBox6.Text);
            int posSecundario = 0;
            List<int> iSecundarios = new List<int>();
            pintaTablaRegistros();
            int j = 0;
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                if (iSecundario != null)
                {
                    if (dataGridView3.Columns[i].Name == secundarios[j]) /* Encuentra la columna para realizar el ordenamiento*/
                    {
                        posSecundario = i;
                        iSecundarios.Add(i);
                        if (j < secundarios.Count)
                        j++;
                        else
                        break;
                        
                    }
                }

            }
            dataGridView3.Columns.Clear();
            pintaTablaRegistros();
            imprimeRegistro(comboBox6.Text + ".dat");
            if(iPrimario != null)
            imprimePrimario(comboBox6.Text);
            //if (iSecundario != null)
                //insertaSecundario(comboBox6.Text+=".idx", iSecundarios);
            comboSecundario.Items.Clear();
            foreach(string secun in secundarios)
            {
                comboSecundario.Items.Add(secun);
            }
            calculaTam(dato);
            insertaNodo(comboBox6.Text + ".idx", null,0);
            
        }
        private void pintaTablaRegistros()
        {
            // Leer el archivo
            // ir insertando en el datagrid todos los atributos de  la entidad
            string nTemp = comboBox6.Text;
            long dAtributo = 0;
            string n;
            long DSIG = 0,DSIGA = 0;
            // br = new BinaryReader(File.Open(nArchivo, FileMode.Open));


            br.Close();
            bw.Close();
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();//nombre
                br.ReadInt64(); //direccion
                dAtributo = br.ReadInt64(); //direccion atributo
                br.ReadInt64();             // direccion datos
                DSIG = br.ReadInt64(); // direccion siguiente
                if(n == nTemp)
                {
                    if(dAtributo != -1)
                    {
                        br.BaseStream.Position = dAtributo;
                        while (br.BaseStream.Position < br.BaseStream.Length)
                        {
                            dataGridView3.Columns.Add(br.ReadString(), null);  //nombre
                            br.ReadChar();    //tipo
                            br.ReadInt32();     // longitud
                            br.ReadInt64();     // direccion
                            br.ReadInt32();     // tipo de indice
                            br.ReadInt64();     // direccion indice
                            DSIGA = br.ReadInt64();     // direccion siguiente
                            if (DSIGA == -1)
                            {
                                break;
                            }
                            else
                            br.BaseStream.Position = DSIGA;
                        }
                    }
                    
                }
                if (DSIG == -1)
                break;
                else
                br.BaseStream.Position = DSIG;

            }





        }
        /************************************************************************************
         * MODIFICA ENTIDAD
         * Para modificar la entidad, se requiere buscar la entidad a modificar y borrarla
         * y después crear la nueva entidad.
         * Reutilizamos los metodos eliminaEntidad y creaEntidad
         ************************************************************************************/

         private void modificaEntidad(object sender, EventArgs e)
         {
            string nueva;
            string actual;
            long anterior;
            long actualSig;
            long DE;
            long cab;
            long siguiente;
            long entidadant;
            long DES = 0;
            bw.Close();
            br.Close();
            List<string> nombres = new List<string>();
            foreach (Entidad i in entidad)
            nombres.Add(i.dameNombre());
            ModificaEntidad modifica = new ModificaEntidad(nombres);
            if(modifica.ShowDialog() == DialogResult.OK)
            {
                actual = modifica.dameEntidad();
                nueva = modifica.dameNombre();
                
                if(nueva != "")
                {
                    while (nueva.Length < 29)
                    nueva += " ";
                    
                    DE = dameDireccionActual(actual);
                    br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
                    cab = br.ReadInt64();
                    br.BaseStream.Position = DE;
                    br.ReadString();
                    br.ReadUInt64();
                    br.ReadUInt64();
                    br.ReadUInt64();
                    DES = br.ReadInt64();
                    br.Close();

                    actualSig = actualSiguiente(actual);
                    anterior = dameAnterior(nueva,actual); // te da la direccion que te apuntara 
                    siguiente = dameSiguiente(nueva, actual);  // te da la direcciona a la que apuntaras
                    entidadant = dameEntidadAnterior2(actual, DE);
                    bw.Close();
                    br.Close();
                    bw = new BinaryWriter(File.Open(nArchivo,FileMode.Open));
                    
                    if (cab == DE)
                    {
                        bw.BaseStream.Position = 0;
                        bw.Write(DES);
                        cabecera.Text = DES.ToString();
                    }
                    if(anterior == 0)
                    {
                        bw.BaseStream.Position = 0;
                        bw.Write(DE);
                        cabecera.Text = DE.ToString();
                        
                    }
                    //actualizar nodo que apunta a nuevo
                    bw.BaseStream.Position = anterior + 30 + 8 + 8 + 8;
                    if(anterior != 0)
                    {
                        bw.Write(DE);
                    }
                    
                    // actualizar nombre
                    bw.BaseStream.Position = DE;
                    bw.Write(nueva);

                    //actualizar  siguiente de nuevo
                    bw.BaseStream.Position = DE + 30 + 8 + 8 + 8;
                    bw.Write((long)siguiente);
                    if(DES !=  siguiente && DES != -1 )
                    {
                        bw.BaseStream.Position = entidadant + 30 + 8 + 8 + 8;
                        bw.Write(DES);
                    }
                    if(anterior == 0)
                    {

                    }


                    //actualiza nodo 
                    //bw.BaseStream.Position = entidadant + 30 + 8 + 8 + 8;
                    //bw.Write(anterior);
                    bw.Close();

                }
                imprimeLista(entidad);
                

            }
            
        }
        public long actualSiguiente(string actual)
        {
            br.Close();
            bw.Close();
            string n = "";
            long DE = 0, DSIG;
            long DE2 = 0;
            int compara;
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                DE = br.ReadInt64();
                br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if (n == actual)
                {
                    br.Close();
                    return DSIG;
                }

                DE2 = DE;

                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;
            }
            return -1;

        }
        public long dameEntidadAnterior2(string actual,long dir)
        {
            br.Close();
            bw.Close();
            string n = "";
            long DE = 0, DSIG;
            long DE2 = 0;
            int compara;
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                DE = br.ReadInt64();
                br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if (DSIG == dir)
                {
                    br.Close();
                    return DE;
                }

                DE2 = DE;

                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;
            }
            return -1;
        }
        public long dameSiguiente(string nEntidad, string actual)
        {
            br.Close();
            bw.Close();
            string n = "";
            long DE = 0, DSIG;
            long DE2 = 0;
            int compara;
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                DE = br.ReadInt64();
                br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if (n != actual)
                {
                    compara = n.CompareTo(nEntidad);

                    if (compara == 1)
                    {
                        br.Close();
                        return DE;
                    }
                }

                DE2 = DE;

                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;
            }
            return -1;
        }
        public long dameAnterior(string nEntidad, string actual)
        {
            br.Close();
            bw.Close();
            string n = "";
            long DE = 0, DSIG;
            long DE2 = 0;
            int compara;
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                DE = br.ReadInt64();
                br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if(n != actual)
                {
                    compara = n.CompareTo(nEntidad);

                    if (compara == 1)
                    {
                        //if (br.BaseStream.Position == 70)
                           // DE2 = DE;
                        br.Close();
                        return DE2;
                    }
                    DE2 = DE;
                }
                
                

                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;
            }
            return DE;
        }
        public long dameDireccionActual(string nEntidad)
        {
            br.Close();
            bw.Close();
            string n = "";
            long DE, DSIG;
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                DE = br.ReadInt64();
                br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if(n == nEntidad)
                {
                    br.Close();
                    return DE;
                }
                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;


            }
            br.Close();
            return -1;
        }
        private void creaEntidad2(Entidad entis, string ant)
        {
            br.Close();
            bw.Close();
            bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
            foreach(Entidad s in entidad)
            {
                if(ant == s.dameNombre())
                {
                    bw.BaseStream.Position = s.dameDE();
                    break;
                }
            }
            long pos;
            long sig = 0;
            bw.Write(entis.dameNombre());
            bw.Write(entis.dameDE());
            bw.Write(entis.dameDA());
            bw.Write(entis.dameDD());
            pos = bw.BaseStream.Position;
            bw.Close();
            sig = buscaEntidad(ant);
            bw.Close();
            br.Close();
            bw.Close();
            bw = new BinaryWriter(File.Open(nArchivo,FileMode.Open));
            bw.BaseStream.Position = pos;
            bw.Write(sig);
            bw.Close();







        }
        private void generaRegistros(object sender, EventArgs e)
        {
            bw.Close(); 
            imprimeLista(entidad);
            string dato, indice;
            button4.Hide();
            bw.Close();
            foreach(Entidad aux in entidad)
            {
                dato = aux.dameNombre() + ".dat";
                indice = aux.dameNombre() + ".idx";
                datos.Add(dato);
                indi.Add(indice);
            }
            
            foreach(string nombre in datos)
            {
                bw = new BinaryWriter(File.Open(nombre, FileMode.Create));
                bw.Close();
            }
            
            foreach (string nombre in indi)
            {
                bw = new BinaryWriter(File.Open(nombre,FileMode.Create));
                bw.Close();
            }
            
            button2.Hide();
            bw.Close();

            //br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            comboBox6.Enabled = true;
            
        }

        private void cargaRegistros(object sender, EventArgs e)
        {
            br.Close();
            bw.Close();
            string dato;
            string indice;
            foreach (Entidad aux in entidad)
            {
                dato = aux.dameNombre() + ".dat";
                indice = aux.dameNombre() + ".idx";
                datos.Add(dato);
                indi.Add(indice);
            }

            foreach (string nombre in datos)
            {
                bw = new BinaryWriter(File.Open(nombre, FileMode.Open));
                bw.Close();
            }

            foreach (string nombre in indi)
            {
                bw = new BinaryWriter(File.Open(nombre, FileMode.Open));
                bw.Close();
            }
            
            comboBox6.Enabled = true;
            button2.Hide();
            button4.Hide();

            
        }

        private void eliminaRegistro(object sender, EventArgs e)
        {
            string cB = "";
            long dirA = 0, dirB = 0;
            long direccionRegistro = 0;
            long DANT = 0;
            string dat = comboBox6.Text + ".dat";
            Atributo aClave = dameClaveBusqueda(dat);
            List<string> claves = new List<string>();
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                if (aClave != null && dataGridView3.Columns[i].Name == aClave.dameNombre()  ) /* Encuentra la columna para realizar el ordenamiento*/
                {
                    pos = i;
                    break;
                }
            }
            foreach (string arch in datos)
            {
                if (arch == dat)
                {
                    bw = new BinaryWriter(File.Open(dat, FileMode.Open));
                    break;
                }
            }
            

            for(int i = 0; i < dataGridView4.Rows.Count-2; i++)
            {
               claves.Add(dataGridView4.Rows[i].Cells[pos+1].Value.ToString());
           }
           EliminaRegistro elimina = new EliminaRegistro(claves);
           if(elimina.ShowDialog() == DialogResult.OK)
           {
            cB = elimina.dameClave();

                /*buscar en datagrid4 el valor que tenga como nombre el Cb */
            for(int i = 0; i < dataGridView4.Rows.Count-1; i++)
            {
                if(dataGridView4.Rows[i].Cells[pos+1].Value.ToString() == cB)
                {
                    direccionRegistro = Convert.ToInt64(dataGridView4.Rows[i].Cells[0].Value);
                    break;
                }
            }
            

            for (int i = 0; i < dataGridView4.Rows.Count - 2; i++)
            {
                if (dataGridView4.Rows[i].Cells[dataGridView4.Columns.Count-1].Value.ToString() == direccionRegistro.ToString())
                {
                    DANT = Convert.ToInt64(dataGridView4.Rows[i].Cells[0].Value);
                    break;
                }
            }
            
            br.Close();
            bw.Close();
            br = new BinaryReader(File.Open(dat, FileMode.Open));
            br.BaseStream.Position = DANT + primero-8;
            dirA = br.ReadInt64();
            br.BaseStream.Position = direccionRegistro + primero-8;
            dirB = br.ReadInt64();

            br.Close();
            bw = new BinaryWriter(File.Open(dat,FileMode.Open));
            bw.BaseStream.Position = DANT + primero - 8;
            bw.Write(dirB);
            
            bw.Close();
            long cab = dameDireccionRegistro(comboBox6.Text);
            if (cab == direccionRegistro)
            {
                br.Close();
                bw.Close();

                ponteRegistro(comboBox6.Text, dirB);
            }
            
            imprimeRegistro(dat);
            imprimePrimario(comboBox6.Text);
            
            
        }
    }
    public long dameApuntadorNodo(string actual, long DR, int clave)
    {
        int i, j;
        int compara = 0;
        long direccion = 0;
        for (i = 0; i < dataGridView4.Rows.Count - 2; i++)
        {
            if (dataGridView4.Rows[i].Cells[dataGridView4.Columns.Count-1].Value.ToString() == DR.ToString())
            {
                direccion = Convert.ToInt64(dataGridView4.Rows[i].Cells[0].Value);
                return direccion;
            }


        }

        return -1;
    }
    public long dameSiguienteR(string actual, long DR, int clave)
    {
        int i, j;
        int compara = 0;
        long direccion = 0;
        for (i = 0; i < dataGridView4.Rows.Count - 2; i++)
        {

            compara = actual.CompareTo(dataGridView4.Rows[i].Cells[clave + 1].Value.ToString());
            if (compara == 0)
            {
                direccion = Convert.ToInt64(dataGridView4.Rows[i].Cells[dataGridView4.Columns.Count - 1].Value);
                return direccion;
            }


        }

        return -1;
    }
    public long dameDireccionSiguienteAnterior(string actual, long DR, int clave)
    {
        int i, j;
        int compara = 0;
        long direccion = 0;
        for (i = 0; i < dataGridView4.Rows.Count - 2; i++)
        {

            compara = actual.CompareTo(dataGridView4.Rows[i].Cells[clave + 1].Value.ToString());
            if (compara == -1)
            {
                direccion = Convert.ToInt64(dataGridView4.Rows[i - 1].Cells[dataGridView4.Columns.Count-1].Value);
                return direccion;
            }


        }

        return -1;
    }
        /********************************************************************************
         *  Metodo encargado de recorrer los registros y encontrar cual apunta al nuevo
         ********************************************************************************/
         public long dameDireccionAnteriorRegistro(string actual, long DR, int clave)
         {
            int i, j;
            int compara = 0;
            long direccion = 0;
            for(i = 0; i < dataGridView4.Rows.Count-2;i++)
            {

                compara = actual.CompareTo(dataGridView4.Rows[i].Cells[clave+1].Value.ToString());
                if(compara == -1)
                {
                    if(i == 0)
                    {
                        direccion = Convert.ToInt64(dataGridView4.Rows[i].Cells[0].Value);
                    }
                    else 
                    direccion = Convert.ToInt64(dataGridView4.Rows[i-1].Cells[0].Value);
                    return direccion;
                }

                
            }

            return -1;
        }

        private void modificaRegistro(object sender, EventArgs e)
        {
            List<string> claves = new List<string>();
            Atributo aClave = dameClaveBusqueda(comboBox6.Text+".dat");
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                if (dataGridView3.Columns[i].Name == aClave.dameNombre()) /* Encuentra la columna para realizar el ordenamiento*/
                {
                    pos = i;
                    break;
                }
            }
            for (int i = 0; i < dataGridView4.Rows.Count - 2; i++)
            {
                claves.Add(dataGridView4.Rows[i].Cells[pos+1].Value.ToString());
            }
            ModificaRegistro mod = new ModificaRegistro(dataGridView3,dataGridView4,claves);
            DataGridView tablatemp = new DataGridView();
            char tipo;
            long pos2 = 0;
            long DireccionRegistro = 0;
            string nRegistro = "";
            string n;
            long DSIGR = 0;
            long DANT = 0;
            long DSANT = 0;
            long DACTUAL = 0;
            tam = 0;
            if (mod.ShowDialog() == DialogResult.OK)
            {
                n = mod.dameClave(); // nombre actual
                
                for (int i = 0; i < dataGridView4.Rows.Count - 2; i++)
                {

                    if(dataGridView4.Rows[i].Cells[pos+1].Value.ToString() == n)
                    {
                     
                        bw = new BinaryWriter(File.Open(comboBox6.Text+".dat", FileMode.Open));
                        pos2 = (long)dataGridView4.Rows[i].Cells[0].Value; // Se obtiene la dirección del registro a modificar
                        DireccionRegistro = pos2;
                        DACTUAL = dameSiguienteR(n, DireccionRegistro, pos);



                        pos2 += 8;
                        for (int j = 0; j < mod.dameRenglon().Columns.Count; j++)
                        {
                            dataGridView4.Rows[i].Cells[j + 1].Value = mod.dameRenglon().Rows[0].Cells[j].Value; // Se intercambian los nombres

                            br.Close();
                            bw.Close();
                            tipo = buscaTipo(comboBox6.Text, dataGridView3.Columns[j].Name); // busca el tipo de registro
                            bw.Close();
                            bw = new BinaryWriter(File.Open(comboBox6.Text+".dat", FileMode.Open));
                            bw.BaseStream.Position = pos2-1; //Se iguala a la posicion para cambiar el nombre
                            if (tipo == 'E')
                            {
                                
                                bw.Write(Convert.ToInt32(mod.dameRenglon().Rows[0].Cells[j].Value));
                                pos2 += 4;
                                
                            }
                            else if (tipo == 'C')
                            {
                                int tamC = buscaTam(comboBox6.Text, dataGridView3.Columns[j].Name); // Busca el tamñano del nombre del registro
                                bw = new BinaryWriter(File.Open(comboBox6.Text + ".dat", FileMode.Open));
                                bw.BaseStream.Position = pos2; // Se iguala a la posicion para el cambiar el nombre del registro
                                while (mod.dameRenglon().Rows[0].Cells[j].Value.ToString().Length < tamC-1)
                                {
                                    mod.dameRenglon().Rows[0].Cells[j].Value += " ";
                                }

                                
                                
                                bw.Write(mod.dameRenglon().Rows[0].Cells[j].Value.ToString()); // Se escribe el nuevo nombre
                                nRegistro = (string)mod.dameRenglon().Rows[0].Cells[j].Value;
                                pos2 += tamC+1;

                            }

                            
                        }
                        bw.Close();
                        br.Close();
                        // DSIGR = siguienteRegistro(comboBox6.Text+".dat", aClave, primero, comboBox6.Text, nRegistro, DireccionRegistro);
                        //  bw = new BinaryWriter(File.Open(comboBox6.Text+".dat",FileMode.Open)); 
                        //  bw.BaseStream.Position = pos2;
                        //bw.Write(DSIGR);

                        /*     ACTUALIZACION DE DIRECCIONES     */


                        // ACTUALIZA A ==> B
                        DANT = dameDireccionAnteriorRegistro(mod.dameRenglon().Rows[0].Cells[pos].Value.ToString(), DireccionRegistro, pos);
                        //MessageBox.Show("Direccion de A: " + DANT);
                        
                        bw = new BinaryWriter(File.Open(comboBox6.Text + ".dat", FileMode.Open));
                        bw.BaseStream.Position = DANT + TR - 8;
                        bw.Write(DireccionRegistro);
               //         MessageBox.Show("Direccion de B: " + DireccionRegistro);
                        // ACTUALIZA B == > C
                        DSANT = dameDireccionSiguienteAnterior(mod.dameRenglon().Rows[0].Cells[pos].Value.ToString(), DireccionRegistro, pos);
                        bw.BaseStream.Position = DireccionRegistro + TR - 8;
                        bw.Write(DSANT);
             //           MessageBox.Show("Direccion de C: " + DSANT);
                        // ACTUALIZA C == > D

                        
              //          MessageBox.Show("Direccion de E: " + DACTUAL);
                        long AP = dameApuntadorNodo(mod.dameRenglon().Rows[0].Cells[pos].Value.ToString(), DireccionRegistro, pos);
                        bw.Close();
                        bw = new BinaryWriter(File.Open(comboBox6.Text + ".dat", FileMode.Open));
                        bw.BaseStream.Position = AP + TR -8;
                        bw.Write(DACTUAL);
                        bw.Close();



                        bw.Close();
                        if(DANT == -1)
                        {
                            br.Close();
                            bw.Close();
                            ponteRegistro(comboBox6.Text, DACTUAL);
                            br.Close();
                            bw.Close();
                        }
                        imprimeRegistro(comboBox6.Text + ".dat");
                        break;
                    }
                }
            }
            imprimeRegistro(comboBox6.Text+".dat");
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void modificaAtributo(object sender, EventArgs e)
        {
            ModificaAtributo mod = new ModificaAtributo(atributo);
            Atributo nuevo;
            bw.Close();
            br.Close();
            if(mod.ShowDialog() == DialogResult.OK)
            {
                nuevo = mod.dameNuevo();
                bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
                bw.BaseStream.Position = nuevo.dameDireccion();
                bw.Write(nuevo.dameNombre());
                bw.Write(nuevo.dameTipo());
                bw.Write(nuevo.dameLongitud());
                bw.Write(nuevo.dameDireccion());
                bw.Write(nuevo.dameTI());
                bw.Write(nuevo.dameDirIndice());
                bw.Write(nuevo.dameDirSig());
                bw.Close();
                imprimeLista(entidad);
                imprimeAtributo(atributo);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /**************************************************************************************************************************
         *  Se crea un nuevo diccionario de datos 
         **************************************************************************************************************************/
         private void nuevoProyecto(object sender, EventArgs e)
         {

            string nombre = " ";
            button1.Enabled = true;
            modificar.Enabled = true;
            button3.Enabled = true;
            textBox1.Enabled = true;
            button4.Hide();
            Archivo archivo = new Archivo(nombre);

            AddOwnedForm(archivo);
            
            if (archivo.ShowDialog() == DialogResult.OK )
            {
                nombre = archivo.nombre + ".bin";
                MessageBox.Show("Nombre de archivo " + nombre);
                bw = new BinaryWriter(File.Open(nombre, FileMode.Create));
                bw.Write((long)8);
                nuevo = true;
                button7.Hide();
                button8.Hide();
                nArchivo = nombre;
                bw.Close();
                bw = new BinaryWriter(File.Open(nombre, FileMode.Open));
            }
        }

        private void comboSecundario_SelectedIndexChanged(object sender, EventArgs e)
        {
            br.Close();
            bw.Close();
            tablaSecundario.Rows.Clear();
            insertaSecundario(comboBox6.Text,iSecundarios);
            br.Close();
            bw.Close();
        }

        private void muestraIndicePrimario(object sender, EventArgs e)
        {
            Atributo iPrimario = dameIndicePrimario(comboBox6.Text);
            int posprimario = 0;
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                if (iPrimario != null)
                {
                    if (dataGridView3.Columns[i].Name == iPrimario.dameNombre()) /* Encuentra la columna para realizar el ordenamiento*/
                    {
                        posprimario = i;
                        break;
                    }
                }

            }
            insertaPrimario(comboBox6.Text + ".idx", iPrimario, posprimario);
            imprimePrimario(comboBox6.Text);
        }

        

        /**************************************************************************************************************************
         * Metodo encargado de eliminar la entidad
         * sus apuntadores los hace null
         * el nombre cambia a eliminado
         * la entidad anterior apunta al siguiente de la entidad eliminada
         *************************************************************************************************************************/
         private void eliminaEntidad(object sender, EventArgs e)
         {
            br.Close();
            bw.Close();
            string n = textBox1.Text;
            while (n.Length < 29)
            n += " ";
            long anterior;
            anterior = dameEntidadAnterior(n);
            long siguiente;
            long cab = 0;
            string nn = " ";
            siguiente = dameSiguienteEntidad(n);
            br = new BinaryReader(File.Open(nArchivo,FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            nn = br.ReadString();
            br.Close();
            bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
            
            if(nn == n)
            {
                bw.BaseStream.Position = 0;
                bw.Write(siguiente);
                cabecera.Text = siguiente.ToString();
            }
            bw.BaseStream.Position = anterior + 30 + 8 + 8 + 8;
            if(anterior == -1)
            {
                bw.BaseStream.Position = 0;
            }
            bw.Write(siguiente);
            bw.Close();
            imprimeLista(entidad);
            

        }
        public long dameSiguienteEntidad(string nEntidad)
        {
            br.Close();
            bw.Close();
            string n = "";
            long DSIG = 0;

            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                br.ReadInt64();
                br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if(n == nEntidad)
                {
                    br.Close();
                    return DSIG;
                }
                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;
            }
            return -1;
        }
        public long dameEntidadAnterior(string nEntidad)
        {
            br.Close();
            bw.Close();
            string n = "";
            long DSIG = 0;
            long DE = 0;
            long ANT = 0;
            long DSANT = 0;
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            br.BaseStream.Position = br.ReadInt64();
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                n = br.ReadString();
                DE = br.ReadInt64();
                br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
                if(n == nEntidad)
                {
                    break;
                }
                if (DSIG != -1)
                br.BaseStream.Position = DSIG;
                else
                break;
            }
            br.BaseStream.Position = 0;
            br.BaseStream.Position = br.ReadInt64();
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                br.ReadString();
                ANT = br.ReadInt64();
                br.ReadInt64();
                br.ReadInt64();
                DSANT = br.ReadInt64();
                if(DSANT == DE)
                {
                    br.Close();
                    return ANT;
                }
                if (DSANT != -1)
                br.BaseStream.Position = DSANT;
                else
                break;
            }

            br.Close();
            return -1;
        }
        
    }
}
