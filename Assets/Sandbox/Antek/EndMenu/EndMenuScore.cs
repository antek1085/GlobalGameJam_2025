using System;
using TMPro;
using UnityEngine;

public class EndMenuScore : MonoBehaviour
{
    [SerializeField] private SO_Int_List list;
    private void Awake()
    {
        int index = list.list.Count - 1;
        GetComponent<TextMeshProUGUI>().text = "Score: " + list.list[index];
    }
}
