using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float mCurrentLife;
    public float mDamage;
    public float mMaxLife;
    public Player mPlayer;

    void Start()
    {
        mCurrentLife = mMaxLife;
    }

    public void TakeDamage(float damage)
    {
        mCurrentLife -= damage;

        // Si l'ennemi meurt, le player regen
        if (mCurrentLife <= 0)
        {
            mPlayer.mCurrentLife += mPlayer.mStats[3];
            if (mPlayer.mCurrentLife > mPlayer.mStats[0])
                mPlayer.mCurrentLife = mPlayer.mStats[0];
            Destroy(this.gameObject);
        }
    }
}
