using UnityEngine;
using System.Collections;

public class IaInput : MonoBehaviour
{
    //private EngineMove EnnemyMovement;
    private EnGun Minigun;
    //private Vector2 movement;
    //public float speed;


    // Use this for initialization
    void Start()
    {
       // EnnemyMovement = this.GetComponent<EngineMove>();
        Minigun = this.GetComponent<EnGun>();
    }


    void OnBecameInvisible()
    {
        //Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Minigun.shooting = true;

      //  EnnemyMovement.speed.x = -speed;
        //EnnemyMovement.speed.y = Mathf.Cos(EnnemyMovement.speed.x) * 0.002f;

        //Minigun.speed.x = -speed;
        //Minigun.speed.y = Mathf.Cos(Minigun.speed.x) * 0.02f;
    }
}