using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    public GameObject myPrefab;
    public bool check;
    void Start()
    {
        float pX = -7.5f, pY = -1.5f, diff = 0;
        for(int i = 0; i < 7; i++, pX += 3)
        {
            do
            {
                diff = Random.Range(-2.5f, 2.5f);
            } while (pY + diff > 1.5f || pY + diff < -5.5f);
            pY += diff;
            Vector3 position = new Vector3(pX, pY, 0);
            GameObject grassClone = Instantiate(myPrefab, position, Quaternion.identity);
            CoinGenerator.instance.GenerateCoin(pX, pY);
        }
    }
}
