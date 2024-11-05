﻿using System.ComponentModel.DataAnnotations;

namespace Simulator;
public class Animals
{
    private string description = "Unknown";
    public required string Description
    {
        get => description;
        init => description = Validator.Shortener(value, 3, 15, '#');
    }

    public uint Size { get; set; } = 3;

    public virtual string Info() => $"{Description} <{Size}>";
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info()}";
}