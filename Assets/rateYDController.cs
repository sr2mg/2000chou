using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class rateYDController:MonoBehaviour
{
    public static double rate_YD=100;
    Text YDText;
    double time=0;

    MessageController MessageC;
    Text MessageT;

    void Start()
    {
        YDText = GameObject.Find("RateYD").GetComponent<Text>();
        YDText.text = "円ドル相場:" +ConfirmRate() ; //初期スコアを代入して画面に表示


    }

    private void Update()
    {
        time++;
        if (time % 20 == 0)
        {
            RndRate();
        }
        if (time > 5000) time = 0;
        YDText.text = "円ドル相場:" + ConfirmRate(); //初期スコアを代入して画面に表示
    }

    public void Rise_rate(int rise)
    {
        rate_YD += rise;
    }

    public void Drop_rate(int drop)
    {
        rate_YD -= drop;
    }

    public double ConfirmRate()
    {
        return rate_YD;
    }

    public void RndRate()//レート取得→条件によってRise or Drop
    {
        int Rnd = Random.Range(0, 10);
        double rate = ConfirmRate();
        int RiseDropRnd = Random.Range(0, 10);
        int RiseOrDrop = 0;//-1or 0or1 1なら上昇-1なら現象
        int StandardCorrect = 0;//1ならレート変化率二倍

        //レートの条件分岐(円高)

        if (rate < 80)
        {
            if (RiseDropRnd < 7) RiseOrDrop = 1; else RiseOrDrop = -1;
            if (RiseDropRnd < 5) StandardCorrect = 1;
        }

        if (rate < 50)
        {
            if (RiseDropRnd < 4) RiseOrDrop = 1; else RiseOrDrop = -1;
        }
        if (rate < 30)
        {
            if (RiseDropRnd < 2) RiseOrDrop = 1; else RiseOrDrop = -1;
        }
        if (rate < 10) { RiseOrDrop = -1; }

        //円安
        if (rate > 120)
        {
            if (RiseDropRnd < 7) RiseOrDrop = -1; else RiseOrDrop = 1;
            if (RiseDropRnd < 5) StandardCorrect = 1;
        }

        if (rate > 150)
        {
            if (RiseDropRnd < 4) RiseOrDrop = -1; else RiseOrDrop = 1;
        }

        if (rate > 180)
        {
            if (RiseDropRnd < 2) RiseOrDrop = -1; else RiseOrDrop = 1;
        }


        if (StandardCorrect == 1) Rnd *= 3;//是正
        if(rate < 0) { RiseOrDrop = 2; }
        if (RiseOrDrop == 1) Rise_rate(Rnd); else if(RiseOrDrop==0)Drop_rate(Rnd);
    }


}
