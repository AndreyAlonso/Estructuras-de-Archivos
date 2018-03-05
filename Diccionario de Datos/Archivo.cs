using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*************************************************************************************************************
 * Clase Archivo
 * Permite guardar en archivo binario la información de las entidades y atributos
 * 
 *************************************************************************************************************/
namespace Diccionario_de_Datos
{
    class Archivo
    {
        private long cab;
        public Archivo()
        {
           
        }
        public void guardaEntidad(List<Entidad> entidad)
        {
            using (BinaryWriter arch = new BinaryWriter(File.Open("Entidad.bin", FileMode.Create)))
            {
                arch.Write(cab);
                for (int i = 0; i < entidad.Count; i++)
                {
                    arch.Write(entidad[i].dameNombre());
                    arch.Write(entidad[i].dameDE());
                    arch.Write(entidad[i].dameDA());
                    arch.Write(entidad[i].dameDD());
                    arch.Write(entidad[i].dameDSIG());
                }
                arch.Close();
            }
        }
        public void leeArchivo()
        {
            string nombre;
            long DE, DA, DD, DSIG;

            using(BinaryReader arch = new BinaryReader(File.Open("Entidad.bin",FileMode.Open)))
            {
                nombre = arch.ReadString();
                
                

            }
            
        }
    }
}
