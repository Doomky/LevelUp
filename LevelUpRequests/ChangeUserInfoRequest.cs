﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public class ChangeUserInfoRequest : Request
    {
        public string NewFirstname { get; set; }
        public string NewLastname { get; set; }
        public string NewEmail { get; set; }
        public string NewGoogleId { get; set; }

        public ChangeUserInfoRequest() : base(Method.POST)
        {

        }
    }
}