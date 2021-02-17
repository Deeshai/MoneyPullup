using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    void Start()
    {
        /*initializes Ad using Android Ad ID from Unity Dashboard*/
        Advertisement.Initialize("3086513", true);

        /*Plays Ad before*/
        StartCoroutine(ShowAdWhenReady());
        bool record = true;

        /*Checks if Ad has started, if the viewer watched the entire Ad, if the viewer has skipped the Ad and if the user 
           has clicked on the Ad */
        AnalyticsEvent.AdStart(record);
        AnalyticsEvent.AdSkip(record);
        AnalyticsEvent.AdComplete(record);
        AnalyticsEvent.PostAdAction(record);
        
    }

    /*Checsk if Ad is ready to show and plays when it is ready*/
    IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.IsReady())
            yield return null;

        Advertisement.Show();
    }
}
 
 