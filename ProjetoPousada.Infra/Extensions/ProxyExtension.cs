using Microsoft.Extensions.Options;

using ProjetoPousada.Dominio.Entidades.Proxy;

using RestSharp;

using System.Net;

namespace ProjetoPousada.Infra.Extensions
{
    public class ProxyExtension
    {
        private readonly ProxyEntity _proxy;

        public ProxyExtension(IOptions<ProxyEntity> proxy)
        {
            _proxy = proxy.Value;
        }

        public void VerificarProxy(RestClient srvCliente)
        {
            if (_proxy.Habilitado)
            {
                srvCliente.Options.Proxy = new WebProxy(_proxy.Host, _proxy.Porta);

                if (_proxy.UseDefaultCredentials)
                    srvCliente.Options.Proxy.Credentials = CredentialCache.DefaultCredentials;
                else
                    srvCliente.Options.Proxy.Credentials = new NetworkCredential(_proxy.Usuario, _proxy.Senha, _proxy.Dominio);
            }
        }
    }
}
