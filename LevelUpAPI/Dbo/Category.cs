﻿using System;
using System.Collections.Generic;

namespace LevelUpAPI.Dbo
{
    public class Category : IObjectWithId
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}