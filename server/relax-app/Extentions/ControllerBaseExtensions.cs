using DataService.Commons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace relax_app.Extentions
{
    public static class ControllerBaseExtensions
    {
        public static int GetUserId(this ControllerBase controller)
        {
            var identity = (ClaimsIdentity)controller.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            return int.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
        }
    }
}
