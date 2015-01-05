using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Users.Infrastructure
{
    public class CustomPasswordValidator : PasswordValidator
    {
        public override async Task<IdentityResult> ValidateAsync(string pass)
        {
            var result = await base.ValidateAsync(pass);

            if (!pass.Contains("12345")) return result;
            var errors = result.Errors.ToList();
            errors.Add("Password cannot contain numeric sequences");
            result = new IdentityResult(errors);

            return result;
        }
    }
}
