private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string archivo;
            string nombre;
            string n;
            long apuntador;
            long pAtributo = 0;
            long final = 0;
            nombre = comboBox6.Text;
            claves = new List<indicep>();
            claveSecundario = new int[10];
            indiceSecundario = new long[10, 10];
            topeClave = 0;
            tope = new int[10];
            tope[0] = 1;
            primero = false;
            pos = 0;
            cont = 0;
            iRen = 0;
            iCol = 0;
            string xx;
            Col = 0;
            Ren = 0;
            iCol2 = 0;
            bw.Close();
            string nEntidad, nIndice;
            nEntidad = comboBox6.Text;
            nIndice = comboBox6.Text;
            nEntidad += ".dat";
            nIndice += ".idx";
            fRegistro = cargaRegistro(nEntidad);
            fIndice = cargaRegistro(nIndice);
            /******************************************************************
            * Se añade a la lista de registros, el nombre del regristro y se
            * crea el archivo del registro para su utilización.
            ******************************************************************/
         //   registro.Add(new BinaryWriter(File.Open(nEntidad, FileMode.Create)));
          //  indice.Add(new BinaryWriter(File.Open(nIndice, FileMode.Create)));

            // Se manda llamar a la apertura del archivo
            br = new BinaryReader(File.Open("Entidad.bin", FileMode.Open));
            apuntador = br.ReadInt64();
            while (apuntador < br.BaseStream.Length)
            {
                n = br.ReadString();
                br.ReadInt64();//direccion entidad
                pAtributo = br.ReadInt64(); // direccion atributo  
                br.ReadInt64(); // direccion del registro
                br.ReadInt64(); // direccion siguiente
                if (nombre == n)
                {
                   // MessageBox.Show("Nombre Entidad ->" + n);
                    apuntador = pAtributo;
                    br.BaseStream.Position = pAtributo;
                  //  MessageBox.Show("Dirección atributo ->" + pAtributo);
                   // MessageBox.Show("Apuntador a atributo ->" + apuntador);
                    while (final != -3)
                    {
                        // br.ReadString(); // nombre atributo
                        xx = br.ReadString();
                   //     MessageBox.Show("Atributo ==> " + xx);
                        dataGridView3.Columns.Add(enti.dameNombre(), xx);
                        registros.Add(xx);
                        br.ReadChar();//tipo
                        br.ReadInt32();// longitud
                        br.ReadInt64(); // direccion atributo
                        br.ReadInt32(); // tipo de indice
                        br.ReadInt64(); // direccion indice
                        final = br.ReadInt64(); // direccion siguiente

                    }

                    break;
                }
                apuntador = br.BaseStream.Position;
            }
            br.Close();
            bw = new BinaryWriter(File.Open("Entidad.bin", FileMode.Open));
            foreach (Entidad i in entidad)
            {
                if (i.dameDA() == apuntador)
                {

                }
            }
        }