using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VolumeController : MonoBehaviour
{
    [SerializeField]

    private GameObject btnPref;  //ボタンプレハブ
    rateYDController ydc;
    Text YDText;
    ScoreController SController;
    Text ScoreT;
    Text DollerT;

    //ボタン表示数
    const int BUTTON_COUNT = 6;
    const double TRILLION = 1000000000000;
    // Start is called before the first frame update
    void Start()
    {
        YDText = GameObject.Find("RateYD").GetComponent<Text>();
        ydc = YDText.GetComponent<rateYDController>();


        ScoreT = GameObject.Find("Score").GetComponent<Text>();
        SController = ScoreT.GetComponent<ScoreController>();


        //ボタン並べる場所取得
        RectTransform content = GameObject.Find("Canvas/Scroll View/Viewport/Content").GetComponent<RectTransform>();
        //Contentの高さ決定
        //float btnSpace = content.GetComponent<VerticalLayoutGroup>().spacing;
        float btnHeight = btnPref.GetComponent<LayoutElement>().preferredHeight;
        //content.sizeDelta = new Vector2(0, (btnHeight + btnSpace) * BUTTON_COUNT);
        content.sizeDelta = content.GetComponent<GridLayoutGroup>().spacing;
        for (int i = 0; i < BUTTON_COUNT; i++)
        {
            int no = i;
            //ボタン生成
            GameObject btn = (GameObject)Instantiate(btnPref);
            //ボタンをContentの子に設定
            btn.transform.SetParent(content, false);
            //ボタンのテキスト変更
            switch (no)
            {
                case 0:
                    btn.transform.GetComponentInChildren<Text>().text = "ドル買→1兆円";
                    break;
                case 2:
                    btn.transform.GetComponentInChildren<Text>().text = "ドル買→10兆円";
                    break;
                case 4:
                    btn.transform.GetComponentInChildren<Text>().text = "ドル買→100兆円";
                    break;


                case 1:
                    btn.transform.GetComponentInChildren<Text>().text = "ドル売→100億ドル";
                    break;
                case 3:
                    btn.transform.GetComponentInChildren<Text>().text = "ドル売→1000億ドル";
                    break;
                case 5:
                    btn.transform.GetComponentInChildren<Text>().text = "ドル売→1兆ドル";
                    break;
                default:break;
            }

            //ボタンのクリックイベント登録
            btn.transform.GetComponent<Button>().onClick.AddListener(() => OnClick(no));

        }

    }

    public void OnClick(int no)

    {

        Debug.Log(no);
        switch (no)//ボタン処理（売買処理）
        {
            //ドル買い処理
            case 0:
                if (ydc.ConfirmRate() < 0) break;
                if (SController.ConfirmS()> TRILLION) {
                    SController.scoreRD(-TRILLION);
                    SController.DollerRD(Math.Truncate(TRILLION/ydc.ConfirmRate())*0.99);
                    ydc.Rise_rate(10);
                }
                else
                {
                    SController.scoreRD(-SController.ConfirmS());
                    SController.DollerRD(Math.Truncate(SController.ConfirmS() / ydc.ConfirmRate()));
                }

                break;
            case 2:
                if (ydc.ConfirmRate() < 0) break;
                if (SController.ConfirmS() >= 10*TRILLION)
                {
                    SController.scoreRD(-10*TRILLION);
                    SController.DollerRD(Math.Truncate(10*TRILLION / ydc.ConfirmRate())*0.98);
                    ydc.Rise_rate(30);
                }
                break;
            case 4:
                if (ydc.ConfirmRate() < 0) break;
                if (SController.ConfirmS() >= 100*TRILLION)
                {
                    SController.scoreRD(-100*TRILLION);
                    SController.DollerRD(Math.Truncate(100 * TRILLION / ydc.ConfirmRate())*0.95);
                    ydc.Rise_rate(50);
                }
                break;
                //ドル売り処理
            case 1:
                if (ydc.ConfirmRate() < 0) break;
                if (SController.ConfirmD() > 0.01 * TRILLION)
                {
                    SController.DollerRD(-0.01 * TRILLION);
                    SController.scoreRD(Math.Truncate(TRILLION*0.01 * ydc.ConfirmRate()));
                    ydc.Drop_rate(10);
                }
                break;
            case 3:
                if (ydc.ConfirmRate() < 0) break;
                if (SController.ConfirmD() > 0.1 * TRILLION)
                {
                    SController.DollerRD(-0.1 * TRILLION);
                    SController.scoreRD(Math.Truncate(0.1 * TRILLION * ydc.ConfirmRate()));
                    ydc.Drop_rate(30);
                }
                break;
            case 5:
                if (ydc.ConfirmRate() < 0) break;
                if (SController.ConfirmD() > TRILLION)
                {
                    SController.DollerRD(-TRILLION);
                    SController.scoreRD(Math.Truncate(TRILLION * ydc.ConfirmRate()));
                    ydc.Drop_rate(50);
                }
                break;

        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
