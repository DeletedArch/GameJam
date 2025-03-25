using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] SpawnPoint;
    public GameObject Enemies;
    int randSpawn;
    public float SpawnRate = 1.0f;
    private void Start()
    {
        StartCoroutine(Spawner());
    }
    
    
    private IEnumerator Spawner()
    {
        WaitForSeconds wait= new WaitForSeconds(SpawnRate);
        while (true)
        {
            yield return wait;
            randSpawn = Random.Range(0, SpawnPoint.Length);
            Instantiate(Enemies, SpawnPoint[randSpawn].position, transform.rotation);
        }
    }
}
