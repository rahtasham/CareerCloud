using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
	
	public class Applicant : IApplicant
	{
		private ApplicantEducationLogic _logic;
		private ApplicantJobApplicationLogic _jLogic;
		private ApplicantProfileLogic _pLogic;
		private ApplicantResumeLogic _rLogic;
		private ApplicantSkillLogic _sLogic;
		private ApplicantWorkHistoryLogic _wLogic;


		public Applicant()
		{
			EFGenericRepository<ApplicantEducationPoco> repo =
				new EFGenericRepository<ApplicantEducationPoco>(false);
			_logic = new ApplicantEducationLogic(repo);


			EFGenericRepository<ApplicantJobApplicationPoco> jRepo =
				new EFGenericRepository<ApplicantJobApplicationPoco>(false);
			_jLogic = new ApplicantJobApplicationLogic(jRepo);


			EFGenericRepository<ApplicantProfilePoco> pRepo =
				new EFGenericRepository<ApplicantProfilePoco>(false);
			_pLogic = new ApplicantProfileLogic(pRepo);


			EFGenericRepository<ApplicantResumePoco> rRepo =
				new EFGenericRepository<ApplicantResumePoco>(false);
			_rLogic = new ApplicantResumeLogic(rRepo);


			EFGenericRepository<ApplicantSkillPoco> sRepo =
				new EFGenericRepository<ApplicantSkillPoco>(false);
			_sLogic = new ApplicantSkillLogic(sRepo);


			EFGenericRepository<ApplicantWorkHistoryPoco> wRepo =
				new EFGenericRepository<ApplicantWorkHistoryPoco>(false);
			_wLogic = new ApplicantWorkHistoryLogic(wRepo);

		}

		public void AddApplicantEducation(ApplicantEducationPoco[] item)
		{
			_logic.Add(item);
		}

		public void AddApplicantJobApplication(ApplicantJobApplicationPoco[] item)
		{
			_jLogic.Add(item);
		}

		public void AddApplicantProfile(ApplicantProfilePoco[] item)
		{
			_pLogic.Add(item);
		}
		public void AddApplicantResume(ApplicantResumePoco[] item)
		{
			_rLogic.Add(item);
		}

		public void AddApplicantSkill(ApplicantSkillPoco[] item)
		{
			_sLogic.Add(item);
		}

		public void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] item)
		{
			_wLogic.Add(item);
		}

		public List<ApplicantEducationPoco> GetAllApplicantEducation()
		{
			return _logic.GetAll();
		}

		public List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication()
		{
			return _jLogic.GetAll();
		}

		public List<ApplicantProfilePoco> GetAllApplicantProfile()
		{
			return _pLogic.GetAll();
		}

		public List<ApplicantResumePoco> GetAllApplicantResume()
		{
			return _rLogic.GetAll();
		}

		public List<ApplicantSkillPoco> GetAllApplicantSkill()
		{
			return _sLogic.GetAll();
		}

		public List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory()
		{
			return _wLogic.GetAll();
		}

		public ApplicantJobApplicationPoco GetSingleApplicantJobApplication(string Id)
		{
			return _jLogic.Get(Guid.Parse(Id));
		}

		public ApplicantProfilePoco GetSingleApplicantProfile(string Id)
		{
			return _pLogic.Get(Guid.Parse(Id));
		}

		public ApplicantResumePoco GetSingleApplicantResume(string Id)
		{
			return _rLogic.Get(Guid.Parse(Id));
		}

		public ApplicantSkillPoco GetSingleApplicantSkill(string Id)
		{
			return _sLogic.Get(Guid.Parse(Id));
		}

		public ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(string Id)
		{
			return _wLogic.Get(Guid.Parse(Id));
		}

		public ApplicantEducationPoco GetSingleApplicantEducation(string Id)
		{
			return _logic.Get(Guid.Parse(Id));
		}

		public void RemoveApplicantEducation(ApplicantEducationPoco[] item)
		{
			_logic.Delete(item);
		}

		public void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] item)
		{
			_jLogic.Delete(item);
		}

		public void RemoveApplicantProfile(ApplicantProfilePoco[] item)
		{
			_pLogic.Delete(item);
		}

		public void RemoveApplicantResume(ApplicantResumePoco[] item)
		{
			_rLogic.Delete(item);
		}

		public void RemoveApplicantSkill(ApplicantSkillPoco[] item)
		{
			_sLogic.Delete(item);
		}

		public void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] item)
		{
			_wLogic.Delete(item);
		}

		public void UpdateApplicantEducation(ApplicantEducationPoco[] items)
		{
			_logic.Update(items);
		}

		public void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] items)
		{
			_jLogic.Update(items);
		}

		public void UpdateApplicantProfile(ApplicantProfilePoco[] items)
		{
			_pLogic.Update(items);
		}

		public void UpdateApplicantResume(ApplicantResumePoco[] items)
		{
			_rLogic.Update(items);
		}

		public void UpdateApplicantSkill(ApplicantSkillPoco[] items)
		{
			_sLogic.Update(items);
		}

		public void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] items)
		{
			_wLogic.Update(items);
		}
	}
}
