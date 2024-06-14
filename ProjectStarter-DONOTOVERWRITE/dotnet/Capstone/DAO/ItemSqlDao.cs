using System;
using Capstone.DatabaseEntities;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Exceptions;

namespace Capstone.DAO
{
    public class ItemSqlDao : IItemDao
    {
        private readonly string connectionString;

        public ItemSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<ItemDatabaseEntity> GetItems()
        {
            List<ItemDatabaseEntity> inventory = new List<ItemDatabaseEntity>();

            string sql = "SELECT item_id, item_name, quantity FROM items;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read()) {
                        ItemDatabaseEntity itemDBE = MapRowToItemDatabaseEntity(reader);
                        inventory.Add(itemDBE);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return inventory;
        }

        public ItemDatabaseEntity GetItemByItemId(int itemId)
        {
            ItemDatabaseEntity item = new ItemDatabaseEntity();

            string sql = "SELECT item_id, item_name, quantity FROM items " +
                "WHERE item_id = @item_id;";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@item_id", itemId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        item = MapRowToItemDatabaseEntity(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return item;

        }

        private ItemDatabaseEntity MapRowToItemDatabaseEntity(SqlDataReader reader)
        {
            ItemDatabaseEntity itemDBE = new ItemDatabaseEntity();
            itemDBE.ItemId = Convert.ToInt32(reader["item_id"]);
            itemDBE.ItemName = Convert.ToString(reader["item_name"]);
            itemDBE.Quantity = Convert.ToInt32(reader["quantity"]);

            return itemDBE;
        }
    }
}
