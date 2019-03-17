﻿using CareerCloud.BusinessLogicLayer;
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
	public class CompanyJobEducationsController : ApiController
    {
		private CompanyJobEducationLogic _logic;

		public CompanyJobEducationsController()
		{
			EFGenericRepository<CompanyJobEducationPoco> repo =
				new EFGenericRepository<CompanyJobEducationPoco>(false);

			_logic = new CompanyJobEducationLogic(repo);
		}

		[HttpGet]
		[Route("jobEducation/{companyJobEducationId}")]
		[ResponseType(typeof(CompanyJobEducationPoco))]

		public IHttpActionResult GetCompanyJobEducation(Guid companyJobEducationId)
		{
			try
			{
				CompanyJobEducationPoco poco = _logic.Get(companyJobEducationId);
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
		[Route("jobEducation")]
		[ResponseType(typeof(List<CompanyJobEducationPoco>))]
		public IHttpActionResult GetAllCompanyJobEducation()
		{
			try
			{
				List<CompanyJobEducationPoco> pocos = _logic.GetAll();
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
		[Route("jobEducation")]
		public IHttpActionResult PostCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
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
		[Route("jobEducation")]
		public IHttpActionResult PutCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
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
		[Route("jobEducation")]
		public IHttpActionResult DeleteCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
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
