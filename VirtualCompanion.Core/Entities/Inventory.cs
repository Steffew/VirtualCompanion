namespace VirtualCompanion.Core.Entities
{
    public class Inventory
    {
        public int ItemId { get; private set; }
        public int OwnerId { get; private set; }
        public int Quantity { get; private set; }

        public Inventory(int itemId, int ownerId, int quantity)
        {
            ItemId = itemId;
            OwnerId = ownerId;
            Quantity = quantity;
        }

        public void AdjustQuantity(int amount)
        {
            Quantity += amount;
        }
    }
}