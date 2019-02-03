using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;



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
				.WithRequired(a => a.SystemCountryCode)
				.HasForeignKey(a => a.CountryCode);

			modelBuilder.Entity<SystemCountryCodePoco>()
				.HasMany(a => a.ApplicantProfiles)
				.WithRequired(a => a.SystemCountryCode)
				.HasForeignKey(a => a.Country);

			modelBuilder.Entity<ApplicantProfilePoco>()
				.HasMany(a => a.ApplicantWorkHistory)
				.WithRequired(e => e.ApplicantProfile)
				.HasForeignKey(e => e.Applicant);

			modelBuilder.Entity<SystemLanguageCodePoco>()
					.HasMany(a => a.CompanyDescriptions)
					.WithRequired(a => a.SystemLanguageCode)
					.HasForeignKey(a => a.LanguageId);

			modelBuilder.Entity<CompanyProfilePoco>()
				.HasMany(a => a.CompanyDescriptions)
				.WithRequired(a => a.CompanyProfile)
				.HasForeignKey(a => a.Company);

			modelBuilder.Entity<CompanyProfilePoco>()
				.HasMany(a => a.CompanyJobs)
				.WithRequired(a => a.CompanyProfile)
				.HasForeignKey(a => a.Company);


			modelBuilder.Entity<CompanyJobPoco>()
				.HasMany(a => a.CompanyJobEducations)
				.WithRequired(e => e.CompanyJob)
				.HasForeignKey(e => e.Job);

			modelBuilder.Entity<CompanyJobPoco>()
				.HasMany(a => a.CompanyJobSkills)
				.WithRequired(e => e.CompanyJob)
				.HasForeignKey(e => e.Job);

			modelBuilder.Entity<CompanyJobPoco>()
				.HasMany(a => a.CompanyJobDescriptions)
				.WithRequired(a => a.CompanyJob)
				.HasForeignKey(a => a.Job);

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



			modelBuilder.Entity<ApplicantEducationPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<ApplicantProfilePoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<ApplicantJobApplicationPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<ApplicantSkillPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<ApplicantWorkHistoryPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<CompanyDescriptionPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<CompanyJobEducationPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<CompanyJobSkillPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<CompanyJobPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<CompanyJobDescriptionPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<CompanyLocationPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<CompanyProfilePoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<SecurityLoginPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<SecurityLoginsRolePoco>()
							.Ignore(a => a.TimeStamp); 
			
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
