using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

public class SessionManager : IRequiresSessionState
{

    public static void SetSessionValue(string Key, object Value)
    {
        HttpContext.Current.Session[Key] = Value;
    }

    public static T GetSessionValue<T>(string Key)
    {
        T Value;

        if (HttpContext.Current.Session[Key] == null)
            Value = default(T);
        else
            Value = (T)HttpContext.Current.Session[Key];
        return Value;
    }

    public static bool IsArabic
    {

        get
        {
            //try
            // {
            var data = GetSessionValue<bool>("IsArabic");
            return GetSessionValue<bool>("IsArabic");
            //}
            // catch (Exception)
            // {
            //     return false;
            // }
        }
        set
        {
            SetSessionValue("IsArabic", value);
        }
    }
    public static bool IsTurkish
    {

        get
        {
            //try
            // {
            var data = GetSessionValue<bool>("IsTurkish");
            return GetSessionValue<bool>("IsTurkish");
            //}
            // catch (Exception)
            // {
            //     return false;
            // }
        }
        set
        {
            SetSessionValue("IsTurkish", value);
        }
    }
}
