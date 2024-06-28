﻿namespace Application.ViewModels.ApiPlc
{
    public class PlcConfig
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string AddressPlc { get; set; }
        public required string Type { get; set; }
        public string? Value { get; set; }
    }
}
