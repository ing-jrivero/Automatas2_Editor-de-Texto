using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorTexto_Vocales
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string leer2;
        private string stringToPrint;
        string datos = "";
        bool error = false;
        bool est = false;
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog buscar = new OpenFileDialog();
                if (buscar.ShowDialog() == DialogResult.OK)
                {
                    StreamReader leer = new StreamReader(buscar.FileName);
                    leer2 = buscar.FileName;
                    editor.Text = leer.ReadToEnd();
                    leer.Close();
                }
            }
            catch
            {
                MessageBox.Show("Error al abrir archivo");
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editor.Text.ToString().Equals(""))
            {
                TextWriter Escribe = new StreamWriter(leer2);
                Escribe.WriteLine("");
                Escribe.Close();
            }
            else
            {

                TextWriter Escribe = new StreamWriter(leer2);
                Escribe.WriteLine(editor.Text);
                Escribe.Close();
            }

        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "*.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "txt files (*.txt) |*.txt";
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        string txt = saveFileDialog.FileName;
                        StreamWriter textoaguardar = File.CreateText(txt);
                        textoaguardar.Write(editor.Text);
                        textoaguardar.Flush();
                        textoaguardar.Close();
                    }
                    else
                    {
                        string txt = saveFileDialog.FileName;
                        StreamWriter textoaguardar = File.CreateText(txt);
                        textoaguardar.Write(editor.Text);
                        textoaguardar.Flush();
                        textoaguardar.Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al guardar archivo");
            }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {/*
            printDocument1.DocumentName = leer2;
            using (FileStream stream = new FileStream(leer2, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                stringToPrint = reader.ReadToEnd();
            }*/
        }

        private void equipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jesus Alexis Alicea Gonzalez \n Francisco Javier Rivero Murillo");

        }
        private void validarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Validar();
        }

        private void compilarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compilar();
            if (error!=true)
            {
                Validar();
            }
            
            
        }
        private void correToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compilar();
            if (error != true)
            {
                Validar();
                Ejecutar();
            }
        }

        public void Validar()
        {
            datos = editor.Text;
            char[] array = datos.ToCharArray();
            string tem = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 'a' || array[i] == 'A')
                {

                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[j] != '#')
                        {

                            tem += array[j];
                        }
                        else
                        {

                            tem += array[j];
                            i = j;
                            break;
                        }

                    }

                    editor.Find(tem);
                    editor.SelectionColor = Color.Yellow;
                    tem = "";

                }
                else if (array[i] == 'e' || array[i] == 'E')
                {

                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[j] != '#')
                        {

                            tem += array[j];
                        }
                        else
                        {

                            tem += array[j];
                            i = j;
                            break;
                        }

                    }

                    editor.Find(tem);
                    editor.SelectionColor = Color.Purple;
                    tem = "";
                }

                else if (array[i] == 'i' || array[i] == 'I')
                {


                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[j] != '#')
                        {

                            tem += array[j];
                        }
                        else
                        {

                            tem += array[j];
                            i = j;
                            break;
                        }

                    }

                    editor.Find(tem);
                    editor.SelectionColor = Color.Blue;
                    tem = "";

                }
                else if (array[i] == 'o' || array[i] == 'O')
                {


                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[j] != '#')
                        {

                            tem += array[j];
                        }
                        else
                        {

                            tem += array[j];
                            i = j;
                            break;
                        }

                    }

                    editor.Find(tem);
                    editor.SelectionColor = Color.Green;
                    tem = "";

                }
                else if (array[i] == 'u' || array[i] == 'U')
                {


                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[j] != '#')
                        {

                            tem += array[j];
                        }
                        else
                        {

                            tem += array[j];
                            i = j;
                            break;
                        }

                    }

                    editor.Find(tem);
                    editor.SelectionColor = Color.Red;
                    tem = "";

                }

            }
            editor.AppendText(" ");
            editor.Find(" ");
            editor.SelectionColor = Color.Black;
            editor.AppendText(" ");


        }

        static string Limpiar(string strIn)
        {
            
            return Regex.Replace(strIn, @"[^\w\.()#]", "");
        }

        public void Compilar()
        {
            rtb_errores.Clear();
            error=false;
            datos = editor.Text;
            string cad = Limpiar(datos);
            Regex regex = new Regex("(i|I)nicio#.*#(e|E)nd#");
            Match match = regex.Match(cad);
            if (match.Success)
            {
           //   MessageBox.Show("correcto");
            }
            else
            {
                rtb_errores.AppendText("ERROR");
                error = true;
            }

        }

        public void Ejecutar()
        {
            datos = editor.Text;
            char[] txt = datos.ToCharArray();
            string texto = "";
            for (int i = 0; i < txt.Length; i++)
            {
                if (txt[i] == ')')
                {
                    est = false;
                    break;
                }
                else if (txt[i]=='(')
                {
                    est = true;
                }
                else if(est==true)
                {
                    texto += txt[i];
                }
            }
            MessageBox.Show(texto);
        }

    }


}