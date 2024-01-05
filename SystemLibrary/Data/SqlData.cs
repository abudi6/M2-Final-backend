using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemLibrary.Models;

namespace SystemLibrary.Data
{
    public class SqlData : ISqlData
    {
        private ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        public void AddItem(ItemModel item)
        {
            _db.SaveData("spItems_Insert", new
            {
                item.Name,
                item.Code,
                item.Brand,
                item.UnitPrice,
                item.DatePosted
            },
                connectionStringName, true);
        }
        public void DeleteItem(string code)
        {
            _db.DeleteData("spItems_Delete", new { Code = code }, connectionStringName, true);
        }
        public List<ItemModel> ListItems()
        {
            return _db.LoadData<ItemModel, dynamic>("dbo.spItems_List", new { }, connectionStringName, true);
        }

        public void UpdateItem(ItemModel item)
        {
            _db.UpdateData("spItems_Update", new
            {
                item.Name,
                item.Code,
                item.Brand,
                item.UnitPrice,
            },
                connectionStringName, true);
        }
    }

}
