namespace Domain.Ports.In.Commands
{
    public interface IRemoveEmployeeCommandHandler
    {
        void Execute(int id);
    }
}
