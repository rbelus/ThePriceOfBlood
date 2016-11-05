using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    // Etats du joueur
    public enum CharacterState { IDLE, MOVE, ATTACK };
    public CharacterState mCurrentState;

    // Variables de gestion
    public Vector3 mPosition;
    public Vector3 mSpeed;

    public float mMoveSpeed;

    void Start()
    {
        mCurrentState = CharacterState.IDLE;
        mPosition = transform.position;
    }

    void Update()
    {
        switch (mCurrentState)
        {
            case CharacterState.IDLE:
                {
                    mSpeed = Vector3.zero;

                    // Cas ou on avance
                    if (System.Math.Abs(Input.GetAxis("Horizontal")) > 0.2)
                    {
                        mCurrentState = CharacterState.MOVE;
                        break;
                    }

                    break;
                }
            case CharacterState.MOVE:
                {
                    if (System.Math.Abs(Input.GetAxis("Horizontal")) > 0.5 ||
                            System.Math.Abs(Input.GetAxis("Vertical")) > 0.5)
                    {
                        if (Input.GetAxis("Horizontal") > 0.5)
                            mSpeed.x = mMoveSpeed;
                        if (Input.GetAxis("Horizontal") < -0.5)
                            mSpeed.x = -mMoveSpeed;
                        if (Input.GetAxis("Vertical") > 0.5)
                            mSpeed.z = mMoveSpeed;
                        if (Input.GetAxis("Vertical") < -0.5)
                            mSpeed.z = -mMoveSpeed;

                        Debug.Log("Speed value : " + mSpeed);

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
