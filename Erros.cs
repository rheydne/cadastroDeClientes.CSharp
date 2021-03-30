using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabahoFinalCadastroClientes
{
    class Erros
    {
        public static bool ValidaCpf(string cpf)
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;

            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(",", "").Replace("-", "");

            if (cpf.Length != 11)
            {
                return false;
            }
            tempCpf = cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * (multiplicador1[i]);
            }
            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            int soma2 = 0;

            for (int i = 0; i < 10; i++)
            {
                soma2 += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma2 % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        public bool VerificacaoCadastro(Cliente x)
        {
            bool valida = false;
            string tel;
            string cep;

            tel = x.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace("_", "");
            cep = x.CodigoCep.Replace("-", "");
            bool cpfvalido = ValidaCpf(x.CPF);

            if (cpfvalido == false)
            {
                MessageBox.Show("Digite novamente um CPF válido.", "CPF inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (x.Nome == "")
            {
                MessageBox.Show("Digite novamente um nome válido.", "Nome inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (x.NomeMae == "")
            {
                MessageBox.Show("Digite novamente um nome da mãe válido.", "Nome da mãe inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (x.Email == "")
            {
                MessageBox.Show("Digite novamente um email válido.", "Email inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tel.Length != 11)
            {
                MessageBox.Show("Digite novamente um telefone válido.", "Telefone inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cep.Length != 8)
            {
                MessageBox.Show("Digite novamente um CEP válido.", "Telefone inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (x.Logradouro == "")
            {
                MessageBox.Show("Digite novamente um logradouro válido.", "Logradouro inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (x.Numero == "")
            {
                MessageBox.Show("Digite novamente um número válido.", "Número inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (x.Bairro == "")
            {
                MessageBox.Show("Digite novamente um bairro válido.", "Bairro inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (x.Cidade == "")
            {
                MessageBox.Show("Digite novamente uma cidade válida.", "Cidade inválida!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (x.Estado == "")
            {
                MessageBox.Show("Digite novamente um estado válido.", "Estado inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                valida = true;

            return valida;
        }

        public void PesquisaCliente()
        {
            MessageBox.Show("Digite novamente um código de cliente válido.", "Código de cliente não encontrado!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ErroCEP(int erro)
        {
            if (erro == 1)
                MessageBox.Show("Falha ao buscar servidor.", "Servidor indisponível!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (erro == 2)
                MessageBox.Show("Falha ao encontrar o CEP.", "CEP inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if(erro == 3)
                MessageBox.Show("Digite um CEP não nulo.", "CEP inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (erro == 4)
                MessageBox.Show("Digite um CEP válido.", "CEP inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
