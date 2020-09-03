using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    [SerializeField]
    private int scoreMilestone = 600;
    [SerializeField]
    private int milestoneIncreaser = 600;
    [SerializeField]
    private Transform[] spawnPos;
    [SerializeField]
    private int policeCarRequired;

    private int currentPoliceCar;
    private GameObject target;

    public int CurrentPoliceCar { get { return currentPoliceCar; } set { currentPoliceCar = value; } }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    void Update()
    {
        if(GuiManager.instance.GameStarted == false || GuiManager.instance.GameOver == true)
        {
            return;
        }
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        MilestoneIncreaser();

        if(currentPoliceCar < policeCarRequired)
        {
            spawnPoliceCar();
        }


    }



    void spawnPoliceCar()
    {
        GameObject policeCar = ObjectPooling.instance.GetPooledObject("PoliceCar");
        int r = Random.Range(0, spawnPos.Length);
        currentPoliceCar++;
        policeCar.transform.position = new Vector3(spawnPos[r].position.x, 0, spawnPos[r].position.z);
        policeCar.SetActive(true);
        policeCar.GetComponent<Damage>().DefaultSetting();
        

    }
    void MilestoneIncreaser()
    {
        if (GuiManager.instance.Score >= scoreMilestone)
        {
            scoreMilestone += milestoneIncreaser;
            policeCarRequired++;
        }
    }

}
