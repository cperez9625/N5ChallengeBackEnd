namespace N5.Api.Models
{
    public class PermissionRequest
    {
        public int Id { get; set; }
        public string EmployeeFirstName { get; set; } = null!;
        public string EmployeeLastName { get; set; } = null!;
        public int PermissionType { get; set; }
    }
}
