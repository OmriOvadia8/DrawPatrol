using UnityEngine;

public class FirebaseManager : MonoBehaviour
{
    public static FirebaseManager Instance { get; private set; }
    public CrashManager CrashManager;
    public AnalyticsManager AnalyticsManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            CrashManager = new CrashManager();
            AnalyticsManager = new AnalyticsManager();

            Debug.Log("Firebase Initialized");
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start() => AnalyticsManager.ReportEvent(DPEventType.app_loaded);
}
