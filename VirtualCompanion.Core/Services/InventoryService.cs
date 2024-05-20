﻿using VirtualCompanion.Core.Entities;
using VirtualCompanion.Core.Interfaces;

namespace VirtualCompanion.Core.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public void AddItemToInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetInventoriesByOwnerId(int ownerId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItemFromInventory(int ownerId, int itemId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateInventoryItem(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public void UseItem(int ownerId, int itemId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
