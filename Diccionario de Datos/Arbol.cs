using System;
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
        public long dameIntermedio(int clave)
        {
            long dir = -1;
            foreach(Nodo n in this)
            {
                if(n.tipo == 'R')
                {
                    for(int i = 0; i < n.clave.Count;i++)
                    {
                        if(clave < n.clave[i])
                        {
                            dir = n.direccion[i];

                            return dir;

                        }
                        else if(i == n.clave.Count-1)
                        {
                            dir = n.direccion[i + 1];
                            return dir;
                        }
                    }
                }
            }

            return dir;
        }
        public long buscaNodo(int clave)
        {
            bool intermedio = false;
            intermedio = existeIntermedio();
            int total = totalIntermedio();
            int cont = 0;
            Nodo inter, inter2 = new Nodo();
            foreach (Nodo n in this)
            {
                if (n.tipo == 'R' && intermedio == false)
                {
                    for (int i = 0; i < n.clave.Count; i++)
                    {
                        if (clave < n.clave[i])
                        {

                            return n.direccion[i];
                        }

                        else if (i == n.clave.Count - 1)
                        {
                            return n.direccion[i + 1];
                        }


                    }
                }
                else if (n.tipo == 'I' && intermedio == true)
                {
                    inter = dameNodo(dameRaiz());
                    cont++;
                    for (int i = 0; i < inter.clave.Count; i++)
                    {
                        if (clave < inter.clave[i])
                        {
                            //inter2 = inter;
                            inter2 = dameNodo(inter.direccion[i]);
                            break;
                        }
                        else if (i == inter.clave.Count - 1)
                        {
                            inter2 = dameNodo(inter.direccion[i + 1]);
                            break;
                        }



                    }
                    if (inter2.clave.Count > 0)
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

            /*
            bool intermedio = false;
            intermedio = existeIntermedio();
            List<int> ClavesIntermedio = new List<int>();
            List<long> DirIntermedio = new List<long>();
            int total = totalIntermedio();
            int cont = 0;
            long dirInter = 0;
            Nodo inter, inter2 = new Nodo();
            if (dameRaiz() == -1)
            {
                return -1;
            }
            else if(intermedio == false && dameRaiz() != -1 )  // Hay raiz pero no hay intermedio
            {
                foreach (Nodo n in this)
                {
                    if (n.tipo == 'R')
                    {
                        for (int i = 0; i < n.clave.Count; i++)
                        {
                            if (clave < n.clave[i])
                            {

                                return n.direccion[i];
                            }

                            else if (i == n.clave.Count - 1)
                            {
                                return n.direccion[i + 1];
                            }


                        }

                    }
                }

            }
            else if(intermedio == true && dameRaiz() != -1 )
            {
                foreach (Nodo n in this)
                {
                    if (n.tipo == 'R')
                    {
                        for (int i = 0; i < n.clave.Count; i++)
                        {
                            if (clave < n.clave[i])
                            {
                                dirInter = n.direccion[i];
                                inter = dameNodo(dirInter);
                                for (int j = 0; j < inter.clave.Count; j++)
                                {
                                    if (clave < inter.clave[j])
                                    {
                                        return inter.direccion[j];
                                    }
                                    else if (j == inter.clave.Count - 1)
                                    {
                                        return inter.direccion[j+1];
                                    }
                                }


                            }

                            else if (i == n.clave.Count - 1)
                            {
                                dirInter = n.direccion[i + 1];
                                inter = dameNodo(dirInter);
                                for (int j = 0; j < inter.clave.Count; j++)
                                {
                                    if (clave < inter.clave[j])
                                    {
                                        return inter.direccion[j];
                                    }
                                    else if (j == inter.clave.Count - 1)
                                    {
                                        return inter.direccion[j + 1];
                                    }
                                }
                            }


                        }
                    }
                }

            }
            /*
            foreach(Nodo n in this)
            {
                if(intermedio == false  && n.tipo == 'R' )
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
                else if (intermedio == true && n.tipo == 'I')
                {
                    inter = dameNodo(dameRaiz());  // Nodo Raiz donde se busca el nodo intermedio
                    cont++;
                    for(int i = 0; i < inter.clave.Count; i++)
                    {
                        if(clave < inter.clave[i])
                        {
                            //inter2 = inter;
                            inter2 = dameNodo(inter.direccion[i]);
                           // break;
                        }
                        else if (i == inter.clave.Count)
                        {
                            inter2 = dameNodo(inter.direccion[i + 1]);
                           // break;
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

                            else if (i == inter2.clave.Count-1)
                            {
                                return inter2.direccion[i+1];
                            }


                        }
                    }
                    
                }
            }
            return -1;
            */

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
        public void ordenaIntermedio(long dir)
        {

            Nodo arr = dameNodo(dir);
            int clave;
            for (int i = 0; i < arr.clave.Count - 1; i++)
            {
                if (arr.clave[i] > arr.clave[i + 1])
                {
                    clave = arr.clave[i];
                    arr.clave[i] = arr.clave[i + 1];
                    arr.clave[i + 1] = clave;

                    dir = arr.direccion[i + 1];
                   // if(i+2 < arr.direccion.Count)
                  //  {
                        arr.direccion[i + 1] = arr.direccion[i + 2];
                        arr.direccion[i + 2] = dir;
                  //  }
                  //  else
                  //  {
                  //      arr.direccion[i + 1] = arr.direccion[i + 1];
                  //      arr.direccion[i + 1] = dir;
                  //  }
                        

                }
            }

        }
        public void ordenaRaiz()
        {
            Nodo arr = dameNodo(dameRaiz());
            int clave;
            long dir;
            for(int i = 0; i < arr.clave.Count-1;i++)
            {
                if(arr.clave[i] > arr.clave[i+1])
                {
                    clave = arr.clave[i];
                    arr.clave[i] = arr.clave[i + 1];
                    arr.clave[i + 1] = clave;

                    dir = arr.direccion[i + 1];
                    arr.direccion[i + 1] = arr.direccion[i + 2];
                    arr.direccion[i + 2] = dir;
                    
                }
            }
            
            
        }
        public bool agregaDato(long direccion, int clave, long apuntador)
        {
            int g;
            int pos = 0;
            long raiz = dameRaiz();
            List<int> tempClave = new List<int>();
            List<long> tempDir = new List<long>();
            foreach (Nodo np in this)
            {
                if (np.dirNodo == direccion)
                {
                    if(np.clave.Count < 4)
                    {

                        if (raiz == direccion)
                        {
                            np.clave.Add(clave);
                            np.direccion.Add(apuntador);
                            ordenaRaiz();
                        }
                        else if(np.tipo == 'I')
                        {
                            np.clave.Add(clave);
                            np.direccion.Add(apuntador);
                            ordenaIntermedio(direccion);
                        }
                        else
                        {
                            np.clave.Add(clave);
                            np.direccion.Add(apuntador);
                            ordenaNodo(np);

                        }

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
