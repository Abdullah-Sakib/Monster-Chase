using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReferences; // Array of different monster prefabs to spawn

    private GameObject spawnedMonster; // Reference to the currently spawned monster

    [SerializeField]
    private Transform leftPos, rightPos; // Left and right positions for spawning

    private int randomIndex; // Index for selecting a random monster from the array
    private int randomSide; // 0 for left, 1 for right

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {
        while (true)
        {
            // Wait for a random time interval before spawning the next monster
            yield return new WaitForSeconds(Random.Range(1, 5));

            // Choose a random monster from the array
            randomIndex = Random.Range(0, monsterReferences.Length);

            // Determine whether to spawn on the left or right side
            randomSide = Random.Range(0, 2);

            // Instantiate the selected monster
            spawnedMonster = Instantiate(monsterReferences[randomIndex]);

            if (randomSide == 0)
            {
                // Spawn on the left side
                spawnedMonster.transform.position = leftPos.position;
                // Set a random speed for the monster
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(2, 5);
            }
            else
            {
                // Spawn on the right side
                spawnedMonster.transform.position = rightPos.position;
                // Set a random negative speed for the monster to make it move left
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(2, 5);
                // Flip the monster's sprite to face left
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
