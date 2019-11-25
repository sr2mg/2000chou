using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    const double TRILLION = 1000000000000;
    public GameObject scoreT;
    public GameObject DollerT;

    public Text scoreText;
    public Text DollerText;

    double score = 5000*TRILLION;
    double scoreD = 1;
    
    /// <summary>
    ///桁数表示用 
    /// </summary>
    static string[] unit = { "", "万", "億", "兆","京" };
    // Start is called before the first frame update
    void Start()
    {

        int a = Random.Range(0,100);
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = "所持金:"+Test(score)+"円"; //初期スコアを代入して画面に表示

        DollerText = GameObject.Find("Doller").GetComponent<Text>();
        DollerText.text = "所持ドル:" + Test(scoreD) + "ドル";
    }

    //円増減用関数
    public void scoreRD(double sc)
    {
        score += sc;
    }
    public void DollerRD(double doll)
    {
        scoreD += doll;
    }
    public double ConfirmS()
    {
        return score;
    }
    public double ConfirmD()
    {
        return scoreD;
    }

    string Test(double a)
    {
        string str=null;
        double b;
        int c=0;
        int d = 1;

        while (a > 0)
        {
            c++;
            if (c > 4)
            {
                str = unit[d] + str;
                c = 1;
                d++;
            }
            b = a % 10;
            str = b.ToString()+str;
            a -= b;
            a /= 10;


        }
        return str;
    }

    string ToKanji(double num)
    {
        int keta = 0;
        string str="";

        while (keta == 3)
        {

            keta++;
        }

        return str;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "所持金:" + Test(score) + "円"; //初期スコアを代入して画面に表示
        DollerText.text = "所持ドル:" + Test(scoreD) + "ドル";
    }
}
