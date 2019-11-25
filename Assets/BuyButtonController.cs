using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButtonController : MonoBehaviour
{

    public Collider2D thiscol;
    Text YDText;
    rateYDController ydc;

    void Start()
    {

        Vector2 thisCollider = GameObject.Find("buy_button").transform.position;

        //円ドル系読み込み
        YDText = GameObject.Find("RateYD").GetComponent<Text>();
        ydc = YDText.GetComponent<rateYDController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OnTouchDown())
        {
            
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);//スクリーンから見たマウスの座標を得る
            //コライダーを持つオブジェクト＝クリックされた場所の座標
            Collider2D collider = Physics2D.OverlapPoint(tapPoint);

            //変更：コライダーが取得出来た時だけ処理する
            if (collider == thiscol)
            {
                Debug.Log("Buyタップされました");
                ydc.Rise_rate(10);
            }
        }

            //スマホ向け そのオブジェクトがタッチされていたらtrue（マルチタップ対応）
        bool OnTouchDown()
        {
            if (Input.GetMouseButtonDown(0)) { return true; }

            // タッチされているとき
            if (0 < Input.touchCount)
            {
                // タッチされている指の数だけ処理
                for (int i = 0; i < Input.touchCount; i++)
                {
                    // タッチ情報をコピー
                    Touch t = Input.GetTouch(i);
                    // タッチしたときかどうか
                    if (t.phase == TouchPhase.Began)
                    {
                        //タッチした位置からRayを飛ばす
                        Ray ray = Camera.main.ScreenPointToRay(t.position);
                        RaycastHit hit = new RaycastHit();
                        if (Physics.Raycast(ray, out hit))
                        {
                            //Rayを飛ばしてあたったオブジェクトが自分自身だったら
                            if (hit.collider.gameObject == this.gameObject)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false; //タッチされてなかったらfalse
        }
    }

}
