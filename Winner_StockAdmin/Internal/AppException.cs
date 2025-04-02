// Decompiled with JetBrains decompiler
// Type: stockadmin.Internal.AppException
// Assembly: stockadmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B21E37CA-2ACE-4FF0-82F8-CD0EB9EBDE3F
// Assembly location: /Users/tunghaotu/Documents/Projects/Winner Finance Service/anfin 2/service/stockadmin/stockadmin.dll

using stockadmin.Libs;
using System;

#nullable enable
namespace stockadmin.Internal
{
    public class AppException : Exception
    {
        private int _status;
        private string _messageKey;

        public AppException(string message)
            : base(message)
        {
            this._messageKey = message;
        }

        public AppException(int errorCode, string message)
            : base(message)
        {
            this._status = errorCode;
            this._messageKey = message;
        }

        public int GetStatus() => this._status;

        public string GetMessage(string language)
        {
            return LanguageLib.GetErrorTranslate(language, this._messageKey);
        }
    }
}