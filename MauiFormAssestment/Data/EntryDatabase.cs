using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace MauiFormAssestment.Data
{
    public class EntryDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public EntryDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            // Use fully-qualified model type to avoid ambiguous 'Entry' with UI control
            _database.CreateTableAsync<MauiFormAssestment.Models.Entry>().Wait();
        }

        // Return list of model entries
        public Task<List<MauiFormAssestment.Models.Entry>> GetEntriesAsync()
        {
            return _database.Table<MauiFormAssestment.Models.Entry>().ToListAsync();
        }

        // Save model entry
        public Task<int> SaveEntryAsync(MauiFormAssestment.Models.Entry entry)
        {
            return _database.InsertAsync(entry);
        }

        // Delete model entry
        public Task<int> DeleteEntryAsync(MauiFormAssestment.Models.Entry entry)
        {
            return _database.DeleteAsync(entry);
        }
    }
}
