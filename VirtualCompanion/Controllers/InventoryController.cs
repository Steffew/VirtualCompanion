using Microsoft.AspNetCore.Mvc;
using VirtualCompanion.Core.Interfaces.Service;
using VirtualCompanion.Models;

public class InventoryController : Controller
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpGet]
    [Route("Inventory/Owner/{ownerId}")]
    public IActionResult Index(int ownerId)
    {
        var inventoryItems = _inventoryService.GetInventoriesByOwnerId(ownerId);
        var model = new ItemListViewModel
        {
            Items = inventoryItems.Select(i => new ItemViewModel
            {
                Id = i.ItemId,
                Name = i.ItemName,
                Amount = i.Amount,
            }).ToList()
        };
        return View(model);
    }

    [HttpGet]
    [Route("Inventory/Details/{ownerId}/{itemId}")]
    public IActionResult Details(int ownerId, int itemId)
    {
        var inventoryItem = _inventoryService.GetInventoryByOwnerIdAndItemId(ownerId, itemId);
        if (inventoryItem == null)
            return NotFound();

        var viewModel = new ItemViewModel
        {
            Id = inventoryItem.ItemId,
            OwnerId = inventoryItem.OwnerId,
            Amount = inventoryItem.Amount,
            Name = inventoryItem.ItemName
        };

        return View("Details", viewModel);
    }
}
