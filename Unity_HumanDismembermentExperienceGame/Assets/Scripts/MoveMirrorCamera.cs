using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MoveMirrorCamera: MonoBehaviour {
  public GameObject textObject = null; // Textオブジェクト
  public GameObject cameraRigObject = null; // cameraRigオブジェクト
  public GameObject mirrorSufaceObject = null; // mirrorオブジェクト
  public GameObject mirrorCameraObject = null; // mirrorCameraオブジェクトk


  private double mirrorTan; //mirrorのtan
  private double mirrorCameraXPosition;
  private double mirrorCameraYPosition;
  private double mirrorCameraZPosition;
  private Text positionText;
  private Renderer mirrorRender;
  private Camera mirrorCamera;

  // 初期化
  void Start() {
    // オブジェクトからTextコンポーネントを取得
    positionText = textObject.GetComponent<Text>();
    Vector3 mirrorRotation = mirrorSufaceObject.transform.eulerAngles; //Mirrorの回転値
    double mirrorRadians = mirrorRotation.y * (Math.PI / 180);
    mirrorTan = Math.Tan(mirrorRadians);

    mirrorRender = mirrorSufaceObject.GetComponent<Renderer>();
    mirrorCamera = mirrorCameraObject.GetComponent<Camera>();
    positionText.text = "このtextが表示される";
  }

  // 更新
  void Update() {
    //座標移動
    Vector3 cameraRigPosition = cameraRigObject.transform.position; //現在のcameraRigの座標
    Vector3 mirrorPosition = mirrorSufaceObject.transform.position; //現在のmirrorの座標
    Vector3 mirrorCameraPosition = mirrorCameraObject.transform.position; //現在のmirrorCameraの座標
    mirrorCameraXPosition = (2 * mirrorTan * mirrorPosition.z + 2 * Math.Pow(mirrorTan, 2) * mirrorPosition.x + cameraRigPosition.x - 2 * mirrorTan * cameraRigPosition.z - Math.Pow(mirrorTan, 2) * cameraRigPosition.x) / (Math.Pow(mirrorTan, 2) + 1);
    mirrorCameraYPosition = cameraRigPosition.y;
    mirrorCameraZPosition = (-2 * mirrorTan * cameraRigPosition.x + Math.Pow(mirrorTan, 2) * cameraRigPosition.z + 2 * mirrorPosition.z + 2 * mirrorTan * mirrorPosition.x - cameraRigPosition.z) / (Math.Pow(mirrorTan, 2) + 1);
    mirrorCameraObject.transform.position = new Vector3((float)mirrorCameraXPosition, (float)mirrorCameraYPosition, (float)mirrorCameraZPosition);

    // mirrorをcameraRig方向に向ける
    // mirrorSufaceObject.transform.rotation = Quaternion.LookRotation(mirrorSufaceObject.transform.position - cameraRigObject.transform.position);
    //mirrorCameraを鏡に向ける
    mirrorCameraObject.transform.rotation = Quaternion.LookRotation(mirrorSufaceObject.transform.position - mirrorCameraObject.transform.position);
    //y軸以外の回転はしないようにする(ローカル座標を基準に回転)
    //(https://www.sejuku.net/blog/51521)
    Vector3 localAngle = mirrorSufaceObject.transform.localEulerAngles;
    localAngle.x = 0;
    localAngle.z = 0;
    // mirrorSufaceObject.transform.localEulerAngles = localAngle;

    // テキストの表示を入れ替える
    positionText.text = ((-cameraRigPosition.x + mirrorPosition.x) / mirrorSufaceObject.transform.lossyScale.x).ToString() + "\n" + (
    (-cameraRigPosition.y + mirrorPosition.y) / mirrorSufaceObject.transform.lossyScale.y).ToString();

    //mirrorCameraの画角を設定
    var distance = Vector3.Distance(mirrorSufaceObject.transform.position, mirrorCameraObject.transform.position);
    var height = mirrorSufaceObject.transform.lossyScale.y;
    mirrorCamera.fieldOfView = 2 * Mathf.Atan(height / (2 * distance)) * Mathf.Rad2Deg;
  }
}
