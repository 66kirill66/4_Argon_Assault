using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    //   in meters per second.
    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float controlSpeed = 15f;  // Speed
    [Tooltip("In m")] [SerializeField] float xRange = 5f;    //  border right left
    [Tooltip("In m")] [SerializeField] float yRange = 3f;   //   border up down
    [SerializeField] GameObject[] guns;

    [Header("Screen-ImagePosition Based")]
    [SerializeField] float positionPichFactor = -5f;     // pitch  nose slope
    [SerializeField] float positionYawFactor = 5;      //   yaw

    [Header("Control-throw Based")]
    [SerializeField] float controlPichFactor = -20;     //  pitch
    [SerializeField] float controlRollFactor = -20;   //    roll
  

    float xThrow, yThrow;    //  Horizontal . Vertical
    bool isControlEnabled = true;
 

    // Update is called once per frame
    void Update ()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }
    void OnPlayerDeath()  // called by string reference.
    {
        isControlEnabled = false; 
    }

    private void ProcessRotation()     // rotation management
    {
        float pitchDueToposition = transform.localPosition.y * positionPichFactor;
        float pitchDueToControlThrow = yThrow * controlPichFactor;

        float pitch = pitchDueToposition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);    // return after turning 
    }

    private void ProcessTranslation()   //   management process 
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);   // borders

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))   
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        } 
    }
    private void SetGunsActive( bool isActive)
    {
       foreach (GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    } 
}
