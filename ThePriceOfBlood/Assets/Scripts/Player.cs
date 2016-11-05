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

    void Start()
    {
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

                    break;
                }
            case CharacterState.ATTACK:
                {

                    break;
                }
        }

        mPosition += mSpeed * Time.deltaTime;
        transform.position = mPosition;
    }
}
