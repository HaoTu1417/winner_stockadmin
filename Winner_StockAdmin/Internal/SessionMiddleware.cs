// Decompiled with JetBrains decompiler
// Type: stockadmin.Internal.SessionMiddleware
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable
namespace stockadmin.Internal
{
    public class SessionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!this.IsExclude((string) context.Request.Path) && string.IsNullOrEmpty(context.Session.GetString("token")))
                context.Response.Redirect("~/Login/Index");
            await next(context);
        }

        private bool IsExclude(string path)
        {
            path = path.ToLower();
            return new List<string>()
            {
                "/",
                "/login/index",
                "/Login/SignIn",
                "/Login/ChangePasswd",
                "/Login/PostChangePasswd",
                "/Login/MfaVerification"
            }.Exists((Predicate<string>) (t => t.ToLower() == path));
        }
    }
}