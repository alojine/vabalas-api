﻿namespace vabalas_api.Controllers.JobOffer.Dtos
{
    public class JobOfferDto
    {
        public int Id { get; set; }

        public string CustomerEmail { get; set; }
        public int JobId { get; set; }
        public string Status { get; set; }
        public string Description {  get; set; }
        public DateTime JobDate { get; set; } 

    }
}
