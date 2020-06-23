using System;
using System.Collections.Generic;

namespace LevelUpAPI.Dbo
{
    public class Quest : IObjectWithId
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public int ProgressValue { get; set; }
        public int ProgressCount { get; set; }
        public int UserId { get; set; }
        public int? XpValue { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsClaimed { get; set; }
    }
}
