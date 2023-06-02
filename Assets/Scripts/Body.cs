using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public SnakeControll snakeControll;
    void Start()
    {
        snakeControll = (SnakeControll)FindObjectOfType(typeof(SnakeControll));
        snakeControll.Body2.Add(gameObject);
        transform.position = snakeControll.transform.position;
    }
}
