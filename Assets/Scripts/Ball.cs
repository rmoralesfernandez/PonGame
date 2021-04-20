using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float vel = 30.0f;

    AudioSource aud;
    public AudioClip audioGol, audioRacket, audioRebound;

    public int leftGoals = 0;
    public int rigthGoals = 0;

    public Text leftCounter;
    public Text rigthCounter;
    public Text score;
    public Text timer;
    public Image backgroundScore;

    Scene scene;

    private string minutes, seconds;

    public float time = 180;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * vel;

        aud = GetComponent<AudioSource>();

        leftCounter.text = leftGoals.ToString();
        rigthCounter.text = rigthGoals.ToString();

        backgroundScore.enabled = false;
        score.enabled = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D myCollision)
    {
     if(myCollision.gameObject.name == "Left racket")
        {
            int x = 1;
            int y = directionY(transform.position, myCollision.transform.position);

            Vector2 direction = new Vector2(x, y);
            GetComponent<Rigidbody2D>().velocity = direction * vel;

            aud.clip = audioRacket;
            aud.Play();
        }

     if(myCollision.gameObject.name == "Rigth racket")
        {
            int x = -1;
            int y = directionY(transform.position, myCollision.transform.position);

            Vector2 direction = new Vector2(x, y);
            GetComponent<Rigidbody2D>().velocity = direction * vel;

            aud.clip = audioRacket;
            aud.Play();
        }

     if(myCollision.gameObject.name == "Up" || myCollision.gameObject.name == "Down")
        {
            aud.clip = audioRebound;
            aud.Play();
        }
    }

    int directionY(Vector2 ballPosition, Vector2 racketPosition)
    {
        int num = -1;
        if (ballPosition.y > racketPosition.y)
        {
            return 1;
        } else if (ballPosition.y < racketPosition.y)
        {
            return num;
        }else
        {
            return 0;
        }
    }

    public void resetBall(string direction)
    {
        transform.position = Vector2.zero;

        vel = 30.0f;

        if(direction == "Rigth")
        {
            rigthGoals++;
            rigthCounter.text = rigthGoals.ToString();

            if(!CheckScore())
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.right * vel;
            }
        } else if (direction == "Left")
        {
            leftGoals++;
            leftCounter.text = leftGoals.ToString();

            if(!CheckScore())
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.left * vel;
            }
        }

        aud.clip = audioGol;
        aud.Play();
    }

    private void Update()
    {
        vel = vel + 2 * Time.deltaTime;
        
        time -= Time.deltaTime;

        if (!CheckScore())
        {
            minutesSeconds(time);
        } else
        {
            minutesSeconds(0);
        }
    }

    void minutesSeconds(float tiempo)
    {
        if(tiempo > 120)
        {
            minutes = "02";
        } else if(tiempo >= 60)
        {
            minutes = "01";
        } else
        {
            minutes = "00";
        }

        int numSeconds = Mathf.RoundToInt(tiempo % 60);
        if(numSeconds > 9)
        {
            seconds = numSeconds.ToString();
        } else
        {
            seconds = "0" + numSeconds.ToString();
        }

        timer.text = minutes + ":" + seconds;
    }

    public bool CheckScore()
    {
        scene = SceneManager.GetActiveScene();

        if(time <= 0)
        {
            if(leftGoals > rigthGoals)
            {
               
                if (scene.name == "Game")
                {
                    score.text = "¡Jugador Izquierda GANA!\nPulsa M para volver a Menu\nPulsa Espacio para volver a jugar";
                } else if (scene.name == "GameIA")
                {
                    score.text = "¡Jugador Izquierda GANA!\nPulsa M para volver a Menu\nPulsa Enter para volver a jugar";
                }
                
            } else if(rigthGoals > leftGoals)
            {
                if (scene.name == "Game")
                {
                    score.text = "¡Jugador Derecha GANA!\nPulsa M para volver a Menu\nPulsa Espacio para volver a jugar";
                } else if(scene.name == "GameIA")
                {
                    score.text = "¡Jugador Derecha GANA!\nPulsa M para volver a Menu\nPulsa Enter para volver a jugar";
                }
                
            } else
            {
                if (scene.name == "Game")
                {
                    score.text = "¡EMPATE!\nPulsa M para volver a Menu\nPulsa Espacio para volver a jugar";
                } else if (scene.name == "GameIA")
                {
                    score.text = "¡EMPATE!\nPulsa M para volver a Menu\nPulsa Enter para volver a jugar";
                }
                
            }

            backgroundScore.enabled = true;
            score.enabled = true;
            Time.timeScale = 0;
            return true;
        }
        if(leftGoals == 5)
        {
            if (scene.name == "Game")
            {
                score.text = "¡Jugador Izquierda GANA!\nPulsa M para volver a Menu\nPulsa Espacio para volver a jugar";
            } else if(scene.name == "GameIA")
            {
                score.text = "¡Jugador Izquierda GANA!\nPulsa M para volver a Menu\nPulsa Enter para volver a jugar";
            }
            
            backgroundScore.enabled = true;
            score.enabled = true;
            Time.timeScale = 0;
            return true;
        } else if(rigthGoals == 5)
        {

            if (scene.name == "Game")
            {
                score.text = "¡Jugador Derecha GANA!\nPulsa M para volver a Menu\nPulsa Espacio para volver a jugar";
            } else if(scene.name == "GameIA")
            {
                score.text = "¡Jugador Derecha GANA!\nPulsa M para volver a Menu\nPulsa Enter para volver a jugar";
            }
            
            backgroundScore.enabled = true;
            score.enabled = true;
            Time.timeScale = 0;
            return true;
        }
        else
        {
            return false;
        }
    }



}
