namespace CourseWork.Modules.Auth.Dtos
{
    public record UserLoginDto
    {
        public string? Email { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
