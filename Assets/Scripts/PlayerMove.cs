using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    Camera viewCamera;

    public float moveSpd = 6;
    public float WaitTime = 0.1f;
    Vector3 velocity;

    Vector3 mousePos;

    public KeyCode walkU;
    public KeyCode walkD;
    public KeyCode walkL;
    public KeyCode walkR;

    public KeyCode lookU;
    public KeyCode lookD;
    public KeyCode lookL;
    public KeyCode lookR;

    public float walkSpeed;
    public float pov;

    Transform player;
    Vector3 position;

    void Start()
    {
        player = GetComponent<Transform>();


        rb = GetComponent<Rigidbody2D>();
        viewCamera = Camera.main;
    }



    void FixedUpdate()
    {
        position = player.position;
        rb.MovePosition(position + velocity * Time.fixedDeltaTime);
    }

   void Update()
    {
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0 ).normalized * moveSpd;


        MouseLook();
    }


    public float defaultSpriteAngle = 0;
    private void MouseLook()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 dir = new Vector2(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y);

        transform.up = dir;
    }

    IEnumerator Reset(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
                                                //And here goes your method of resetting the game...
        yield return null;
    }
}
