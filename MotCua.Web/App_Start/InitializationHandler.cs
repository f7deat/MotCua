using MotCua.Model.Data;
using System.Data.Entity;

namespace MotCua.Web.App_Start
{
    public class InitializationHandler
    {
        public static void Initialize()
        {
            Database.SetInitializer(new CreateInitializer());

            using (var db = new MotCuaDbContext())
            {
                db.Database.Initialize(true);
            }
        }
    }
}