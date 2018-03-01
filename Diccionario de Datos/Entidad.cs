using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**********************************************************************************************
 * Clase Entidad
 *
 *
 *********************************************************************************************/

namespace Diccionario_de_Datos
{
    class Entidad
    {
    	private char[] nombre; 	// nombre Entidad
    	private long DE;		// Dirección Entidad		
    	private long DA;		// Dirección Atributo
    	private long DD;		// Dirección del Registro
    	private long DSIG;		// Direccioón Siguiente Entidad
        private int i;

    	// Constructor 
    	public Entidad()
    	{
            nombre = new char[20];
    		DE = -1;
    		DA = -1;
    		DD = -1;
    		DSIG  = -1;
            i = 0;

    	}
    	//Get's y Set's
    	public void nombrate(string n){
            this.nombre = n.ToCharArray();
        }
        public void direccionate(long dir){
            this.DE = dir;
        }
        public void ponteDireccionAtributo(long dir){
            this.DA = dir;
        }
        public void ponteDireccionRegistro(long dir){
            this.DD = dir;
        }
        public void ponteDireccionSig(long dir){
            this.DSIG = dir;
        }
        public string dameNombre() { string _nombre = this.nombre.ToString(); return _nombre; }
        public long dameDE() { return DE; }
        public long dameDA(){ return DA;}
        public long dameDD(){ return DD;}
        public long dameDSIG() { return DSIG; }

    }
}
