namespace Capstone.DAO
{
    public class ItemSqlDao : IItemDao
    {
        private readonly string connectionString;

        public ItemSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
    }
}
