public void eliminaEntidad()
{
	// Declaración de variables *****************************
            string n;
            long pos = 0;
            long DSIG = 0;
            long DANT = 0;
            long DE = 0;
            int compara;
            long cabecera = -1;
            string borrar = textBox1.Text;
            int cont = borrar.Length;
            for (; cont < 29; cont++)
            {
                borrar += " ";
            }
            /****************************************************8*/

            bw.Close();
            br = new BinaryReader(File.Open(nArchivo, FileMode.Open));
            pos = br.ReadInt64();
            cabecera = pos;
            br.BaseStream.Position = pos;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                n  = br.ReadString();
                DE = br.ReadInt64();
                br.ReadInt64();
                br.ReadInt64();
                DSIG = br.ReadInt64();
               
          //      if (DSIG == -1)
         /////       {
        //            break;
         //       }
                compara = borrar.CompareTo(n);
                if(compara == 0)
                {
                    if(cabecera == DE)
                    {
                        br.BaseStream.Position = 0;
                        br.Close();
                        bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
                        bw.BaseStream.Position = bw.BaseStream.Length;
                        bw.Write(DSIG);
                        bw.Close();
                        br = new BinaryReader(File.Open(nArchivo, FileMode.Open));

                    }   
                    //MessageBox.Show("Se ha encontrado la entidad " + n);
                    //MessageBox.Show("Dirección Anterior " + DANT);
                    //MessageBox.Show("Dirección Entidad: " +  DE);
                    //MessageBox.Show("Dirección Siguiente: " + DSIG);
                    br.Close();
                    bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
                    bw.BaseStream.Position = DE;
                    bw.Write((string)"NULL                          ");
                    bw.Write((long)-1);
                    bw.BaseStream.Position = DE + 54;
                    bw.Write((long)-1);
                   
                    bw.BaseStream.Position = DANT + 54;
                    bw.Write(DSIG);
                    bw.Close();
                    br = new BinaryReader(File.Open(nArchivo, FileMode.Open));                    
                }
                 DANT = DE;
                if(DSIG == -1)
                    break;
                else
                    br.BaseStream.Position = DSIG;
            }
            br.Close();
            bw = new BinaryWriter(File.Open(nArchivo, FileMode.Open));
            bw.BaseStream.Position = bw.BaseStream.Length;
            imprimeLista(entidad);
}