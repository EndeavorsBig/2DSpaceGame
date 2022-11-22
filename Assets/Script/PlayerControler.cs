using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private int score;
    private int life = 3;

    [SerializeField] private float speed = 2;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text lifeText;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigidbody.velocity = new Vector2(horizontal*speed, vertical*speed);

        //print(horizontal);
        //print(vertical);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            score = score + 5;
            Destroy(collision.gameObject);

        }else if(collision.gameObject.tag == "Rock")
        {
            score = score - 5;
            life = life - 1;
        }

        scoreText.text = "Score : " + score.ToString();
        lifeText.text = "Life = " + life.ToString();
        if (life <= 0)
        {
            lifeText.text = "GAME OVER";
        }
    }
}
