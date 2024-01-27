using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> itemList;
    public float counter = 0;

    private int lastItemID = -1;

    private void Start()
    {
        foreach (Transform tr in this.GetComponentsInChildren<Transform>())
        {
            if(tr.tag == "Item") {
                itemList.Add(tr.gameObject);
                tr.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        counter = counter - Time.deltaTime;
        if (counter > 0) {
            counter = counter - Time.deltaTime;
        } else {
            counter = Random.Range(20, 30);
            int randomValue = Random.Range(0, itemList.Count);
            if (lastItemID != -1)
                itemList[lastItemID].SetActive(false);
            itemList[randomValue].SetActive(true);
            lastItemID = randomValue;
        }
    }
}
