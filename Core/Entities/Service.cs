﻿namespace Core.Entities;

public class Service
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<ServicePayment> PaymentServices { get; set; } = new List<ServicePayment>();
}
