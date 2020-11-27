using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Conta_Poupanca
{
    class Saldo : Conta
    {
        public Saldo(Conta_titular contatitular, decimal saldo) : base(contatitular, saldo)
        {
            Tipo = Conta_tipo.Número_00689;
            Saldo = saldo;
            Contatitular = contatitular;
        }
    }
}

