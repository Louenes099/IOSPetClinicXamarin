using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App1;
using SQLite;

namespace Aug27
{

    public class DBVet
    {
        readonly SQLiteAsyncConnection _databaseVet;
        public DBVet(string dbPath)
        {
            _databaseVet = new SQLiteAsyncConnection(dbPath);
            _databaseVet.CreateTableAsync<Vet>().Wait();
        }
        public Task<List<Vet>> GetPeopleAsync()
        {
            return
            _databaseVet.Table<Vet>().ToListAsync();
        }
        public Task<int> SavePersonAsync(Vet
        vet)
        {
            return _databaseVet.InsertAsync(vet);
        }

        public Task<int> UpdatePersonAsync(Vet vet)
        {
            if (vet.ID != 0)
            {
                return _databaseVet.UpdateAsync(vet);
            }
            else
            {
                return _databaseVet.InsertAsync(vet);
            }
        }
        public Task<int> DeleteItemAsync(Vet vet)
        {
            return _databaseVet.DeleteAsync(vet);
        }

    }
}
