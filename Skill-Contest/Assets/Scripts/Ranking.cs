using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public static int[] scores;
    public static string[] names;
    [SerializeField] InputField input;
    [SerializeField] GameObject infoPrefab;
    [SerializeField] Transform rankingGreed;
    [SerializeField] GameObject restart;

    void Start()
    {
        if(scores == null)
        {
            scores = new int[5] {0,0,0,0,0};
        }
        if(names == null)
        {
            names = new string[5] { "없음", "없음", "없음", "없음", "없음" };
        }

        if(GameManager.lastScore > Mathf.Min(scores))
        {
            input.gameObject.SetActive(true);
        }
        else
        {
            restart.SetActive(true);
            rankingGreed.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RequestRanking(string name)
    {
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] < GameManager.lastScore)
            {
                for (int j = scores.Length - 1; j > i; j--)
                {
                    scores[j] = scores[j - 1];
                    names[j] = names[j - 1];
                }
                scores[i] = GameManager.lastScore;
                names[i] = name;
                break;
            }

        }

        for(int i = 0; i < scores.Length; i++)
        {
            Instantiate(infoPrefab, rankingGreed).GetComponentInChildren<Text>().text = names[i] + " : " + scores[i];
        }

        restart.SetActive(true);
        rankingGreed.gameObject.SetActive(true);
    }
}
