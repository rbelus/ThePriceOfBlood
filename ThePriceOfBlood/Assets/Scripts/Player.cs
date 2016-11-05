﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    // Etats du joueur
    public enum CharacterState { IDLE, MOVE, ATTACK };
    public CharacterState mCurrentState;

    // Variables de déplacement
    public Vector3 mPosition;
    public Vector3 mSpeed;

    // Regard
    public Vector3 mLook;

    // Animator
    private Animator mAnimator;
    private SpriteRenderer mSpriteRenderer;

    // Weapon - GameObject enfant qui représente l'attaque
    public Weapon mWeapon;

    // Stats
    // 0 - VIE, 1 - ATK, 2 - SPD, 3 - REGEN, 4 - ANTIREGEN, 5 - DEF
    public int[] mStats;
    public int mInitVie;
    public int mInitAtk;
    public int mInitSpd;
    public int mInitRegen;
    public int mInitAntiregen;
    public int mInitDef;

    // Vie actuelle
    public float mCurrentLife;

    // UI
    public Slider mLifeSlider;
    public Text mStatsUI;

    void Start()
    {
        mStats = new int[6];
        mStats[0] = mInitVie;
        mStats[1] = mInitAtk;
        mStats[2] = mInitSpd;
        mStats[3] = mInitRegen;
        mStats[4] = mInitAntiregen;
        mStats[5] = mInitDef;
        mCurrentState = CharacterState.IDLE;
        mPosition = transform.position;
        mLook = Vector3.back;
        mAnimator = GetComponent<Animator>();
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        mCurrentLife = mStats[0];
    }

    void Update()
    {
        // GESTION DES DEPLACEMENTS ET DES ACTIONS 
        switch (mCurrentState)
        {
            case CharacterState.IDLE:
                {
                    mSpeed = Vector3.zero;

                    // Cas ou on avance
                    if (System.Math.Abs(Input.GetAxis("Horizontal")) > 0.5 ||
                            System.Math.Abs(Input.GetAxis("Vertical")) > 0.5)
                    {
                        mCurrentState = CharacterState.MOVE;
                        break;
                    }

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        mCurrentState = CharacterState.ATTACK;
                    }
                    break;
                }
            case CharacterState.MOVE:
                {
                    mAnimator.SetBool("playerMoveBool", true);
                    if (System.Math.Abs(Input.GetAxis("Horizontal")) > 0.5 ||
                            System.Math.Abs(Input.GetAxis("Vertical")) > 0.5)
                    {
                        mSpeed.x = Input.GetAxis("Horizontal");
                        mSpeed.z = Input.GetAxis("Vertical");

                        if (mSpeed.x < 0)
                            mSpriteRenderer.flipX = true;
                        else
                            mSpriteRenderer.flipX = false;

                        mSpeed.Normalize();
                        mLook = mSpeed;
                        mSpeed *= mStats[2];
                    }
                    else
                    {
                        mSpeed = Vector3.zero;
                        mCurrentState = CharacterState.IDLE;
                        mAnimator.SetBool("playerMoveBool", false);
                        break;
                    }

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        mAnimator.SetBool("playerMoveBool", false);
                        mAnimator.SetTrigger("playerAttack");
                        mCurrentState = CharacterState.ATTACK;
                    }
                    break;
                }
            case CharacterState.ATTACK:
                {
                    // "Instanciation" d'une attaque
                    Instantiate(mWeapon, transform.position + mLook * 0.2f, Quaternion.identity, transform);

                    mAnimator.SetTrigger("playerAttack");

                    mCurrentState = CharacterState.IDLE;
                    break;
                }
        }

        //Test du move
        int layerMask = 1 << 11;
        if (Physics.Linecast(transform.position, transform.position + mLook * 0.5f,layerMask))
        {
            Debug.Log("Collision");
            mSpeed = Vector3.zero;
        }

        // Affichage de la vie
        mLifeSlider.value = mCurrentLife / mStats[0];

        // Affichage des stats
        mStatsUI.text = "ATK : " + mStats[1] + "  SPD : " + mStats[2] + "  REGEN : " + mStats[3] + "  BLOODLOSS : " + mStats[4];

        // Perte de vie
        mCurrentLife -= mStats[4] * Time.deltaTime;

        // DID YOU JUST DIE ? BITCH
        if (mCurrentLife <= 0)
            Destroy(this.gameObject);

        // Update Position
        mPosition += mSpeed * Time.deltaTime;
        transform.position = mPosition;
    }
}
