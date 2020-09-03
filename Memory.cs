using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{
    public int carSelectedDebug;

    void Start()
    {
        if (gameObject != null)
        {
            switch (Selector.carSelected)
            {
                case 1:
                    Transistor.car1.SetActive(true);
                    break;
                case 2:
                    Transistor.car2.SetActive(true);
                    break;
                case 3:
                    Transistor.car3.SetActive(true);
                    break;
                case 4:
                    Transistor.car4.SetActive(true);
                    break;
                case 5:
                    Transistor.car5.SetActive(true);
                    break;
                case 6:
                    Transistor.car6.SetActive(true);
                    break;
                case 7:
                    Transistor.car7.SetActive(true);
                    break;
                case 8:
                    Transistor.car8.SetActive(true);
                    break;
                case 9:
                    Transistor.car9.SetActive(true);
                    break;
            }
        }
    }
    private void Update()
    {

        carSelectedDebug = Selector.carSelected;
    }
}
