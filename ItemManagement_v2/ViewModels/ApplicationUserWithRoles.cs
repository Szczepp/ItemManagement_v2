namespace ItemManagement_v2.ViewModels
{
    public class ApplicationUserWithRoles
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
