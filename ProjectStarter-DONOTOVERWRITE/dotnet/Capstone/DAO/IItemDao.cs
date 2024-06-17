using Capstone.DatabaseEntities;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IItemDao
    {
        List<ItemDatabaseEntity> GetItems();
        ItemDatabaseEntity GetItemByItemId(int itemId);
        ItemDatabaseEntity CreateItem(ItemDatabaseEntity item);
    }
}
