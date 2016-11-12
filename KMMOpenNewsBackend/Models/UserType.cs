﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KMMOpenNewsBackend.Models
{
    [Table("UserTypes")]
    public class UserType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}