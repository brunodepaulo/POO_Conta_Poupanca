using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POO_Conta_Poupanca
{
    public class Conta_titular
    {
        private string Nome;
        public Dictionary<int, Conta> contas = new Dictionary<int, Conta>();
        private Conta ContaSelecionada;

        public Conta_titular(string nome)
        {
            Nome = nome;
        }

        public string PegarNome()
        {
            return Nome;
        }
        public void LinkarContaTitular(Conta conta)
        {
            contas.Add(contas.Count + 1, conta);
            if (contas.Count == 1)
            {
                ContaSelecionada = contas[1];
            }
            else
            {
                ContaSelecionada = ContaAtualSelecionada();
            }
        }

        public void SelecionarConta(Conta_titular titularConta)
        {
            Console.WriteLine("Contas Disponíveis:");
            foreach (var conta in contas)
            {
                Console.WriteLine($"[{conta.Key}] {conta.Value.PegarTipoConta()} Conta");
            }
            Console.Write($"Selecione a conta? (1, 2, 3)");
            string selecionar = Console.ReadLine();
            if (int.TryParse(selecionar, out int contaSelecao))
            {
                if (contas.ContainsKey(contaSelecao))
                {
                    Console.WriteLine($"Conta {contaSelecao} selecionada.");
                    ContaSelecionada = contas[contaSelecao];
                    Console.WriteLine();
                    Conta_sumario.InformarContas(titularConta);
                }
                else
                {
                    Console.WriteLine("Seleção Inválida.");
                    Console.WriteLine();
                    Conta_sumario.InformarContas(titularConta);
                }
            }
            else
            {
                Console.WriteLine("Seleção Inválida.");
                Conta_sumario.InformarContas(titularConta);
            }
        }

        public Conta ContaAtualSelecionada()
        {
            return ContaSelecionada;
        }

        public void ExibirContas()
        {
            foreach (var conta in contas)
            {
                if (conta.Value.Equals(ContaAtualSelecionada()))
                {
                    Console.WriteLine($"*[{conta.Key}] {conta.Value.PegarTipoConta()} / Saldo: {conta.Value.PegarSaldo()}");
                    Console.WriteLine("*Conta selecionada para as operações.");
                }
                else
                {
                    Console.WriteLine($"[{conta.Key}] {conta.Value.PegarTipoConta()} / Saldo: {conta.Value.PegarSaldo()}");
                }
            }
        }

        public bool PegaContanaoSelecionada()
        {
            foreach (var conta in contas.Where(a => a.Value != ContaAtualSelecionada()))
            {
                Console.WriteLine($"[{conta.Key}] {conta.Value.PegarTipoConta()} Conta");
            }
            return true;
        }
    }
}