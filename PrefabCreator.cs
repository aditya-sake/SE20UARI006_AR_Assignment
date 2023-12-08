using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Prefabcreator : MonoBehaviour
{
    [SerializeField] private GameObject planePrefab;
    [SerializeField] private Vector3 prefabOffset;

    private GameObject plane;
    private ARTrackedImageManager aRTrackedImageManager;
    

    private void OnEnable()
    {

        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();

        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }


    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            plane = Instantiate(planePrefab, image.transform);
            plane.transform.position += prefabOffset;
        }
    }




}
