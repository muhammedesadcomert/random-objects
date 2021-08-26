using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public static CoinGenerator instance;
    public GameObject Coin;
    void Start()
    {
        if (instance == null)
            instance = this;
    }
    public void GenerateCoin(float pX, float pY)
    {
        bool trueFalse;
        for (int i = 0, j = -1, k = 1; i < 6; i++, j++)
        {
            trueFalse = Random.value > 0.5f;
            if(trueFalse)
            {
                Vector3 position = new Vector3(pX + j, pY + k, 0);
                GameObject coinClone = Instantiate(Coin, position, Quaternion.identity);
            }
            if (i == 2)
            {
                j = -1;
                k++;
            }
        }
    }
}
