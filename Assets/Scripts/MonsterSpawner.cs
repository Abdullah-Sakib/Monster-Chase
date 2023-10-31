using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterRefrences;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform LeftPos, RightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterRefrences.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterRefrences[randomIndex]);

            if (randomSide == 0)
            {
                // left side
                spawnedMonster.transform.position = LeftPos.transform.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(2, 5);
            }
            else
            {
                // right side
                spawnedMonster.transform.position = RightPos.transform.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(2, 5);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
