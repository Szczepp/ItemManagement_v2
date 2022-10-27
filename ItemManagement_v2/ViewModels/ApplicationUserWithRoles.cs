namespace ItemManagement_v2.ViewModels
{
    public class ApplicationUserWithRoles
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public string RoleId { get; set; }
    }
}
