﻿namespace ReservacionesApi.Domain.Entities;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int ReservationId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? PaymentMethod { get; set; }

    public string? TransactionId { get; set; }

    public virtual Reservation Reservation { get; set; } = null!;
}
