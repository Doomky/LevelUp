// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using LevelUpAPI.DataAccess.Repositories.Interfaces;

namespace IdentityServer
{
    public class CredentialsClientStore : IClientStore
    {
        private readonly IUserRepository _userRepository;

        public CredentialsClientStore(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            var user = await _userRepository.GetUserByLoginOrEmail(clientId, null);
            if (user != null)
            {
                Secret secret = new Secret(user.PasswordHash.Sha256());
                Client client = new Client()
                {
                    ClientId = user.Login,
                    ClientSecrets =
                            {
                                secret,
                            },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "api1" }
                };
                return client;
            }
            return null;
        }
    }
}