public void insertaClave(long dir, int cb, int i)
        {
            // MessageBox.Show("valor de i " + i);
            if (Arbol.Count == 0) // Si no hay nodos
            {
                nodo = new Arbol();
                nodo.clave[i] = cb;
                nodo.apuntador[i] = dir;
                nodo.direccion = 1000;
                nodo.renglon = 0;
                nodo.valor = 0;
                nodo.tipo = 'H';
                nodo.tam = 2;
                tablaArbol.Rows[nodo.renglon].Cells[0].Value = nodo.direccion;
                tablaArbol.Rows[nodo.renglon].Cells[1].Value = nodo.tipo;
                tablaArbol.Rows[nodo.renglon].Cells[nodo.tam].Value = nodo.apuntador[i];
                nodo.tam++;
                tablaArbol.Rows[nodo.renglon].Cells[nodo.tam].Value = nodo.clave[i];
                nodo.tam++;
                Arbol.Add(nodo);

            }
            else
            {
                // busca raiz
                int pos = 0;
                foreach (Arbol aux in Arbol)
                {
                    if (aux.tipo == 'R')
                    {
                        pos = aux.valor;
                    }
                    else
                    {
                        if (i < 4)
                        {
                            for (int j = 0; j < i; j++)
                            {
                                if (cb < nodo.clave[j] && j < i)
                                {
                                    for (int g = i; g > j; g--)
                                    {
                                        nodo.clave[g] = nodo.clave[g - 1];
                                        nodo.apuntador[g] = nodo.apuntador[g - 1];
                                    }
                                    nodo.clave[j] = cb;
                                    nodo.apuntador[j] = dir;
                                    break;
                                }
                                else
                                {
                                    nodo.clave[i] = cb;
                                    nodo.apuntador[i] = dir;
                                    break;
                                }
                                

                            }
                            for (int k = 0, h = 2; k <= i; k++)
                            {
                                tablaArbol.Rows[nodo.renglon].Cells[h].Value = nodo.apuntador[k];
                                h++;
                                tablaArbol.Rows[nodo.renglon].Cells[h].Value = nodo.clave[k];
                                h++;
                            }
                        }
                        else if(i == 4)
                        {
                            MessageBox.Show("Nodo Lleno");
                            Arbol temp = new Arbol();
                            temp = nodo;
                            nodo = new Arbol();
                            //Metodo para capturar claves
                            nodo.tipo = 'H';
                            nodo.renglon++;
                            nodo.direccion = 1100;
                            tablaArbol.Rows.Add();
                            tablaArbol.Rows[nodo.renglon].Cells[0].Value = nodo.direccion;
                            tablaArbol.Rows[nodo.renglon].Cells[1].Value = nodo.tipo;
                            nodo.tam = 2;
                            for(int c = 2, d = 0; c < 4; c++, d++)
                            {
                                nodo.clave[d] = temp.clave[c];
                                temp.clave[c] = 0;
                                nodo.apuntador[d] = temp.apuntador[c];
                                temp.apuntador[c] = 0;
                            }

                            Arbol[temp.renglon] = temp;
                            Arbol.Add(nodo);
                            for (int k = 0, h = 2; k < i; k++)
                            {
                                tablaArbol.Rows[nodo.renglon].Cells[h].Value = nodo.apuntador[k];
                                h++;
                                tablaArbol.Rows[nodo.renglon].Cells[h].Value = nodo.clave[k];
                                h++;
                            }
                            insertaClave(dir, cb, 0);
                            
                            int f = 0, g = 0;
                            foreach(Arbol arbl in Arbol)
                            {
                                f = 2;
                                g = 0;
                                tablaArbol.Rows[arbl.renglon].Cells[0].Value = arbl.direccion;
                                tablaArbol.Rows[arbl.renglon].Cells[1].Value = arbl.tipo;
                                for (int k = 0, h = 2; k < i; k++)
                                {
                                    tablaArbol.Rows[arbl.renglon].Cells[h].Value = arbl.apuntador[k];
                                    h++;
                                    tablaArbol.Rows[arbl.renglon].Cells[h].Value = arbl.clave[k];
                                    h++;
                                }
                            }
                           
                       
                           // break;
                        }
                    }
                }
            }
        }
    }
}