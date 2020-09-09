using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    //moving horizontal
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float speed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 4.8f;
    [Tooltip("In m")] [SerializeField] float yRange = 2.5f;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    bool isControlEnabled = true;

    float xThrow, yThrow;

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProccesTranslation();
            ProcessRotation();
        }
    }

    private void ProcessRotation()
    {
        {
            float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
            float pitchDueToControlThrow = yThrow * controlPitchFactor;
            float pitch = pitchDueToPosition + pitchDueToControlThrow;

            float yaw = transform.localPosition.x * positionYawFactor;

            float roll = xThrow * controlRollFactor;

            transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        }
    }

    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }
    private void ProccesTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // refer to axis
        yThrow = CrossPlatformInputManager.GetAxis("Vertical"); // refer to yaxis

        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset; // add value to ship on X
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); // lock value of X, prevent to go out of screen

        float rawYPos = transform.localPosition.y + yOffset; // add value to ship on Y 
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}