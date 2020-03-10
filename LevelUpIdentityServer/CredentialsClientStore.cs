// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using System.Linq;
using System.Threading.Tasks;

using IdentityServer4.Models;
using IdentityServer4.Stores;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Model;

namespace IdentityServer
{
    public class CredentialsClientStore : IClientStore
    {
        private readonly levelupContext _context;
        private readonly IUserRepository _userRepository;

        public CredentialsClientStore(levelupContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            var user = await _userRepository.GetUserByLogin(clientId);
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