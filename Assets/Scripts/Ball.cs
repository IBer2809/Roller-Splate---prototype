using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    Vector2 firstPos;
    Vector2 secondPos;
    public Vector2 currentPos;
    public float moveSpeed;
    public float currentGroundNumber;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("gm").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentGroundNumber < gm.groundNumbers){
            Swipe();
        }
        
    }

    void Swipe(){
        
        if(Input.GetMouseButtonDown(0)){
            firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if(Input.GetMouseButtonUp(0)){
            secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        currentPos = new Vector2(
            secondPos.x - firstPos.x,
            secondPos.y - firstPos.y

        );

        currentPos.Normalize();

        if(currentPos.y < 0 && currentPos.x > -0.5f && currentPos.x < 0.5f){
            rb.velocity = Vector3.back * moveSpeed;

        }
        else if(currentPos.y > 0 && currentPos.x > -0.5f && currentPos.x < 0.5f){
            rb.velocity = Vector3.forward * moveSpeed;
            
        }
        else if(currentPos.x < 0 && currentPos.y > -0.5f && currentPos.y < 0.5f){
            rb.velocity = Vector3.left * moveSpeed;
            
        }
        else if(currentPos.x > 0 && currentPos.y > -0.5f && currentPos.y < 0.5f){
            rb.velocity = Vector3.right * moveSpeed;
            
        }


    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.GetComponent<MeshRenderer>().material.color != Color.red){
            if(col.gameObject.tag == "ground"){
                col.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                Constaints();
                currentGroundNumber++;
            }
            

        }
    }

    void Constaints(){
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
}
