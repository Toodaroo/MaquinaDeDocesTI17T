using System;

namespace MaquinaDeDoces
{
    class ControlProduto
    {
        Produto prod;
        private int opcao;

        public ControlProduto()
        {
            prod = new Produto();
            ModificarOpcao = -1;
        }// fim construtor

        //Método getSet
        public int ModificarOpcao
        {
            get { return opcao; }
            set { opcao = value; }
        }//fim do método get e set de opcao

        public void Menu()
        {
            Console.WriteLine("Escolha uma das opções abaixo: \n" +
                              "0. Sair\n" +
                              "1. Cadastrar um produto\n" +
                              "2. Consultar um produto\n" +
                              "3. Atualizar um produto\n" +
                              "4. Mudar situação\n");
            ModificarOpcao = Convert.ToInt32(Console.ReadLine());
        }// fim do metodo menu

        //Realizar a Operação
        public void Operacao()
        {
            do
            {
                Menu();//Mostrando o Menu na tela
                switch (ModificarOpcao)
                {
                    case 0:
                        Console.WriteLine("Obrigado!");
                        Console.Clear();//Limpa tela
                        break;
                    case 1:
                        ColetarDados();
                        Console.Clear();//Limpa tela
                        break;
                    case 2:
                        Consultar();
                        Console.Clear();//Limpa tela
                        break;
                    case 3:
                        Atualizar();
                        Console.Clear();//Limpa tela
                        break;
                    case 4:
                        AlterarSituacao();
                        Console.Clear();//Limpa tela
                        break;
                    default:
                        Console.WriteLine("Opção escolhida não é válida!");
                        Console.Clear();//Limpa tela
                        break;
                }//fim do switch
            } while (ModificarOpcao != 0);
        }//fim do metodo Operacao




        //Criar um método de solicitação de Dados
        public void ColetarDados()
        {

            //coletar dados
            Console.WriteLine("Informe um código: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o nome do produto: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Faça uma breve descrição do produto: ");
            string descricao = Console.ReadLine();

            Console.WriteLine("Informe o preço do produto: ");
            double preco = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Informe a quantidade de produtos em estoque: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe a data de validade do lote do produto: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe a situação: True - Ativo | False - inativo");
            Boolean situacao = Convert.ToBoolean(Console.ReadLine());

            //Cadastrar Produto
            prod.CadastrarProduto(codigo, nome, descricao, preco, quantidade, data, situacao);
            Console.WriteLine("Dado Registrado!");
        }//fim do coletarDados

        //Consultar
        public void Consultar()
        {
            //Consultar os dados do produto
            Console.WriteLine("\n\n\nInforme o código do produto que deseja consultar");
            int codigo = Convert.ToInt32(Console.ReadLine());
            //Escrever o resultado da consulta da tela
            Console.WriteLine("Os dados do produto escolhido são: \n\n\n" + prod.ConsultarProduto(codigo));

        }//fim do método

        public void Atualizar()
        {
            //Atualizar Produto
            Console.WriteLine("\n\nInforme o código do produto que deseja atualizar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            short campo = 0;

            do
            {
                Console.WriteLine("Informe o campo que deseja atualizar de acordo com a regra abaixo: \n" +
                    "1. Nome\n" +
                    "2. Descrição\n" +
                    "3. Preço\n" +
                    "4. Quantidade\n" +
                    "5. Data de Validade\n" +
                    "6. Situação\n");
                campo = Convert.ToInt16(Console.ReadLine());
                //Avisar o usuário
                if ((campo < 1) || (campo > 6))
                {
                    Console.WriteLine("Erro, escolha um código entre 1 e 6");
                }

            } while ((campo < 1) || (campo > 6));

            Console.WriteLine("Informe o dado para atualização: ");
            string novodado = Console.ReadLine();

            //Chamar o método de atualização
            prod.AtualizarProduto(codigo, campo, novodado);
            Console.WriteLine("Atualizado!");
        }//fim do método atualizar

        public void AlterarSituacao()
        {
            Console.WriteLine("Informe o código do produto que deseja alterar o status: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //Chamar o método alterar situação - Classe produto
            prod.AlterarSituacao(codigo);
            Console.WriteLine("Alterado!");
        }//fim do metodo

    }//fim da classe
}//fim do projeto
