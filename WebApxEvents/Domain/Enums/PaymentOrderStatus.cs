namespace Domain.Enums
{
    public enum PaymentOrderStatus
    {
        Available = 1,
        Expired,
        Paid,
        Cancelled,
        PendingRefund,
        Refunded
    }
}