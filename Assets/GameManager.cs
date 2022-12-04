using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text text;
    public TMP_InputField input;
    Save save = new Save();
    
    public void setA1()
    {
        PlayerPrefs.SetString("A1", input.text);
    }

    public void getA1()
    {
        string temp = PlayerPrefs.GetString("A1");
        text.SetText(temp);
    }

    public void SaveData()
    {
        string saveJson = JsonUtility.ToJson(save);
        PlayerPrefs.SetString("save1", saveJson);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("save1"))
        {
            string saveJson = PlayerPrefs.GetString("save1");
            save = JsonUtility.FromJson<Save>(saveJson);
            text.SetText(save.ToString());
        }
    }
}


public class Save
{
    public int number = 56;
    public Vector3 vector3  = new Vector3(3.3f,2.2f,1.2f);
    public bool isBool = true;

    public override string ToString()
    {
        return number.ToString() + Environment.NewLine+
            vector3.ToString() + Environment.NewLine + isBool.ToString();
    }
}