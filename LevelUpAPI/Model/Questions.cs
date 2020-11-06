using System;
using System.Collections.Generic;

namespace LevelUpAPI.Model
{
    public partial class Questions
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ResponseA { get; set; }
        public string ResponseB { get; set; }
        public string ResponseC { get; set; }
        public string ResponseD { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
