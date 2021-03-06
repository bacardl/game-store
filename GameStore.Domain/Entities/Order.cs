﻿using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending";

    }

}