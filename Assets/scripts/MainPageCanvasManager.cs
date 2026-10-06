using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MainPageCanvasManager : MonoBehaviour
{
    public GameObject MobileCanvas; // Assign your on-screen buttons in the Unity Inspector
    public GameObject mob_bg;
    public GameObject webCanvas; // Assign your on-screen buttons in the Unity Inspector
    public GameObject web_bg;


    void Start()
    {


        if (isMobile())
        {
            MobileCanvas.SetActive(true);
            webCanvas.SetActive(false);
            mob_bg.SetActive(true);
            web_bg.SetActive(false);

        }
        else
        {
            MobileCanvas.SetActive(false);
            webCanvas.SetActive(true);
            mob_bg.SetActive(false);
            web_bg.SetActive(true);
        }


    }
    #region WebGL is on mobile check
    [DllImport("__Internal")]
    private static extern bool IsMobile();

    public bool isMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        return IsMobile();
#endif

        return false;
    }

    #endregion
}
