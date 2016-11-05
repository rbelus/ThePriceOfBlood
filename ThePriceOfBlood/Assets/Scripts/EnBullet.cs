using UnityEngine;
using System.Collections;

public class EnBullet : MonoBehaviour
{
    public GameObject target;
    private Vector3 direction;
    public float speed = 1;

    // Use this for initialization
    void Start()
    {
        direction = (target.transform.position - this.transform.position);
        float distance = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
        direction /= distance;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        //Vector2 newposi = this.transform.position + (direction * speed);
        this.transform.position += (direction * speed);
    }


   /* void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Bim !", gameObject);
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Ennemy")
        {
            Destroy(col.gameObject);
        }
    }*/
}
