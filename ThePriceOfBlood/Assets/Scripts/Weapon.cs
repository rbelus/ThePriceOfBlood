using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public BoxCollider mCollider;
    public float mCreationDate;
    public float mDamage;

    void Start()
    {
        mCollider = GetComponent<BoxCollider>();
        mCreationDate = Time.time;
        mDamage = GetComponentInParent<Player>().mStats[1];
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("TOUCHAY : " + mDamage);
            other.GetComponent<Enemy>().TakeDamage(mDamage);
        }
    }

    void Update()
    {
        if (Time.time > mCreationDate + 0.6f)
            Destroy(gameObject);
    }
}
