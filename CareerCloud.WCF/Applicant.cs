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

		public void AddApplicantProfiles(ApplicantProfilePoco[] item)
		{
			_pLogic.Add(item);
		}

		public void AddApplicantResume(ApplicantResumePoco[] item)
		{
			_rLogic.Add(item);
		}

		public void AddApplicantSkills(ApplicantSkillPoco[] item)
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

		public List<ApplicantProfilePoco> GetAllApplicantProfiles()
		{
			return _pLogic.GetAll();
		}

		public List<ApplicantResumePoco> GetAllApplicantResume()
		{
			return _rLogic.GetAll();
		}

		public List<ApplicantSkillPoco> GetAllApplicantSkills()
		{
			return _sLogic.GetAll();
		}

		public List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory()
		{
			return _wLogic.GetAll();
		}

		public ApplicantJobApplicationPoco GetSingleApplicantJobApplication(Guid Id)
		{
			return _jLogic.Get(Id);
		}

		public ApplicantProfilePoco GetSingleApplicantProfiles(Guid Id)
		{
			return _pLogic.Get(Id);
		}

		public ApplicantResumePoco GetSingleApplicantResume(Guid Id)
		{
			return _rLogic.Get(Id);
		}

		public ApplicantSkillPoco GetSingleApplicantSkills(Guid Id)
		{
			return _sLogic.Get(Id);
		}

		public ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(Guid Id)
		{
			return _wLogic.Get(Id);
		}

		public ApplicantEducationPoco GetSingleAppplicantEducation(Guid Id)
		{
			return _logic.Get(Id);
		}

		public void RemoveApplicantEducation(ApplicantEducationPoco[] item)
		{
			_logic.Delete(item);
		}

		public void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] item)
		{
			_jLogic.Delete(item);
		}

		public void RemoveApplicantProfiles(ApplicantProfilePoco[] item)
		{
			_pLogic.Delete(item);
		}

		public void RemoveApplicantResume(ApplicantResumePoco[] item)
		{
			_rLogic.Delete(item);
		}

		public void RemoveApplicantSkills(ApplicantSkillPoco[] item)
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

		public void UpdateApplicantProfiles(ApplicantProfilePoco[] items)
		{
			_pLogic.Update(items);
		}

		public void UpdateApplicantResume(ApplicantResumePoco[] items)
		{
			_rLogic.Update(items);
		}

		public void UpdateApplicantSkills(ApplicantSkillPoco[] items)
		{
			_sLogic.Update(items);
		}

		public void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] items)
		{
			_wLogic.Update(items);
		}
	}
}
