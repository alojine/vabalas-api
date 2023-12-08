﻿namespace vabalas_api.Controllers.JobOffer.Dtos
{
    public class JobOfferDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int jobId { get; set; }
        public string Status { get; set; }
        public string Note {  get; set; }
        public DateTime JobDate { get; set; } 

    }
}
