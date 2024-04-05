using Domain.Entities;

namespace ErpSecurity.Domain.Models
{
    public class InputGetAccessToken(User user, int durationTokenInMinutes, string key)
    {
        public InputGetAccessToken(User user, string key) : this(user, 60 * 24 * 7, key)
        {

        }
        public User User { get; } = user;
        public int DurationTokenInMinutes { get; } = durationTokenInMinutes;
        public string Key { get; } = key;
    }
}
