using System;

namespace ItemCore
{
    public class MyModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? OrderNumber { get; set; }
    }
}