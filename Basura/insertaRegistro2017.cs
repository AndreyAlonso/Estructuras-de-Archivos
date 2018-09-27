/*
            string sVal;
            long ap;
            int auxCol;
            int longitud;
            long direccion;
            int long1;
            string long2;
            int iTam = 0;
            int claveB;
            long dir;
           
            char dato = ' ';
            
            reg = new List<string>();
            //Se asigna el apuntador del archivo 
            dataGridView4.Rows.Add();
            // INSERCIÓN EN LA TABLA DE REGISTROS
            if (Ren == 0){
                foreach (Atributo i in atributo){
                    dataGridView4.Columns.Add(i.dameNombre(), i.dameNombre());
                    
                }
                dataGridView4.Columns.Add("Direccion siguiente", "Direccion siguiente");
            }
            for (auxCol = 0; auxCol <= dataGridView3.Columns.Count; auxCol++)
            {
                if (auxCol == 0)
                {
                  // SE OBTIENE LA DIRECCIÓN DEL REGISTRO
                  dataGridView4.Rows[Ren].Cells[auxCol].Value = fRegistro.BaseStream.Length;
                  direccion = Convert.ToInt64(dataGridView4.Rows[Ren].Cells[auxCol].Value);
                  fRegistro.Write(fRegistro.BaseStream.Length);
              }
              else
              {
                dato = buscaTipoDato(dataGridView3.Columns[Col].HeaderText);
                iTam = buscaLongitud(dataGridView3.Columns[Col].HeaderText);
                if (dato == 'E')
                {
                    long1 = Convert.ToInt32(dataGridView3.Rows[0].Cells[auxCol - 1].Value); // valor de la tabla
                    dataGridView4.Rows[Ren].Cells[auxCol].Value = long1;
                    fRegistro.Write(long1);
                        reg.Add(long1.ToString());
                }
                else if(dato == 'C')
                {
                   long2 = dataGridView3.Rows[0].Cells[auxCol - 1].Value.ToString();
                   for(int c = long2.Length; c < iTam-1; c++){
                    long2 += " ";
                }
                fRegistro.Write(long2);
                reg.Add(long2);
                dataGridView4.Rows[Ren].Cells[auxCol].Value = reg[auxCol - 1];
            }


        }
    }
    //MessageBox.Show("HASTA AQUI ESTA BIEN");
    if(Ren > 0)
    {
                dataGridView4.Rows[Ren-1].Cells[auxCol].Value = dataGridView4.Rows[Ren].Cells[0].Value;// fRegistro.BaseStream.Length;
                dataGridView4.Rows[Ren].Cells[auxCol].Value = -1;
                fRegistro.Write(Convert.ToInt64(-1));
              //  MessageBox.Show("tamaño del archivo " + fRegistro.BaseStream.Length);
            }
            else
            {
                dataGridView4.Rows[Ren].Cells[auxCol].Value = -1;
                fRegistro.Write(Convert.ToInt64(-1));
            }


            Ren++;
            // METODO ENCARGADO PARA ENVIAR A SUS RESPECTIVOS ARCHIVOS
            // buscaRegistros();

            int tipo;
            int val;
          
   
            for(int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                tipo = 0;
                tipo = buscaTipoIndice(dataGridView3.Columns[i].HeaderText);
             //   MessageBox.Show("Atributo " + dataGridView3.Rows[0].Cells[i].Value + "\nTipo" + tipo);
                //Switch que controla el tipo de cada  atributo para saber a cual indice mandar
                // INDICE PRIMARIO  n
                switch(tipo) 
                {
                    case 0:
                      //  MessageBox.Show("atributo " + dataGridView3.Rows[0].Cells[i].Value + ", con tipo " + tipo );
                    break;
                    case 1:
                     //   MessageBox.Show("atributo " + dataGridView3.Rows[0].Cells[i].Value + ", con tipo " + tipo);
                        break;
                    case 2:
                      //  MessageBox.Show("CASE 2\natributo " + dataGridView3.Rows[0].Cells[i].Value + ", con tipo " + tipo);
                        // Se envia al indice primario el valor 
                        indicep ip;
                        ip.clave = Convert.ToInt32(dataGridView3.Rows[0].Cells[i].Value);
                        ip.dir = Convert.ToInt64(dataGridView4.Rows[Ren-1].Cells[0].Value);
                        claves.Add(ip);
                        ordenaIndicePrimario(claves);
                        
                        break;
                    case 3:
                        if(primero == false)
                        {
                            for(int f = 0; f < 10; f++)
                            {
                                tope[f] = 1;
                            }
                            tablaSecundario.Rows.Add();
                            indiceSecundario[0,0] = Convert.ToInt32(dataGridView3.Rows[0].Cells[i].Value);
                            indiceSecundario[0,1] = Convert.ToInt64(dataGridView4.Rows[Ren - 1].Cells[0].Value);
                          //  MessageBox.Show("[" + topeClave + "," + tope[pos] + "]");
                            tablaSecundario.Rows[0].Cells[0].Value = indiceSecundario[0,0];
                            tablaSecundario.Rows[0].Cells[1].Value = indiceSecundario[0,1];
                            
                            //  tope[0]++;
                            primero = true;
                            //topeClave++;
                        }
                        else
                        {
                            int tempClave = Convert.ToInt32(dataGridView3.Rows[0].Cells[i].Value);
                            bool existe = false;
                            cont = 0;
                            while(cont < 10)
                            {
                                if(indiceSecundario[cont,0] == tempClave) // solo dice en que clave esta pero no la posicion de direccion
                                {
                                    existe = true;
                                    pos = cont;
                                    topeClave = pos;
                                }
                                cont++;
                            }
                       
                            if (existe)
                            {
                                tope[pos]++;
                                
                            //    MessageBox.Show("[" + topeClave + "," + tope[pos]+ "]");
                                indiceSecundario[topeClave, tope[pos]] = Convert.ToInt64(dataGridView4.Rows[Ren - 1].Cells[0].Value);
                                tablaSecundario.Rows[topeClave].Cells[tope[pos]].Value = indiceSecundario[topeClave, tope[pos]];
                                
                            }
                            else
                            {
                                topeClave = pos;
                                pos++;
                                tope[pos] = 1;
                                topeClave++;
                                tablaSecundario.Rows.Add();
                          //      MessageBox.Show("[" + topeClave + "," + tope[pos] + "]");
                                indiceSecundario[topeClave,0] = Convert.ToInt32(dataGridView3.Rows[0].Cells[i].Value);
                                indiceSecundario[1, tope[pos]] = Convert.ToInt64(dataGridView4.Rows[Ren - 1].Cells[0].Value);
                           //     MessageBox.Show("Edad " + indiceSecundario[topeClave, 0] + "  dirección " + indiceSecundario[1, tope[pos]]);

                                tablaSecundario.Rows[topeClave].Cells[0].Value = indiceSecundario[topeClave,0];
                                tablaSecundario.Rows[topeClave].Cells[1].Value = indiceSecundario[1, tope[pos]];
                               
                            }
                        }
                        break;
                    case 4:
                     //   MessageBox.Show("atributo " + dataGridView3.Rows[0].Cells[i].Value + ", con tipo " + tipo);
                        claveB = Convert.ToInt32(dataGridView3.Rows[0].Cells[i].Value);
                        dir = Convert.ToInt64(dataGridView4.Rows[Ren - 1].Cells[0].Value);
                        // MessageBox.Show("Clave: " + claveB + "\n dirección: " + dir);
                        insertaClave(dir, claveB, cont2);
                        if(cont2 == 4){
                            cont2 = 0;
                        }
                        else
                        {
                            cont2++;
                        }
                        
                        break;
                    case 5:
                    break;

                }

            }
            */