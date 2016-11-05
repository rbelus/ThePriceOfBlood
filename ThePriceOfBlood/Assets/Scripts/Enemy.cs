using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float mCurrentLife;
    public float mDamage;
    public float mMaxLife;

    void Start()
    {
        mCurrentLife = mMaxLife;
    }

    public void TakeDamage(float damage)
    {
        mCurrentLife -= damage;
        if (mCurrentLife <= 0)
            Destroy(this.gameObject);
    }
}
