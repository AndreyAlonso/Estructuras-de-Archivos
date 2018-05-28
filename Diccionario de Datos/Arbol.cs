using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_Datos
{
    class Arbol
    {
        public long direccion { get; set; }
        public char tipo { get; set; }
        public long[] apuntador { get; set; }
        
        public int[]  clave { get; set; }
        public int tam { get; set; }

        public Arbol()
        {
            direccion = -1;
            tipo = 'H';
            apuntador = new long[4];
            clave = new int[4];
            tam = 0;

        }
        
        
    }
}
