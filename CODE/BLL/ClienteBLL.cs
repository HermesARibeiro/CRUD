using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.CODE.DAL;
using CRUD.CODE.DTO;
using System.Data;

namespace CRUD.CODE.BLL
{
    class ClienteBLL
    {
        AcessoBancoDados db;

        public void Inserir(ClienteDTO dto)
        {
            db.Conectar();
            string comando = "call cadastrar_cliente ('" + dto.Nome_completo + "', '"+dto.Matricula +"', '"+ dto.Cpf + "', '" + dto.Rg + "', '" + dto.Email + "')";
            db.ExecutarComandoSQL(comando);
        }
        public void Deletar(ClienteDTO dto)
        {
            db.Conectar();
            string comando = "call excluir_cliente ('" + dto.Id_cliente + "')";
            db.ExecutarComandoSQL(comando);
        }

        public void Atualizar(ClienteDTO dto)
        {
            db.Conectar();
            string comando = "call atualizar_cliente ('" + dto.Id_cliente + "', '" + dto.Nome_completo + "', '" + dto.Matricula + "', '" + dto.Cpf + "', '" + dto.Rg + "', '" + dto.Email + "')";
            //string comando = "UPDATE  clientes set nome_completo = '" + dto.Nome_completo + "', matricula = '" + dto.Matricula + "', cpf = '" + dto.Cpf + "', rg = '" + dto.Rg + "', email = '" + dto.Email + "' WHERE id_cliente = '"+dto.Id_cliente+"'";

            db.ExecutarComandoSQL(comando);
        }
        public DataTable MostraDados()
        {
            DataTable dataTable = new DataTable();
            try
            {
                db = new AcessoBancoDados();
                db.Conectar();
                dataTable = db.RetDataTable("Select * from clientes;");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro ao selecionar os dados" + ex);
            }
            return dataTable;
        }
    }
}
