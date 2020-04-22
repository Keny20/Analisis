using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejercico1.Datos;

namespace Ejercico1
{
    public partial class Form1 : Form
    {
        public Funciones V { get; set; }
        public Form1()  
        {
            InitializeComponent();
           V = new Funciones();
            cargarVariables();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //AGREGAR LOS ELEMENTOS A LA TABLA
        public void cargarVariables()
        {

            var ls = V.getVariables();


            Listar.Rows.Clear();

            foreach (var item in ls)
            {
                Listar.Rows.Add(item.codigo, item.nombre, item.direccion, item.telefono, item.genero,item.trabajo, item.estado);
            }
        }
        public void vaciar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
           
            

        }
        private void btn_Click(object sender, EventArgs e)
        {
            string che1 = null, che2=null, che3=null;
            string opc = null;
            if(radioFeme.Checked)
            {
                opc = "Femenino";

            }
            else if(radioMascu.Checked)
            {
                opc = "Masculino";
            }
            if(check1.Checked)
            {
                che1 = "Diseñador";
            }
            if (check2.Checked)
            {
                che2 = "Programador";
            }
            if (check3.Checked)
            {
                che3 = "Mantenimiento";
            }
            V.Agregar(new Variables()
            {
                codigo = int.Parse(txtCodigo.Text),
                nombre = txtNombre.Text,
                direccion = txtDireccion.Text,
                telefono = int.Parse(txtTelefono.Text),
                genero =opc,
                trabajo=che1+","+che2 + "," + che3,
                estado=comboBox1.SelectedItem.ToString()
            }) ;
            cargarVariables();
            vaciar();
        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        

        private void radioMascu_CheckedChanged(object sender, EventArgs e)
        {
            string gene = null;
            if(radioFeme.Checked)
            {
                gene = "Femenino";

            }
        }
        public void cargarPorCodigo(string nombre)
        {
            var ls = V.getVariablesNombre(nombre);

            Listar.Rows.Clear();

            foreach (var item in ls)
            {

                Listar.Rows.Add(item.codigo, item.nombre, item.direccion, item.telefono, item.genero, item.trabajo, item.estado);
            }

        }
        private void radioFeme_CheckedChanged(object sender, EventArgs e)
        {
            string gene = null;
            if (radioMascu.Checked)
            {
                gene = "Masculino";

            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsLetter(e.KeyChar))&&(e.KeyChar!=(char)Keys.Back)&&(e.KeyChar!=(char)Keys.Space))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string buscar = txtBuscar.Text;
            var ls = V.getVariablesNombre(buscar);

            Listar.Rows.Clear();

            foreach (var item in ls)
            {

                Listar.Rows.Add(item.codigo, item.nombre, item.direccion, item.telefono, item.genero, item.trabajo, item.estado);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                MessageBox.Show("Por favor introduzca un nombre para buscarlo en la lista", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                List<Variables> list = V.getVariables();//crea una lista
                list.RemoveAll(x => x.nombre.Contains(txtBuscar.Text));//recorre esa lista y elimina el item si coincide con la busqueda
                MessageBox.Show("Registro borrado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cargarVariables(); //funcion que carga los elementos en la tabla


        }



    }
}
