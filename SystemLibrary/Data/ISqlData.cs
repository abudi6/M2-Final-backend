using SystemLibrary.Models;

namespace SystemLibrary.Data
{
    public interface ISqlData
    {
        void AddItem(ItemModel item);
        void DeleteItem(string code);
        List<ItemModel> ListItems();
        void UpdateItem(ItemModel item);
    }
}