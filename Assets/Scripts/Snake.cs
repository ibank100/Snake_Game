using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    GameObject head;
    public Material _head, _tail;
    List<GameObject> tail;

    Vector2 dir = Vector2.right;
    float passedTime;
    float timeBetweenMovements = 0.2f;
    bool isAlive = true;
    public Text points;

    public GameObject gameOverUI;

    public void createPlayer()
    {
        head = Instantiate(S_Data.block) as GameObject;
        head.GetComponent<MeshRenderer>().material = _head;
        tail = new List<GameObject>();
    }

    public bool cotainedInSnake(Vector2 spawnPos)
    {
        bool isInHead = spawnPos.x == head.transform.position.x && spawnPos.y == head.transform.position.y;
        bool isInTail = false;
        foreach (var item in tail)
        {
            if (item.transform.position.x == spawnPos.x && item.transform.position.y == spawnPos.y)
            {
                isInTail = true;
            }
        }
        return isInHead || isInTail;
    }

    private void gameOver()
    {
        isAlive = false;
        gameOverUI.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && dir.y != -1)
        {
            dir = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.A) && dir.x != 1)
        {
            dir = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.S) && dir.y != 1)
        {
            dir = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.D) && dir.x != -1)
        {
            dir = Vector2.right;
        }

        passedTime += Time.deltaTime;
        if (timeBetweenMovements < passedTime && isAlive)
        {
            passedTime = 0;

            Vector3 newPosition = head.GetComponent<Transform>().position + new Vector3(dir.x, dir.y, 0);

            if (newPosition.x >= S_Data.width / 2
            || newPosition.x <= -S_Data.width / 2
            || newPosition.y >= S_Data.height / 2
            || newPosition.y <= -S_Data.height / 2)
            {
                gameOver();
            }

            foreach (var item in tail)
            {
                if (item.transform.position == newPosition)
                {
                    gameOver();
                }
            }

            if (newPosition.x == Fruit.fruit.transform.position.x && newPosition.y == Fruit.fruit.transform.position.y)
            {
                GameObject newTile = Instantiate(S_Data.block);
                newTile.SetActive(true);
                newTile.transform.position = Fruit.fruit.transform.position;
                head.GetComponent<MeshRenderer>().material = _tail;
                tail.Add(head);
                head = newTile;
                head.GetComponent<MeshRenderer>().material = _head;
                S_Data.isFruitCollect = true;
                points.text = "Points: " + tail.Count;
            }
            else
            {

                if (tail.Count == 0)
                {
                    head.transform.position = newPosition;
                }
                else
                {
                    head.GetComponent<MeshRenderer>().material = _tail;
                    tail.Add(head);
                    head = tail[0];
                    head.GetComponent<MeshRenderer>().material = _head;
                    tail.RemoveAt(0);
                    head.transform.position = newPosition;
                }
            }
        }
    }
}
