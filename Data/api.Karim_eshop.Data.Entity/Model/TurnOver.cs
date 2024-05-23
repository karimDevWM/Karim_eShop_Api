using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Karim_eshop.Data.Entity.Model
{
    public class TurnOver
    {
        public int Id { get; set; }
        public DateTime? created_at { get; set; }
        public int amount { get; set; }
    }
}
