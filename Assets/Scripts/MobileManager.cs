using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileManager : MonoBehaviour {

    private GameObject[] mobileOnly;

	// Use this for initialization
	void Start () {
        mobileOnly = GameObject.FindGameObjectsWithTag("MobileOnly");
        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            HideMobile();
        }
	}

    public void HideMobile()
    {
        foreach (GameObject g in mobileOnly)
        {
            g.SetActive(false);
        }
    }

    public void ShowMobile()
    {
        foreach (GameObject g in mobileOnly)
        {
            g.SetActive(true);
        }
    }
}
