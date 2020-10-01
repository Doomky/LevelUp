using System;
using System.Collections.Generic;

namespace LevelUpAPI.Dbo
{
    public class Skin : IObjectWithId
    {
        public enum SkinNameAsEnum 
        {
            unknown,
            man_default,
            woman_default,
            man_pyjama,
            woman_pyjama,
            man_fancy,
            woman_fancy
        };

        public int Id { get; set; }
        public string Name { get; set; }
        public int LevelMin { get; set; }
    }
}
