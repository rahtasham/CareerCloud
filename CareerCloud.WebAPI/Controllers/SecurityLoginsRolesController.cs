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
	public class SecurityLoginsRolesController : ApiController
    {
		private SecurityLoginsRoleLogic _logic;

		public SecurityLoginsRolesController()
		{
			EFGenericRepository<SecurityLoginsRolePoco> repo =
				new EFGenericRepository<SecurityLoginsRolePoco>(false);

			_logic = new SecurityLoginsRoleLogic(repo);
		}

		[HttpGet]
		[Route("loginsRole/{securityLoginsRoleId}")]
		[ResponseType(typeof(SecurityLoginsRolePoco))]

		public IHttpActionResult GetSecurityLoginsRole(Guid securityLoginsRoleId)
		{
			try
			{
				SecurityLoginsRolePoco poco = _logic.Get(securityLoginsRoleId);
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
		[Route("loginsRole")]
		[ResponseType(typeof(List<SecurityLoginsRolePoco>))]
		public IHttpActionResult GetAllSecurityLoginsRole()
		{
			try
			{
				List<SecurityLoginsRolePoco> pocos = _logic.GetAll();
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
		[Route("loginsRole")]
		public IHttpActionResult PostSecurityLoginsRole([FromBody] SecurityLoginsRolePoco[] pocos)
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
		[Route("loginsRole")]
		public IHttpActionResult PutSecurityLoginsRole([FromBody] SecurityLoginsRolePoco[] pocos)
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
		[Route("loginsRole")]
		public IHttpActionResult DeleteSecurityLoginsRole([FromBody] SecurityLoginsRolePoco[] pocos)
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
