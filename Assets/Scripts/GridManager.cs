using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public void creategrid()
    {
        for (int x = 0; x <= S_Data.width; x++)
        {
            GameObject borderBottom = Instantiate(S_Data.block) as GameObject;
            borderBottom.GetComponent<Transform>().position = new Vector3(x - S_Data.width / 2, -S_Data.height / 2, 0);

            GameObject borderTop = Instantiate(S_Data.block) as GameObject;
            borderTop.GetComponent<Transform>().position = new Vector3(x - S_Data.width / 2, S_Data.height - S_Data.height / 2, 0);
        }

        for (int y = 0; y <= S_Data.height; y++)
        {
            GameObject borderRight = Instantiate(S_Data.block) as GameObject;
            borderRight.GetComponent<Transform>().position = new Vector3(-S_Data.width / 2, y - S_Data.height / 2, 0);

            GameObject borderLeft = Instantiate(S_Data.block) as GameObject;
            borderLeft.GetComponent<Transform>().position = new Vector3(S_Data.width - S_Data.width / 2, y - S_Data.height / 2, 0);
        }
    }
}
