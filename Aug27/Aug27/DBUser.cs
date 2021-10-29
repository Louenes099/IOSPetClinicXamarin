using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App1;
using SQLite;

namespace Aug27
{

    public class DBUser
    {
        readonly SQLiteAsyncConnection _database;
        public DBUser(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }
        public Task<List<User>> GetPeopleAsync()
        {
            return
            _database.Table<User>().ToListAsync();
        }
        public Task<int> SavePersonAsync(User
        user)
        {
            return _database.InsertAsync(user);
        }

        public Task<int> UpdatePersonAsync(User user)
        {
            if (user.ID != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }
        public Task<int> DeleteItemAsync(User user)
        {
            return _database.DeleteAsync(user);
        }

        public Task<User> GetItemAsync(int id)
        {
            return _database.Table<User>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<User> GetItemAsync(string username, string password)
        {
            return _database.Table<User>().Where(i => i.Name == username && i.Password == password).FirstOrDefaultAsync();
        }

    }
}
