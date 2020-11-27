using System;

namespace POO_Conta_Poupanca
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************Bem Vindo(a) ao Banco Orientação ao Objeto S/A***************");
            Console.WriteLine();

            Conta_titular RicardoConta = new Conta_titular("Ricardo Segundo");

            Conta_atual RicardoSaldoAtual = new Conta_atual(RicardoConta, 500);
            RicardoConta.LinkarContaTitular(RicardoSaldoAtual);
            
            Saldo RicardoContaSaldo = new Saldo(RicardoConta, 2600);
            RicardoConta.LinkarContaTitular(RicardoContaSaldo);
            
            Saldo_Conta3 RicardoContaSaldo3 = new Saldo_Conta3(RicardoConta, 4999);
            RicardoConta.LinkarContaTitular(RicardoContaSaldo3);


            Console.WriteLine($"Olá {RicardoConta.PegarNome()}.");
            Console.WriteLine();
            Conta_sumario.InformarContas(RicardoConta);
        }
    }
}
