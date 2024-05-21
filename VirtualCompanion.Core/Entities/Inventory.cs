namespace VirtualCompanion.Core.Entities
{
    public class Inventory
    {
        public int ItemId { get; private set; }
        public int OwnerId { get; private set; }
        public int Amount { get; private set; }
        public string ItemName { get; set; }

        public Inventory(int itemId, int ownerId, int amount, string itemName = "Item")
        {
            ItemId = itemId;
            OwnerId = ownerId;
            Amount = amount;
            ItemName = itemName;
        }

        public void AdjustAmount(int amount)
        {
            Amount += amount;
        }
    }
}