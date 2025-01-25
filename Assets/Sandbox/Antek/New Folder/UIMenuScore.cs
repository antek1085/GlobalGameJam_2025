using System;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuScore : MonoBehaviour
{
    [SerializeField] private SO_Int_List scoreList;
    [SerializeField] private GameObject scorePanel;
    private void Awake()
    {
        scoreList.list.Sort();
        for (int i = scoreList.list.Count -1; i >= 0; i--)
        {
            var panel = Instantiate(scorePanel,transform);
            panel.GetComponent<Text>().text = scoreList.list[i].ToString();
        }   
    }
}
