using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ContaCorrenteController : ControllerBase
{
    private readonly ContaCorrenteService service;

    public ContaCorrenteController(ContaCorrenteService servico)
    {
        service = servico;
    }

    // Endpoint para movimentar uma conta corrente (crédito ou débito)
    [HttpPost("movimentar")]
    public async Task<IActionResult> Movimentar([FromBody] MovimentoRequisicao req)
    {
        // Chama o service para processar a movimentação
        var (ok, result) = await service.Movimentar(req.IdContaCorrente, req.Valor, req.TipoMovimento);
        // Retorna 200 (OK) se sucesso, senão 400 (BadRequest) com erro de negócio
        return ok ? Ok(result) : BadRequest(result);
    }

    // Endpoint para consultar o saldo atual de uma conta
    [HttpGet("saldo/{id}")]
    public async Task<IActionResult> ObterSaldo(string id)
    {
        // Chama o service para obter o saldo da conta
        var (ok, result) = await service.ObterSaldo(id);
        // Retorna 200 se tudo certo, ou 400 com erro
        return ok ? Ok(result) : BadRequest(result);
    }
}

public class MovimentoRequisicao
{
    public string IdContaCorrente { get; set; }
    public string TipoMovimento { get; set; } // C ou D
    public decimal Valor { get; set; }
}
