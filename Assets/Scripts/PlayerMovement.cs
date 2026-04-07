using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;

    public float speed = 12f;
    public float gravity = -9.8f;

    Vector3 velocity;

    //JUMP
    public float jumpHeight = 1.0f;
    bool groundedPlayer;

    
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

   
    void Update()
    {
        
        groundedPlayer = cc.isGrounded;//JUMP non infinito

        if (groundedPlayer && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        
        float x = Input.GetAxis("Horizontal");//MOVIMENTO
        float z= Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        

        
        if (Input.GetButtonDown("Jump") && groundedPlayer)//JUMP
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -3.0f* gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        cc.Move((move * speed + velocity) * Time.deltaTime);
    }
}
