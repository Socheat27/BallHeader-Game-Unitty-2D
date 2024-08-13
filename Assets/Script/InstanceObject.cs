using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static ControllPlayer;

public class InstanceObject : MonoBehaviour
{
    public float nextSpawn = 1f; 
    public Transform[] prefabToSpawn;
    public GameObject Area;
    public Transform left_position, right_position;
    public static int speedInstance;

    void Update()
    {
        if (IsOVer)
        {
            if (Time.time > nextSpawn)
            {
                speedInstance++;
                int TypeEnem = Random.Range(0, prefabToSpawn.Length);
                var oo = Instantiate(prefabToSpawn[TypeEnem], GetRandomPositionInArea(), Quaternion.identity);
                float T;
                T = Random.Range(3f, 5f);
                nextSpawn = Time.time + T;
                print("Object :" + speedInstance);
                IsOVer = false;
                
            }

        }
    }
    Vector3 GetRandomPositionInArea()
    {
        Vector3 areaPosition = Area.transform.position;
        float areaWidth = Area.transform.localScale.x;
        float minX = areaPosition.x - (areaWidth / 2);
        float maxX = areaPosition.x + (areaWidth / 2);
        float randomX = Random.Range(minX, maxX);
        float xPos = Random.Range(left_position.position.x, right_position.position.x);
        return new Vector3(xPos, transform.position.y, transform.position.z);  

    }
}
