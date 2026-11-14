

namespace UserServiceDemo
{
    public interface IUserService
    {
        string? GetUserName(int id);
        Task<string?> GetUsernameAsync(int id);
        void SaveUser(int id, string name);
    }

    public interface INotifier
        {
            void Send(string message);
            Task SendAsync(string message);
        }

    public class UserService
    {
        private readonly IUserService _userService;
        private readonly INotifier _notifier;

        public UserService(IUserService userService, INotifier notifier)
        {
            _userService = userService;
            _notifier = notifier;
        }

        public string GetWelcomeMessage(int id)
        {
            string? name = _userService.GetUserName(id);
            if (name is null) return "User not found";
            return $"Welcome, {name}";
        }

        public async Task<string> GetWelcomeMessageAsync(int id)
        {
            string? name = await _userService.GetUsernameAsync(id);
            if (name is null) return "User not found";
            return $"Welcome, {name}";
        }

        public bool SendWelcome(int id)
        {
            string? name = _userService.GetUserName(id);
            if (name is null) return false;

            _notifier.Send($"Welcome, {name}");
            return true;
        }

        public async Task<bool> SendWelcomeAsync(int id)
        {
            string? name = await _userService.GetUsernameAsync(id);
            if (name is null) return false;

            await _notifier.SendAsync($"Welcome, {name}");
            return true;
        }

        public void SaveUser(int id, string name) => _userService.SaveUser(id, name);
    }
}
