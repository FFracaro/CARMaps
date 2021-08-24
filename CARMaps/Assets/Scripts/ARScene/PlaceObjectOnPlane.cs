using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceObjectOnPlane : MonoBehaviour
    {
        bool WasContentAddedToScene = false;

        [SerializeField]
        [Tooltip("Instantiates this prefab on a plane at the touch location.")]
        GameObject m_PlacedPrefab;

        public GameObject placedPrefab
        {
            get { return m_PlacedPrefab; }
            set { m_PlacedPrefab = value; }
        }

        /// <summary>
        /// Invoked whenever an object is placed in on a plane.
        /// </summary>
        public static event Action onPlacedObject;

        ARRaycastManager m_RaycastManager;

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        PinHolder Pins;

        ARPlaneManager planeManager;
        ARPointCloudManager pointManager;

        [SerializeField]
        ARSceneUI ARUI;

        void Awake()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
        }

        private void Start()
        {
            Pins = FindObjectOfType<PinHolder>();
            planeManager = GetComponent<ARPlaneManager>();
            pointManager = GetComponent<ARPointCloudManager>();
        }

        void Update()
        {
            if (!WasContentAddedToScene)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        if (m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
                        {
                            Pose hitPose = s_Hits[0].pose;

                            if (!m_PlacedPrefab.activeSelf)
                                m_PlacedPrefab.SetActive(true);

                            FindObjectOfType<ARSessionOrigin>().MakeContentAppearAt(m_PlacedPrefab.transform, hitPose.position, hitPose.rotation);

                            if (onPlacedObject != null)
                            {
                                onPlacedObject();
                            }

                            Pins.LoadPinsFromMemory();

                            WasContentAddedToScene = true;

                            ARUI.ResetButtonOn(true);

                            ControlPlaneVisibility(false);

                        }
                    }
                }
            }
            /*
            else
            {
                if (Input.touchCount > 1)
                {
                    Touch touch = Input.GetTouch(0);

                    Vector2 TouchPosition = touch.position;

                    if(touch.phase == TouchPhase.Began)
                    {
                        Ray ray = Camera.main.ScreenPointToRay(touch.position);
                        RaycastHit hitObject;

                        if(Physics.Raycast(ray, out hitObject))
                        {
                            if(hitObject.collider.tag == "Pin")
                            {
                                hitObject.collider.gameObject.GetComponent<PinUI>().OpenClosePinText();
                            }
                        }
                    }
                }
            }*/
        }

        public void ResetScene()
        {
            m_PlacedPrefab.SetActive(false);            

            WasContentAddedToScene = false;

            ControlPlaneVisibility(true);
        }

        private void ControlPlaneVisibility(bool option)
        {
            planeManager.enabled = option;
            pointManager.enabled = option;

            if(pointManager.enabled)
            {
                ARPlanesPointsVisibility(true);
            }
            else
            {
                ARPlanesPointsVisibility(false);
            }
        }

        private void ARPlanesPointsVisibility(bool value)
        {
            planeManager.SetTrackablesActive(value);
            pointManager.SetTrackablesActive(value);
        }

    }
}
