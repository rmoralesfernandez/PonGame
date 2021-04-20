using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketAI : MonoBehaviour
{
    public GameObject ball;
    public GameObject racket;
    float vel = 0.001f;
    public int hits = 0;
    public int randNum;
    public Ball score;
    public int leftScore = 0;
    public int rigthScore = 0;

    private void Start()
    {
        randNum = Random.Range(3, 8);
    }

    void FixedUpdate()
    {
        //float v = Input.GetAxisRaw("Vertical2");
        //GetComponent<Rigidbody2D>().velocity = new Vector2(0, v * vel);

        
        if(hits < randNum)
        {
            int x = -50;
            float y = ball.transform.position.y;

            racket.transform.position = new Vector2(x, y);
            //Vector2 direction = new Vector2(x, y);
            //GetComponent<Rigidbody2D>().velocity = direction * vel;
        } else
        {
            int x = -50;
            float y = ball.transform.position.y;

            //racket.transform.position = new Vector2(x, y - 5);
            Vector2 direction = new Vector2(x, y);
            GetComponent<Rigidbody2D>().velocity = direction * vel;
        }

        if(leftScore != score.leftGoals)
        {
            randNum = Random.Range(3, 8);
            hits = 0;
            leftScore = score.leftGoals;
        } else if(rigthScore != score.rigthGoals)
        {
            randNum = Random.Range(3, 8);
            hits = 0;
            rigthScore = score.rigthGoals;
        }
    }

    void OnCollisionEnter2D(Collision2D myCollision)
    {
        if (myCollision.gameObject.name == "Ball")
        {
            hits++;
        }
    }
}
