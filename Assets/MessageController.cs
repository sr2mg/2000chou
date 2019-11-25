using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    Text MesText;
    rateYDController rYDC;
    int[] Mes;
    Text rYD;

    ScoreController SController;
    Text ScoreText;


    // Start is called before the first frame update
    void Start()
    {
        Mes = new int[50];
        rYD = GameObject.Find("RateYD").GetComponent<Text>();
        rYDC = rYD.GetComponent<rateYDController>();

        MesText = GameObject.Find("Message").GetComponent<Text>();
        MesText.text = "test";


        ScoreText = GameObject.Find("Score").GetComponent<Text>();
        SController = ScoreText.GetComponent<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCondition();
    }

    public void ShowMessages(int MesNum)
    {
        string MesTex="";
        switch (MesNum)
        {
            case 0: {
                    MesTex = "首相が「円の価値はもうない」と宣言しました。";
                    break;
                    }
            case 1:
                {
                    MesTex = "アメリカ大統領が「世界の終わりだ」と宣言しました。";
                    break;
                }
            case 2:
                {
                    MesTex = "アメリカ大統領が「世界の終わりは近い」と宣言しました。";
                    break;
                }
            case 3:
                {
                    MesTex = "おめでとうございます！\n見事5000兆円をドルに換えることができました！\n日本経済は崩壊してしまったので、\nいつまでそのドルが使えるかはわかりませんが…";
                    break;
                }
            case 4:
                {
                    MesTex = "おめでとうございます！\n見事5000兆円をドルに換えることができました！\n経済破綻もせずに乗り切ることができ、裕福な生活ができそうです！";
                    break;
                }
            case 6:
                {
                    MesTex = "おめでとうございます、見事5000兆円をドルに換えることができました！いささか所持金は減ってしまったように思えましたがクリアなことに違いはありません。";
                    break;
                }
        }
        MesText.text = MesTex;

    }

    void DisplayCondition()
    {
        if (rYDC.ConfirmRate() > 180 && Mes[0] == 0) { ShowMessages(0); Mes[0]++; }
        if (rYDC.ConfirmRate() < 50&&Mes[2]==0) { ShowMessages(2); Mes[2]++; }
        if (rYDC.ConfirmRate() < 30&&Mes[1]==0) { ShowMessages(1);Mes[1]++; }
        if (SController.ConfirmS() <= 0)
        {
            if (rYDC.ConfirmRate() < 30||rYDC.ConfirmRate()>150) { ShowMessages(3); } else { ShowMessages(4); }
        }
    }
}
