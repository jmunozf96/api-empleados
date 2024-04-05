using Domain.Entities;

namespace Domain.Ports.Out
{
    public interface UserRoleRepositoryPort
    {
        void DeleteByUserId(int id);
    }
}
