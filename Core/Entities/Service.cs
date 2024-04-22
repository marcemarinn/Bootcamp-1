﻿namespace Core.Entities;

public class Service
{
    public int Id { get; set; }

    public string ServiceName { get; set; }

    public List<ServicePayment> ServicePayments { get; set; } = new List<ServicePayment>();


}
