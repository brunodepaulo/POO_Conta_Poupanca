using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Conta_Poupanca
{
    public class Conta_sumario
    {
        public static void InformarContas(Conta_titular contaTitular)
        {
            Console.WriteLine("Você possui as seguintes Contas Poupança e Saldos atuais:");
            Console.WriteLine();
          
            contaTitular.ExibirContas();

            Console.WriteLine();

            ContaComandos(contaTitular);
        }

        public static void ContaComandos(Conta_titular contaTitular)
        {
            Console.WriteLine("Digite a letra específica da função: [D]epósito [R]etirada [T]ransferência [E]scolher conta diferente ou [S]air");
            string comando = Console.ReadLine().ToUpper();
            switch (comando)
            {
                case "D":
                    contaTitular.ContaAtualSelecionada().DepositoFundos();
                    break;
                case "R":
                    contaTitular.ContaAtualSelecionada().RetiradaFundos();
                    break;
                case "T":
                    contaTitular.ContaAtualSelecionada().TransferirFundos();
                    break;
                case "E":
                    contaTitular.SelecionarConta(contaTitular);
                    break;
                case "S":
                    Sair(contaTitular);
                    break;
                
                default:
                    Console.WriteLine("Comando Inválido.");
                    Console.WriteLine();
                    ContaComandos(contaTitular);
                    break;
            }
        }
        public static void Sair(Conta_titular contatitular)
        {
            Console.WriteLine("Tem certeza que deseja sair? S/N");
            string sinao = Console.ReadLine().ToUpper();

            if (sinao == "S")
            {
                Environment.Exit(0);
            }
            else
            {
                ContaComandos(contatitular);
            }
        }
    }
}
