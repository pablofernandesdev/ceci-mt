using CeciMT.Domain.Entities;
using CeciMT.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CeciMT.Infra.Data.Context
{
    [ExcludeFromCodeCoverage]
    public class AppDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private Company _currentTenant;

        public AppDbContext(DbContextOptions<AppDbContext> options,
            IHttpContextAccessor httpContextAccessor) : base(options) { 
            
            _httpContextAccessor = httpContextAccessor;
            if (_httpContextAccessor != null)
            {
                if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue("X-Api-Key", out var apiKey))
                {
                    SetTenant(apiKey);
                }
                else
                {
                    throw new Exception("Invalid Tenant!");
                }
            }
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<RegistrationToken> RegistrationToken { get; set; }
        public DbSet<ValidationCode> ValidationCode { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Company> Company { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasQueryFilter(a => a.CompanyId == _currentTenant.Id);
            modelBuilder.Entity<Role>();
            modelBuilder.Entity<RefreshToken>().HasQueryFilter(a => a.User.CompanyId == _currentTenant.Id);
            modelBuilder.Entity<RegistrationToken>().HasQueryFilter(a => a.User.CompanyId == _currentTenant.Id);
            modelBuilder.Entity<ValidationCode>().HasQueryFilter(a => a.User.CompanyId == _currentTenant.Id);
            modelBuilder.Entity<Address>().HasQueryFilter(a => a.User.CompanyId == _currentTenant.Id);
            modelBuilder.Entity<Company>();
        }

        public void Commit()
        {
            base.SaveChanges();
        }

        private void SetTenant(string apiKey)
        {
            if (!string.IsNullOrEmpty(_session.GetString(apiKey)))
            {
                _currentTenant = JsonConvert.DeserializeObject<Company>(_session.GetString(apiKey));
            }
            else
            {
                _currentTenant = Set<Company>()
                    .AsNoTracking()
                    .FirstOrDefault(x => x.ApiKey.Equals(apiKey));

                if (_currentTenant == null) throw new Exception("Invalid Tenant!");

                _session.SetString(apiKey, JsonConvert.SerializeObject(_currentTenant));
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entry.Entity.CompanyId = _currentTenant.Id;
                        break;
                }
            }
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entry.Entity.CompanyId = _currentTenant.Id;
                        break;
                }
            }
            var result = base.SaveChanges();
            return result;
        }
    }
}
