﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMVC.Models.DB
{
    [Table("Requests")]
    public class Request
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }
}
