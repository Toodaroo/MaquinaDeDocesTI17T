using System;

namespace MaquinaDeDoces
{
    class Program
    {
        static void Main(string[] args)
        {
            //Conecta com a classe Control Produto
            ControlProduto controlprod = new ControlProduto();

            //Chamar o metodo principal daquela classe
            controlprod.Operacao();

            Console.ReadLine();//Manter janela aberta
        }//fim do método main
    }//fim da classe
}//fim do projeto
