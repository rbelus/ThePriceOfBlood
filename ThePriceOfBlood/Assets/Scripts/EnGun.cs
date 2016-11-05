using UnityEngine;
using System.Collections;

public class EnGun : MonoBehaviour
{
    public Vector2 speed = new Vector2(0, 0);
    public GameObject bullet;
    public float FireRate = 0.0f;
    private float reload = 0.0f;
    private float BulletRate;
    public bool shooting;
    private Vector2 Position;
    public GameObject target;

    public float reloadRate;
    public float dischargeRate;

    private float MaxEnergy = 100f;
    public float Energy;

    bool charging = false;
    bool blocked = false;


    //public UIManager uiScript;
    //public delegate void EnergyChangedEventHandler(object sender, float Energy);
    //public static event EnergyChangedEventHandler EnergyChangedEvent;


    // Use this for initialization
    void Start()
    {
        //InvokeRepeating("Shoot", 0.0, 1.0 / BulletRate);

        Position = this.transform.position;
        Energy = MaxEnergy;
        // uiScript = FindObjectOfType<UIManager>();
        // EnergyChangedEvent += uiScript.MyCustomEnergyChanged;
        // EnergyChangedEvent(gameObject, Energy);
    }

   /* public void OnEnergyChanged(object sender, float Energy)
    {
        if (EnergyChangedEvent != null)
        {
            EnergyChangedEvent(sender, Energy);
        }
    }*/

    void Shoot()
    {
        if (!shooting) return;
        GameObject go = (GameObject)Instantiate(bullet, this.transform.position, this.transform.rotation);
        EnBullet bbullet = go.GetComponent<EnBullet>();
        bbullet.target = target;
        reload = 0.0f;
        Energy -= dischargeRate;
        //go.rigidbody.AddRelativeForce(Vector3.forward * 1000.0);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 newposi = Position + speed;
        //Position = newposi;
        //this.transform.position = newposi;
        reload += Time.deltaTime;

        if (Energy <= 0)
        {
            blocked = true;
        }
        if (Energy >= MaxEnergy)
        {
            blocked = false;
        }
        if (Energy < MaxEnergy)
        { charging = true; }
        else { charging = false; }


        if (shooting == true)
        {

            if (blocked == false)
            {

                if (reload >= FireRate)
                {

                    Shoot();

                }
            }
        }
        else
        {
            if (reload >= FireRate)
            {
                if (charging == true)
                {
                    reload = 0.0f;
                    Energy += reloadRate;
                }
            }
        }
    }
}