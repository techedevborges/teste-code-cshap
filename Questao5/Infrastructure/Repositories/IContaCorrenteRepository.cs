using Questao5.Models;

public interface IContaCorrenteRepository
{
    Task<ContaCorrente?> ObterConta(string id);
    Task<decimal> ObterSaldo(string id);
    Task<string> InserirMovimento(Movimento movimento);
}
