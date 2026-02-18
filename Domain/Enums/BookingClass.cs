namespace Domain.Enums
{
    public enum BookingClass
    {
        Standard = 1,
        Business,
        Economy
    };

    public enum TripStatus { Scheduled, Ongoing, Completed, Cancelled }
    public enum SeatStatus { Available, Booked, Reserved }
    public enum BookingStatus { Pending, Confirmed, Cancelled }
}
