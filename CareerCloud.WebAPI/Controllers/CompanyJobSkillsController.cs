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
	[RoutePrefix("api/careercloud/company/v1")]
	public class CompanyJobSkillsController : ApiController
    {
		private CompanyJobSkillLogic _logic;

		public CompanyJobSkillsController()
		{
			EFGenericRepository<CompanyJobSkillPoco> repo =
				new EFGenericRepository<CompanyJobSkillPoco>(false);

			_logic = new CompanyJobSkillLogic(repo);
		}

		[HttpGet]
		[Route("jobSkill/{companyJobSkillId}")]
		[ResponseType(typeof(CompanyJobSkillPoco))]

		public IHttpActionResult GetCompanyJobSkill(Guid companyJobSkillId)
		{
			try
			{
				CompanyJobSkillPoco poco = _logic.Get(companyJobSkillId);
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
		[Route("jobSkill")]
		[ResponseType(typeof(List<CompanyJobSkillPoco>))]
		public IHttpActionResult GetAllCompanyJobSkill()
		{
			try
			{
				List<CompanyJobSkillPoco> pocos = _logic.GetAll();
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
		[Route("jobSkill")]
		public IHttpActionResult PostCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
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
		[Route("jobSkill")]
		public IHttpActionResult PutCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
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
		[Route("jobSkill")]
		public IHttpActionResult DeleteCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
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
