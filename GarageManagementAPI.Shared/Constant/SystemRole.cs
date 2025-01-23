namespace GarageManagementAPI.Shared.Constant
{
    public class SystemRole
    {
        public const string Administrator = "Administrator";
        public const string Mechanic = "Mechanic";
        public const string Cashier = "Cashier";
        public const string Customer = "Customer";
        public const string WarehouseManager = "WarehouseManager";


        private static readonly HashSet<string> ValidRoles = new()
        {
            Administrator,
            Mechanic,
            Cashier,
            Customer,
            WarehouseManager
        };
        public static bool ValidRole(string? role)
        {
            return role != null && ValidRoles.Contains(role);
        }
    }
}
