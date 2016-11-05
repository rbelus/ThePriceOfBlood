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

    void OnTriggerStay(Collider other)
    {
        Debug.Log("TOUCHAY : " + mDamage);
        Destroy(other.gameObject);
    }

    void Update()
    {
        if (Time.time > mCreationDate + 0.6f)
            Destroy(gameObject);
    }
}
