using Newtonsoft.Json;
using ProjectManagement.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EHealthcare.Entities
{
    public class Cart : BaseEntity
    {
        public virtual Product product { set; get; }

        public virtual User user { get; set; }

        public virtual ICollection<CartItem> Items { get; set; }
    }
}
