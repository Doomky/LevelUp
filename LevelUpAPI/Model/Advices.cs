using System;
using System.Collections.Generic;

namespace LevelUpBackend.Model
{
    public partial class Advices
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Text { get; set; }

        public virtual Categories Category { get; set; }
    }
}
