using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleHandler : MonoBehaviour
{
    private Rigidbody2D paddle;
    void Start()
    {
        paddle=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition2D=new Vector2(mousePosition.x,mousePosition.y);
        if(transform.position.y<=3.35f && transform.position.y>=-3.35f)
        {
        paddle.MovePosition(mousePosition2D);
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
