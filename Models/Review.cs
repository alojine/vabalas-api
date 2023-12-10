﻿namespace vabalas_api.Models
{
    public class Review
    {
        public int Id { get; set; }
        public Job Job { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
    }
}
