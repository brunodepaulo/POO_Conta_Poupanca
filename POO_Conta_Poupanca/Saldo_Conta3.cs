using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Conta_Poupanca
{
    class Saldo_Conta3: Conta
    {
        public Saldo_Conta3(Conta_titular contatitular, decimal saldo) : base(contatitular, saldo)
        {
            Tipo = Conta_tipo.Número_08977;
            Saldo = saldo;
            Contatitular = contatitular;
        }
    }
}

