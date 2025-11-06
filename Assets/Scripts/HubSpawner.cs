using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class HubSpawner : MonoBehaviour
{
    public GameObject hubPrefab;
    private GameObject hubInstance;

    private ARRaycastManager raycastManager;
    private ARTrackedImageManager trackedImageManager;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    void Awake()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        if (raycastManager == null)
            Debug.LogError("ARRaycastManager not found!");

        if (trackedImageManager == null)
            Debug.LogWarning("ARTrackedImageManager not found! Image tracking will be disabled.");
    }

    void OnEnable()
    {
        if (trackedImageManager != null)
            trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        if (trackedImageManager != null)
            trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void Update()
    {
        if (hubInstance != null) return;

#if UNITY_EDITOR
        // 🔹 Simulação: tecla "I" spawna hub como se fosse imagem detectada
        if (Input.GetKeyDown(KeyCode.I))
        {
            Vector3 fakeImagePos = new Vector3(0, 0, 0.5f);
            Quaternion fakeImageRot = Quaternion.identity;

            hubInstance = Instantiate(hubPrefab, fakeImagePos, fakeImageRot);
            Debug.Log("Simulated tracked image detected in Editor");
            return;
        }
#endif

        // 🔹 Caso contrário, segue a lógica de toque em plano
        Vector2 screenPos = Vector2.zero;
        bool inputDetected = false;

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            screenPos = Input.mousePosition;
            inputDetected = true;
        }
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            screenPos = Input.GetTouch(0).position;
            inputDetected = true;
        }
#endif

        if (!inputDetected) return;

        if (raycastManager.Raycast(screenPos, s_Hits, TrackableType.PlaneWithinBounds | TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = s_Hits[0].pose;
            hubInstance = Instantiate(hubPrefab, hitPose.position, hitPose.rotation);
            hubInstance.AddComponent<ARAnchor>();
            Debug.Log("Hub spawned on plane at " + hitPose.position);
        }
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        if (hubInstance != null) return;

        foreach (var trackedImage in eventArgs.added)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                SpawnAtImage(trackedImage);
                return;
            }
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            if (hubInstance == null && trackedImage.trackingState == TrackingState.Tracking)
            {
                SpawnAtImage(trackedImage);
                return;
            }
        }
    }

    private void SpawnAtImage(ARTrackedImage trackedImage)
    {
        Pose pose = new Pose(trackedImage.transform.position, trackedImage.transform.rotation);
        hubInstance = Instantiate(hubPrefab, pose.position, pose.rotation, trackedImage.transform);
        Debug.Log("Hub spawned on tracked image: " + trackedImage.referenceImage.name);
    }
}
