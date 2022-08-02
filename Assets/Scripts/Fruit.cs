using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public static GameObject fruit;
    private Snake other;

    private Vector2 getRandomPosition()
    {
        return new Vector2(Random.Range(-S_Data.width / 2 + 1, S_Data.width / 2), Random.Range(-S_Data.height / 2 + 1, S_Data.height / 2));
    }

    public void spawnFruit()
    {
        Vector2 spawnPosition = getRandomPosition();
        other = GameObject.Find("Script").GetComponent<Snake>();
        while (other.cotainedInSnake(spawnPosition))
        {
            spawnPosition = getRandomPosition();
        }
        fruit = Instantiate(S_Data.block);
        fruit.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, 0);
        fruit.SetActive(true);
    }

    private void destoryFruit()
    {
        S_Data.isFruitCollect = false;
        DestroyImmediate(fruit);
        spawnFruit();
    }

    void Update()
    {
        if (S_Data.isFruitCollect)
        {
            destoryFruit();
        }
    }
}
