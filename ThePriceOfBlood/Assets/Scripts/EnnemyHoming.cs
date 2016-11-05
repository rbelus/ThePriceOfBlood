using UnityEngine;
using System.Collections;

public class EnnemyHoming : Enemy {

    public float speed = 0.1f;
    public GameObject target;
    private Vector3 direction;
    public int dist;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {


        //return new PointF(A.X / distance, A.Y / distance);
        direction = (target.transform.position - this.transform.position);
        float distance = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
        if (distance <= dist)
        {
            this.transform.position += (direction * speed * 3)/ (distance);
        }
        else
        {
            this.transform.position += direction * speed;
        }
    }
}
