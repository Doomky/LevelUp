using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.Dbo
{
    public class Question : IObjectWithId
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
