using Domain.Entities;

namespace Domain.Ports.Out
{
    public interface UserRepositoryPort
    {
        User GetById(int id);

        User GetByEmail(string email);

        User Create(User user);

        void Update(User user);

        void Delete(int id);
    }
}
