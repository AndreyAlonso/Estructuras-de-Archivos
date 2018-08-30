using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diccionario_de_Datos
{
    public partial class EliminaAtributo : Form
    {
        private List<string> entidad = new List<string>();
        private string archivo;
        private BinaryReader br;
        private string nAtributo;
        private long dAtributo;


        public EliminaAtributo(List<string> entidad, string archivo)
        {
            InitializeComponent();

            this.entidad = entidad;
            this.archivo = archivo;

            foreach(string s in entidad)
            {
                comboBox1.Items.Add(s);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            long cab, DSIG = 0, DAT = 0;
            string n;
           
            br = new BinaryReader(File.Open(archivo, FileMode.Open));
            cab = br.ReadInt64();
            br.BaseStream.Position = cab;
            while(cab < br.BaseStream.Length)
            {
                if(DSIG != -1)
                {
                    n = br.ReadString();
                    br.ReadInt64();
                    DAT = br.ReadInt64();
                    br.ReadInt64();
                    DSIG = br.ReadInt64();
                    if(n == comboBox1.Text)
                    {
                        cab = DAT;
                        break;
                    }
                }
                br.BaseStream.Position = DSIG;
                cab = DSIG;  
            }
            // Apuntador en la lista de atributos de la entidad seleccionada
            if(cab != -1)
            {
                br.BaseStream.Position = cab;
                DSIG = 0;
                while (cab < br.BaseStream.Length)
                {
                    if (DSIG != -1)
                    {
                        comboBox2.Items.Add(br.ReadString()); // nombre
                        br.ReadChar();                        // tipo
                        br.ReadInt32();                       // longitud
                        br.ReadInt64();                       // Dirección
                        br.ReadInt32();                       // tipo indice
                        br.ReadInt64();                       // dirección indice
                        DSIG = br.ReadInt64();                // dirección siguiente

                        if(DSIG == -1)
                        {
                            break;
                        }
                        else
                        {
                            br.BaseStream.Position = DSIG;
                            cab = DSIG;
                        }
                        
                    }


                }


            }

            br.Close();             
        }
    }
}
