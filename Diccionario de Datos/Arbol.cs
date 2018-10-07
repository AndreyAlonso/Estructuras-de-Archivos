﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_Datos
{
    class Arbol: List<Nodo>
    {        
        public int renglon { get; set; }
        public int tam { get; set; }
        public int valor { get; set; }
        
        public Arbol()
        {
           
       

        }
        public Nodo creaNodo(Nodo nuevo, long DN)
        {
            nuevo.tipo = 'H';
            nuevo.dirNodo = DN;
            nuevo.sig = -1;
            nuevo.clave = new List<int>();
            nuevo.direccion = new List<long>();

            return nuevo;
        }
        public long dameRaiz()
        {
            foreach(Nodo n in this)
            {
                if(n.tipo == 'R')
                {
                    return n.dirNodo;
                }
            }
            return -1;
        }
        public Nodo dameNodo(long dir)
        {
            Nodo aux = new Nodo();
            foreach(Nodo np in this)
            {
                if(np.dirNodo == dir)
                {
                    aux = np;
                }
            }
            return aux;
        }
        public Nodo dameNodo(long dir, long no)
        {
            Nodo aux = new Nodo();
            foreach (Nodo np in this)
            {
                if (np.dirNodo == dir && np.dirNodo != no)
                {
                    aux = np;
                }
            }
            return aux;
        }
        public bool existeIntermedio()
        {
            bool band = false;
            foreach (Nodo n in this)
            {
                if (n.tipo == 'I')
                {
                    band = true;
                    return band;
                }
            }
            return band;
        }
        public int totalIntermedio()
        {
            int total = 0;
            foreach(Nodo n in this)
            {
                if (n.tipo == 'I')
                    total++;
               
            }
            return total;
        }
        public long buscaNodo(int clave)
        {
            bool intermedio = false;
            intermedio = existeIntermedio();
            int total = totalIntermedio();
            int cont = 0;
            Nodo inter, inter2 = new Nodo();
            foreach(Nodo n in this)
            {
                if(n.tipo == 'R' && intermedio == false )
                {
                    for(int i = 0; i < n.clave.Count; i++)
                    {
                        if (clave < n.clave[i])
                        {

                            return n.direccion[i];
                        }
                        
                        else if(i == n.clave.Count-1)
                        {
                            return n.direccion[i + 1];
                        }
                        

                    }
                }
                else if (n.tipo == 'I' && intermedio == true)
                {
                    inter = dameNodo(dameRaiz());
                    cont++;
                    for(int i = 0; i < inter.clave.Count; i++)
                    {
                        if(clave < inter.clave[i])
                        {
                            //inter2 = inter;
                            inter2 = dameNodo(inter.direccion[i]);
                            break;
                        }
                        else if (i == inter.clave.Count -1)
                        {
                            inter2 = dameNodo(inter.direccion[i + 1]);
                            break;
                        }

                        
                          
                    }
                    if(inter2.clave.Count > 0)
                    {
                        for (int i = 0; i < inter2.clave.Count; i++)
                        {
                            if (clave < inter2.clave[i])
                            {

                                return inter2.direccion[i];
                            }

                            else if (i == inter2.clave.Count - 1)
                            {
                                return inter2.direccion[i + 1];
                            }


                        }
                    }
                    
                }
            }
            return -1;
        }
        public long dameUltimoNodo()
        {
            foreach(Nodo np in this)
            {
                if (np.tipo != 'R' && np.sig == -1)
                    return np.dirNodo;
            }
            return -1;
        }
        public bool agregaDato(long direccion, int clave, long apuntador)
        {
            int g;
            int pos = 0;
            List<int> tempClave = new List<int>();
            List<long> tempDir = new List<long>();
            foreach (Nodo np in this)
            {
                if (np.dirNodo == direccion)
                {
                    if(np.clave.Count < 4)
                    {
                        np.clave.Add(clave);
                        np.direccion.Add(apuntador);
                        ordenaNodo(np);
                        return false;

                    }
                    else if(np.clave.Count == 4) // Aqui se reestructura el nodo
                    {

                        return true;
  
                    }
                   
                }
            }
            return false;
        }
        public void ordenaNodo(Nodo np)
        {
            int i, j, k;
            long k2;
            for (i = np.clave.Count - 1; i > 0; i--)
                for (j = 0; j < i; j++)
                    if (np.clave[j] > np.clave[j + 1])
                    {
                        k = np.clave[j];
                        np.clave[j] = np.clave[j + 1];
                        np.clave[j + 1] = k;

                        k2 = np.direccion[j];
                        np.direccion[j] = np.direccion[j + 1];
                        np.direccion[j + 1] = k2;
                    }
        }
        public void ordenaCinco(List<int> tempClave, List<long> tempDir)
        {
            int i, j, k;
            long k2;
            for (i = tempClave.Count - 1; i > 0; i--)
                for (j = 0; j < i; j++)
                    if (tempClave[j] > tempClave[j + 1])
                    {
                        k = tempClave[j];
                        tempClave[j] = tempClave[j + 1];
                        tempClave[j + 1] = k;

                        k2 = tempDir[j];
                        tempDir[j] = tempDir[j + 1];
                        tempDir[j + 1] = k2;
                    }
        }
        
    }
}
