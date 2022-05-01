using CapaNegocio;

namespace CapaPresentación
{
    public partial class Form1 : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto;
        private bool Editar = false;

        private void LeerProds()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.LeerProd();
        }

        private void LimpiarForm()
        {
            txtProd.Clear();
            txtDesc.Clear();
            txtPrec.Clear();   
            txtExis.Clear();
            txtEsta.Clear();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
                    objetoCN.EliProd(idProducto);
                    MessageBox.Show("Eliminado correctamente");
                    LeerProds();
                }
                else
                    MessageBox.Show("Seleccione una fila");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeerProds();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            {
                if (Editar == false)
                {
                    try
                    {
                        objetoCN.InsProd(txtProd.Text, txtDesc.Text, txtPrec.Text, txtExis.Text, txtEsta.Text);
                        MessageBox.Show("Registro creado con exito");
                        LeerProds();
                        LimpiarForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Registro no insertado, motivo: " + ex);
                    }
                }
                if (Editar == true)
                {
                    try
                    {
                        objetoCN.ActProd(txtProd.Text, txtDesc.Text, txtPrec.Text, txtExis.Text, txtEsta.Text, idProducto);
                        MessageBox.Show("Registro actualizado con exito");
                        LeerProds();
                        LimpiarForm();
                        Editar = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Registro no actualizado, motivo: " + ex);
                    }
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Editar = true;
                    txtProd.Text = dataGridView1.CurrentRow.Cells["nomProd"].Value.ToString();
                    txtDesc.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                    txtPrec.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                    txtExis.Text = dataGridView1.CurrentRow.Cells["cantidad"].Value.ToString();
                    txtEsta.Text = dataGridView1.CurrentRow.Cells["estado"].Value.ToString();
                    idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
                }
                else
                    MessageBox.Show("Seleccione una fila");
            }
        }
    }
}