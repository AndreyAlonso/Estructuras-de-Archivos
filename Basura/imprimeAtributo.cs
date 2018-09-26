bw.Close();
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));   
            dataGridView2.Rows.Clear();
            /*Obtener el total de entidades para sacar el primer atributo */
            int totalEntidad = entidad.Count;
            int totalAtributos = 0;
            string nombre;
            long pos = 0;
            string n;
            
             
            totalEntidad = (entidad.Count * 62)+ 8;
            br.BaseStream.Position = totalEntidad;
            pos = totalEntidad;
            atributo.Clear();
            if(br.BaseStream.Position+62 < br.BaseStream.Length)
            {
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    atri = new Atributo();
                    n = br.ReadString();         // nombre               30 
                    atri.nombrate(n);
                    while (n == "NULL                          " || n == "NULL                         ")
                    {
                        if (br.BaseStream.Position + 33 < br.BaseStream.Length - 63)
                        {
                            //  br.BaseStream.Position = br.BaseStream.Position + 33;
                            br.ReadChar();
                            br.ReadInt32();
                            br.ReadInt64();
                            br.ReadInt32();
                            br.ReadInt64();
                            br.BaseStream.Position = br.ReadInt64();
                            n = br.ReadString();
                            atri.nombrate(n);
                        }
                        else
                            if (br.BaseStream.Position + 33 == br.BaseStream.Length)
                        {
                            br.BaseStream.Position = br.BaseStream.Length;
                            break;
                        }

                    }
                    if (n != "NULL                          ")
                    {
                        atri.ponteTipo(br.ReadChar());                  // tipo                 01
                        atri.ponteLongitud(br.ReadInt32());             // longitudo            04
                        atri.direccionate(br.ReadInt64());              // dir Atributo         08
                        atri.ponteTipoIndice(br.ReadInt32());           // tipo indice          04
                        atri.ponteDirIndice(br.ReadInt64());            // dir Indice           08
                        pos = br.ReadInt64();                           // dir Sig              08
                        atri.ponteDirSig(pos);
                        atributo.Add(atri);
                        totalAtributos++;
                        if (pos != -1)
                            br.BaseStream.Position = pos;
                        else if (br.BaseStream.Position < br.BaseStream.Length)
                        {

                        }
                        /*    else if (br.BaseStream.Position < br.BaseStream.Length)
                            {
                                br.BaseStream.Position += 8;
                            }*/
                        else
                            break;

                    }


                }

            }
           

            br.Close();
            bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
         //   br = new BinaryReader(File.Open(nArchivo, FileMode.Open));

            foreach (Atributo a in atributo)
            {
                dataGridView2.Rows.Add(a.dameNombre(), a.dameTipo(), a.dameLongitud(), a.dameDireccion(), a.dameTI(), a.dameDirIndice(), a.dameDirSig());
            }