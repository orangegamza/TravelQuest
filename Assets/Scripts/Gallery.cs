using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallery : MonoBehaviour {

    List<Texture2D> Pictures;
    int num = 0;

    private void Start()
    {
        Pictures = new List<Texture2D>();
    }

    public void Save(Texture2D photo)
    {
        Pictures.Add(photo);
        num++;
        Debug.Log("Saved!");
        Debug.Log(num);
    }

    public List<Texture2D> Get()
    {
        if (num != 0)
            return Pictures;
        else
            return null;
    }
}
