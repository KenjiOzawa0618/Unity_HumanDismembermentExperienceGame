using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.XR;
using System;

public class moveleft : MonoBehaviour
{
    Animator anim;
    Vector3 PastPosition = Vector3.zero;
    Quaternion PastRotation;
    private Vector3 latestPos;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    [Obsolete]
    void Update()
    {
        Vector3 PresentPosition = InputTracking.GetLocalPosition(XRNode.CenterEye);
        Quaternion PresentRotation = InputTracking.GetLocalRotation(XRNode.CenterEye);
        Vector3 distance = 3 * (PresentPosition - PastPosition);
        anim = GetComponent<Animator>();

        Vector2 vectorL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);

        Vector3 diff = transform.position - latestPos;
        latestPos = transform.position;

        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.LTouch) || OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp, OVRInput.Controller.LTouch) || OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.LTouch) || OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.LTouch))
        {
            distance.x = (vectorL.x / 10);
            distance.z = (vectorL.y / 10);

            if (diff.magnitude > 0.01f)
            {
                transform.rotation = Quaternion.LookRotation((transform.forward - diff.normalized) / 100);
            }
            
            this.transform.position += distance;
            anim.SetBool("ismove", true);
        }
        if (Input.GetKey("j") || Input.GetKey("k") || Input.GetKey("l") || Input.GetKey("i")){
            if (Input.GetKey("i")){
                distance.z = 0.1f;
            }
            else if (Input.GetKey("k")){
                distance.z = -0.1f;
            }
            else if (Input.GetKey("l")){
                distance.x = 0.1f;
            }
            else if (Input.GetKey("j")){
                distance.x = -0.1f;
            }
            if (diff.magnitude > 0.01f)
            {
                transform.rotation = Quaternion.LookRotation((transform.forward - diff.normalized) / 100);
            }
            this.transform.position += distance;
            anim.SetBool("ismove", true);
        }
        else
        {
            anim.SetBool("ismove", false);
        }
        PastPosition = PresentPosition;
        PastRotation = PresentRotation;
    }
}