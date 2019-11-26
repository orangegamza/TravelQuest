using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Album : MonoBehaviour {

    public Gallery gallery;
    public GameObject temp;
    public RawImage[] images;
    List<Texture2D> pictures;

    private void Start()
    {
    }

    public void SetGallery()
    {
        pictures = gallery.Get();

        int num = 0;
        if (pictures != null)
        {
            foreach (Texture2D pic in pictures)
            {
                images[num].GetComponent<RawImage>().texture = pic;
                num++;
            }
        }
        else
            Debug.Log("Empty!");
    }
}
