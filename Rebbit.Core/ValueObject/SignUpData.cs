namespace Rebbit.Core.ValueObject
{
    public struct SignUpData
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
