using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_Datos
{
    class Atributo
    {
    	//Declaracion de variavbles
    	private char[] nombre;	// nombre del atributo
    	private char[] tipo;	// tipo del atributo
    	private int longitud;	// longitud del atributo 
    	private long DA;		// Dirección del atributo
    	private int TI;			// Tipo de Indice
    	private long DI;		// Dirección del indice
    	private long DSIG;		// Dirección siguiente atributo

    	//Constructor
    	public Atributo(){
    		nombre = new char[20];
    		tipo   = new char[1];
    		longitud = 0;
    		DA = -1;
    		TI = 0;
    		DI = -1;
    		DSIG = -1;
    	}
    }
}

