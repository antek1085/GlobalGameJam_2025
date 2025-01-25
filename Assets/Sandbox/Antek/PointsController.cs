using UnityEngine;

public class PointsController : MonoBehaviour
{
    private int points;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void addPoints(int newPoints)
    {
        points += newPoints;
    }
}
