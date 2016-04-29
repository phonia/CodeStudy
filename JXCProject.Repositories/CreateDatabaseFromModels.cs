using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace JXCProject.Repositories
{
    public class CreateDatabaseFromModels
    {
        public static void CreateDatabase()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<JXCContext>());

            using (JXCContext context = new JXCContext())
            {
                context.Database.Initialize(true);
            }
        }
    }
}
