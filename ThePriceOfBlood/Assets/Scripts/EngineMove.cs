using UnityEngine;
using System.Collections;

public class EngineMove : MonoBehaviour
{

    public Vector2 speed = new Vector2(0, 0);
    private Vector2 Position;
    //private BaseAvatar Avatar;

    // Use this for initialization
    void Start()
    {
        //Avatar = this.GetComponent<BaseAvatar>();
        Position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newposi = Position + speed;
        Position = newposi;
        this.transform.position = newposi;
    }
}

