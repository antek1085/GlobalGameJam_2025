using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointsController : MonoBehaviour
{
    private int points;
    [SerializeField] SO_Int_List so_int_list;

    [SerializeField] private string sceneName;
    [SerializeField] private float time,timeToPass;

    [SerializeField] private TextMeshProUGUI timeObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void addPoints(int newPoints)
    {
        points += newPoints;
    }

    private void Update()
    {
        Timer();
    }

    void onEndGame()
    {
        so_int_list.list.Add(points);
        SceneManager.LoadScene(sceneName);
    }
    
    void Timer()
    {
        time += Time.deltaTime;
        timeObject.text = (timeToPass - time).ToString("00:00");
        if (time >= timeToPass)
        {
            onEndGame();
        }
    }
}
