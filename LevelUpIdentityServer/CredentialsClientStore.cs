// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using System.Linq;
using System.Threading.Tasks;

using IdentityServer4.Models;
using IdentityServer4.Stores;
using LevelUpAPI.Model;

namespace IdentityServer
{
    public class CredentialsClientStore : IClientStore
    {
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            using (var dbcontext = new levelupContext())
            {
                //foreach (var user in dbcontext.Users)
                //{
                //    if (!_clients.ContainsKey(user.Id))
                //    {
                //        Client client = new Client()
                //        {
                //            ClientId = user.Login,
                //            ClientSecrets =
                //            {
                //                new Secret(user.PasswordHash),
                //            },
                //            AllowedGrantTypes = GrantTypes.ClientCredentials,

                //            AllowedScopes = { "api1" }
                //        };
                //        _clients.Add(user.Id, client);
                //    }
                //}
                var client = Config.Clients.Where(client => client.ClientId == clientId);
                if (client.Any())
                {
                    return Task.FromResult(client.First());
                }
                return null;
            }
        }
    }
}