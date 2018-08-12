using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;
using BioReactor072818.Models;
using System.Threading.Tasks;

namespace BioReactor072818.Data
{
	public class RecipeDatabase
	{
        readonly SQLiteAsyncConnection database;
        
		public RecipeDatabase (string dbPath)
		{
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Recipe>().Wait();
		}

        public Task<List<Recipe>> GetItemsAsync()
        {
            return database.Table<Recipe>().ToListAsync();
        }

        public Task<List<Recipe>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Recipe>("SELECT * FROM [Recipe]");
            //return database.QueryAsync<Recipe>("SELECT * FROM [Recipe] WHERE [Done] = 0");
        }

        public Task<Recipe> GetItemAsync(int id)
        {
            return database.Table<Recipe>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Recipe item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Recipe item)
        {
            return database.DeleteAsync(item);
        }

        public async Task<List<TableName>> GetTableNamesAsync()
        {
            string queryString = $"SELECT name FROM sqlite_master WHERE type = 'table'";
            return await database.QueryAsync<TableName>(queryString).ConfigureAwait(false);

        }

        public async void DeleteData()
        {
            List<Recipe> items = await GetItemsNotDoneAsync();
            foreach (Recipe item in items)
            {
                await DeleteItemAsync(item);
            }
        }
    }
}