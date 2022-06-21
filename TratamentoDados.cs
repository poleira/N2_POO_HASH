using System;
using System.IO;
using System.Collections.Generic;

namespace N2POO2
{
class TratamentoDadados{
    private string[] Imput;
    public string[] imput   
    {
        get => Imput;
        set => Imput = value;
    }


    public TratamentoDadados(){
        Imput = new string[Constantes.TAM];
         

        //string[] dadosLinha = a.Split(' ');
        //Console.WriteLine(dadosLinha[0]);
        //Console.WriteLine(dadosLinha[1]);
    }

    public void inicializarTabela(string[] t){
        int i;

        for(i = 0; i< Constantes.TAM; i++){
            t[i] = "";
        }

    }


    private int funcaoHash(string chave){
        int i;
        int count = 0;
        int tamS = chave.Length;
        int hash = 0;
        int[] str = new int[tamS];

        foreach(var c in chave)
            {   
                str[count] = (int)c;
                count++;
            }


        for(i = 0; i < tamS; i++){
            hash += str[i] * (i + 1);   // somatório do código ASCII vezes a posição
            } 
            
        return hash % Constantes.TAM;

    }

    int funcaoHashInt(int chave){
        return chave % Constantes.TAM;
}

    public void inserir (string[] t, string valor){
        int id = funcaoHash(valor);
        while (t[id] != ""){
            id = funcaoHashInt(id + 1);
        }
        t[id] = valor;
    }

    
    public string busca(string[] t, string chave){
        int id = funcaoHash(chave);

        while(t[id] != "") { 
            if(t[id] == chave) 
                return t[id]; // retorna a palavra
            else
                id = funcaoHashInt(id + 1); // vai para a posição seguinte
        }
        return null;
}
    public void imprimir(string[] t){
        for (int i = 0; i < Constantes.TAM; i++)
        {
            Console.WriteLine("{0} - {1}", i,t[i]);
        }
    }

    public void gravarArquivo(string[] t){
        StreamWriter escritor = new StreamWriter("resultados.txt");
        for (int i = 0; i < Constantes.TAM; i++)
        {
            escritor.WriteLine("{0}", t[i]);
        }
        escritor.Close();
    }

    public void lerArquivo(string[] t){
        const string filePath = "C:\\Bares.txt";
        var data = File.ReadAllLines(filePath);
        foreach (var line in data)
        {    
        inserir(t,line);
        //Console.WriteLine(line);
        }
    }

    
    

    


}
}