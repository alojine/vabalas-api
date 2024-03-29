﻿using System.ComponentModel.DataAnnotations.Schema;
using vabalas_api.Enums;

namespace vabalas_api.Models
{
    public class Job
    {
        public int Id { get; set; }
        
        [ForeignKey("VabalasUser")]
        public String UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public JobCategory Category { get; set; }   
        public decimal Price { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
