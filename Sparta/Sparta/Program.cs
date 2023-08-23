namespace Sparta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpartaGame spartaGame = SpartaGame.Instance();
            Store.Instance().Init();
            Inventory.Instance().SetInventoryItem();

            spartaGame.DisplayStartGame();
        }
    }
}