using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceMultipleObjectsOnPlane : MonoBehaviour
    {
        bool WasContentAddedToScene = false;

        [SerializeField]
        [Tooltip("Instantiates this prefab on a plane at the touch location.")]
        GameObject m_PlacedPrefab;

        /// <summary>
        /// The prefab to instantiate on touch.
        /// </summary>
        public GameObject placedPrefab
        {
            get { return m_PlacedPrefab; }
            set { m_PlacedPrefab = value; }
        }

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        public GameObject spawnedObject { get; private set; }

        /// <summary>
        /// Invoked whenever an object is placed in on a plane.
        /// </summary>
        public static event Action onPlacedObject;

        ARRaycastManager m_RaycastManager;

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        PinHolder Pins;

        void Awake()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
        }

        private void Start()
        {
            Pins = FindObjectOfType<PinHolder>();
        }

        void Update()
        {
            if(!WasContentAddedToScene)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        if (m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
                        {
                            Pose hitPose = s_Hits[0].pose;

                            FindObjectOfType<ARSessionOrigin>().MakeContentAppearAt(m_PlacedPrefab.transform, hitPose.position, hitPose.rotation);
                            //spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);

                            Pins.LoadPinsFromMemory();

                            if (onPlacedObject != null)
                            {
                                onPlacedObject();
                            }

                            WasContentAddedToScene = true;
                        }
                    }
                }
            }
        }
    }
}