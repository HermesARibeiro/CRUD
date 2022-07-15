using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD.CODE.DTO;
using CRUD.CODE.BLL;

namespace CRUD
{

    public partial class s : Form
    {
        ClienteBLL clientebll = new ClienteBLL();
        ClienteDTO clientedto = new ClienteDTO();

        public s()
        {
            InitializeComponent();
        }

        public void carregarGrid()
        {
            GridView.DataSource = clientebll.MostraDados();
        }



        private void FrmCadCliente_Load(object sender, EventArgs e)
        {
            carregarGrid();
        }

        private void BtnGravar_Click(object sender, EventArgs e)
        {
            clientedto.Nome_completo = TxtNomeCompleto.Text;
            clientedto.Matricula = TxtMatricula.Text;
            clientedto.Cpf = TxtCPF.Text;
            clientedto.Rg = TxtRG.Text;
            clientedto.Email = TxtEmail.Text;

            clientebll.Inserir(clientedto);

            MessageBox.Show("Cliente " + clientedto.Nome_completo + " inserido com sucesso! ");

            carregarGrid();

            TxtNomeCompleto.Focus();

            TxtNomeCompleto.Clear();
            TxtMatricula.Clear();
            TxtCPF.Clear();
            TxtRG.Clear();
            TxtEmail.Clear();
            

        }

        private void GridView_CellDoubleClick(object sender, DataGridViewCellEventArgs indice)
        {
            // cria um objeto DataGridViewRow de um indice particular
            DataGridViewRow rowData = GridView.Rows[indice.RowIndex];
            //exibe os valores nos textBox
            TxtCodigo.Text = rowData.Cells[0].Value.ToString();
            TxtNomeCompleto.Text = rowData.Cells[1].Value.ToString();
            TxtMatricula.Text = rowData.Cells[2].Value.ToString();
            TxtCPF.Text = rowData.Cells[3].Value.ToString();
            TxtRG.Text = rowData.Cells[4].Value.ToString();
            TxtEmail.Text = rowData.Cells[5].Value.ToString();

        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void s_Shown(object sender, EventArgs e)
        {
            TxtNomeCompleto.Focus();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            clientedto.Id_cliente = Convert.ToInt32(TxtCodigo.Text);
            clientebll.Deletar(clientedto);
            carregarGrid();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            clientedto.Id_cliente = Convert.ToInt32(TxtCodigo.Text);

            clientedto.Nome_completo = TxtNomeCompleto.Text;
            clientedto.Matricula = TxtMatricula.Text;
            clientedto.Cpf = TxtCPF.Text;
            clientedto.Rg = TxtRG.Text;
            clientedto.Email = TxtEmail.Text;

            clientebll.Atualizar(clientedto);

            carregarGrid();

            TxtNomeCompleto.Focus();
        }

        // PARA HABILITAR TECLA ENTER
        //1) Alterar a propriedade KeyPreview do Formulário para ” true”
        //(2) Preencha o evento KeyDown do Formulário com o seguinte código:

        private void s_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }
    }
}

