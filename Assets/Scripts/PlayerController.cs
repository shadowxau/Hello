using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    // variable are here

    public float speed = 1.0f;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate = 0.5F;
    private float nextFire = 0.0f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Object.Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;

        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidBody.position = new Vector3
        (
            Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidBody.position.z, boundary.zMin, boundary.zMax)
        );

        rigidBody.rotation = Quaternion.Euler(0, 0, rigidBody.velocity.x * -tilt);
    }
}
