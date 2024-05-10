using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ChangeEyes: MonoBehaviour {
  //RightEyeオブジェクト
  GameObject rightEye; 
  Vector3 rightEyePosition;
  Vector3 rightEyeRotation;
  //leftEyeオブジェクト
  GameObject leftEye ; 
  Vector3 leftEyePosition;
  Vector3 leftEyeRotation;
  //cameraRigオブジェクト
  GameObject camera ;
  Vector3 cameraPosition;
  Vector3 cameraRotation;
  int EyePossible = 0; //0:左目,1:右目,2:両目が見えるように設定
  public bool isEyeDisplay=false;//目ん玉が見ている映像をcameraに映すかどうか

  void Start() {
    rightEye = GameObject.Find("PotatoHead/RightEye");
    leftEye=GameObject.Find("PotatoHead/LeftEye");
    camera=GameObject.Find("OVRPlayerController");
  
  }
  // Update is called once per frame
  void Update() {
    if(isEyeDisplay){
      rightEyePosition=rightEye.transform.position;
      leftEyePosition=leftEye.transform.position;
      // 各Eyeから映る映像をoculusに映す(oculusのXボタンを押すたびに切り替える)
      if (OVRInput.GetDown(OVRInput.RawButton.X)) {
        if(EyePossible==0){
          // rightEyeの画面を表示させる
          EyePossible=1;
          camera.transform.parent=rightEye.transform;
          camera.transform.localPosition=new Vector3(0,0,0);
          // camera.transform.position=new Vector3(rightEyePosition.x,rightEyePosition.y,rightEyePosition.z);
          camera.transform.localRotation=Quaternion.Euler(0,rightEye.transform.eulerAngles.y-90,-90);
        }else if(EyePossible==1){
          // rightEyeの画面を表示させる
          EyePossible=0;
          camera.transform.parent=leftEye.transform;
          camera.transform.localPosition=new Vector3(0,0,0);
          // camera.transform.position=new Vector3(leftEyePosition.x,leftEyePosition.y,leftEyePosition.z);
          camera.transform.localRotation=Quaternion.Euler(0,leftEye.transform.eulerAngles.y-90,-90);
        }
      }
      if (Input.GetKeyDown("b")) {
        if(EyePossible==0){
          // leftEyeの画面を表示させる
          EyePossible=1;
          camera.transform.parent=rightEye.transform;
          camera.transform.localPosition=new Vector3(0,0,0);
          // camera.transform.position=new Vector3(rightEyePosition.x,rightEyePosition.y,rightEyePosition.z);
          camera.transform.localRotation=Quaternion.Euler(0,rightEye.transform.eulerAngles.y-90,-90);
        }else if(EyePossible==1){
          // rightEyeの画面を表示させる
          EyePossible=0;
          camera.transform.parent=leftEye.transform;
          camera.transform.localPosition=new Vector3(0,0,0);
          // camera.transform.position=new Vector3(leftEyePosition.x,leftEyePosition.y,leftEyePosition.z);
          camera.transform.localRotation=Quaternion.Euler(0,leftEye.transform.eulerAngles.y-90,-90);
        }
      }
      if(Input.GetKeyDown("f")){
        camera.transform.localRotation=Quaternion.Euler(0,90,0);
      }
    }
  }
}