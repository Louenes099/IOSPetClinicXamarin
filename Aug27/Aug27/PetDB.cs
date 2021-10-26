using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aug27
{
    public class PetDB
    {
        readonly SQLiteAsyncConnection _database;
        public PetDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Pets>().Wait();
        }
        public Task<List<Pets>> GetPetsAsync()
        {
            return _database.Table<Pets>().ToListAsync();
        }
        public Task<int> SavePetAsync(Pets pet)
        {
            return _database.InsertAsync(pet);
        }

        public Task<int> UpdatePetAsync(Pets pet)
        {
            if (pet.PetID != 0)
            {
                return _database.UpdateAsync(pet);
            }
            else
            {
                return _database.InsertAsync(pet);
            }
        }
        public Task<int> DeletePetAsync(Pets pet)
        {
            return _database.DeleteAsync(pet);
        }
        public Task<Pets> GetPetAsync(int id)
        {
            return _database.Table<Pets>().Where(i => i.PetID == id).FirstOrDefaultAsync();
        }
    }
}
