

namespace DBEFAPI.Service.Emp
{
    public interface IEmp
    {
        Task<IEnumerable<Emp>> GetEmps();
        Task<Empser> GetEmp(int id);
        Task<Empser> PutEmp(int id, Empser emp);
        string PostEmp(Empser emp);
        Task<string> DeleteEmp(int id);
        string PostEmp(Models.Emp emp);
    }
}
