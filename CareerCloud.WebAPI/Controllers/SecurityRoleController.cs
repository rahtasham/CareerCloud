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
	[RoutePrefix("api/careercloud/security/v1")]
	public class SecurityRoleController : ApiController
    {
		private SecurityRoleLogic _logic;

		public SecurityRoleController()
		{
			EFGenericRepository<SecurityRolePoco> repo =
				new EFGenericRepository<SecurityRolePoco>(false);

			_logic = new SecurityRoleLogic(repo);
		}

		[HttpGet]
		[Route("role/{securityRoleId}")]
		[ResponseType(typeof(SecurityRolePoco))]

		public IHttpActionResult GetSecurityRole(Guid securityRoleId)
		{
			try
			{
				SecurityRolePoco poco = _logic.Get(securityRoleId);
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
		[Route("role")]
		[ResponseType(typeof(List<SecurityRolePoco>))]
		public IHttpActionResult GetAllSecurityRole()
		{
			try
			{
				List<SecurityRolePoco> pocos = _logic.GetAll();
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
		[Route("role")]
		public IHttpActionResult PostSecurityRole([FromBody] SecurityRolePoco[] pocos)
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
		[Route("role")]
		public IHttpActionResult PutSecurityRole([FromBody] SecurityRolePoco[] pocos)
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
		[Route("role")]
		public IHttpActionResult DeleteSecurityRole([FromBody] SecurityRolePoco[] pocos)
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
