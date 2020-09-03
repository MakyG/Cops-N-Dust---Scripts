using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    public GameObject barObject, barBackground, lockImage;
    public float scoreNeeded = 1; 
    public float highScore;
    public float traveledDistance;
    public static int carSelected = 1;
    public Text requiredText;
    public int preferedMethod = 1;
    void Start()
    {
        PlayerPrefs.SetInt("CarSelected", 1);
        highScore = PlayerPrefs.GetFloat("HighScore");
        traveledDistance = PlayerPrefs.GetFloat("ScoreTotal");
    }

    void Update()
    {
        if (preferedMethod == 1) // REACH
        {
            requiredText.text = "Reach " + scoreNeeded + " m";

            if (highScore < scoreNeeded)
            {
                Transform bar = barObject.transform;
                bar.localScale = new Vector3((highScore / scoreNeeded), 1f);
            }
            else
            {
                lockImage.SetActive(false);
                barBackground.SetActive(false);
                barObject.SetActive(false);
            }
        }
        if (preferedMethod == 2) // TRAVEL
        {
            requiredText.text = "Travel " + scoreNeeded + " m";

            if (traveledDistance < scoreNeeded)
            {
                Transform bar = barObject.transform;
                bar.localScale = new Vector3((traveledDistance / scoreNeeded), 1f);
            }
            else
            {
                lockImage.SetActive(false);
                barBackground.SetActive(false);
                barObject.SetActive(false);
            }
        }
    }

    public void ChooseCar1()
    {
        carSelected = 1;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar2()
    {
        carSelected = 2;
        PlayerPrefs.SetInt("CarSelected", carSelected);

    }
    public void ChooseCar3()
    {
        carSelected = 3;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar4()
    {
        carSelected = 4;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar5()
    {
        carSelected = 5;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar6()
    {
        carSelected = 6;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar7()
    {
        carSelected = 7;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar8()
    {
        carSelected = 8;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar9()
    {
        carSelected = 9;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar10()
    {
        carSelected = 10;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar11()
    {
        carSelected = 11;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar12()
    {
        carSelected = 12;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar13()
    {
        carSelected = 13;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar14()
    {
        carSelected = 14;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar15()
    {
        carSelected = 15;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar16()
    {
        carSelected = 16;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar17()
    {
        carSelected = 17;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar18()
    {
        carSelected = 18;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar19() // TANK
    {
        carSelected = 19;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar20()
    {
        carSelected = 20;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar21()
    {
        carSelected = 21;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar22()
    {
        carSelected = 22;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar23()
    {
        carSelected = 23;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar24()
    {
        carSelected = 24;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar25()
    {
        carSelected = 25;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar26()
    {
        carSelected = 26;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar27()
    {
        carSelected = 27;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar28()
    {
        carSelected = 28;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar29()
    {
        carSelected = 29;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar30()
    {
        carSelected = 30;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
    public void ChooseCar31()
    {
        carSelected = 31;
        PlayerPrefs.SetInt("CarSelected", carSelected);
    }
}
 