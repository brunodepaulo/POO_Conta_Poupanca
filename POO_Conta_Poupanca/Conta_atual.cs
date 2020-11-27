using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Conta_Poupanca
{
    class Conta_atual : Conta
    {

        public Conta_atual(Conta_titular contatitular, decimal saldo) : base(contatitular, saldo)
        {
            Tipo = Conta_tipo.Número_10689;
            Saldo = saldo;
            Contatitular = contatitular;
        }
    }
}
