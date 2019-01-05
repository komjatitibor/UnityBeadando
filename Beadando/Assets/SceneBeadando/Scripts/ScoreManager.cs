using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int _score = 0;
    public string _vege = "";

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Score: " + _score + _vege;
    }
}
