using System;
using Microsoft.EntityFrameworkCore;

namespace CRM_APi
{
	public class CompanyDb : DbContext
	{
		public CompanyDb(DbContextOptions<CompanyDb>options) : base(options) { }

		public DbSet<Company> Companies => Set<Company>();
		
	}
}

