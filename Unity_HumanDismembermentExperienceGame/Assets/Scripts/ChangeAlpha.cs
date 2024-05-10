using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// CanvasGroupコンポーネントがアタッチされていない場合、アタッチ
[RequireComponent(typeof(CanvasGroup))]
public class ChangeAlpha : MonoBehaviour
{
    //add 1/25
    bool counter = false;

    GameObject textchan; //textちゃんそのものが入る変数
    TextDisplay script; //TextDisplayが入る変数

    // フェードさせる時間を設定
    [SerializeField]
    [Tooltip("フェードさせる時間(秒)")]
    private float fadeTime=1f;
    // 経過時間を取得
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        // このゲームオブジェクトのCanvasGroupコンポーネントを取得して、
        // alpha値を0(透明）にする。
        this.gameObject.GetComponent<CanvasGroup>().alpha = 1;

        textchan = GameObject.Find ("Text"); //textちゃんをオブジェクトの名前から取得して変数に格納する
        script = textchan.GetComponent<TextDisplay>(); //textchanの中にあるTextChanScriptを取得して変数に格納する
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == true){
            // 経過時間を加算
            timer += Time.deltaTime;
            // 経過時間をfadeTimeで割った値をalphaに入れる
            // ※alpha値は1(不透明)が最大。
            this.gameObject.GetComponent<CanvasGroup>().alpha = 1 - (timer / fadeTime);
        }
        counter = script.alphaFlag; //Textオブジェクト
    }
}
