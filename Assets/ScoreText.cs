using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    //スコアを表示するテキストを作成、空っぽの箱、GameObjectをいれるもの
    private GameObject scoText;
    

    //Start関数内での計算で使うText用の変数、最後はscoTextに値を渡す。ただの計算用紙
    private Text scoreText;

    //スコア計算用の、代入用の変数
    private int Fscore = 0;   //初期値
    private int SSscore = 10;   //SmallStarの得点
    private int LSscore = 30;   //LargeStarの得点
    private int SCscore = 20;   //SmallCloudの得点
    private int LCscore = 100;   //LargeCloudの得点
    


	// Use this for initialization
	void Start () {
        //シーン中のScoreTextオブジェクトを取得することで、スコアボードが表示される下準備
        this.scoText = GameObject.Find("ScoreText");
    }
	


	// Update is called once per frame
	void Update () {
        //ScoreTextにスコアを表示したいため、まずscoTextに計算済みのFscoreを渡す
        scoText.GetComponent<Text>().text =  "score:" + Fscore.ToString();
        //Debug.Log(scoText.text);
	}

    


//ターゲットへ衝突時に呼ばれる関数
void OnCollisionEnter(Collision other) {

        //個別のターゲットに衝突するたび、設定されたtagで判断するため、
        //まずother引数のgameObjectと名付けてタグを取得する下準備
        string otherTag = other.gameObject.tag;
        Debug.Log(other.gameObject);

        //ターゲットの種類をタグで判断する
        if (otherTag == "SmallStarTag"){
            Fscore += SSscore;
        }
        else if (otherTag == "LargeStarTag"){
            Fscore += LSscore;
        }
        else if (otherTag == "SmallCloudTag"){
            Fscore += SCscore;
        }
        else if (otherTag == "LargeCloudTag") {
            Fscore += LCscore;
        }
        }
}