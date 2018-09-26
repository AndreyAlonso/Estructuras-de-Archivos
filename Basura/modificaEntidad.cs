private void modificaEntidad(object sender, EventArgs e)
        {
            string mod;
            string combo;
            bw.Close();
            br.Close();
            List<string> nombres = new List<string>();
            foreach (Entidad i in entidad)
            {
                nombres.Add(i.dameNombre());
            }
            ModificaEntidad m = new ModificaEntidad(nombres);
            if (m.ShowDialog() == DialogResult.OK)
            {
                combo = m.dameEntidad();
                mod = m.dameNombre();
                long pos = 0;
                if (mod != "")
                {
                    foreach (Entidad datos in entidad)
                    {
                        if (combo == datos.dameNombre())
                        {
                            while (mod.Length < 29)
                            {
                                mod += " ";
                            }
                            datos.nombrate(mod);
                           
                            bw.Close();
                            long dSIG = buscaEntidad(mod);
                            if (dSIG == datos.dameDE())
                                dSIG = -1;
                            datos.ponteDireccionSig(dSIG);

                            bw.Close();
                            br.Close();
                            if(posicion == 1)
                            {
                                bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
                                bw.Seek(0, SeekOrigin.Begin);
                                cabecera.Text = datos.dameDE().ToString();
                                Cab = enti.dameDE();
                                bw.Write(Cab);
                                bw.Close();
                            }
                            bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
                            bw.BaseStream.Position = datos.dameDE();
                            bw.Write(datos.dameNombre());
                            bw.Write(datos.dameDE());
                            bw.Write(datos.dameDA());
                            bw.Write(datos.dameDD());
                            bw.Write(datos.dameDSIG());
                            bw.Close();



                            break;
                        }

                    }
                    
                    imprimeLista(entidad);
                    textBox1.Text = combo;
                    
                    //imprimeLista(entidad);
                    //textBox1.Text = mod;
                    // creaEntidad(this, null);
                }
                else
                    MessageBox.Show("No se guardo una Entidad");
            }
        }