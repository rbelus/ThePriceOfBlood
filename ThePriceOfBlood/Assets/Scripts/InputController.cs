using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    private EngineMove PlayerMovement;
    //private Gun Minigun;
    private Vector2 movement;

    private float MaxSpeed;



    // Use this for initialization
    void Start()
    {
        PlayerMovement = this.GetComponent<EngineMove>();
        //Minigun = this.GetComponent<Gun>();

    }




    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        bool inputG = Input.GetKey("space");



        if (inputG == true)
        {

            //Minigun.shooting = true;

        }
        else {
            //Minigun.shooting = false;
        }



        PlayerMovement.speed.x = inputX * 0.2f;
        PlayerMovement.speed.y = inputY * 0.2f;

        //Minigun.speed.x = inputX * 0.2f;
        //Minigun.speed.y = inputY * 0.2f;
    }
}