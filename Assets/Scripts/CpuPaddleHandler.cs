using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpuPaddleHandler : MonoBehaviour
{
    private Rigidbody2D cpuPaddle;
    public GameObject ball;
    private Vector2 velocity=Vector2.zero;

    void Start()
    {
        cpuPaddle=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(ball.transform.position.x>6f){
            if(transform.position.y<=3.35f && transform.position.y>=-3.35f)
        {
            Vector2 target= new Vector2(transform.position.x,ball.transform.position.y);
        cpuPaddle.MovePosition(Vector2.SmoothDamp(transform.position,target,ref velocity,0.02f));
        }
        else 
        {
            if(transform.position.y>3.35f){
                transform.position=(new Vector2(transform.position.x,3.35f));    
            }
            else{
                transform.position=(new Vector2(transform.position.x,-3.35f));    
            }
        }
        }
        
    }
}
