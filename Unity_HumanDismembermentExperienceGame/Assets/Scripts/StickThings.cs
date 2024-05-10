using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class StickThings: MonoBehaviour {
  public GameObject textObject = null; // Textオブジェクト
  GameObject OVRPlayerControllerCenter;
  Vector3 OVRPlayerControllerCenterPosition;
  GameObject potatoHead; //ポテトヘッドのオブジェクト
  int numParts=0;//現在くっついているパーツの数
  // 右目
  GameObject rightEye;
  Vector3 rightEyePosition;
  Rigidbody rightEyeRigidbody;
  GameObject rightEyeHolder;
  Vector3 rightEyeHolderPosition;
  bool isRightEyeSticked = false;
  bool isRightEyeStickedEnable = false;
  SphereCollider rightEyeSphereCol;
  OVRGrabbable rightEyeGrabbable;
  // 右腕
  GameObject rightArm;
  Vector3 rightArmPosition;
  // GameObject rightArmJoint;
  // Vector3 rightArmJointPosition;
  Rigidbody rightArmRigidbody;
  GameObject rightShoulder; // 右肩
  Vector3 rightShoulderPosition;
  bool isRightArmSticked = false; //体と部位がくっついている状態かどうか
  bool isRightArmStickedEnable = false; //くっつけることが可能かどうか
  Vector3 rightArmVec; //右肩から右ジョイコンへのベクトル
  BoxCollider rightArmBoxCol;
  OVRGrabbable rightArmGrabbable;
  // 右手
  GameObject rightHand;
  Vector3 rightHandPosition;
  // 右耳
  GameObject rightEar;
  GameObject rightEarHolder;
  Vector3 rightEarPosition;
  Vector3 rightEarHolderPosition;
  Rigidbody rightEarRigidbody;
  bool isRightEarSticked = false; //体と部位がくっついている状態かどうか
  SphereCollider rightEarSphereCol;
  OVRGrabbable rightEarGrabbable;
  // 左目
  GameObject leftEye;
  Vector3 leftEyePosition;
  Rigidbody leftEyeRigidbody;
  GameObject leftEyeHolder;
  Vector3 leftEyeHolderPosition;
  bool isLeftEyeSticked = false;
  bool isLeftEyeStickedEnable = false;
  SphereCollider leftEyeSphereCol;
  OVRGrabbable leftEyeGrabbable;
  // 左腕
  GameObject leftArm;
  Vector3 leftArmPosition;
  // GameObject leftArmJoint;
  // Vector3 leftArmJointPosition;
  Rigidbody leftArmRigidbody;
  GameObject leftShoulder; // 左肩
  Vector3 leftShoulderPosition;
  bool isLeftArmSticked = false; //体と部位がくっついている状態かどうか
  bool isLeftArmStickedEnable = false; //くっつけることが可能かどうか
  Vector3 leftArmVec; //左肩から左ジョイコンへのベクトル
  BoxCollider leftArmBoxCol;
  OVRGrabbable leftArmGrabbable;
  // 左手
  GameObject leftHand;
  Vector3 leftHandPosition;
  // 左耳
  GameObject leftEar;
  GameObject leftEarHolder;
  Vector3 leftEarPosition;
  Vector3 leftEarHolderPosition;
  Rigidbody leftEarRigidbody;
  bool isLeftEarSticked = false; //体と部位がくっついている状態かどうか
  SphereCollider leftEarSphereCol;
  OVRGrabbable leftEarGrabbable;
// 体
  GameObject body;
  Vector3 bodyPosition;
  Rigidbody bodyRigidbody;
  bool isbodySticked = false; //体と部位がくっついている状態かどう
  bool isbodyStickedEnable = false; //くっつけることが可能かどうか
  SphereCollider bodySphereCol;
  OVRGrabbable bodyGrabbable;
  // 足
  GameObject feet;
  Vector3 feetPosition;
  Vector3 feetRotation;
  Rigidbody feetRigidbody;
  bool isFeetSticked = false; //体と部位がくっついている状態かどう
  bool isFeetStickedEnable = false; //くっつけることが可能かどうか
  BoxCollider feetBoxCol;
  OVRGrabbable feetGrabbable;

  private Text positionText;


  void Start() {
    potatoHead = GameObject.Find("PotatoHead");
    // 右目
    rightEye = GameObject.Find("PotatoHead/RightEye");
    rightEyeHolder= GameObject.Find("OVRPlayerController/RightEyeHolder");
    rightEyeSphereCol=rightEye.GetComponent<SphereCollider>();
    rightEyeGrabbable=rightEye.GetComponent<OVRGrabbable>();
    // 右腕
    rightArm = GameObject.Find("PotatoHead/RightArm");
    // rightArmJoint = GameObject.Find("PotatoHead/RightArm/Joint");
    rightShoulder = GameObject.Find("OVRPlayerController/RightShoulder");
    rightArmBoxCol=rightArm.GetComponent<BoxCollider>();
    rightArmGrabbable=rightArm.GetComponent<OVRGrabbable>();
    // 右手
    rightHand=GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/RightHandAnchor");
    // 右耳
    rightEar = GameObject.Find("PotatoHead/RightEar");
    rightEarHolder = GameObject.Find("OVRPlayerController/RightEarHolder");
    rightEarSphereCol=rightEar.GetComponent<SphereCollider>();
    rightEarGrabbable=rightEar.GetComponent<OVRGrabbable>();
    // 左目
    leftEye = GameObject.Find("PotatoHead/LeftEye");
    leftEyeHolder= GameObject.Find("OVRPlayerController/LeftEyeHolder");
    leftEyeSphereCol=leftEye.GetComponent<SphereCollider>();
    leftEyeGrabbable=leftEye.GetComponent<OVRGrabbable>();
    // 左腕
    leftArm = GameObject.Find("PotatoHead/LeftArm");
    // leftArmJoint = GameObject.Find("PotatoHead/LeftArm/Joint");
    leftShoulder = GameObject.Find("OVRPlayerController/LeftShoulder");  
    leftArmBoxCol=leftArm.GetComponent<BoxCollider>();  
    leftArmGrabbable=leftArm.GetComponent<OVRGrabbable>();  
    // 左手
    leftHand=GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/LeftHandAnchor");
    // 左耳
    leftEar = GameObject.Find("PotatoHead/LeftEar");
    leftEarHolder = GameObject.Find("OVRPlayerController/LeftEarHolder");
    leftEarSphereCol=leftEar.GetComponent<SphereCollider>();
    leftEarGrabbable=leftEar.GetComponent<OVRGrabbable>();
    // 体
    body = GameObject.Find("PotatoHead/Body");
    OVRPlayerControllerCenter = GameObject.Find("OVRPlayerController");
    bodySphereCol=body.GetComponent<SphereCollider>();
    bodyGrabbable=body.GetComponent<OVRGrabbable>();
    // 足
    feet = GameObject.Find("PotatoHead/Feet");
    feetBoxCol=feet.GetComponent<BoxCollider>();
    feetGrabbable=feet.GetComponent<OVRGrabbable>();
    // オブジェクトからTextコンポーネントを取得
    positionText = textObject.GetComponent<Text>();
    positionText.text = "このtextが表示される";
    // ゲーム開始2秒後に体のパーツをくっつけることが可能
    Invoke("ToEnableSticked",3.0f);
    Invoke("ToEyeSleep",3.0f);
  }

  void Update() {
    // 体
    bodyPosition=body.transform.position;
    feetPosition=feet.transform.position;
    feetRotation=feet.transform.localEulerAngles;
    if(isbodyStickedEnable){
      if(Vector3.Distance(bodyPosition, feetPosition)<=2){
        numParts+=1;
        isbodySticked=true;
        bodySphereCol.enabled=false;
        bodyRigidbody.isKinematic=true;
        body.transform.position = new Vector3(feetPosition.x, feetPosition.y, feetPosition.z);
        body.transform.rotation = Quaternion.Euler(0,feetRotation.y+180,90);
        isbodyStickedEnable=false;
      }
    }
    if (isbodySticked) {
      body.transform.position = new Vector3(feetPosition.x-0.423f, feetPosition.y+1.475f, feetPosition.z-0.2448f);
        body.transform.rotation = Quaternion.Euler(0,feetRotation.y+180,90);
    }
    // 足
    if (isFeetSticked) {
      feet.transform.position = new Vector3(OVRPlayerControllerCenterPosition.x-0.558f, OVRPlayerControllerCenterPosition.y+1.33f, OVRPlayerControllerCenterPosition.z-0.467f);
    }
    //右腕
    rightShoulderPosition = rightShoulder.transform.position;
    rightArmPosition=rightArm.transform.position;
    if(isRightArmStickedEnable){
      if(Vector3.Distance(bodyPosition, rightArmPosition)<=2){
        numParts+=1;
        rightArmRigidbody.isKinematic = true;
        isRightArmSticked=true;
        rightArmBoxCol.enabled=false;
        rightArm.transform.parent=body.transform;
        isRightArmStickedEnable=false;
      }
    }
    if (isRightArmSticked) {
    // ジョイコンの動きによって右腕を動かす
      rightArmVec = rightHand.transform.position - rightShoulder.transform.position;
      var rightArmAngleZ = Vector3.SignedAngle(-Vector3.up, new Vector3(rightArmVec.x,rightArmVec.y,0), -Vector3.forward) ; 
      rightArm.transform.localPosition = new Vector3(-2f, 1.19f,2.65f);
      rightArm.transform.localRotation = Quaternion.Euler(90,0, rightArmAngleZ);
    }
    //右手
    rightHandPosition=rightHand.transform.position;
    //右目
    rightEyePosition = rightEye.transform.position;
    rightEyeHolderPosition = rightEyeHolder.transform.position;
    if(isRightEyeStickedEnable){
      if(Vector3.Distance(bodyPosition, rightEyePosition)<=1.8f){
        numParts+=1;
        isRightEyeSticked=true;
        rightEyeSphereCol.enabled=false;
        rightEye.transform.parent=body.transform;
        isRightEyeStickedEnable=false;
      }
    }
    if (isRightEyeSticked){
      rightEye.transform.localPosition = new Vector3(-1.71f,1.56f,0.95f);
      rightEye.transform.localRotation = Quaternion.Euler(0,0,0);
    }
    //右耳
    rightEarPosition = rightEar.transform.position;
    rightEarHolderPosition = rightEarHolder.transform.position;
    //右耳をつかんでいるとき
    if (rightEarGrabbable.isGrabbed) {
      isRightEarSticked = false;
      rightEarRigidbody.isKinematic = true;
    }
    if (isRightEarSticked){
      rightEar.transform.position = new Vector3(rightEarHolderPosition.x, rightEarHolderPosition.y, rightEarHolderPosition.z);
      rightEar.transform.rotation = Quaternion.Euler(0,0,-75);
    }
    // 左腕
    leftShoulderPosition = leftShoulder.transform.position;
    leftArmPosition=leftArm.transform.position;
    if(isLeftArmStickedEnable){
      if(Vector3.Distance(bodyPosition, leftArmPosition)<=2){
        numParts+=1;
        leftArmRigidbody.isKinematic = true;
        isLeftArmSticked=true;
        leftArmBoxCol.enabled=false;
        leftArm.transform.parent=body.transform;
        isLeftArmStickedEnable=false;
      }
    }
    if (isLeftArmSticked) {
      // ジョイコンの動きによって左腕を動かす
      leftArmVec = leftHand.transform.position - leftShoulder.transform.position;
      var leftArmAngleZ = Vector3.SignedAngle(-Vector3.up, new Vector3(leftArmVec.x,leftArmVec.y,0), -Vector3.forward) ; 
      leftArm.transform.localPosition = new Vector3(-1.77f, 0.5f,-0.07f);
      leftArm.transform.localRotation = Quaternion.Euler(180f,-90f-leftArmAngleZ, 90f);
    }
    //左目
    leftEyePosition = leftEye.transform.position;
    leftEyeHolderPosition = leftEyeHolder.transform.position;
    if(isLeftEyeStickedEnable){
      if(Vector3.Distance(bodyPosition, leftEyePosition)<=1.8f){
        numParts+=1;
        isLeftEyeSticked=true;
        leftEyeSphereCol.enabled=false;
        leftEye.transform.parent=body.transform;
        isLeftEyeStickedEnable=false;
      }
    }
    if (isLeftEyeSticked) {
      leftEye.transform.localPosition = new Vector3(-1.71f,1.56f,1.81f);
      leftEye.transform.localRotation = Quaternion.Euler(0,0,0);
    }
    //左耳
    leftEarPosition = leftEar.transform.position;
    leftEarHolderPosition = leftEarHolder.transform.position;
    //左耳をつかんでいるとき
    if (leftEarGrabbable.isGrabbed) {
      isLeftEarSticked = false;
      leftEarRigidbody.isKinematic = true;
    }
    if (isLeftEarSticked) {
      leftEar.transform.position = new Vector3(leftEarHolderPosition.x, leftEarHolderPosition.y, leftEarHolderPosition.z);
      leftEar.transform.rotation = Quaternion.Euler(0,0,75);
    }
    // オブジェクトをくっつける処理
    if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger) || OVRInput.GetUp(OVRInput.RawButton.LHandTrigger)) {
      // 右目
      // if ((Vector3.Distance(rightEyePosition, rightEyeHolderPosition)) <= 0.5) {
      //   isRightEyeSticked = true;
      //   rightEyeRigidbody.isKinematic = true;
      //   rightEyeSphereCol.enabled=false;
      //   rightEyeGrabbable.enabled=false;
      // } else {
      //   rightEyeRigidbody.isKinematic = false;
      // }
      // 右耳
      if ((Vector3.Distance(rightEarPosition, rightEarHolderPosition)) <= 0.5) {
        isRightEarSticked = true;
        rightEarRigidbody.isKinematic = true;
        rightEarSphereCol.enabled=false;
        rightEarGrabbable.enabled=false;
        numParts+=1;
      } else {
        rightEyeRigidbody.isKinematic = false;
      }
      // 左目
      // if ((Vector3.Distance(leftEyePosition, leftEyeHolderPosition)) <= 0.5) {
      //   isLeftEyeSticked = true;
      //   leftEyeRigidbody.isKinematic = true;
      //   leftEyeSphereCol.enabled=false;
      //   leftEyeGrabbable.enabled=false;
      // } else {
      //   leftEyeRigidbody.isKinematic = false;
      // }
      // 左耳
      if ((Vector3.Distance(leftEarPosition, leftEarHolderPosition)) <= 0.5) {
        isLeftEarSticked = true;
        leftEarRigidbody.isKinematic = true;
        leftEarSphereCol.enabled=false;
        leftEarGrabbable.enabled=false;
        numParts+=1;
      } else {
        leftEyeRigidbody.isKinematic = false;
      }
      if(numParts==7){
        SceneManager.LoadScene("Ending");
      }
    }
    // テスト用
    positionText.text="Body.position"+(body.transform.position).ToString()+"\nFeet.position"+(feet.transform.position).ToString()+"\ndistance"+(Vector3.Distance(body.transform.position, feet.transform.position)).ToString();
    Debug.Log(Vector3.Distance(body.transform.position, rightArm.transform.position));
   
    if (Input.GetKeyDown("a")) {
      Debug.Log("test7");
      rightArmRigidbody.isKinematic = true;
      isRightArmSticked = true;
      leftArmRigidbody.isKinematic = true;
      isLeftArmSticked = true;
      leftArmBoxCol.enabled=false;
      rightArmBoxCol.enabled=false;
      rightEyeRigidbody.isKinematic = true;
      isRightEyeSticked = true;
      leftEyeRigidbody.isKinematic = true;
      isLeftEyeSticked = true;
      bodyRigidbody.isKinematic = true;
      isbodySticked = true;
      leftEarRigidbody.isKinematic = true;
      isLeftEarSticked = true;
      rightEarRigidbody.isKinematic = true;
      isRightEarSticked = true;
      // feetRigidbody.isKinematic = true;
      isFeetSticked = true;
    }
  }
  // 物体にrigidbodyのcomponentを付ける
  public void GiveRigidBody() {
    rightArmRigidbody = rightArm.GetComponent<Rigidbody>();
    leftArmRigidbody = leftArm.GetComponent<Rigidbody>();
    rightEyeRigidbody = rightEye.GetComponent<Rigidbody>();
    leftEyeRigidbody = leftEye.GetComponent<Rigidbody>();
    rightEarRigidbody = rightEar.GetComponent<Rigidbody>();
    leftEarRigidbody = leftEar.GetComponent<Rigidbody>();
    bodyRigidbody=body.GetComponent<Rigidbody>();
    feetRigidbody=feet.GetComponent<Rigidbody>();
  }

// パーツをくっつけるのを可能にする
  void ToEnableSticked(){
    Debug.Log("test6");
    isbodyStickedEnable=true;
    isFeetStickedEnable=true;
    isRightArmStickedEnable=true;
    isLeftArmStickedEnable=true;
    isRightEyeStickedEnable=true;
    isLeftEyeStickedEnable=true;
  }
  
  void ToEyeSleep(){
    // rightEyeRigidbody.isKinematic=true;
    // leftEyeRigidbody.isKinematic=true;
    Destroy(rightEye.GetComponent<Rigidbody>());
    Destroy(leftEye.GetComponent<Rigidbody>());

  }
}