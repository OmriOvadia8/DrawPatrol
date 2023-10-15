using Firebase.Crashlytics;
using System;
using UnityEngine;

public class CrashManager
{
    public CrashManager()
    {
        Debug.Log($"DBCrashManager");

        Crashlytics.ReportUncaughtExceptionsAsFatal = true;
    }

    public void LogExceptionHandling(Exception exception)
    {
        Crashlytics.LogException(exception);
        Debug.LogException(exception);
    }

    public void LogBreadcrumb(string message)
    {
        Crashlytics.Log(message);
        Debug.Log(message);
    }
}