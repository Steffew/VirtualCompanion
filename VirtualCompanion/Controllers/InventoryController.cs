using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VirtualCompanion.Core.Exceptions;
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
        try
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
        catch (InventoryException ex)
        {
            return View("Error", new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Message = $"Unable to load inventory. Please try again later. Error: {ex.Message}"
            });
        }
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
