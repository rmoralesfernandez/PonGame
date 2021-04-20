using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D ball)
    {
        if(ball.name == "Ball")
        {
            if(this.name == "Left")
            {
                ball.GetComponent<Ball>().resetBall("Rigth");
            } else if(this.name == "Rigth")
            {
                ball.GetComponent<Ball>().resetBall("Left");
            }
        }
    }
}
