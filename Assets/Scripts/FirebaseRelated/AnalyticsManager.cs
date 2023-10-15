using Firebase.Analytics;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticsManager
{
    public AnalyticsManager() => SetUserID();

    public void ReportEvent(DPEventType eventType) => ReportEvent(eventType, new Dictionary<DPDataKeys, object>());

    public void ReportEvent(DPEventType eventType, Dictionary<DPDataKeys, object> data)
    {
        var paramsData = new List<Parameter>();

        foreach (var keyVal in data)
        {
            if (keyVal.Value == null)
            {
                continue;
            }

            var objType = keyVal.Value.GetType();

            var keyName = keyVal.Key.ToString();
            if (objType == typeof(string))
            {
                paramsData.Add(new Parameter(keyName, (string)keyVal.Value));
            }
            else if (objType == typeof(float))
            {
                paramsData.Add(new Parameter(keyName, (float)keyVal.Value));
            }
            else if (objType == typeof(int))
            {
                paramsData.Add(new Parameter(keyName, (int)keyVal.Value));
            }
            else if (objType == typeof(bool))
            {
                paramsData.Add(new Parameter(keyName, (bool)keyVal.Value ? 1 : 0));
            }
        }

        FirebaseAnalytics.LogEvent(eventType.ToString(), paramsData.ToArray());
    }

    public void SetUserProperties(Dictionary<string, string> data)
    {
        foreach (var keyVal in data)
        {
            SetUserProperty(keyVal.Key, keyVal.Value);
        }
    }

    public void SetUserProperty(string key, string val) => FirebaseAnalytics.SetUserProperty(key, val);

    public void SetUserID() => FirebaseAnalytics.SetUserId(SystemInfo.deviceUniqueIdentifier);
}

public enum DPEventType
{
    app_loaded,
    drawing_saved,
    big_display,
    open_instegram,
    image_uploaded
}

public enum DPDataKeys
{
    type_id,
    upgrade_level,
    popup_type,
    product_id,
    product_receipt
}