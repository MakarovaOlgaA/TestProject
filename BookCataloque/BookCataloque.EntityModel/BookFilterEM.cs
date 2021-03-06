﻿using System;

namespace BookCataloque.EntityModel
{
    public class BookFilterEM
    {
        public string Title { get; set; }

        public float? RatingLowerBound { get; set; }
        public float? RatingUpperBound { get; set; }

        public DateTime? PublicationDateUpperBound { get; set; }
        public DateTime? PublicationDateLowerBound { get; set; }

        public short? PagesLowerBound { get; set; }
        public short? PagesUpperBound { get; set; }
    }
}
