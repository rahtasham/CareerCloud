using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
	[RoutePrefix("api/careercloud/applicant/v1")]
	public class ApplicantSkillController : ApiController
    {
		private ApplicantSkillLogic _logic;

		public ApplicantSkillController()
		{
			EFGenericRepository<ApplicantSkillPoco> repo =
				new EFGenericRepository<ApplicantSkillPoco>(false);

			_logic = new ApplicantSkillLogic(repo);
		}

		[HttpGet]
		[Route("skill/{applicantSkillId}")]
		[ResponseType(typeof(ApplicantSkillPoco))]

		public IHttpActionResult GetApplicantSkill(Guid applicantSkillId)
		{
			try
			{
				ApplicantSkillPoco poco = _logic.Get(applicantSkillId);
				if (poco == null)
				{
					return NotFound();
				}

				return Ok(poco);
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}
		}

		[HttpGet]
		[Route("skill")]
		[ResponseType(typeof(List<ApplicantSkillPoco>))]
		public IHttpActionResult GetAllApplicantSkill()
		{
			try
			{
				List<ApplicantSkillPoco> pocos = _logic.GetAll();
				if (pocos == null)
				{
					return NotFound();
				}

				return Ok(pocos);
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}
		}

		[HttpPost]
		[Route("skill")]
		public IHttpActionResult PostApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
		{
			try
			{
				_logic.Add(pocos);
				return Ok();
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}

		}

		[HttpPut]
		[Route("skill")]
		public IHttpActionResult PutApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
		{
			try
			{
				_logic.Update(pocos);
				return Ok();
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}

		}

		[HttpDelete]
		[Route("skill")]
		public IHttpActionResult DeleteApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
		{
			try
			{
				_logic.Delete(pocos);
				return Ok();
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}

		}
	}
}
