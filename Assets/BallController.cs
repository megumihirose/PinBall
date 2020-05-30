using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    GameObject pointText;
    int point = 0;

    public void GetLargeStar(){
        this.point += 50;
    }

    public void GetLargeCloud(){
        this.point += 100;
    }

    public void GetSmallCloud(){
        this.point += 50;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LargeStarTag")
        {
            this.GetLargeStar();  
        }

        if (collision.gameObject.tag == "LargeCloudTag")
        {
            this.GetLargeCloud();
        }
        if (collision.gameObject.tag == "SmallCloudTag")
        {
            this.GetSmallCloud();
        }
   
    }

    // Use this for initialization
    void Start(){
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.pointText = GameObject.Find("Point");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
        {
            this.pointText.GetComponent<Text>().text =
                this.point.ToString() + " point";
        }
    }
}