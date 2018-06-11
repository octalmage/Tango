using UnityEngine;
using System.Collections;
 
public class ScreenWrapping : MonoBehaviour
{
    float leftConstraint = Screen.width;
    float rightConstraint = Screen.width;
    float bottomConstraint = Screen.height;
    float topConstraint = Screen.height;
    float buffer = 0f;
    Camera cam;
    float distanceZ;
    public ParticleSystem particle;

    void Start()
    {
        cam = Camera.main;
        distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);

        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;
    }

    void Update()
    {
        if (transform.position.x < leftConstraint - buffer)
        {
            StopParticle();
            transform.position = new Vector3(rightConstraint + buffer, transform.position.y, transform.position.z);
            StartParticle();
        }
        if (transform.position.x > rightConstraint + buffer)
        {
            StopParticle();
            transform.position = new Vector3(leftConstraint - buffer, transform.position.y, transform.position.z);
            StartParticle();
        }
        if (transform.position.y < bottomConstraint - buffer)
        {
            StopParticle();
            transform.position = new Vector3(transform.position.x, topConstraint + buffer, transform.position.z);
            StartParticle();
        }
        if (transform.position.y > topConstraint + buffer)
        {
            StopParticle();
            transform.position = new Vector3(transform.position.x, bottomConstraint - buffer, transform.position.z);
            StartParticle();
        }
    }
       
    // Stop particle system for screen jumping.
    void StopParticle() 
    {
        if (particle != null)
        {
            particle.Stop();
        }
    }

    void StartParticle() 
    {
        if (particle != null)
        {
            particle.Play();
        }
    }
}