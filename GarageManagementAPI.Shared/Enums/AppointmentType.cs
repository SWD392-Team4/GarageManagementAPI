namespace GarageManagementAPI.Shared.Enums
{
    public enum AppointmentType
    {
        ServiceBooking,       // Booking để sử dụng một hoặc nhiều service
        ServicePackageBooking, // Booking để đăng ký/sử dụng một hoặc nhiều gói dịch vụ
        ScheduledMaintenance,   // Booking để đi bảo dưỡng định kỳ (đã có gói dịch vụ đăng ký trước)
        BuyingProduct
    }
}
