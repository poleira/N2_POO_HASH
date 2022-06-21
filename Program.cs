using System;

namespace N2POO2
{
    class Program
    {
        static void Main(string[] args)
        {   
            TratamentoDadados v = new TratamentoDadados();

            v.inicializarTabela(v.imput);
            v.lerArquivo(v.imput);

            string opcao;
            
            do
            {
                Console.WriteLine(" Opções digite: 0 para Sair, 1 para inserir PALAVRA, 2 buscar FRASE (usar palavras no MAIÚSCULO), 3 para imprimir dicionário, 4 para salvar dicionario.");
                opcao = Console.ReadLine();

                switch (opcao){
                case "1":
                    Console.WriteLine(" Qual PALAVRA deseja inserir?");
                    string valor = Console.ReadLine();                
                    v.inserir(v.imput, valor);
                    break;
                case "2":
                    Console.WriteLine(" Qual FRASE deseja buscar?");
                    string valor1 = Console.ReadLine();
                    string[] dadosBusca = valor1.Split(" ");
                    foreach (var item in dadosBusca)
                    {   
                        string retorno = v.busca(v.imput, item);
                        if (retorno != null)
                        Console.WriteLine(" Palavra encontrada: {0}. ", retorno);
                        else
                        Console.WriteLine(" Palavra não encontrada: {0}, aperte 1 para inseri-la. ", item);
                    }     
                    break;
                case "3":
                    v.imprimir(v.imput);
                    break;
                case "4":
                    v.gravarArquivo(v.imput);
                    break;    
                case "0":
                        Console.WriteLine(" Tamo junto prof! ");
                    break;    
                default:
                    Console.WriteLine(" Opções invalida");
                    break;
                }
            } while (opcao != "0");



        }
    }
}
