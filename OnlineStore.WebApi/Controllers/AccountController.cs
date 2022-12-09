using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.Repositories;
using OnlineStore.Domain;
using OnlineStore.Models;
using OnlineStore.Models.Requests;

namespace OnlineStore.WebApi.Controllers;
[ApiController]
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

    [HttpPost("registration")]
    public async Task<ActionResult<Account>> RegisterAccount(RegisterRequest request, CancellationToken cancellationToken)
    {
        var account = new Account(Guid.NewGuid(), request.Name, request.Email, request.Password);
        //проверка на наличие Email
       await _accountRepository.Add(account, cancellationToken);

       return account;
    }


    [HttpDelete("delete")]
    public async Task DeleteProduct(Guid id, CancellationToken cancellationToken)
    {
        await _accountRepository.DeleteById(id, cancellationToken);
    }
    [HttpGet("FindByEmail")]
    public ActionResult<Account> GetByEmail(string email)
    {
        Task<Account> account = _accountRepository.GetByEmail(email);
        if (email is null)
        {
            return NotFound(new { message = "Почтовый адресс не найден" });
        }

        return Ok(account);

    }
}