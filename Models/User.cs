﻿namespace vabalas_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        
        public virtual ICollection<JobOffer> JobOffers { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
