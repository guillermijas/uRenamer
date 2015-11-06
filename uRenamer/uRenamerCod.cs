using System;
using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApplication2
{
    internal class uRenamerCod
    {
        string directorio;
        string nuevoNombre;
        int numDigitos;
        int numInicio;

        public uRenamerCod(string carp, string nombre, int numdig, int numini)
        {
            directorio = carp;
            nuevoNombre = nombre;
            numDigitos = numdig;
            numInicio = numini;
        }

        public void RenombrarArchivos(string[] files){
            int j = numInicio;

            for (int i = 0; i < files.Length; i++){
                string nombreAntiguo = directorio + "\\" + files[i];
                string num = j + "";
                j++;

                while (num.Length < numDigitos)
                    num = "0" + num;

                string ext = "";
                ext = nombreAntiguo.Substring(nombreAntiguo.LastIndexOf('.'));
                string nombreNuevo = directorio + "\\" + nuevoNombre + " - " + num + ext;
                File.Move(nombreAntiguo, nombreNuevo);
            }

        }

        public string[] MostrarArchivos(){
            List<string> files = new List<string>();
            files.AddRange(Directory.GetFiles(directorio));

            if (files.Contains(directorio + "\\desktop.ini"))
                files.Remove(directorio + "\\desktop.ini");

            string[] archivos = files.ToArray();
            Array.Sort(archivos);
            for (int i = 0; i < archivos.Length; i++)
                archivos[i] = archivos[i].Substring(directorio.Length + 1);

            return archivos;
        }

        internal string[] MostrarPrevia(string[] files){
            int j = numInicio;
            string[] vprevia = new string[files.Length];
            for (int i = 0; i < files.Length; i++){
                string num = j + "";
                j++;

                while (num.Length < numDigitos)
                    num = "0" + num;

                string ext = "";

                if (!files[i].LastIndexOf('.').Equals(-1))
                    ext = files[i].Substring(files[i].LastIndexOf('.'));

                string nombre = nuevoNombre + " - " + num + ext;
                vprevia[i] = nombre;
            }
            return vprevia;
        }
    }
}