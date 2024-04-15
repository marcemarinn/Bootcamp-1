﻿using Core.Constants;
using Core.Entities;

namespace Core.DTOs;

public class AccountDTO
{
    public int Id { get; set; }
    public decimal? OperationalLimit { get; set; }
    public decimal? MonthAverage { get; set; }
    public decimal? Interest { get; set; }
    public AccountType Type { get; set; } = AccountType.Current;
}
