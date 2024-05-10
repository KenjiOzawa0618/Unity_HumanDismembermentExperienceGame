using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.XR;
using System;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public Transform headset;
    Animator anim;
    Vector3 PastPosition = Vector3.zero;
    Quaternion PastRotation;
    Vector3 distance = Vector3.zero;
    Quaternion direction;
    GameObject text;
    Text logText;
    GameObject feet;//両足
    float feetXRot, feetYRot, feetZRot;
    new GameObject camera;


    void Start()
    {
        anim = GetComponent<Animator>();
        Vector3 pos = transform.position;
        // Debug.Log($"positonStart(x,y,z) = ({pos.x},{pos.y},{pos.z}");//startの足の位置

        //Logを表示したい
        text = GameObject.Find("LogSpeed/Text");
        feet = GameObject.Find("PotatoHead/Feet");
        camera = GameObject.Find("OVRPlayerController/OVRCameraRig");

        //testで角度を設定
        feetXRot = 0.0f;
        feetYRot = 0.0f;
        feetZRot = 0.0f;
        logText = text.GetComponent<Text>();
        logText.text = "これが表示される";
    }

    [Obsolete]
    void Update()
    {
        anim = GetComponent<Animator>();
        Vector3 PresentPosition = InputTracking.GetLocalPosition(XRNode.CenterEye);
        Quaternion PresentRotation = InputTracking.GetLocalRotation(XRNode.CenterEye);
        Vector3 distance = 5*(PresentPosition - PastPosition);
        var direction = Quaternion.LookRotation(PresentPosition - PastPosition);

        float headsetVelocity;
        headsetVelocity = (PresentPosition - PastPosition).magnitude / Time.deltaTime;
        
        if ( PresentPosition != PastPosition && headsetVelocity >0.1)
        {
            Vector3 pos = transform.position;
            distance.y = 0.0f;//y軸固定
            this.transform.position += distance;//positon移動
            anim.SetBool("ismove", true);
        }

        else if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            transform.Rotate(0,1,0);
            anim.SetBool("ismove", true);
        }
        else if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            transform.Rotate(0,-1,0);
            anim.SetBool("ismove", true);
        }
        else
        {
            anim.SetBool("ismove", false);//animation停止
        }

        PastPosition = PresentPosition;//値の更新
        PastRotation = PresentRotation;

        if(Input.GetKey(KeyCode.UpArrow)){
            this.transform.position=new Vector3(this.transform.position.x+0.1f,this.transform.position.y,this.transform.position.z);
            this.transform.rotation=Quaternion.Euler(0,0,0);
            anim.SetBool("ismove", true);
        }else if(Input.GetKey(KeyCode.DownArrow)){
            this.transform.position=new Vector3(this.transform.position.x-0.1f,this.transform.position.y,this.transform.position.z);
            this.transform.rotation=Quaternion.Euler(0,0,0);
            anim.SetBool("ismove", true);
        }else if(Input.GetKey(KeyCode.RightArrow)){
            this.transform.position=new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z-0.1f);
            this.transform.rotation=Quaternion.Euler(0,0,0);
            anim.SetBool("ismove", true);
        }else if(Input.GetKey(KeyCode.LeftArrow)){
            this.transform.position=new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z+0.1f);
            this.transform.rotation=Quaternion.Euler(0,0,0);
            anim.SetBool("ismove", true);
        }else if(Input.GetKey("q")){
            transform.Rotate(0,-1,0);
            anim.SetBool("ismove", true);
        }else if(Input.GetKey("w")){
            transform.Rotate(0,1,0);
            anim.SetBool("ismove", true);
        }
    }

}
