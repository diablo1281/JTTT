using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class JTTTDBContext : DbContext
    {
        public JTTTDBContext()
        {
            Configuration.ProxyCreationEnabled = false;
        }
        // przetrzymywanie w bazie nazwy i id
        public DbSet<IfThenActions> IfThatActions { get; set; }

        // wykorzystywane tylko do czyszczenia bazy danych
        public DbSet<FindOnWebsite> fow { get; set; }

        public DbSet<SendEmail> sm { get; set; }

        public DbSet<ShowOnBrowser> sb { get; set; }
    }
}

