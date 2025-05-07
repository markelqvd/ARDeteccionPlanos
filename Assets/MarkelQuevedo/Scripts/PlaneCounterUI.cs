using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.ARFoundation;

public class PlaneCounterUI : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public TextMeshProUGUI planesCountText;

    void Start()
    {
        if (planeManager != null)
        {
            planeManager.planesChanged += OnPlanesChanged;
            UpdatePlaneCount();
        }
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        UpdatePlaneCount();
    }

    void UpdatePlaneCount()
    {
        planesCountText.text = $"Planes detectados: {planeManager.trackables.count}";
    }
}
