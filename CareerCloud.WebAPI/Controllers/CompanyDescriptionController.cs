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
	public class CompanyDescriptionController : ApiController
    {
		private CompanyDescriptionLogic _logic;

		public CompanyDescriptionController()
		{
			EFGenericRepository<CompanyDescriptionPoco> repo =
				new EFGenericRepository<CompanyDescriptionPoco>(false);

			_logic = new CompanyDescriptionLogic(repo);
		}

		[HttpGet]
		[Route("description/{companyDescriptionId}")]
		[ResponseType(typeof(CompanyDescriptionPoco))]

		public IHttpActionResult GetCompanyDescription(Guid companyDescriptionId)
		{
			try
			{
				CompanyDescriptionPoco poco = _logic.Get(companyDescriptionId);
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
		[Route("description")]
		[ResponseType(typeof(List<CompanyDescriptionPoco>))]
		public IHttpActionResult GetAllCompanyDescription()
		{
			try
			{
				List<CompanyDescriptionPoco> pocos = _logic.GetAll();
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
		[Route("description")]
		public IHttpActionResult PostCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
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
		[Route("description")]
		public IHttpActionResult PutCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
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
		[Route("description")]
		public IHttpActionResult DeleteCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
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
