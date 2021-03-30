using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace TrabahoFinalCadastroClientes
{
    class BuscaCEP
    {
        bool valida;

        CEP MeuCep = new CEP();

        TelaCadastrar c = new TelaCadastrar();

        Erros MeuErro = new Erros();

        string Cep;

        public CEP BuscarCep(string Cep)
        {
            Cep = Cep.Replace("-", "");

            int erro;

            if (Cep.Count() < 8)
            {
                erro = 4;
                MeuErro.ErroCEP(erro);
            }
            else
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + Cep + "/json/");
                request.AllowAutoRedirect = false;
                HttpWebResponse ChecaServidor = (HttpWebResponse)request.GetResponse();

                if (ChecaServidor.StatusCode != HttpStatusCode.OK)
                {
                    erro = 1;
                    MeuErro.ErroCEP(erro);
                }
                using (Stream webStream = ChecaServidor.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            string response = responseReader.ReadToEnd();
                            response = Regex.Replace(response, "[{},]", string.Empty);
                            response = response.Replace("\"", "");

                            String[] substrings = response.Split('\n');

                            int cont = 0;
                            foreach (var substring in substrings)
                            {
                                if (cont == 1)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    if (valor[0] == "  erro")
                                    {
                                        erro = 2;
                                        MeuErro.ErroCEP(erro);
                                        c.txtCodigoCep.Focus();
                                        return null;
                                    }
                                }

                                if (cont == 2)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    MeuCep.Logradouro = valor[1];
                                }

                                if (cont == 3)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    MeuCep.Complemento = valor[1];
                                }

                                if (cont == 4)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    MeuCep.Bairro = valor[1];
                                }

                                if (cont == 5)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    MeuCep.Cidade = valor[1];
                                }

                                if (cont == 6)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    MeuCep.Estado = valor[1];
                                }

                                cont++;
                            }
                        }
                    }
                }
            }

            return MeuCep;
        }
    }
}
