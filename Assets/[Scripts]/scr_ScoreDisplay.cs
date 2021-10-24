using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class scr_ScoreDisplay : MonoBehaviour
{
    public string playerPrefKey;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt(playerPrefKey).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
