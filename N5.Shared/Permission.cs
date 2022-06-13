namespace N5.Shared
{
    public class Permission
    {
        public int Id { get; set; }
        public string EmployeeFirstName { get; set; } = null!;
        public string EmployeeLastName { get; set; } = null!;
        public int PermissionType { get; set; }
        public DateTime PermissionDate { get; set; }

        public virtual PermissionType PermissionTypeNavigation { get; set; } = null!;
    }
}
