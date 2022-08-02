using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Data : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private GameObject _block;

    public static int width, height;
    public static GameObject block;
    public static bool isFruitCollect;
    public static GameObject fruitBlock;

    private Snake _snake;
    private Fruit _fruit;
    private GridManager _grid;

    // Start is called before the first frame update
    void Start()
    {
        width = _width;
        height = _height;
        block = _block;

        _grid = GameObject.Find("Script").GetComponent<GridManager>();
        _snake = GameObject.Find("Script").GetComponent<Snake>();
        _fruit = GameObject.Find("Script").GetComponent<Fruit>();

        _grid.creategrid();
        _snake.createPlayer();
        _fruit.spawnFruit();
        _block.SetActive(false);
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
