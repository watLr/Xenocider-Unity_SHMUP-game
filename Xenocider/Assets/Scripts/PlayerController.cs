using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform[] shotSpawns;
    public float fireRate;

    private float nextFire;

    private void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            if (Input.GetKey(KeyCode.UpArrow) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                foreach (var shotSpawn in shotSpawns) {
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                }                
                GetComponent<AudioSource>().Play();
            }
        }

    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Rigidbody rgbd = GetComponent<Rigidbody>();

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rgbd.velocity = movement * speed;

        rgbd.position = new Vector3
        (
            Mathf.Clamp(rgbd.position.x,boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rgbd.position.z, boundary.zMin, boundary.zMax)
        );

        rgbd.rotation = Quaternion.Euler(0.0f, 0.0f, rgbd.velocity.x * -tilt);
    }
}
