using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdControl : MonoBehaviour
{
    public GameObject LockImage;
    public GameObject AdButton;
    bool tankUnlocked = false;
    public void AdTank()
    {
        tankUnlocked = true;
        PlayerPrefs.SetInt("tankUnlocked", 1);
        LockImage.SetActive(false);
        AdButton.SetActive(false);
    }
    public void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("tankUnlocked") == 1)
        {
            tankUnlocked = true;
        }
        if (tankUnlocked == true)
        {
            LockImage.SetActive(false);
            AdButton.SetActive(false);
        }
    }
}
