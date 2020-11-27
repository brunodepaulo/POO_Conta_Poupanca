using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Conta_Poupanca
{
    public class Conta
    {
        protected decimal Saldo;
        protected Conta_tipo Tipo;
        public Conta_titular Contatitular;

        protected Conta(Conta_titular contatitular, decimal saldo)
        {
            Contatitular = contatitular;
            Saldo = saldo;
        }

        public decimal PegarSaldo()
        {
            return Saldo;
        }

        public Conta_tipo PegarTipoConta()
        {
            return Tipo;
        }

        public bool RetiradaFundos()
        {
            Console.Write($"Informe o valor da retirada: ");
            string retirada = Console.ReadLine();
            if (decimal.TryParse(retirada, out decimal valor) && valor > 0)
            {
                if (Saldo > valor)
                {
                    Saldo = Saldo - valor;
                    Console.WriteLine($"Retirada Efetuada. Seu saldo atual é {Saldo}.");
                    Console.WriteLine();
                    Conta_sumario.InformarContas(Contatitular);
                    return true;
                }
                else
                {
                    Console.WriteLine("Saldo Insuficiente.");
                    Console.WriteLine();
                    Conta_sumario.InformarContas(Contatitular);
                    return false;
                }

            }
            else
            {
                Console.WriteLine("Valor inválido.");
                Console.WriteLine();
                Conta_sumario.InformarContas(Contatitular);
                return false;
            }
        }

        public bool RetiradaFundos(decimal retiradaValor)
        {
            if (Saldo > retiradaValor && retiradaValor > 0)
            {
                Saldo = Saldo - retiradaValor;
                return true;
            }
            else
            {
                Console.WriteLine("Saldo insuficiente.");
                Console.WriteLine();
                Conta_sumario.InformarContas(Contatitular);
                return false;
            }
        }

        public bool DepositoFundos()
        {
            Console.Write($"Digite o valor que irá depositar: ");
            string depositar = Console.ReadLine();
            if (decimal.TryParse(depositar, out decimal valor) && valor > 0)
            {
                Saldo = Saldo + valor;
                Console.WriteLine($"Depósito Efetuado. Seu saldo bancário atual: {Saldo}.");
                Console.WriteLine();
                Conta_sumario.InformarContas(Contatitular);
                return true;
            }
            else
            {
                Console.WriteLine("Não foi possível efetuar o depósito. Verifique a digitação e sempre utilize um valor maior que 0.");
                Console.WriteLine();
                Conta_sumario.InformarContas(Contatitular);
                return false;
            }
        }

        public bool DepositoFundos(decimal depositoValor)
        {
            if (depositoValor > 0)
            {
                Saldo = Saldo + depositoValor;
                return true;
            }

            else
            {
                Console.WriteLine("Para realizar o depósito o valor tem que ser maior que 0.");
                Conta_sumario.InformarContas(Contatitular);
                return false;
            }

        }

        public bool TransferirFundos()
        {
            Console.WriteLine("Contas Poupanças disponíveis para transferência:");
            Console.WriteLine(Contatitular.PegaContanaoSelecionada());
            Console.Write($"Por favor digite a conta que deseja transferir? (1, 2, 3)");
            string transferirPara = Console.ReadLine();
            if (int.TryParse(transferirPara, out int conta) && conta < 4)
            {
                Console.Write("Quanto deseja transferir: ");
                var valorTransferencia = Console.ReadLine();
                if (decimal.TryParse(valorTransferencia, out decimal valor))
                {
                    Contatitular.contas.TryGetValue(conta, out Conta transferirParaConta);
                    Contatitular.ContaAtualSelecionada().RetiradaFundos(valor);
                    transferirParaConta.DepositoFundos(valor);
                    Console.WriteLine("Transferência efetuada.");
                    Console.WriteLine($"Conta {Contatitular.ContaAtualSelecionada().PegarTipoConta()} saldo após transferência {Contatitular.ContaAtualSelecionada().Saldo}.");
                    Console.WriteLine($"Conta {transferirParaConta.PegarTipoConta()} saldo após transferência {transferirParaConta.Saldo}.");
                    Conta_sumario.InformarContas(Contatitular);
                    return true;
                }
                else
                {
                    Console.WriteLine("Digitação Inválida.");
                    Conta_sumario.InformarContas(Contatitular);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Conta Inválida.");
                Conta_sumario.InformarContas(Contatitular);
                return false;
            }
        }

    }
}

