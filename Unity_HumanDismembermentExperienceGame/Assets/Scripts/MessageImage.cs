using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// CanvasGroupコンポーネントがアタッチされていない場合、アタッチ
[RequireComponent(typeof(CanvasGroup))]
public class MessageImage : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButton(0) || OVRInput.Get(OVRInput.RawTouch.B)){//クリックされた判定(修正)  
            //表示から非表示
            this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        }
        if (Input.GetMouseButton(1) || OVRInput.Get(OVRInput.RawTouch.A)){//クリックされた判定(修正)  
            //非表示から表示
            this.gameObject.GetComponent<CanvasGroup>().alpha = 1;
        }
    }
}
