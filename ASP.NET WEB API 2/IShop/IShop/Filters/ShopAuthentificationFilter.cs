﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace IShop.Filters
{
    public class ShopAuthentificationFilter : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }
        public Task AuthenticateAsync(HttpAuthenticationContext context,
                            CancellationToken cancellationToken)
        {
            context.Principal = null;
            AuthenticationHeaderValue authentication = context.Request.Headers.Authorization;

            if (authentication != null && authentication.Scheme == "Basic")
            {

                string[] authData = Encoding.ASCII.GetString(Convert.FromBase64String(authentication.Parameter)).Split(':');
                string[] roles = new string[] { "user" };
                string login = authData[0];
                context.Principal = new GenericPrincipal(new GenericIdentity(login), roles);
            }
            if (context.Principal == null)
            {
                context.ErrorResult
                = new UnauthorizedResult(new AuthenticationHeaderValue[] {
                    new AuthenticationHeaderValue("Basic") }, context.Request);
            }
            return Task.FromResult<object>(null);
        }
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context,
                                    CancellationToken cancellationToken)
        {
            return Task.FromResult<object>(null);
        }
    }
}