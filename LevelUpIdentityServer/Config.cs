// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using LevelUpAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("api1", "My API")
            };

        public static Dictionary<int, Client> _clients = new Dictionary<int,Client>();

        public static IEnumerable<Client> Clients => GetClients();

        public static IEnumerable<Client> GetClients()
        {
            try
            {
                using (var dbcontext = new levelupContext())
                {
                    foreach (var user in dbcontext.Users)
                    {
                        if (!_clients.ContainsKey(user.Id))
                        {
                            Client client = new Client()
                            {
                                ClientId = user.Login,
                                ClientSecrets =
                            {
                                new Secret(user.PasswordHash),
                            },
                                AllowedGrantTypes = GrantTypes.ClientCredentials,

                                AllowedScopes = { "api1" }
                            };
                            _clients.Add(user.Id, client);
                        }
                    }
                }
            }
            catch (System.Exception)
            {

            }
            return _clients.Values.ToList();
        }
    }
}