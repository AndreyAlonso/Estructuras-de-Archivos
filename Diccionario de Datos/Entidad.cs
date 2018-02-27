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

    	// Constructor 
    	public Entidad()
    	{
    		nombre = new char[20];
    		DE = -1;
    		DA = -1;
    		DD = -1;
    		DSIG  = -1;

    	}
    }
}
