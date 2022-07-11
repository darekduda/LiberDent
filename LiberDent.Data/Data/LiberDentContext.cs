using LiberDent.Data.Data.Account;
using LiberDent.Data.Data.CMS;
using LiberDent.Data.Data.Slownikowe;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiberDent.Data.Data
{
    public class LiberDentContext : IdentityDbContext<ApplicationUser>
    {
        public LiberDentContext(DbContextOptions<LiberDentContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().HasOne(b=>b.Dane).WithOne(i=>i.Uzytkownik).HasForeignKey<DaneUzytkownika>(b=>b.IdUzytkownika);
            builder.Entity<ApplicationUser>().HasOne(b => b.DaneLekarza).WithOne(i => i.Uzytkownik).HasForeignKey<DaneLekarza>(b => b.IdUzytkownika);
            builder.Entity<ApplicationUser>().HasOne(b => b.Adres).WithOne(i => i.Uzytkownik).HasForeignKey<AdresUzytkownika>(b => b.IdUzytkownika);
        }

        public DbSet<Kontakt> Kontakt { get; set; }
        public DbSet<Powitanie> Powitanie { get; set; }
        public DbSet<GodzinyOtwarcia> GodzinyOtwarcia { get; set; }
        public DbSet<CenyUslug> CenyUslug { get; set; }
        public DbSet<AdresUzytkownika> AdresUzytkownika { get; set; }
        public DbSet<DaneUzytkownika> DaneUzytkownika { get; set; }
        public DbSet<DaneOPersonelu> DaneOPersonelu { get; set; }
        public DbSet<TytulNaukowy> TytulNaukowy { get; set; }
        public DbSet<Stanowiska> Stanowiska { get; set; }
        public DbSet<DaneLekarza> DaneLekarza { get; set; }
        public DbSet<RodzajeWizyty> RodzajeWizyty { get; set; }
        public DbSet<UmowioneWizyty> UmowioneWizyty { get; set; }
        public DbSet<ONas> ONas { get; set; }
        public DbSet<PoziomUprawnien> PoziomUprawnien { get; set; }
    }
}