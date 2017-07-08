using System;
using System.Collections.Generic;

namespace UnityEngine.XR.iOS
{
	public class UnityARGeneratePlane : MonoBehaviour
	{
		public GameObject planePrefab;
        private UnityARAnchorManager unityARAnchorManager;

		private bool _debugPlanesActive; 
		public bool debugPlanesActive {
			get {
				return _debugPlanesActive;
			}
			set {
				_debugPlanesActive = value;
				CreatePlaneInSceneCallback ();
			}
		}

		// Use this for initialization
		void Start () {
			debugPlanesActive = false;

            unityARAnchorManager = new UnityARAnchorManager();
			UnityARUtility.InitializePlanePrefab (planePrefab);
			UnityARUtility.onCreatePlaneInScene += CreatePlaneInSceneCallback;
		}

        void OnDestroy()
        {
            unityARAnchorManager.Destroy ();
        }

        void OnGUI()
        {
            List<ARPlaneAnchorGameObject> arpags = unityARAnchorManager.GetCurrentPlaneAnchors ();
            if (arpags.Count >= 1) {
                //ARPlaneAnchor ap = arpags [0].planeAnchor;
                //GUI.Box (new Rect (100, 100, 800, 60), string.Format ("Center: x:{0}, y:{1}, z:{2}", ap.center.x, ap.center.y, ap.center.z));
                //GUI.Box(new Rect(100, 200, 800, 60), string.Format ("Extent: x:{0}, y:{1}, z:{2}", ap.extent.x, ap.extent.y, ap.extent.z));
            }
        }

		void CreatePlaneInSceneCallback() {
			Debug.Log("onCreatePlaneInScene " + Time.deltaTime);

			GameObject[] gos = GameObject.FindGameObjectsWithTag ("DebugPlane");
			foreach(GameObject go in gos) {
				MeshRenderer mr = go.GetComponentInChildren<MeshRenderer> (true);
				mr.enabled = debugPlanesActive;
			}
		}
	}
}

