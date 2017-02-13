using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchText : MonoBehaviour {
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;
    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    //タッチ座標を認識するための初期値、これより > か < かで左右を認識させる
    float pos = 0.0f;

    //画面サイズ 横幅を取得する
    int halfWidth = Screen.width/2;

    //タッチ関連を入れる箱
    Touch myTouch;




	// Use this for initialization
	void Start () {
        //HingeJointコンポーネントを取得
        myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(defaultAngle);
        }

    // Update is called once per frame
    void Update(){

        for (int i = 0; i < Input.touchCount; i++){
            myTouch = Input.touches[i];
            pos = Input.touches[i].position.x;
        }




        //タッチしていないのに
        //if (myTouch.phase == TouchPhase.Began)
        //SetAngle(flickAngle);
        //を処理して左フリッパーが上がりっぱなしになってしまうため制御する
        if (Input.touchCount > 0) {


            //pos（タッチ座標）をhalfWidth（画面の横幅の半分）と比較し、左右を認識させる
            //タッチ座標が半分より少なかったとき（左だったとき）
            if ((pos < halfWidth && "LeftFripperTag" == tag) || (pos >= halfWidth && "RightFripperTag" == tag)){

                //「 `myTouch`（自作のタッチ関連の箱）の `phase` (タッチの状態？)が 
                //`TouchPhase.Began` (既設のタッチ機能、その中の『タッチされた状態』 )と
                //全く同じだった場合、別の関数で計算していた `SetAngle` に `flickAngle` 
                //などが代入されますよー 」
                if (myTouch.phase == TouchPhase.Began)
                    SetAngle(flickAngle);

                if (myTouch.phase == TouchPhase.Ended)
                    SetAngle(defaultAngle);
            }
        }
    }



    //フリッパーの角度を制御するための機能
    //jointSpr.targetPositionにflickAngleなどを代入したいがための式
    //この関数（SetAngle関数）がないと下記3行をif文の個数ごとにいちいち書かなければ
        public void SetAngle(float angle) {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
        }