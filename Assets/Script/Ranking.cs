using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.IO;
using UnityEngine.SceneManagement;

public class Ranking : MonoBehaviour
{
    float Starttime = 20;
    //private string path = "./Piku_Data/Score.txt";
    string path = "./Assets/Data/Score.txt";
    int rankingSize = 7;
    GameObject YourScoreText;


    void Start()
    {
        this.YourScoreText = GameObject.Find("YourScore");
        
        


    }
    private void OnEnable()
    {
        string yourScore = GameDirector.point.ToString();   //データに書き込むからString

        string scoresText = File.ReadAllText(path);         //scoresTextにスコアを入れる
        //データの先頭に追加
        scoresText = yourScore + "\n" + scoresText;
        File.WriteAllText(path, scoresText);                //データ上書き保存

        /////////////////////////////////////////////////////////
        //ランキング作る

        string[] scores = File.ReadAllLines(path);
        int[] intScores = scores.Select(int.Parse).ToArray();
        //ソートしてひっくり返す
        Array.Sort(intScores, (a, b) => b - a);

        int[] topScore = new int[rankingSize];  //表示する分のスコアを入れる配列
        if(intScores.Length < rankingSize)      //足りないとき
        {
            for(int i = 0; i < intScores.Length; i++)
            {
                topScore[i] = intScores[i];
            }
        }
        else
        {
            for (int i = 0; i < rankingSize; i++)
            {
                topScore[i] = intScores[i];
            }
        }

        //配列を改行で区切って1つのテキストに
        string rankingText = string.Join("\n", topScore);

        GetComponent<Text>().text = rankingText;
    }

     void Update()
    {
        this.Starttime -= Time.deltaTime;
        this.YourScoreText.GetComponent<Text>().text = GameDirector.point.ToString();

        if (Starttime <= 0)
        {           
            Debug.Log("Go to the Next Stage");
            GameDirector.point = 0;
            GameDirector.time = 90;
            GameDirector.thereResult = false;
            SceneManager.LoadScene("Start");
        }
    }
}
