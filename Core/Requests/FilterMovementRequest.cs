﻿namespace Core.Requests;

public class FilterMovementRequest
{

    public int AccountId { get; set; }
    public int? Month { get; set; }
    public int? Year { get; set; } 
    public DateTime? StartDate { get; set; } 
    public DateTime? EndDate { get; set; } 
    public string? Description { get; set; }
    
}