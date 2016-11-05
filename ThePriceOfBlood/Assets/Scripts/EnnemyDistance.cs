using UnityEngine;
using System.Collections;

public class EnnemyDistance : Enemy {

    public float speed = 0.1f;
    public GameObject target;
    private Vector3 direction;
    private Vector3 reverse;
    public int dist;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        direction = (target.transform.position - this.transform.position);
        reverse = (this.transform.position - target.transform.position);
        float distance = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
        if (distance < dist)
        {
            this.transform.position -= (direction * speed * 3 *dist) / (distance);
        }
        else if (distance > (dist+1))
        {
            this.transform.position += direction * speed;
        }
    }
}
