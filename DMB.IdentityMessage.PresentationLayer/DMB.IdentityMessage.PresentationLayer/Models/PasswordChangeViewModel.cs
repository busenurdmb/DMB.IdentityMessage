namespace DMB.IdentityMessage.PresentationLayer.Models
{
    public class PasswordChangeViewModel
    {
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? NewPasswordConfirm { get; set; }
    }
}
