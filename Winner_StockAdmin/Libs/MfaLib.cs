// Decompiled with JetBrains decompiler
// Type: stockadmin.Libs.MfaLib
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using System;
using System.Runtime.CompilerServices;
using TwoStepsAuthenticator;

#nullable enable
namespace stockadmin.Libs
{
    public static class MfaLib
    {
        public static readonly TimeAuthenticator authenticator = new TimeAuthenticator();

        public static string GenerateSecretKey() => Authenticator.GenerateKey();

        public static bool VerifyCode(string secret, string code, object? user = null)
        {
            return MfaLib.authenticator.CheckCode(secret, code, user, out DateTime _);
        }

        public static string GenerateUri(string label, string issuer, string secret)
        {
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 3);
            interpolatedStringHandler.AppendLiteral("otpauth://totp/");
            interpolatedStringHandler.AppendFormatted(label);
            interpolatedStringHandler.AppendLiteral("?issuer=");
            interpolatedStringHandler.AppendFormatted(issuer);
            interpolatedStringHandler.AppendLiteral("&secret=");
            interpolatedStringHandler.AppendFormatted(secret);
            return interpolatedStringHandler.ToStringAndClear();
        }
    }
}