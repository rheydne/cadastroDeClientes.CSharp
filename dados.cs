using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace TrabahoFinalCadastroClientes
{
    class Dados
    {
        private ArrayList CadastroCliente;

        public Dados()
        {
            CadastroCliente = new ArrayList();
        }

        public void InserirCliente(Cliente x)
        {
            CadastroCliente.Add(x);
        }

        public Cliente PesquisarCliente(string Cod)
        {
            foreach (Cliente x in CadastroCliente)
            {
                if (x.Codigo.ToUpper() == Cod.ToUpper())
                {
                    return x;
                }
            }

            return null;
        }

        public void AlterarCliente(Cliente x, Cliente y)
        {
            foreach (Cliente c in CadastroCliente)
            {
                if (c.Codigo.ToUpper() == y.Codigo.ToUpper())
                {
                    x = c;

                    int Posicao;

                    Posicao = CadastroCliente.IndexOf(x);

                    y.Codigo = x.Codigo;

                    CadastroCliente.Remove(x);
                    CadastroCliente.Insert(Posicao, y);
                }
            }
        }

        public void ExcluirCliente(string y, Cliente x)
        {
            foreach (Cliente c in CadastroCliente)
            {
                if (c.Codigo.ToUpper() == y.ToUpper())
                    x = c;
            }
            CadastroCliente.Remove(x);
        }

        public int OrdenarClientes()
        {
            CadastroCliente.Sort(new MinhaOrdenacao());

            return CadastroCliente.Count;
        }

        public class MinhaOrdenacao : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                return ((Cliente)x).Nome.CompareTo(((Cliente)y).Nome);
            }

        }

        public ArrayList ListarClientes()
        {
            return CadastroCliente;
        }

        public void LerArquivoCliente()
        {
            FileStream Arquivo = new FileStream(@"R:\Program\POO\TrabahoFinalCadastroClientes\ArquivoClientes.xml", FileMode.Open);

            Cliente[] ListaCliente = (Cliente[])CadastroCliente.ToArray(typeof(Cliente));

            XmlSerializer Serializacao = new XmlSerializer(ListaCliente.GetType());

            ListaCliente = (Cliente[])Serializacao.Deserialize(Arquivo);

            CadastroCliente.Clear();

            CadastroCliente.AddRange(ListaCliente);

            Arquivo.Close();
        }

        public void SalvarArquivoCliente()
        {
            TextWriter MeuWriter = new StreamWriter(@"R:\Program\POO\TrabahoFinalCadastroClientes\ArquivoClientes.xml");

            Cliente[] ListaCliente = (Cliente[])CadastroCliente.ToArray(typeof(Cliente));

            XmlSerializer Serializacao = new XmlSerializer(ListaCliente.GetType());

            Serializacao.Serialize(MeuWriter, ListaCliente);

            MeuWriter.Close();
        }
    }
}
