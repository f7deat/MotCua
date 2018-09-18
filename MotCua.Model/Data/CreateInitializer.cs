using System.Data.Entity;

namespace MotCua.Model.Data
{
    public class CreateInitializer : DropCreateDatabaseIfModelChanges<MotCuaDbContext>
    {
        protected override void Seed(MotCuaDbContext context)
        {

        }
    }
}
