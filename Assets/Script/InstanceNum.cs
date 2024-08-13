using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InstanceNum : MonoBehaviour
{
    public float nextSpawn = 1f;
    public Transform prefabToSpawn;
    //public GameObject Area;
    public static int speedInstance;
    void Update()
    {

        if (Time.time > nextSpawn)
        {
            speedInstance++;
            var oo = Instantiate(prefabToSpawn,Vector3.up* Time.deltaTime, Quaternion.identity);
            float T;
            T=0.1f;
            nextSpawn = Time.time + T;
            print("Object :" + speedInstance);
            Destroy(oo.gameObject, 0.2f);
        }
    }
}
