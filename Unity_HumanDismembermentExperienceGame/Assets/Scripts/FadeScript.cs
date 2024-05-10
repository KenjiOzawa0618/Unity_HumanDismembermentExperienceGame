using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeScript : MonoBehaviour
{
    
    public string[] texts;//Unity上で入力するstringの配列
    int textNumber;//何番目のtexts[]を表示させるか
    string displayText;//表示させるstring
    int textCharNumber;//何文字目をdisplayTextに追加するか
    int displayTextSpeed; //全体のフレームレートを落とす変数
    bool click;//クリック判定
    bool textStop; //テキスト表示を始めるか

    public bool alphaFlag = false; //透明化スクリプトのためのフラグ
    GameObject image;
    public GameObject text = null;
    private Text displayTextComponent;
    CanvasGroup screenObject;

    TextDisplay textdisplay;

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
        image=GameObject.Find("OVRPlayerController/OVRCameraRig/TitleScreen/Image");
        text=GameObject.Find("OVRPlayerController/OVRCameraRig/TitleScreen/Image/Text");
        displayTextComponent=text.GetComponent<Text>();
        displayTextComponent.text="test";
        screenObject=image.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (textStop == false) //テキストを表示させるif文
        { 
            displayTextSpeed++;
            if (displayTextSpeed % 10 == 0)//５回に一回プログラムを実行するif文
            {

                if (textCharNumber != texts[textNumber].Length)//もしtext[textNumber]の文字列の文字が最後の文字じゃなければ
                {
                    displayText = displayText + texts[textNumber][textCharNumber];//displayTextに文字を追加していく
                    textCharNumber = textCharNumber + 1;//次の文字にする
                }
                else//もしtext[textNumber]の文字列の文字が最後の文字だったら
                {
                    if (textNumber != texts.Length - 1)//もしtexts[]が最後のセリフじゃないときは
                    {
                        if (click == true || OVRInput.Get(OVRInput.RawTouch.A))//クリックされた判定(修正)
                        {
                            displayText = "";//表示させる文字列を消す
                            textCharNumber = 0;//文字の番号を最初にする
                            textNumber = textNumber + 1;//次のセリフにする
                        }
                    }
                    else //もしtexts[]が最後のセリフになったら
                    { 
                        if (click == true || OVRInput.Get(OVRInput.RawTouch.A)) //クリックされた判定(修正)
                        { 
                            displayText = ""; //表示させる文字列も消す
                            textCharNumber = 0; //文字の番号を最初にする
                            textStop = true; //セリフ表示を止める

                            alphaFlag = true;

                        } 
                    } 
                }

                displayTextComponent.text = displayText;//画面上にdisplayTextを表示
                click = false;//クリックされた判定を解除
            }
            if (Input.GetMouseButton(0))//マウスをクリックしたら
            {
                click = true; //クリックされた判定にする
            }
        } 
        if (alphaFlag == true){ //60フレームだから1回クリックしてるつもりでも数フレームにわたってクリックしている判定になってるっぽい

                                // 経過時間を加算
                                timer += Time.deltaTime;
                                // 経過時間をfadeTimeで割った値をalphaに入れる
                                // ※alpha値は1(不透明)が最大。
                                screenObject.alpha = 1 - (timer / fadeTime);
                            }
    }
}
