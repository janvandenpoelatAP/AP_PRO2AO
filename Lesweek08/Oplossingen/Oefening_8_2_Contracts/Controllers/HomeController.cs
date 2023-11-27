using Microsoft.AspNetCore.Mvc;
using Oefening_8_2_EFContracts.Models;
using Oefening_8_2_EFContracts.Services;
using Oefening_8_2_EFContracts.ViewModels;

namespace Oefening_8_2_EFContracts.Controllers;
[Route("[controller]")]
public class HomeController : Controller
{
    private readonly IContractRepository contractRepository;

    public HomeController(IContractRepository contractRepository)
    {
        this.contractRepository = contractRepository;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(contractRepository.GetAll());
    }
    [HttpGet("id")]
    public IActionResult Get(int id)
    {
        Contract contract = contractRepository.Get(id);
        if (contract is null)
        {
            return NotFound();
        }
        return Ok(contract);
    }
    [HttpDelete]
    public IActionResult delete(int id)
    {
        Contract contract = contractRepository.Get(id);
        if (contract is null)
        {
            return NotFound();
        }
        contractRepository.Delete(contract);
        return NoContent();
    }
    [HttpPost]
    public IActionResult Create([FromBody] ContractCreateViewModel contractCreateViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var newContract = new Contract()
        {
            Code = contractCreateViewModel.Code,
            Description = contractCreateViewModel.Description,
            Type = contractCreateViewModel.Type,
            State = contractCreateViewModel.State
        };
        contractRepository.Add(newContract);
        return CreatedAtAction(nameof(Create), new { newContract.Id }, newContract);
    }
    [HttpPut]
    public IActionResult Update(int id, [FromBody] ContractUpdateViewModel contractUpdateViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        Contract contract = contractRepository.Get(id);
        if (contract is null)
        {
            return NotFound();
        }
        contract.Description = contractUpdateViewModel.Description;
        contract.State = contractUpdateViewModel.State;
        contractRepository.Update(contract);
        return NoContent();
    }
}
