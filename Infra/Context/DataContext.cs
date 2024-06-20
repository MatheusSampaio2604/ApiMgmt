using Domain.Models.ApplicationUser;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Context
{
    public class DataContext : IdentityDbContext<ApplicationUser>

    {
        #region Private Element's
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor's
        public DataContext(DbContextOptions<DataContext> dbContext, IConfiguration configuration) : base(dbContext)
        {
            _configuration = configuration;
        }
        #endregion

        #region Table's
        public DbSet<ApplicationUser> Users { get; set; }
        #endregion

        #region Override Function's
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Não permitir a exclusão em cascata
            foreach (Microsoft.EntityFrameworkCore.Metadata.IMutableForeignKey foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
                foreignKey.DeleteBehavior = DeleteBehavior.ClientSetNull;

            //Aplica as configurações com base no Mapping do Imapper 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly, x => x.Namespace == "Application.AutoMapperAll.Mapping");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableDetailedErrors();
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DataConnection"));

                //Lazy loading carrega automaticamente entidades relacionadas na primeira vez que são acessadas
                //optionsBuilder.UseLazyLoadingProxies();
            }
        }

        #endregion
    }
}
