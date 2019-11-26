using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class WebCamPhotoCamera : MonoBehaviour
{
    public GameObject cam;
    WebCamTexture webCamTexture;
    public RawImage rawImage;
    public Gallery gallery;
    
    bool reset;

    void Start()
    {
        webCamTexture = new WebCamTexture();
        rawImage.texture = webCamTexture; //Add Mesh Renderer to the GameObject to which this script is attached to
        webCamTexture.Play();
        reset = false;
    }

    IEnumerator TakePhoto()  // Start this Coroutine on some button click
    {


        // NOTE - you almost certainly have to do this here:

        yield return new WaitForEndOfFrame();


        // it's a rare case where the Unity doco is pretty clear,
        // http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
        // be sure to scroll down to the SECOND long example on that doco page 

        Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
        photo.SetPixels(webCamTexture.GetPixels());
        photo.Apply();

        gallery.Save(photo);

        reset = true;
        
        //Encode to a PNG
        //byte[] bytes = photo.EncodeToPNG();
        //Write out the PNG. Of course you have to substitute your_path for something sensible
        //File.WriteAllBytes("C:\\Games\\TravelQuest\\Assets\\Pictures\\" + "photo.png", bytes);
        
    }

    public void Shot()
    {
        StartCoroutine(TakePhoto());
    }

    private void Update()
    {
        if (reset)
        {
            StopCoroutine(TakePhoto());
            cam.SetActive(false);
            reset = false;
        }
    }

    private void OnDisable()
    {
        webCamTexture.Stop();
    }

    private void OnEnable()
    {
        webCamTexture.Play();
    }
}