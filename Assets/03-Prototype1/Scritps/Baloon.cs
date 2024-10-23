using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{

    public GameObject BombPrefab;

    public GameObject BaloonPrefab;

    public float speed = 1f;


    public float leftAndRightEdge = 7f;



    public float chanceToChangeDirections = 1f;

    public float secondsBetweenBombDrops = 2f;




    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropBomb", 2f);
    }

    void DropBomb()
    {
        GameObject Bomb = Instantiate<GameObject>(BombPrefab);
        Bomb.transform.position = transform.position;
        Invoke("DropBomb", secondsBetweenBombDrops);

    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;


        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }




    }
    public void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

    }


}