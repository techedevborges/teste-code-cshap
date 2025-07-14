using System.Globalization;

namespace Questao1
{
    class ContaBancaria
    {

        // Atributos privados
        private double _saldo;
        private const double TaxaSaque = 3.50;

        // Propriedades autoimplementadas
        public int Numero { get; } // Somente leitura
        public string Titular { get; set; } // Pode ser alterado

        // Construtor sem depósito inicial
        public ContaBancaria(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
            _saldo = 0.0;
        }

        // Construtor com depósito inicial
        public ContaBancaria(int numero, string titular, double depositoInicial) : this(numero, titular)
        {
            Deposito(depositoInicial);
        }

        // Método para depósito
        public void Deposito(double quantia)
        {
            _saldo += quantia;
        }

        // Método para saque (com taxa)
        public void Saque(double quantia)
        {
            _saldo -= quantia + TaxaSaque;
        }

        // ToString para exibir os dados da conta
        public override string ToString()
        {
            return $"Conta {Numero}, Titular: {Titular}, Saldo: $ {_saldo.ToString("F2", CultureInfo.InvariantCulture)}";
        }

    }
}
