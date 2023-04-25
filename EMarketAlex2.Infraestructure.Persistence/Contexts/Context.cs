using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using EMarketAlex2.Core.Domain.Entities;
using EMarketAlex2.Core.Domain.Common;
using EMarketAlex2.Core.Aplication.ViewModels.Users;
using EMarketAlex2.Core.Aplication.Helpers;
using System.Net.NetworkInformation;

namespace EMarketAlex2.Infraestructure.Persistence.Contexts
{
    public class Context:DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Context(DbContextOptions<Context> option, IHttpContextAccessor httpContextAccessor) : base(option)
        {

            _httpContextAccessor = httpContextAccessor;

        }

        public DbSet<Anuncios> Anuncios { get; set; }
        public DbSet<Categorias> categorias { get; set; }
        public DbSet<Users> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellation = new CancellationToken())
        {
            UserViewModel vm = new();

            vm = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("usuario");

            foreach(var entrada in ChangeTracker.Entries<AuditBaseEntity>())
            {
                switch (entrada.State)
                {

                    case EntityState.Added:

                        entrada.Entity.CreatedDate = DateTime.Now;
                        if (vm != null)
                        {
                            entrada.Entity.CreatedBy = vm.Username;
                        }
                        else
                        {
                            entrada.Entity.CreatedBy = "Admin";

                        }

                        break;


                    case EntityState.Modified:

                        entrada.Entity.ModifiedDate = DateTime.Now;
                        if (vm != null)
                        {
                            entrada.Entity.ModifiedBy = "Nombre: " + vm.Nombre + ", Username: " + vm.Username;
                        }
                        else
                        {
                            entrada.Entity.ModifiedBy = "Admin";
                        }
                        break;

                }



            }

            return base.SaveChangesAsync(cancellation);

        }

        //Configuraciones de las propiedades con Fluent Api.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region tablas

            modelBuilder.Entity<Anuncios>().ToTable("Anuncios");
            modelBuilder.Entity<Categorias>().ToTable("Categorias");
            modelBuilder.Entity<Users>().ToTable("Users");

            #endregion

            #region "Claves Primarias"


            modelBuilder.Entity<Anuncios>().HasKey(anuncios => anuncios.IdAnuncio);
            modelBuilder.Entity<Categorias>().HasKey(categoria =>categoria.IdCategoria);
            modelBuilder.Entity<Users>().HasKey(user => user.Id);

            #endregion

            #region relaciones
            modelBuilder.Entity<Categorias>()
                .HasMany<Anuncios>(categorias => categorias.Anuncios)
                .WithOne(anuncios => anuncios.categorias)
                .HasForeignKey(anuncios => anuncios.miCategoriaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Users>().HasMany<Anuncios>(user => user.anuncios)
                .WithOne(anuncios => anuncios.user).HasForeignKey
                (anuncio => anuncio.miUserId).OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "Configuracion de propiedades"

            #region "Anuncios"

            modelBuilder.Entity<Anuncios>().Property(anuncio => anuncio.precio).IsRequired();
            modelBuilder.Entity<Anuncios>().Property(anuncio => anuncio.descripcion).IsRequired();
            modelBuilder.Entity<Anuncios>().Property(anuncios => anuncios.nombre_anuncio).IsRequired();
          

            #endregion

            #region "Categorias"
            modelBuilder.Entity<Categorias>().Property(categoria => categoria.Descripcion).IsRequired();

            #endregion

            #region "Users"


            modelBuilder.Entity<Users>().Property(user => user.Password).IsRequired();
            modelBuilder.Entity<Users>().Property(user => user.Edad).IsRequired();
            modelBuilder.Entity<Users>().Property(user => user.Email).IsRequired();
            modelBuilder.Entity<Users>().Property(user => user.Nombre).IsRequired();
            modelBuilder.Entity<Users>().Property(user => user.Phone).IsRequired();
            modelBuilder.Entity<Users>().Property(user => user.Username).IsRequired();
            #endregion

            #endregion




        }

    }
}
