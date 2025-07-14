using Questao5.Models;

public class ContaCorrenteService
{
    private readonly IContaCorrenteRepository repo;

    public ContaCorrenteService(IContaCorrenteRepository repository)
    {
        repo = repository;
    }

    // Valida se a conta existe e está ativa
    public async Task<(bool success, string? error, string? tipoErro)> ValidarConta(string id)
    {
        var conta = await repo.ObterConta(id);
        if (conta == null)
            return (false, "Conta não encontrada", "INVALID_ACCOUNT");
        if (!conta.Ativo)
            return (false, "Conta inativa", "INACTIVE_ACCOUNT");
        return (true, null, null);
    }

    // Processa uma movimentação de crédito ou débito
    public async Task<(bool success, object result)> Movimentar(string id, decimal valor, string tipo)
    {
        // Valida existência e status da conta
        var (ok, msg, tipoErro) = await ValidarConta(id);
        if (!ok) return (false, new { erro = msg, tipo = tipoErro });

        // Valida regras de negócio específicas
        if (valor <= 0) return (false, new { erro = "Valor inválido", tipo = "INVALID_VALUE" });
        if (tipo != "C" && tipo != "D") return (false, new { erro = "Tipo inválido", tipo = "INVALID_TYPE" });

        // Cria o movimento com data atual
        var mov = new Movimento
        {
            IdMovimento = Guid.NewGuid().ToString().ToUpper(),
            IdContaCorrente = id,
            DataMovimento = DateTime.Now.ToString("dd/MM/yyyy"),
            TipoMovimento = tipo,
            Valor = valor
        };

        // Insere no banco e retorna o ID
        var idMovimento = await repo.InserirMovimento(mov);
        return (true, new { id = idMovimento });
    }

    // Calcula o saldo da conta corrente (créditos - débitos)
    public async Task<(bool success, object result)> ObterSaldo(string id)
    {
        var conta = await repo.ObterConta(id);
        if (conta == null)
            return (false, new { erro = "Conta não encontrada", tipo = "INVALID_ACCOUNT" });
        if (!conta.Ativo)
            return (false, new { erro = "Conta inativa", tipo = "INACTIVE_ACCOUNT" });

        var saldo = await repo.ObterSaldo(id);
        return (true, new
        {
            numero = conta.Numero,
            nome = conta.Nome,
            dataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
            saldo
        });
    }
}
