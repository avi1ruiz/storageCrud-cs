using Microsoft.AspNetCore.Mvc;
using storageCRUD.Services;
using storageCRUD.Models;

namespace storageCRUD.Controllers;

[ApiController]
[Route("[controller]")]

public class StorageController : ControllerBase{

    public StorageServices _storageService;

    public StorageController(StorageServices storageServices){
        _storageService = storageServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _storageService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id) {

        var product = await _storageService.GetByIdAsync(id);

        if (product == null) {
            NotFound();
        }

        return Ok(product);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(string id) {
        var product = await _storageService.GetByIdAsync(id);

        if (product == null) {
            return NotFound();
        }

        await _storageService.DeleteAsync(product.id);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Product product) {
        if (!ModelState.IsValid){
            return BadRequest();
        }

        await _storageService.AddAsync(product);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Product productUpdate) {
        var product = await _storageService.GetByIdAsync(id);
        if (product == null){
            return NotFound();
        }

        await _storageService.UpdateAsync(id, productUpdate);
        return NoContent();
    }

}