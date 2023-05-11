using System;

namespace MaquinaDeDoces
{
    class Pagamento
    {
        //definição das variáveis
        private int codigo;
        private string descricao;
        private decimal valorTotal;
        private string formaDePagamento;
        private DateTime dataHora;
        private int codCartao;
        private string bandeiraCartao;

        //método construtor
        public Pagamento()
        {
            ModificarCodigo = 0;
            ModificarDescricao = "";
            ModificarValorTotal = 0;
            ModificarFormaDePagamento = "";
            ModificarDataHora = new DateTime();//0000/00/00 00:00:00
            ModificarcodCartao = 0;
            ModificarBandeiraCartao = "";
        }//fim do método construtor

        //método construtor com parametros
        public Pagamento(int codigo, string descricao, decimal valorTotal, string formaDePagamento, DateTime dataHora, int codCartao, string bandeiraCartao)
        {
            ModificarCodigo = codigo;
            ModificarDescricao = descricao;
            ModificarValorTotal = valorTotal;
            ModificarFormaDePagamento = formaDePagamento;
            ModificarDataHora = dataHora;
            ModificarcodCartao = codCartao;
            ModificarBandeiraCartao = bandeiraCartao;
        }//fim do método construtor com parametros

        //métodos get e set
        //Métodos de acesso e modificação
        public int ModificarCodigo
        {
            get
            {
                return this.codigo;
            }//fim do get - retornar o código

            set
            {
                this.codigo = value;
            }//fim do set - modificar o código
        }//fim do Modificar Código

        public string ModificarDescricao
        {
            get { return this.descricao; }
            set { this.descricao = value; }
        }//fim do ModificarDescricao

        public decimal ModificarValorTotal
        {
            get { return this.valorTotal; }
            set { this.valorTotal = value; }
        }//fim do ModificarValorTotal

        public string ModificarFormaDePagamento
        {
            get { return this.formaDePagamento; }
            set { this.formaDePagamento = value; }
        }//fim do Forma de Pagamento

        public DateTime ModificarDataHora
        {
            get { return this.dataHora; }
            set { this.dataHora = value; }
        }//fim do Modificar data e hora

        //métodos get e set
        //Métodos de acesso e modificação
        public int ModificarcodCartao
        {
            get
            {
                return this.codCartao;
            }//fim do get - retornar o código do cartão

            set
            {
                this.codCartao = value;
            }//fim do set - modificar o código do cartão
        }//fim do Modificar código Cartão

        public string ModificarBandeiraCartao
        {
            get { return this.bandeiraCartao; }
            set { this.bandeiraCartao = value; }
        }//fim do Modificar Bandeira do cartão

        //Método Verificar Troco
        public decimal VerificarTroco(decimal valorPago)
        {
            decimal troco = valorPago - this.valorTotal;
            if (troco < 0)
            {
                //se o valor pago for menor do que o valor total da compra, retorna zero
                return 0;
            }
            else
            {
                return troco;
            }

        }//fim do método verificar troco

        //Método Validar Cartão
        public bool ValidarCartao(string numeroCartao)
        {
            int soma = 0;
            bool alternar = false;

            for (int i = numeroCartao.Length - 1; i >= 0; i--)
            {
                int digito = int.Parse(numeroCartao.Substring(i, 1));

                if (alternar)
                {
                    digito *= 2;

                    if (digito > 9) digito -= 9;

                }
                soma += digito;

                alternar = !alternar;
            }
            return (soma % 10) == 0;
        }//fim do método validar cartão

        //Método Efetuar Pagamento
        public bool EfetuarPagamento(string numeroCartao, decimal valor)
        {
            if (!ValidarCartao(numeroCartao))
            {
                Console.WriteLine("O cartão é inválido.");
                return false;
            }

            if (valor > ModificarValorTotal)
            {
                Console.WriteLine("O valor do pagamento é maior que o valor total da compra.");
                return false;
            }

            return true;
        }//fim do método Efetuar Pagamento

        //Consultar Pagamento
        public string ConsultarPagamento(int codigo)
        {
            string msg = "";//Criando uma variável local

            if (ModificarCodigo == codigo)
            {
                msg = "\nCódigo: " + ModificarCodigo +
                      "\nDescrição: " + ModificarDescricao +
                      "\nValor Total: " + ModificarValorTotal +
                      "\nForma de pagamento: " + ModificarFormaDePagamento +
                      "\nData e hora: " + ModificarDataHora +
                      "\nCódigo do cartão: " + ModificarcodCartao +
                      "\nBandeira do cartão: " + ModificarBandeiraCartao;
            }
            else
            {
                msg = "O código digitado não existe!";
            }

            return msg;
        }//fim do método Consultar Pagamento


    }//fim da classe


}//fim do projeto