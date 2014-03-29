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
            context.Kanal.Add(new Kanal() { Id = 1, Naziv = "PINK", Broj = 106, Logo = "pink.gif" });
            context.Kanal.Add(new Kanal() { Id = 464, Naziv = "HAPPY TV", Broj = 107, Logo = "happy.jpg" });
            context.Kanal.Add(new Kanal() { Id = 582, Naziv = "PINK 2", Broj = 108, Logo = "pink2.gif" });
            context.Kanal.Add(new Kanal() { Id = 626, Naziv = "PINK 3", Broj = 109, Logo = "pink3.gif" });
            context.Kanal.Add(new Kanal() { Id = 74, Naziv = "RTS DIGITAL", Broj = 110, Logo = "rts-digital.gif" });
            context.Kanal.Add(new Kanal() { Id = 610, Naziv = "SKY PLUS", Broj = 150, Logo = "skyplustv.gif" });
            context.Kanal.Add(new Kanal() { Id = 20, Naziv = "SOS", Broj = 152, Logo = "sos.gif" });
            context.Kanal.Add(new Kanal() { Id = 21, Naziv = "STUDIO B", Broj = 154, Logo = "studio-b.gif" });
        }
    }
}