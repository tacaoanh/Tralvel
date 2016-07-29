using Microsoft.Practices.EnterpriseLibrary.Data;


namespace travel.Manager
{
    public class BaseManager
    {
        private static Database _database;
        protected static Database Database
        {
            get
            {
                if (_database == null)
                {
                    var factory = new DatabaseProviderFactory();
                    _database = factory.CreateDefault();
                }
                return _database;
            }
        }
    }
}