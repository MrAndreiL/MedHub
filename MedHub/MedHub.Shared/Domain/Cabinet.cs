﻿namespace MedHub.Shared.Domain
{
    public class Cabinet
    {
        public Guid Id { get;  set; }
        public string Address { get;  set; }
        public List<StockLineItem> DrugsStock { get;  set; }
        public List<Doctor> Doctors { get;  set; }
    }
}