using System.Threading.Tasks;
using AgentiVanzari.Domain;
using Microsoft.EntityFrameworkCore;

namespace AgentiVanzari.Repository;

public class RepositoryUsers
{
    public async Task<Agent> GetByUserNameAndPassword(string username, string password)
    {
        using var context = new AgentContext();
        return await context.Agents.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
    }
}