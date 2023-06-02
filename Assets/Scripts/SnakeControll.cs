using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeControll : MonoBehaviour
{
    //public Transform[] Body;

    public List<GameObject> Body2;

    public GameObject BodyGameobject, Map, Menu;

    public int VerticalId, HorizontalId;

    public float TimerAutoMoving = 0;

    public bool AddBody = false, IsDead = false, IsPause = false;

    public int BorderX, BorderY;

    
    //0 Это право, 1 это лево, 2 это вверх, 3 это вниз
    public bool[] MovingBool = new bool[4];
    //public Transform newtransform;

    //Перевменная для определения дистанции
    public float distanse;

    public int ii = 0;

    private void Awake()
    {
        Application.targetFrameRate = 120;
        Time.timeScale = 1;
        Pause(true);
    }


    //1 Вправо, 2 Влево, 3 Вверх, 4 Вниз
    public void Move(int side)
    {
        if (IsDead || IsPause) return;

        if (side == 1 && !MovingBool[1] && !MovingBool[0])
        {
            if (HorizontalId < 0 || HorizontalId > BorderX)
            {
                Dead();
            }

            transform.rotation = Quaternion.Euler(transform.rotation.x, -90, transform.rotation.x);

            MovingNull();
            MovingBool[0] = true;
            HorizontalId++;
            MovingBody();
            Moving();
            TimerAutoMoving = 0;
        }
        if (side == 2 && !MovingBool[1] && !MovingBool[0])
        {
            if (HorizontalId < 0 || HorizontalId > BorderX)
            {
                Dead();
            }

            transform.rotation = Quaternion.Euler(transform.rotation.x, 90, transform.rotation.x);

            MovingNull();
            MovingBool[1] = true;
            HorizontalId--;
            MovingBody();
            Moving();
            TimerAutoMoving = 0;
        }
        if (side == 3 && !MovingBool[2] && !MovingBool[3])
        {
            if (VerticalId < 0 || VerticalId > BorderY)
            {
                Dead();
            }

            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.x);

            MovingNull();
            MovingBool[2] = true;
            VerticalId--;
            MovingBody();
            Moving();
            TimerAutoMoving = 0;
        }
        if (side == 4 && !MovingBool[2] && !MovingBool[3])
        {
            if (VerticalId < 0 || VerticalId > BorderY)
            {
                Dead();
            }

            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.x);

            MovingNull();
            MovingBool[3] = true;
            VerticalId++;
            MovingBody();
            Moving();
            TimerAutoMoving = 0;
        }
    }
    public Transform HeadSnake;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(IsPause) Pause(false);
            else Pause(true);
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            Move(1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(2);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(3);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Move(4);
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //newtransform.position = transform.position;
        //    Instantiate(BodyGameobject);
        //    //Body2.Add((GameObject)FindObjectOfType(typeof(GameObject)));
        //}
        if (Input.GetKeyDown(KeyCode.V))
        {
            MovingAuto();
        }
        if(TimerAutoMoving >= 0.5f)
        {
            MovingAuto();
            TimerAutoMoving = 0;
        }

        TimerAutoMoving += Time.deltaTime;

        if (HorizontalId < 0 || HorizontalId > BorderX)
        {
            Dead();
        }
        if (VerticalId < 0 || VerticalId > BorderY)
        {
            Dead();
        }
    }

    public void Moving()
    {
        HeadSnake.position = new Vector3(HorizontalId * distanse, HeadSnake.position.y, VerticalId * -1 * distanse);
    }

    public void MovingAuto()
    {
        if (IsDead || IsPause) return;

        MovingBody();

        if (MovingBool[0])
        {
            HorizontalId++;
            HeadSnake.position = new Vector3(HorizontalId * distanse, HeadSnake.position.y, VerticalId * -1 * distanse);
        }

        if (MovingBool[1])
        {
            HorizontalId--;
            HeadSnake.position = new Vector3(HorizontalId * distanse, HeadSnake.position.y, VerticalId * -1 * distanse);
        }

        if (MovingBool[2])
        {
            VerticalId--;
            HeadSnake.position = new Vector3(HorizontalId * distanse, HeadSnake.position.y, VerticalId * -1 * distanse);
        }

        if (MovingBool[3])
        {
            VerticalId++;
            HeadSnake.position = new Vector3(HorizontalId * distanse, HeadSnake.position.y, VerticalId * -1 * distanse);
        }

        if (HorizontalId < 0 || HorizontalId > BorderX)
        {
            Dead();
        }
        if (VerticalId < 0 || VerticalId > BorderY)
        {
            Dead();
        }
    }

    public void MovingNull()
    {
        for(int i = 0; i < 4; i++)
        {
            MovingBool[i] = false;
        }
    }
    public void MovingBody()
    {
        for (int i = Body2.Count - 1; i >= 0; i--)
        {
            if(i == 0)
            {
                Body2[i].transform.position = HeadSnake.position;

            }
            else
            {
                Body2[i].transform.position = Body2[i-1].transform.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Apple")
        {
            Instantiate(BodyGameobject, Map.transform);
            AddBody = true;
        }
        if (other.tag == "Player")
        {
            if (!AddBody) Dead();
            else AddBody = false;
        }
    }

    public void Dead()
    {
        IsDead = true;
        Time.timeScale = 0;
        Menu.SetActive(true);
    }

    public void Pause(bool pause)
    {
        IsPause = pause;
    }

    public void BotomPause()
    {
        if (IsPause) IsPause = false;
        else IsPause = true;
    }
}