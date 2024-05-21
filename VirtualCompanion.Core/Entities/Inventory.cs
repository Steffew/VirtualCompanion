namespace VirtualCompanion.Core.Entities
{
    public class Inventory
    {
        public int ItemId { get; private set; }
        public int OwnerId { get; private set; }
        public int Quantity { get; private set; }
        public string ItemName { get; set; }

        public Inventory(int itemId, int ownerId, int quantity, string itemName = "Item")
        {
            ItemId = itemId;
            OwnerId = ownerId;
            Quantity = quantity;
            ItemName = itemName;
        }

        public void AdjustQuantity(int amount)
        {
            Quantity += amount;
        }
    }
}