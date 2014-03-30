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

    public class DatabaseInit : CreateDatabaseIfNotExists<DataContext>
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
            context.Kanal.Add(new Kanal() { Id = 724, Naziv = "PINK WESTERN", Broj = 174, Logo = "pinkwestern.png" });
            context.Kanal.Add(new Kanal() { Id = 725, Naziv = "PINK STYLE", Broj = 175, Logo = "pinkwestern.png" });
            context.Kanal.Add(new Kanal() { Id = 726, Naziv = "PINK CLASSIC", Broj = 176, Logo = "pinkwestern.png" });
            context.Kanal.Add(new Kanal() { Id = 733, Naziv = "BRAVO MUSIC", Broj = 177, Logo = "gen.gif" });
            context.Kanal.Add(new Kanal() { Id = 664, Naziv = "PINK PEDIA", Broj = 179, Logo = "gen.gif" });
            context.Kanal.Add(new Kanal() { Id = 660, Naziv = "PINK COMEDY", Broj = 180, Logo = "pinkcomedy.gif" });
            context.Kanal.Add(new Kanal() { Id = 661, Naziv = "PINK HOROR", Broj = 181, Logo = "pinkcomedy.gif" });
            context.Kanal.Add(new Kanal() { Id = 633, Naziv = "PINK REALITY", Broj = 184, Logo = "pink_reality.gif" });
            context.Kanal.Add(new Kanal() { Id = 628, Naziv = "PINK PREMIUM", Broj = 185, Logo = "pink_premium.gif" });
            context.Kanal.Add(new Kanal() { Id = 624, Naziv = "PINK MOVIES 2", Broj = 186, Logo = "pinkmovies2.gif" });
            context.Kanal.Add(new Kanal() { Id = 625, Naziv = "PINK MOVIES 3", Broj = 187, Logo = "pinkmovies3.gif" });
            context.Kanal.Add(new Kanal() { Id = 622, Naziv = "PINK ACTION 2", Broj = 188, Logo = "pinkaction2.gif" });
            context.Kanal.Add(new Kanal() { Id = 623, Naziv = "PINK ACTION 3", Broj = 189, Logo = "pinkaction3.gif" });
            context.Kanal.Add(new Kanal() { Id = 627, Naziv = "PINK SOAP", Broj = 194, Logo = "pink_soap.gif" });
            context.Kanal.Add(new Kanal() { Id = 595, Naziv = "PINK FAMILY", Broj = 195, Logo = "pink-family.gif" });
            context.Kanal.Add(new Kanal() { Id = 599, Naziv = "PINK WORLD", Broj = 196, Logo = "pink_world.gif" });
            context.Kanal.Add(new Kanal() { Id = 662, Naziv = "SRPSKA NAUČNA TELEVIZIJA", Broj = 197, Logo = "gen.gif" });
            context.Kanal.Add(new Kanal() { Id = 705, Naziv = "MTS", Broj = 198, Logo = "gen.gif" });
            context.Kanal.Add(new Kanal() { Id = 208, Naziv = "BEST", Broj = 210, Logo = "best-rtv.gif" });
            context.Kanal.Add(new Kanal() { Id = 33, Naziv = "HRT 1", Broj = 501, Logo = "hrt-1.gif" });
            context.Kanal.Add(new Kanal() { Id = 25, Naziv = "BN TV", Broj = 502, Logo = "bn.gif" });
            context.Kanal.Add(new Kanal() { Id = 602, Naziv = "RT CG Sat", Broj = 503, Logo = "gen.gif" });
            context.Kanal.Add(new Kanal() { Id = 64, Naziv = "OBN", Broj = 504, Logo = "obn.gif" });
            context.Kanal.Add(new Kanal() { Id = 585, Naziv = "ATLAS TV", Broj = 505, Logo = "atlas.gif" });
            context.Kanal.Add(new Kanal() { Id = 455, Naziv = "RTRS", Broj = 507, Logo = "rtrs.png" });
            context.Kanal.Add(new Kanal() { Id = 704, Naziv = "NICKELODEON", Broj = 516, Logo = "nickelodeon.gif" });
            context.Kanal.Add(new Kanal() { Id = 247, Naziv = "DISNEY JUNIOR", Broj = 518, Logo = "disneyjunior.png" });
            context.Kanal.Add(new Kanal() { Id = 232, Naziv = "DISNEY XD", Broj = 519, Logo = "disney-xd.gif" });
            context.Kanal.Add(new Kanal() { Id = 233, Naziv = "DISNEY", Broj = 520, Logo = "disney.gif" });
            context.Kanal.Add(new Kanal() { Id = 46, Naziv = "PINK KIDS", Broj = 521, Logo = "pink-kids.gif" });
            context.Kanal.Add(new Kanal() { Id = 59, Naziv = "CARTOON NETWROK", Broj = 522, Logo = "cartoon-network2.gif" });
            context.Kanal.Add(new Kanal() { Id = 84, Naziv = "MINIMAX", Broj = 523, Logo = "minimax.gif" });
        }
    }
}