using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public int x = 5, z = 5;
    public float XRandom, ZRandom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            XRandom = Random.RandomRange(0, x) * 1.5f;
            ZRandom = Random.RandomRange(0, z) * 1.5f;
            transform.position = new Vector3(XRandom, transform.position.y, ZRandom * -1);
        }
    }
}
