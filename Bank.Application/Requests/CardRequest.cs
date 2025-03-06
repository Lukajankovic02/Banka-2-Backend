﻿namespace Bank.Application.Requests;

public class CardCreateRequest
{
    public Guid CardTypeId { get; set; }
    public Guid AccountId  { get; set; }

    public string Name { get; set; }

    public decimal Limit { get; set; }

    public bool Status { get; set; }
}
