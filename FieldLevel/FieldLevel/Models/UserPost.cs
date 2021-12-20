using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldLevel.Models {
    public class UserPost {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime createdOn { get; set; } = DateTime.Now;
    }
}
