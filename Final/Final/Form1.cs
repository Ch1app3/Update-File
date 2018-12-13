using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            var Lineas = File.ReadAllLines("Maestro.csv");
            var Texto = String.Join("\r\n", Lineas);
            textBox1.Text = Texto;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            var Lineas = File.ReadAllLines("Novedades.csv");
            var Texto = String.Join("\r\n", Lineas);
            textBox2.Text = Texto;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.Delete("ArchivoDestino.csv");

            FileStream AD = new FileStream("ArchivoDestino.csv", FileMode.Append);
            StreamWriter SW = new StreamWriter(AD);
            StreamReader RM = new StreamReader("Maestro.csv");
            StreamReader RN = new StreamReader("Novedades.csv");
            var Maestro = RM.ReadLine();
            var Novedades = RN.ReadLine();
            SW.WriteLine(Maestro, "\r\n");
            


            string[] VM = Maestro.Split(';');
            string[] VN = Novedades.Split(';');

            Maestro = RM.ReadLine();
            VM = Maestro.Split(';');
            int VMnumero = int.Parse(VM[0]);
            
            Novedades = RN.ReadLine();
            VN = Novedades.Split(';');
            int VNnumero = int.Parse(VN[0]);

            while (Maestro!=null && Novedades != null)
            {
                    if (VMnumero == VNnumero)
                    {
                        SW.WriteLine(Novedades, "\r\n");
                        Maestro = RM.ReadLine();

                        if (Maestro != null)
                        {
                            VM = Maestro.Split(';');
                            VMnumero = int.Parse(VM[0]);
                        }

                        Novedades = RN.ReadLine();
                        if (Novedades != null)
                        {
                            VN = Novedades.Split(';');
                            VNnumero = int.Parse(VN[0]);
                        }


                }
                    else
                    {
                        if(VMnumero > VNnumero)
                        {
                            SW.WriteLine(Novedades, "\r\n");
                            Novedades = RN.ReadLine();
                            if (Novedades != null)
                            {
                                VN = Novedades.Split(';');
                                VNnumero = int.Parse(VN[0]);
                            }
                                
                        }
                        else
                        {
                            SW.WriteLine(Maestro, "\r\n");
                            Maestro = RM.ReadLine();
                            if (Maestro != null)
                            {
                                VM = Maestro.Split(';');
                                VMnumero = int.Parse(VM[0]);
                            }
                                
                        
                        }
                    }

                
            }

            if (Maestro == null)
            {
                while (Novedades != null)
                {
                    Novedades = RN.ReadLine();

                    if (Novedades != null)
                    {
                        SW.WriteLine(Novedades, "\r\n");
                    }
                    
                }



            }
            else
            {
                while (Maestro != null)
                {
                    Maestro = RM.ReadLine();

                    if (Maestro != null)
                    {
                        SW.WriteLine(Maestro, "\r\n");
                    }
                    
                    

                }
            }


            RM.Close();
            RN.Close();
            SW.Close();
            AD.Close();
           
             


        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            var Lineas = File.ReadAllLines("ArchivoDestino.csv");
            var Texto = String.Join("\r\n", Lineas);
            textBox3.Text = Texto;

        }
    }
}
