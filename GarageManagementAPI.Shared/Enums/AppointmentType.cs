namespace GarageManagementAPI.Shared.Enums
{
    public enum AppointmentType
    {
        ServiceBooking = 1,       // Booking để sử dụng một hoặc nhiều service
        ServicePackageBooking = 2, // Booking để đăng ký/sử dụng một hoặc nhiều gói dịch vụ
        ScheduledMaintenance = 3,   // Booking để đi bảo dưỡng định kỳ (đã có gói dịch vụ đăng ký trước)
        SellingProduct = 4,       // Booking để mua một hoặc nhiều sản phẩm
    }
}
