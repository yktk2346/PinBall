using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
    //HingeJointコンポーネントを入れる
        private HingeJoint myHingeJoint;

        //初期の傾き
        private float defaultAngle = 20;
        //弾いた時の傾き
        private float flickAngle = -20;

        // Use this for initialization
        void Start () {
                //HingeJointコンポーネント取得
                this.myHingeJoint = GetComponent<HingeJoint>();

                //フリッパーの傾きを設定
                JointSpring rot = this.myHingeJoint.spring;
                rot.targetPosition = this.defaultAngle;
                this.myHingeJoint.spring = rot;
        }

        // Update is called once per frame
        void Update () {

                //左矢印キーを押した時左フリッパーを動かす
                if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
            //左フリッパーの稼働の内容
            JointSpring leftM = this.myHingeJoint.spring;
            leftM.targetPosition = this.flickAngle;
            this.myHingeJoint.spring = leftM;
                }
                //右矢印キーを押した時右フリッパーを動かす
                if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
            //右フリッパーの稼働の内容
            JointSpring rightM = this.myHingeJoint.spring;
            rightM.targetPosition = this.flickAngle;
            this.myHingeJoint.spring = rightM;
                }

                //左矢印キーが離された時フリッパーを元に戻す
                if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
            //左フリッパーが戻る内容
            JointSpring leftR = this.myHingeJoint.spring;
            leftR.targetPosition = this.defaultAngle;
            this.myHingeJoint.spring = leftR;
                }
        //右矢印キーが離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag" ) {
            //右フリッパーが戻る内容
            JointSpring rightR = this.myHingeJoint.spring;
            rightR.targetPosition = this.defaultAngle;
            this.myHingeJoint.spring = rightR;
        }
        }




    //お手本　SetAngle関数(どこにも適用されていない)
        //フリッパーの傾きを設定
        public void SetAngle (float angle){
                JointSpring jointSpr = this.myHingeJoint.spring;
                jointSpr.targetPosition = angle;
                this.myHingeJoint.spring = jointSpr;
        }
}