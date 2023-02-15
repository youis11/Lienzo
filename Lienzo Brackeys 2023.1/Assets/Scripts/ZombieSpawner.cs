using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    private int waveNumber = 0;
    public int enemiesAmount = 0;
    public GameObject zombie;
    private Camera cam;
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        enemiesAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float height = cam.orthographicSize + 1; // now they spawn just outside
        float width = cam.orthographicSize * cam.aspect + 1;
        if (enemiesAmount == 0)
        {
            //NEW WAVE SOUND
            waveNumber = waveNumber + 1;
            for (int i = 0; i < waveNumber; i++)
            {
                Instantiate(zombie, new Vector3(cam.transform.position.x + Random.Range(-width, width), Random.Range(-height,height), 0), Quaternion.identity);
                enemiesAmount = enemiesAmount + 1;
            }
        }
    }
}
