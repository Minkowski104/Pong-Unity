using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallHandler : MonoBehaviour
{
    private Rigidbody2D ball;
    private static int player1Score;
    private static int player2Score;
    public TextMeshProUGUI player1TextScore;
    public TextMeshProUGUI player2TextScore;
    
    // Start is called before the first frame update
    public float moveSpeed;
    void Start()
    {
        player1Score=player1Score>0?player1Score:0;
        player2Score=player2Score>0?player2Score:0;
        player1TextScore.text="Player 1:"+ player1Score;
        player2TextScore.text="Player 2:"+ player2Score;
        ball=GetComponent<Rigidbody2D>();
        float x = Random.value;
        float direction = Random.Range(-1f,1f)>0?1f:-1f;
        Vector2 randomVector = new Vector2(x*direction,Random.Range(0,x/3)*direction);
        randomVector.Normalize();
        ball.velocity=new Vector2(moveSpeed*randomVector.x,moveSpeed*randomVector.y);   
    }



    void OnTriggerEnter2D(Collider2D collider){
        string colliderName = collider.gameObject.name.ToUpper();
        if(colliderName.Contains("BOTTOM")||colliderName.Contains("TOP"))
        {
            ball.velocity= new Vector2(ball.velocity.x,ball.velocity.y*-1);
        }
        if(colliderName.Contains("LEFT"))
        {
            UpdateScore(2);
            SceneManager.LoadScene("MainBoard");
        }
        if(colliderName.Contains("RIGHT"))
        {
            UpdateScore(1);
            SceneManager.LoadScene("MainBoard");
        }

        if(colliderName.Contains("PAD"))
        {
            moveSpeed+=0.7f;
            Vector2 newVelocity=new Vector2(ball.velocity.x*-1,ball.velocity.y);
            newVelocity.Normalize();
            ball.velocity= new Vector2(newVelocity.x*moveSpeed,newVelocity.y*moveSpeed);
        }

        Debug.Log("Trigger"+moveSpeed);
    }
    // Update is called once per frame
    void Update()
    {
    }

    void UpdateScore(int player){
        if (player==1)
        {
         player1Score+=1;
         player1TextScore.text="Player 1 : "+ player1Score;   
         if(player1Score==5)
         {
            Time.timeScale=0;
         }
        }
        else if (player==2)
        {
         player2Score+=1;
         player2TextScore.text="Player 2 : "+ player2Score;   
         if(player2Score==5)
         {
            Time.timeScale=0;
         }
        }
    }
}
