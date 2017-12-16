using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using gvn_ab_mobile.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(gvn_ab_mobile.Services.MockDataStore))]
namespace gvn_ab_mobile.Services {
    public class MockDataStore : IDataStore<Models.Usuario> {
        List<Models.Usuario> usuarios;

        public async Task<bool> AddItemAsync(Models.Usuario usuario) {
            new DAO.DAOUsuario().Insert(usuario);
            await InitializeAsync();
            
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Models.Usuario usuario) {
            await InitializeAsync();

            var _item = usuarios.Where((Models.Usuario arg) => arg.Id == usuario.Id).FirstOrDefault();
            usuarios.Remove(_item);
            usuarios.Add(usuario);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Models.Usuario usuario) {
            await InitializeAsync();

            var _item = usuarios.Where((Models.Usuario arg) => arg.Id == usuario.Id).FirstOrDefault();
            usuarios.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Models.Usuario> GetItemAsync(long Id) {
            await InitializeAsync();

            return await Task.FromResult(usuarios.FirstOrDefault(s => s.Id == Id));
        }

        public async Task<IEnumerable<Models.Usuario>> GetItemsAsync(bool forceRefresh = false) {
            await InitializeAsync();

            return await Task.FromResult(usuarios);
        }

        public Task<bool> PullLatestAsync() {
            return Task.FromResult(true);
        }
    
        public Task<bool> SyncAsync() {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync() {
            usuarios = new DAO.DAOUsuario().Select();
        }
    }
}
