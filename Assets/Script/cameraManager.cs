using UnityEngine;
using System.Collections;

public class cameraManager : MonoBehaviour {

	MapCreate mapCreate;

	public GameObject focusObject;

	float drawHeight;
	float drawWidth;

	// Use this for initialization
	void Start () {
		mapCreate = GameObject.Find ("MapCreate").GetComponent<MapCreate> ();

		drawHeight = (float)(GetComponent<Camera> ().orthographicSize * 2.0);
		drawWidth = (float)(GetComponent<Camera> ().orthographicSize * 2.0 / Screen.height * Screen.width);

		setFocusObject (GameObject.Find ("chara_jaik"));
	}

	public void setFocusObject(GameObject obj) {
		focusObject = obj;
	}
	
	// Update is called once per frame
	void Update () {
		if (focusObject != null) {
			float cx = focusObject.transform.position.x;
			float cy = focusObject.transform.position.y;
			float cz = -100.0f;

			if (cx <= drawWidth / 2 - mapCreate.chipSize/2) {
				cx = drawWidth / 2 - mapCreate.chipSize/2;
			}
			if (cx >= mapCreate.mapXSize * mapCreate.chipSize - drawWidth / 2 - mapCreate.chipSize/2) {
				cx = mapCreate.mapXSize * mapCreate.chipSize - drawWidth / 2 - mapCreate.chipSize/2;
			}
			if (cy <= drawHeight / 2 - mapCreate.chipSize/2) {
				cy = drawHeight / 2 - mapCreate.chipSize/2;
			}
			if (cy >= mapCreate.mapYSize * mapCreate.chipSize - drawHeight / 2 - mapCreate.chipSize/2) {
				cy = mapCreate.mapYSize * mapCreate.chipSize - drawHeight / 2 - mapCreate.chipSize/2;
			}



			transform.position = new Vector3 (cx,cy,cz);
		}
	}
}
