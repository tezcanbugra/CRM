using System;
using Microsoft.EntityFrameworkCore;

namespace CRMApi.Models;

	public class CompanyContext:DbContext
	{
		public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
		{
		}

	public DbSet<Company> Companies { get; set; } = null;
	}


