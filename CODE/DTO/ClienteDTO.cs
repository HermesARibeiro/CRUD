using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.CODE.DTO
{
    class ClienteDTO
    {
        private int id_cliente;
        private string nome_completo;
        private string matricula;
        private string cpf;
        private string rg;
        private string email;

        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public string Nome_completo { get => nome_completo; set => nome_completo = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Rg { get => rg; set => rg = value; }
        public string Email { get => email; set => email = value; }
    }
}
