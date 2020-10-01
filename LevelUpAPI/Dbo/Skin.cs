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
            woman_fancy,
            man_funny,
            woman_funny,
            man_sportive,
            woman_sportive,
            man_cook,
            woman_cook
        };

        public int Id { get; set; }
        public string Name { get; set; }
        public int? LevelMin { get; set; }
    }
}
