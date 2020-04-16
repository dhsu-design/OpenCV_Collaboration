using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Camera Image by Unity's build in Webcam Texture.
/// Rotation is fixed.
/// Still having some scaling issues, might anyone solve?
/// </summary>
public class CameraAcess : MonoBehaviour
{
    static WebCamTexture webcamTexture;
    private Texture fallbackBg;

    public RawImage webcamDisplay;
    public AspectRatioFitter aspectRatioFitter;

    private bool backCam;


    // Start is called before the first frame update
    private void Start()
    {
        //fallback background if we don't get camera access
        fallbackBg = webcamDisplay.texture;

        //check for device cameras
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.LogError("No camera device detected");
            backCam = false;
            return;
        }

        //backcamera gets assigned if available
        for (int i = 0; i < devices.Length; i++)
        {            
            if(!devices[i].isFrontFacing)
            {
                webcamTexture = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                backCam = true;
            }
        }

        //if there is no backcamera we assign the front camera
        if(webcamTexture == null && backCam)
        {
            Debug.LogWarning("Unable to find back camera, assigning front camera");
            for(int i = 0; i < devices.Length; i++)
            {
                if(devices[i].isFrontFacing && backCam)
                {
                    webcamTexture = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                }
            }
        }

        //assigning the webcam texture (camera image) to an raw image
        webcamDisplay.material.mainTexture = webcamTexture;

        if(!webcamTexture.isPlaying)
        {
            webcamTexture.Play();
        }

        //setting the received image to a proper ratio
        float ratio = (float)webcamTexture.width / (float)webcamTexture.height;
        aspectRatioFitter.aspectRatio = ratio;

        //webcam texture has weird rotations by default
        float scaleY = webcamTexture.videoVerticallyMirrored ? -1f : 1f;
        webcamDisplay.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orientation = -webcamTexture.videoRotationAngle;
        webcamDisplay.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }
}
