using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    float span = 1.0f;
    float delta = 0.0f;
    int ratio = 2;
    float speed = -0.03f;

    public void SetParameter(float span, int ratio, float speed)
    {
        this.span  = span;
        this.ratio = ratio;
        this.speed = speed;
    }

    void Start()
    {
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta >= span) 
        {
            this.delta = 0.0f;

            GameObject Item;
            int dice = Random.Range(1, 11);
            
            if(dice <= ratio)
            {
                Item = Instantiate(bombPrefab);
            }
            else
            {
                Item = Instantiate(applePrefab) as GameObject;
            }
            float RandX = Random.Range(-1, 2);
            float RandZ = Random.Range(-1, 2);
            Item.transform.position = new Vector3(RandX, 4, RandZ);

            Item.GetComponent<ItemController>().dropSpeed = this.speed;
        }
        
    }
}
