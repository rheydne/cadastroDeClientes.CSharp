using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabahoFinalCadastroClientes.Telas;

namespace TrabahoFinalCadastroClientes
{
    public class Cliente
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Sexo { get; set; }
        public string NomeMae { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CodigoCep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Cliente()
        {
            Codigo = Guid.NewGuid().ToString().Substring(9, 4).ToUpper();
        }

        public void LeDados(Cliente MeuCliente)
        {
            Operacoes MinhaOperacao = new Operacoes();

            Dados MeusDados = new Dados();

            MinhaOperacao.LerXML(MeusDados);

            MinhaOperacao.Inserir(MeuCliente, MeusDados);

            MinhaOperacao.SalvarXML(MeusDados);
        }
    }
}
