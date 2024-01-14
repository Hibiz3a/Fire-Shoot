using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Zm_Spawner : MonoBehaviour
{
    private int waveNumber = 0;
    public int ennemyAmmount = 0;

    public int ennemiesKilled = 0;
    [SerializeField]
    private GameObject[] spawners;

    [SerializeField]
    TextMeshProUGUI textWave;

    private int timer = 10;


    [SerializeField]
    private GameObject zombie;
    private void Start()
    {
        spawners = new GameObject[11];


        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }

        startWave();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    SpawnEnnemie();
        //}

        if (ennemiesKilled >= ennemyAmmount)
        {
            StartCoroutine(NextWave());

        }
        else
        {
            StopAllCoroutines();
        }
    }
    private void SpawnEnnemie()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        Instantiate(zombie, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
    }

    private void startWave()
    {
        waveNumber = 1;
        ennemyAmmount = 5;
        ennemiesKilled = 0;

        for (int i = 0; i < ennemyAmmount; i++)
        {
            SpawnEnnemie();
        }
        textWave.text = waveNumber.ToString();
    }

    public IEnumerator NextWave()
    {
        yield return new WaitForSeconds(timer);
        waveNumber++;
        ennemyAmmount += 2;
        ennemiesKilled = 0;
        for (int i = 0; i < ennemyAmmount; i++)
        {
            SpawnEnnemie();
        }
        textWave.text = waveNumber.ToString();
    }
}
