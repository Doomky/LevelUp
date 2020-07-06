﻿using System;

namespace LevelUpDTO
{
    public class SignInDTOResponse : DTOResponse
    {
        public string Token { get; set; }

        public SignInDTOResponse(string token)
        {
            Token = token;
        }
    }
}