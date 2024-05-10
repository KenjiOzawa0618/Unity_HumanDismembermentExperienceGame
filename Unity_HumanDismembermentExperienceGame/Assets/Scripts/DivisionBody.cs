using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionBody: MonoBehaviour {
  
  GameObject potatoHead;
  GameObject body;
  GameObject feet;
  GameObject rightEye;
  GameObject leftEye;
  GameObject rightEar;
  GameObject leftEar;
  GameObject rightArm;
  GameObject leftArm;
  GameObject forScript;
  System.Random random;
  private bool isStick = true;//体が完成状態であるときtrue
  int xForce=350;
  int yForce=250;
  int zForce=350;
  public StickThings stickThings; 

  // Start is called before the first frame update
  void Start() {
    random=new System.Random(0);
    potatoHead = GameObject.Find("PotatoHead");
    body = potatoHead.transform.Find("Body").gameObject;
    rightEye = potatoHead.transform.Find("RightEye").gameObject;
    leftEye = potatoHead.transform.Find("LeftEye").gameObject;
    rightEar = potatoHead.transform.Find("RightEar").gameObject;
    leftEar = potatoHead.transform.Find("LeftEar").gameObject;
    rightArm = potatoHead.transform.Find("RightArm").gameObject;
    leftArm = potatoHead.transform.Find("LeftArm").gameObject;
    feet = potatoHead.transform.Find("Feet").gameObject;
    Invoke("divisionPotato", 1.0f);
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown("c")) {
      rightArm.transform.rotation=Quaternion.Euler(0,0,0);
    }
  }

  void divisionPotato(){
        potatoHead.transform.DetachChildren();
        Rigidbody bodyRigidbody = body.AddComponent<Rigidbody>();
        bodyRigidbody.AddForce(random.Next(-xForce,xForce),yForce,random.Next(-zForce,zForce));
        bodyRigidbody.angularDrag = 100f;
        Rigidbody feetRigidbody = feet.AddComponent<Rigidbody>();
        feetRigidbody.AddForce(random.Next(-xForce,xForce),yForce,random.Next(-zForce,zForce));
        feetRigidbody.angularDrag = 100f;
        Rigidbody rightEyeRigidbody = rightEye.AddComponent<Rigidbody>();
        rightEyeRigidbody.constraints=RigidbodyConstraints.FreezeRotation;
        rightEyeRigidbody.AddForce(random.Next(-xForce,xForce),yForce,random.Next(-zForce,zForce));
        rightEyeRigidbody.angularDrag = 100f;
        Rigidbody leftEyeRigidbody = leftEye.AddComponent<Rigidbody>();
        leftEyeRigidbody.constraints=RigidbodyConstraints.FreezeRotation;
        leftEyeRigidbody.AddForce(random.Next(-xForce,xForce),yForce,random.Next(-zForce,zForce));
        leftEyeRigidbody.angularDrag = 100f;
        Rigidbody rightEarRigidbody = rightEar.AddComponent<Rigidbody>();
        rightEarRigidbody.AddForce(random.Next(-xForce,xForce),yForce,random.Next(-zForce,zForce));
        rightEarRigidbody.angularDrag = 100f;
        Rigidbody leftEarRigidbody = leftEar.AddComponent<Rigidbody>();
        leftEarRigidbody.AddForce(random.Next(-xForce,xForce),yForce,random.Next(-zForce,zForce));
        leftEarRigidbody.angularDrag = 100f;
        Rigidbody rightArmRigidbody = rightArm.AddComponent<Rigidbody>();
        rightArmRigidbody.constraints=RigidbodyConstraints.FreezeRotation;
        rightArm.transform.rotation=Quaternion.Euler(0,0, 0);
        rightArmRigidbody.AddForce(random.Next(-xForce,xForce),yForce,random.Next(-zForce,zForce));
        Rigidbody leftArmRigidbody = leftArm.AddComponent<Rigidbody>();
        leftArmRigidbody.constraints=RigidbodyConstraints.FreezeRotation;
        leftArm.transform.rotation=Quaternion.Euler(0,0, 0);
        leftArmRigidbody.AddForce(random.Next(-xForce,xForce),yForce,random.Next(-zForce,zForce));
        
        forScript=GameObject.Find("ForScript");
        forScript.GetComponent<StickThings>().GiveRigidBody();
  }

  void OnCollisionEnter(Collision collision) {
    if (isStick) {
      if (collision.gameObject.name == "Plane") {
        Debug.Log("地面と衝突");
        potatoHead.transform.DetachChildren();
        Rigidbody bodyRigidbody = body.AddComponent<Rigidbody>();
        bodyRigidbody.AddForce(random.Next(-xForce,xForce),yForce,random.Next(-zForce,zForce));
        bodyRigidbody.angularDrag = 100f;
        Rigidbody feetRigidbody = feet.AddComponent<Rigidbody>();
        feetRigidbody.AddForce(random.Next(-xForce,xForce),yForce,random.Next(-zForce,zForce));
        feetRigidbody.angularDrag = 100f;
        Rigidbody rightEyeRigidbody = rightEye.AddComponent<Rigidbody>();
        rightEyeRigidbody.constraints=RigidbodyConstraints.FreezeRotation;
        rightEyeRigidbody.AddForce(random.Next(-xForce,xForce),yForce,random.Next(-zForce,zForce));
        rightEyeRigidbody.angularDrag = 100f;
        Rigidbody leftEyeRigidbody = leftEye.AddComponent<Rigidbody>();
        leftEyeRigidbody.constraints=RigidbodyConstraints.FreezeRotation;
        leftEyeRigidbody.AddForce(random.Next(-xForce,xForce),yForce,random.Next(-zForce,zForce));
        leftEyeRigidbody.angularDrag = 100f;
        Rigidbody rightEarRigidbody = rightEar.AddComponent<Rigidbody>();
        rightEarRigidbody.AddForce(random.Next(-xForce,xForce),yForce,random.Next(-zForce,zForce));
        rightEarRigidbody.angularDrag = 100f;
        Rigidbody leftEarRigidbody = leftEar.AddComponent<Rigidbody>();
        leftEarRigidbody.AddForce(random.Next(-xForce,xForce),yForce,random.Next(-zForce,zForce));
        leftEarRigidbody.angularDrag = 100f;
        Rigidbody rightArmRigidbody = rightArm.AddComponent<Rigidbody>();
        rightArmRigidbody.constraints=RigidbodyConstraints.FreezeRotation;
        rightArm.transform.rotation=Quaternion.Euler(0,0, 0);
        rightArmRigidbody.AddForce(random.Next(-xForce,xForce),yForce,random.Next(-zForce,zForce));
        Rigidbody leftArmRigidbody = leftArm.AddComponent<Rigidbody>();
        leftArmRigidbody.constraints=RigidbodyConstraints.FreezeRotation;
        leftArm.transform.rotation=Quaternion.Euler(0,0, 0);
        leftArmRigidbody.AddForce(random.Next(-xForce,xForce),yForce,random.Next(-zForce,zForce));
        
        forScript=GameObject.Find("ForScript");
        forScript.GetComponent<StickThings>().GiveRigidBody();
      }
      isStick = false;
    }
  }

}
