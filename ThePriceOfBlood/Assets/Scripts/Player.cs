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

    void Start()
    {
        mCurrentState = CharacterState.IDLE;
        mPosition = transform.position;
        mLook = Vector3.back;
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
                    if (System.Math.Abs(Input.GetAxis("Horizontal")) > 0.5 ||
                            System.Math.Abs(Input.GetAxis("Vertical")) > 0.5)
                    {
                        mSpeed.x = Input.GetAxis("Horizontal");
                        mSpeed.z = Input.GetAxis("Vertical");

                        mSpeed.Normalize();
                        mLook = mSpeed;
                        mSpeed *= mMoveSpeed;
                    }
                    else
                    {
                        mSpeed = Vector3.zero;
                        mCurrentState = CharacterState.IDLE;
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

        Debug.Log("Axis value : " + Input.GetAxis("Vertical"));

    }
}
