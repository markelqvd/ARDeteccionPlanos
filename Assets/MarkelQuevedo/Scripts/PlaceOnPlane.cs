using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceOnPlane : PressInputBase
    {
        [Header("Prefabs")]
        public List<GameObject> prefabs;
        public TMP_Dropdown prefabDropdown;
        public Button clearButton;

        private ARRaycastManager m_RaycastManager;
        private List<GameObject> spawnedObjects = new List<GameObject>();
        private bool m_Pressed;

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        protected override void Awake()
        {
            base.Awake();
            m_RaycastManager = GetComponent<ARRaycastManager>();
        }

        void Start()
        {
            if (prefabDropdown != null)
            {
                prefabDropdown.ClearOptions();
                List<string> options = new List<string>();
                foreach (var prefab in prefabs)
                {
                    options.Add(prefab.name);
                }
                prefabDropdown.AddOptions(options);
            }

            if (clearButton != null)
            {
                clearButton.onClick.AddListener(ClearSpawnedObjects);
            }
        }

        void Update()
        {
            if (Pointer.current == null || m_Pressed == false)
                return;

            var touchPosition = Pointer.current.position.ReadValue();

            if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = s_Hits[0].pose;

                int selectedIndex = prefabDropdown != null ? prefabDropdown.value : 0;
                GameObject selectedPrefab = prefabs[selectedIndex];

                GameObject newObject = Instantiate(selectedPrefab, hitPose.position, hitPose.rotation);
                spawnedObjects.Add(newObject);
            }
        }

        protected override void OnPress(Vector3 position) => m_Pressed = true;
        protected override void OnPressCancel() => m_Pressed = false;

        private void ClearSpawnedObjects()
        {
            foreach (var obj in spawnedObjects)
            {
                Destroy(obj);
            }
            spawnedObjects.Clear();
        }
    }
}
