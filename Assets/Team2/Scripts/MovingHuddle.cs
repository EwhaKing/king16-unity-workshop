using UnityEngine;

public class MovingHuddle : MonoBehaviour
{
    bool isMove;
    public float dist;
    public float velocity;
    Vector3 StartPos;
    Vector3 MoveDist;
    Collider2D col;

    void Start()
    {
        col= GetComponent<Collider2D>();
        isMove = false;
    }

    void Update()
    {
        if (isMove)
        {
            MoveDist += new Vector3(1, 0, 0) * Time.deltaTime * velocity;
            transform.position = StartPos + MoveDist;
            if(MoveDist.x > dist)
            {
                isMove = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Move");
            Move();
            col.enabled = false;
        }
    }

    void Move()
    {
        isMove = true;
        StartPos = transform.position;
        MoveDist = Vector3.zero;
    }
}


