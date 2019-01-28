using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CareerCloud.EntityFrameworkDataAccess
{
	class CareerCloudContext : DbContext
	{
		public CareerCloudContext() : base(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString)
		{
			Database.Log = l => System.Diagnostics.Debug.WriteLine(l);
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ApplicantProfilePoco>()
				.HasMany(a => a.ApplicantEducations)
				.WithRequired(e => e.ApplicantProfile)
				.HasForeignKey(e => e.Applicant);

			modelBuilder.Entity<ApplicantProfilePoco>()
				.HasMany(a => a.ApplicantJobApplications)
				.WithRequired(e => e.ApplicantProfile)
				.HasForeignKey(e => e.Applicant);

			modelBuilder.Entity<CompanyJobPoco>()
				.HasMany(a => a.ApplicantJobApplications)
				.WithRequired(e => e.CompanyJob)
				.HasForeignKey(e => e.Job);

			modelBuilder.Entity<SecurityLoginPoco>()
				.HasMany(a => a.ApplicantProfiles)
				.WithRequired(e => e.SecurityLogin)
				.HasForeignKey(e => e.Login);

			modelBuilder.Entity<SystemCountryCodePoco>()
				.HasMany(a => a.ApplicantProfiles)
				.WithRequired(e => e.SystemCountryCode)
				.HasForeignKey(e => e.Country);

			modelBuilder.Entity<ApplicantProfilePoco>()
				.HasMany(a => a.ApplicantResumes)
				.WithRequired(e => e.ApplicantProfile)
				.HasForeignKey(e => e.Applicant);

			modelBuilder.Entity<ApplicantProfilePoco>()
				.HasMany(a => a.ApplicantSkills)
				.WithRequired(e => e.ApplicantProfile)
				.HasForeignKey(e => e.Applicant);

			modelBuilder.Entity<SystemCountryCodePoco>()
				.HasMany(a => a.ApplicantWorkHistory)
				.WithRequired(e => e.SystemCountryCode)
				.HasForeignKey(e => e.CountryCode);

			modelBuilder.Entity<ApplicantProfilePoco>()
				.HasMany(a => a.ApplicantWorkHistory)
				.WithRequired(e => e.ApplicantProfile)
				.HasForeignKey(e => e.Applicant);

			modelBuilder.Entity<SystemLanguageCodePoco>()
				.HasMany(a => a.CompanyDescriptions)
				.WithRequired(e => e.SystemLanguageCode)
				.HasForeignKey(e => e.LanguageId);

			modelBuilder.Entity<CompanyProfilePoco>()
				.HasMany(a => a.CompanyDescriptions)
				.WithRequired(e => e.CompanyProfile)
				.HasForeignKey(e => e.Company);

			modelBuilder.Entity<CompanyJobPoco>()
				.HasMany(a => a.CompanyJobEducations)
				.WithRequired(e => e.CompanyJob)
				.HasForeignKey(e => e.Job);

			modelBuilder.Entity<CompanyJobPoco>()
				.HasMany(a => a.CompanyJobSkills)
				.WithRequired(e => e.CompanyJob)
				.HasForeignKey(e => e.Job);

			modelBuilder.Entity<CompanyProfilePoco>()
				.HasMany(a => a.CompanyLocations)
				.WithRequired(e => e.CompanyProfile)
				.HasForeignKey(e => e.Company);

			modelBuilder.Entity<SecurityLoginPoco>()
				.HasMany(a => a.SecurityLoginsLogs)
				.WithRequired(e => e.SecurityLogin)
				.HasForeignKey(e => e.Login);

			modelBuilder.Entity<SecurityRolePoco>()
				.HasMany(a => a.SecurityLoginsRoles)
				.WithRequired(e => e.SecurityRole)
				.HasForeignKey(e => e.Role);

			modelBuilder.Entity<SecurityLoginPoco>()
				.HasMany(a => a.SecurityLoginsRoles)
				.WithRequired(e => e.SecurityLogin)
				.HasForeignKey(e => e.Login);


			base.OnModelCreating(modelBuilder);
		}

		public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
		public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
		public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
		public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
		public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
		public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
		public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
		public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
		public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
		public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
		public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
		public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
		public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
		public DbSet<SecurityLoginPoco>	SecurityLogins { get; set; }
		public DbSet<SecurityLoginsLogPoco>	SecurityLoginsLogs { get; set; }
		public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
		public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
		public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
		public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }

	}
}
