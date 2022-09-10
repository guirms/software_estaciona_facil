using Microsoft.EntityFrameworkCore;

namespace Infra.Context;

public class ConfigContext: DbContext
{
    public ConfigContext(DbContextOptions<ConfigContext> option): base(option)
    {
    }
}