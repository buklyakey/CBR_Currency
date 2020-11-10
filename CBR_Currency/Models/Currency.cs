﻿namespace CBR_Currency.Models
{

    public class Currency
    {
        public string ID { get; set; }

        public int NumCode { get; set; }

        public string CharCode { get; set; }

        public int Nominal { get; set; }

        public string Name { get; set; }

        public double Value { get; set; }

        public double Previous { get; set; }
    }
}
