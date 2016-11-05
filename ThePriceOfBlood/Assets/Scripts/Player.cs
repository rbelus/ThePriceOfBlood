using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    // Etats du joueur
    public enum CharacterState { IDLE, MOVE, ATTACK };
    public CharacterState mCurrentState;

    // Variables de déplacement
    public Vector3 mPosition;
    public Vector3 mSpeed;
    public float mMoveSpeed;

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

    void Start()
    {
        mStats = new int[6];
        mStats[0] = 5;
        mStats[1] = 5;
        mStats[2] = 5;
        mStats[3] = 5;
        mStats[4] = 5;
        mStats[5] = 5;
        mCurrentState = CharacterState.IDLE;
        mPosition = transform.position;
        mLook = Vector3.back;
        mAnimator = GetComponent<Animator>();
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
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
                        mSpeed *= mMoveSpeed;
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
 
        mPosition += mSpeed * Time.deltaTime;
        transform.position = mPosition;
    }
}
