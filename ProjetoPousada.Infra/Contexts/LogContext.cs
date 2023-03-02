using JsonDiffPatchDotNet;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ProjetoPousada.Dominio.Entidades;
using ProjetoPousada.Dominio.Entidades.Config;
using ProjetoPousada.Dominio.Entidades.Helpers;
using ProjetoPousada.Dominio.Entidades.Log;

namespace ProjetoPousada.Infra.Contexts
{
    public static class LogContext
    {
        private static readonly List<EntityState> entityStates = new List<EntityState>() { EntityState.Added, EntityState.Modified, EntityState.Deleted };

        static IServiceProvider services = null;

        /// <summary>
        /// Provides static access to the framework's services provider
        /// </summary>
        public static IServiceProvider Services
        {
            get { return services; }
            set
            {
                if (services != null)
                {
                    throw new Exception("Can't set once a value has already been set.");
                }
                services = value;
            }
        }

        public static void Log(this DbContext context)
        {
            LogEntity _oLog = new LogEntity();

            var _dtCadastro = DateTime.Now;
            const string _emptyJson = "{}";
            const string _primarykey = "Id";
            int idRegistro = 0;

            int idUsuario = 0;
            var usuario = AppHttpContextHelper.Current.User.Claims.Where(p => p.Type.Equals("Usuario")).FirstOrDefault().Value;

            if (!string.IsNullOrEmpty(usuario))
            {
                var oUsuario = JsonConvert.DeserializeObject<UsuarioEntity>(usuario);
                idUsuario = AppHttpContextHelper.Current != null ? oUsuario.Id : 0; //Em caso de serviços e robôs não é setado o código do usuário
            }

            var _monitoradas = context.ChangeTracker.Entries()
                .Where(x => entityStates.Contains(x.State) && x.Entity.GetType().IsSubclassOf(typeof(Entidade)))
                .ToList();

            var _jdp = new JsonDiffPatch();

            foreach (var _item in _monitoradas)
            {
                var _original = _emptyJson;
                var _nova = _emptyJson;

                if (_item.State == EntityState.Deleted)
                {
                    idRegistro = ((Entidade)_item.Entity).Id;
                    _original = JsonConvert.SerializeObject(_item.Entity);
                }
                else
                {
                    idRegistro = Convert.ToInt32(_item.CurrentValues[_primarykey]);
                    _nova = JsonConvert.SerializeObject(_item.CurrentValues.Properties.ToDictionary(p => p.Name, cv => _item.CurrentValues[cv]));
                }

                string _propriedadesAlteradas = string.Empty;

                if (_item.State == EntityState.Modified)
                {
                    var _propriedades = _item.GetDatabaseValues();
                    _original = JsonConvert.SerializeObject(_propriedades.Properties.ToDictionary(p => p.Name, pn => _propriedades[pn]));

                    string diff = _jdp.Diff(_original, _nova);

                    if (!string.IsNullOrEmpty(diff))
                        _propriedadesAlteradas = JToken.Parse(diff).ToString(Formatting.None);
                }

                _oLog = new LogEntity()
                {
                    Escopo = _item.Entity.GetType().Name,
                    IdRegistro = idRegistro,
                    DtCadastro = _dtCadastro,
                    TipoOperacao = _item.State.ToString(),
                    IdUsuario = idUsuario,
                    ValoresAntigos = _original,
                    ValoresNovos = _nova,
                    PropriedadesAlteradas = _propriedadesAlteradas
                };

                context.Add(_oLog);
            }
        }
    }

}
