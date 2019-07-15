using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ImageManager : MonoBehaviour
{
    public GameObject fitToScanOverlay;
    public AugmentedImage currentAugmentedImage;
    public GameObject currentWorldObject;

    public GameObject worldPrefab;

    private List<AugmentedImage> _tempAugmentedImages = new List<AugmentedImage>();

    void Update()
    {
        if (Session.Status != SessionStatus.Tracking)
            return;

        Session.GetTrackables<AugmentedImage>(_tempAugmentedImages, TrackableQueryFilter.Updated);

        foreach (AugmentedImage image in _tempAugmentedImages)
        {
            if(image.TrackingState == TrackingState.Tracking && currentAugmentedImage == null)
            {
                Anchor anchor = image.CreateAnchor(image.CenterPose);

                currentWorldObject = Instantiate(worldPrefab, anchor.transform);

                currentWorldObject.transform.localEulerAngles = new Vector3(90, 0, 0);
                currentAugmentedImage = image;
            }
            else if(image.TrackingState == TrackingState.Stopped && currentAugmentedImage != null)
            {
                currentAugmentedImage = null;
                Destroy(currentWorldObject);
            }
        }

        if (currentAugmentedImage == null && !fitToScanOverlay.activeSelf)
            fitToScanOverlay.SetActive(true);

        if (currentAugmentedImage != null && fitToScanOverlay.activeSelf)
            fitToScanOverlay.SetActive(false);
    }
}
