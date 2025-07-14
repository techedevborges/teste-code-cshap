using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Sqlite;
using Questao5.Models;

public class ContaCorrenteRepository : IContaCorrenteRepository
{
    private readonly DatabaseConfig databaseConfig;

    public ContaCorrenteRepository(DatabaseConfig config)
    {
        databaseConfig = config;
    }

    // Busca os dados de uma conta corrente pelo ID
    public async Task<ContaCorrente?> ObterConta(string id)
    {
        using var conn = new SqliteConnection(databaseConfig.Name);
        return await conn.QueryFirstOrDefaultAsync<ContaCorrente>(
            "SELECT * FROM contacorrente WHERE idcontacorrente = @id",
            new { id });
    }

    // Calcula o saldo: soma de créditos - soma de débitos
    public async Task<decimal> ObterSaldo(string id)
    {
        using var conn = new SqliteConnection(databaseConfig.Name);
        var credito = await conn.ExecuteScalarAsync<decimal>("SELECT COALESCE(SUM(valor), 0) FROM movimento WHERE idcontacorrente = @id AND tipomovimento = 'C'", new { id });
        var debito = await conn.ExecuteScalarAsync<decimal>("SELECT COALESCE(SUM(valor), 0) FROM movimento WHERE idcontacorrente = @id AND tipomovimento = 'D'", new { id });
        return credito - debito;
    }

    // Insere um novo registro de movimentação
    public async Task<string> InserirMovimento(Movimento movimento)
    {
        using var conn = new SqliteConnection(databaseConfig.Name);
        var sql = @"INSERT INTO movimento(idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) 
                    VALUES(@IdMovimento, @IdContaCorrente, @DataMovimento, @TipoMovimento, @Valor)";
        await conn.ExecuteAsync(sql, movimento);
        return movimento.IdMovimento;
    }
}
