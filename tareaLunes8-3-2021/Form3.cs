using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tareaLunes8_3_2021
{
    public partial class Form3 : Form
    {
        List<alquileres> pre = new List<alquileres>();
        List<clientes> per = new List<clientes>();
        List<vehiculos> au = new List<vehiculos>();
        Boolean h = false;
        int c = 0;
        public Form3()
        {
            InitializeComponent();
        }
        void leernit()
        {
            OpenFileDialog op = new OpenFileDialog();
            string filename = "clientes.txt";
            FileStream st = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek() > -1)
            {
                clientes a = new clientes();
                a.Nit = reader.ReadLine();
                a.Nombre = reader.ReadLine();
                a.Direccion = reader.ReadLine();
                per.Add(a);


            }
            reader.Close();

            comboBox1.DisplayMember = "NIT";
            comboBox1.ValueMember = "NIT";

            comboBox1.DataSource = null;
            comboBox1.DataSource = per;
            comboBox1.Refresh();
        }
        void leerpla()
        {
            OpenFileDialog op = new OpenFileDialog();
            string filename = "vehiculos.txt";
            FileStream st = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek() > -1)
            {
                vehiculos a = new vehiculos();
                a.Placa1 = reader.ReadLine();
                a.Marca = reader.ReadLine();
                a.Modelo = reader.ReadLine();
                a.Color = reader.ReadLine();
                a.Preciki = Convert.ToDouble(reader.ReadLine());
                au.Add(a);

            }
            reader.Close();

            comboBox2.DisplayMember = "Placa1";
            comboBox2.ValueMember = "Placa1";

            comboBox2.DataSource = null;
            comboBox2.DataSource = au;
            comboBox2.Refresh();
        }
        void agregar()
        {
            alquileres c = new alquileres();
            c.Nit = comboBox1.SelectedValue.ToString();
            c.Placa = comboBox2.SelectedValue.ToString();
            c.Fechalqui = dateTimePicker1.Value.ToString();
            c.Fechadevo = dateTimePicker2.Value.ToString();
            c.Kilrec = Convert.ToDouble(textBox1.Text);
        }

        void escribira()
        {
            FileStream stream = new FileStream("alquiler.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var d in pre)
            {
                write.WriteLine(d.Nit);
                write.WriteLine(d.Placa);
                write.WriteLine(d.Fechalqui);
                write.WriteLine(d.Fechadevo);
                write.WriteLine(d.Kilrec);
            }
            write.Close();
        }

        void leera()
        {
            OpenFileDialog op = new OpenFileDialog();
            string filename = "alquiler.txt";
            FileStream st = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek() > -1)
            {
                alquileres a = new alquileres();
                a.Nit = reader.ReadLine();
                a.Placa = reader.ReadLine();
                a.Fechalqui = reader.ReadLine();
                a.Fechadevo = reader.ReadLine();
                a.Kilrec = Convert.ToDouble(reader.ReadLine());
                pre.Add(a);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = pre;
                dataGridView1.Refresh();
            }
            reader.Close();
        }

        void repetidos()
        {
            while (h == false && c < pre.Count)
            {
                if (pre[c].Placa.CompareTo(comboBox1.SelectedValue.ToString()) == 0)
                {
                    h = true;
                }
                else
                {
                    c++;
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            leernit();
            leerpla();
            leera();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                agregar();
                repetidos();
                alquileres f = new alquileres();

                f.Nit = comboBox1.SelectedValue.ToString();
                f.Placa = comboBox2.SelectedValue.ToString();
                f.Fechalqui = dateTimePicker1.Value.ToString();
                f.Fechadevo = dateTimePicker2.Value.ToString();
                f.Kilrec = Convert.ToDouble(textBox1.Text);
                pre.Add(f);
                MessageBox.Show("Se ha agregado a la base de datos");
                textBox1.Clear();
                escribira();
            }
            else
            {
                MessageBox.Show("Debe de llenar todos los campos");
            }

        }
    }
}
