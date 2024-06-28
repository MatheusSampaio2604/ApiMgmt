namespace Application.ViewModels
{

    public class LoginResult
    {
        public bool Succeeded { get; set; }
        public string? Name { get; set; }
        public string? Token { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }

    public class RequestLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
