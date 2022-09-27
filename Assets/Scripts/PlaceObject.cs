using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceObject : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToSpawn;

    private GameObject spawnedObject;
    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GameObject.FindObjectOfType<ARPlaneManager>();
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedObject == null)
            {
                planeManager.enabled = false;
                hitPose.rotation.y = Camera.main.transform.rotation.y;
                spawnedObject = Instantiate(objectToSpawn, hitPose.position, hitPose.rotation);
                foreach (var trackable in planeManager.trackables)
                {
                    trackable.gameObject.SetActive(false);
                }
            }
        }
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
            return true;
        }
        touchPosition = default;
        return false;
    }
}
