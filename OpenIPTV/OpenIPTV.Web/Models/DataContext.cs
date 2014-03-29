using System.Data.Entity;

namespace OpenIPTV.Web.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Compact")
        {
            Database.SetInitializer(new DatabaseInit());
        }

        public DbSet<Kanal> Kanal { get; set; }

        public DbSet<Emisija> Emisije { get; set; }
    }

    public class DatabaseInit : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);
            context.Kanal.Add(new Kanal() {Id = 40, Naziv = "RTS 1", Broj = 101, Logo = "rts.gif"});
            context.Kanal.Add(new Kanal() { Id = 18, Naziv = "RTS 2", Broj = 102, Logo = "rts.gif" });
            context.Kanal.Add(new Kanal() { Id = 718, Naziv = "TV NOVA", Broj = 103, Logo = "nova.png" });
            context.Kanal.Add(new Kanal() { Id = 23, Naziv = "B92", Broj = 104, Logo = "b92.gif" });
            context.Kanal.Add(new Kanal() { Id = 14, Naziv = "PRVA Srpska Televizija", Broj = 105, Logo = "prva.gif" });
        }
    }
}