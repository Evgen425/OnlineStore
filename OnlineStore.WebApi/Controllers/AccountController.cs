using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Repositories;
using OnlineStore.Models;

namespace OnlineStore.WebApi.Controllers;
[Route("accounts")]
public class AccountController:ControllerBase
{
    private readonly IAccountRepository _accountRepository;

    public AccountController(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    [HttpGet("get_all")]
    public async Task<IReadOnlyList<Account>> GetAllAccounts(CancellationToken cancellationToken)
    {
        var accounts = await _accountRepository.GetAll(cancellationToken);
        return accounts;
    }

    [HttpGet("get_by_id")]
    public async Task<Account> GetAccountById([FromQuery]Guid id, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetById(id, cancellationToken);
        return account;
    }

    [HttpPost("add")]
    public async Task AddAccount(Account account, CancellationToken cancellationToken)
    {
        await _accountRepository.Add(account, cancellationToken);
    }
    [HttpDelete("delete")]
    public async Task DeleteProduct(Guid id, CancellationToken cancellationToken)
    {
        await _accountRepository.DeleteById(id, cancellationToken);
    }
    [HttpGet("FindByEmail")]
    public Task<Account> GetByEmail(string email)
    {
        var account = _accountRepository.GetByEmail(email);
        return account;
    }
}