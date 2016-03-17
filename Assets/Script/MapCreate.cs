using UnityEngine;
using System.Collections.Generic;
using System;

public class MapCreate : MonoBehaviour {

	public int sceneId;

	public int mapXSize = 10;
	public int mapYSize = 10;

	public float chipSize = 1.00f;
	public float spriteSize = 0.98f;

	Sprite[] mapImageSprites;
	ChipKind[,] map;
	List< Dictionary<string,string> > actions;
	enumDefine enumDefine;
	List< GameObject > mapObjects;


	// Use this for initialization
	void Start () {
	}
	void Awake () {
		enumDefine = GetComponent<enumDefine>();

		this.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);

		mapImageSprites = Resources.LoadAll<Sprite> ("Sprite/field/mapChip");

		mapObjects = new List< GameObject> ();

		loadMap ();
	}

	public void loadMap() {
		if (actions == null) {
			actions = new List<Dictionary<string,string> >() { };
		}
		actions.Clear ();
		for (int i = 0; i < mapObjects.Count; i++) {
			Destroy (mapObjects [i]);
		}
		mapObjects.Clear ();

		if (sceneId == 0) {
			mapXSize = 40;
			mapYSize = 40;
			ChipKind[,] tmpmap = new ChipKind[10, 10] { {
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass
				}, {
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.GrassTree,
					ChipKind.GrassTree,
					ChipKind.GrassTree,
					ChipKind.Grass,
					ChipKind.Grass
				}, {
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.GrassTree,
					ChipKind.GrassTree,
					ChipKind.GrassTree,
					ChipKind.Grass,
					ChipKind.Grass
				}, {
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass
				}, {
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.GrassStone,
					ChipKind.Grass,
					ChipKind.GrassTree,
					ChipKind.GrassTree,
					ChipKind.GrassTree,
					ChipKind.Grass,
					ChipKind.Grass
				}, {
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.GrassTree,
					ChipKind.GrassTree,
					ChipKind.GrassTree,
					ChipKind.Grass,
					ChipKind.Grass
				}, {
					ChipKind.GrassTree,
					ChipKind.GrassTree,
					ChipKind.GrassTree,
					ChipKind.GrassTree,
					ChipKind.GrassTree,
					ChipKind.GrassTree,
					ChipKind.GrassTree,
					ChipKind.GrassTree,
					ChipKind.Grass,
					ChipKind.Grass
				}, {
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.GrassTree,
					ChipKind.GrassTree,
					ChipKind.Grass,
					ChipKind.GrassTree,
					ChipKind.Grass,
					ChipKind.Grass
				}, {
					ChipKind.GrassTree,
					ChipKind.Grass,
					ChipKind.GrassTree,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass
				}, {
					ChipKind.GrassTree,
					ChipKind.Grass,
					ChipKind.GrassTree,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass
				}
			};

			map = new ChipKind[mapYSize, mapXSize];
			for (int i = 0; i < mapYSize; i++) {
				for (int j = 0; j < mapXSize; j++) {
					map [i, j] = tmpmap [i % 10, j % 10];
				}
			}

			Dictionary<string,string> action = new Dictionary<string,string> (){{"kind",enumDefine.getChipActionKindString(ChipActionKind.MoveScene)},
				{"i","7"},
				{"j","6"},
				{"toScene","1"},
				{"toI","4"},
				{"toJ","1"},
				{"toD","right"},
			};
			Dictionary<string,string> action2 = new Dictionary<string,string> (){{"kind",enumDefine.getChipActionKindString(ChipActionKind.MoveScene)},
				{"i","37"},
				{"j","36"},
				{"toScene","1"},
				{"toI","7"},
				{"toJ","4"},
				{"toD","up"},
			};

			actions.Add (action);
			actions.Add (action2);
		}

		if (sceneId == 1) {
			mapXSize = 10;
			mapYSize = 10;
			map = new ChipKind[10, 10] { {ChipKind.None,ChipKind.None,ChipKind.None,ChipKind.None,ChipKind.None,ChipKind.None,ChipKind.None,ChipKind.None,ChipKind.None,ChipKind.None},
				{ChipKind.None,ChipKind.GrassTree,ChipKind.GrassTree,ChipKind.GrassTree,ChipKind.GrassTree,ChipKind.GrassTree,ChipKind.GrassTree,ChipKind.GrassTree,ChipKind.None,ChipKind.None},
				{ChipKind.GrassTree,ChipKind.GrassTree,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.GrassTree,ChipKind.GrassTree,ChipKind.None},
				{ChipKind.GrassTree,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.GrassTree,ChipKind.None},
				{ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.GrassTree,ChipKind.None},
				{ChipKind.GrassTree,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.GrassTree,ChipKind.None},
				{ChipKind.GrassTree,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.GrassTree,ChipKind.None},
				{ChipKind.GrassTree,ChipKind.GrassTree,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.Grass,ChipKind.GrassTree,ChipKind.GrassTree,ChipKind.None},
				{ChipKind.None,ChipKind.GrassTree,ChipKind.GrassTree,ChipKind.GrassTree,ChipKind.Grass,ChipKind.GrassTree,ChipKind.GrassTree,ChipKind.GrassTree,ChipKind.None,ChipKind.None},
				{ChipKind.None,ChipKind.None,ChipKind.None,ChipKind.None,ChipKind.None,ChipKind.None,ChipKind.None,ChipKind.None,ChipKind.None,ChipKind.None},
			};

			Dictionary<string,string> action = new Dictionary<string,string> (){{"kind",enumDefine.getChipActionKindString(ChipActionKind.MoveScene)},
				{"i","4"},
				{"j","0"},
				{"toScene","0"},
				{"toI","8"},
				{"toJ","6"},
				{"toD","down"},
			};
			Dictionary<string,string> action2 = new Dictionary<string,string> (){{"kind",enumDefine.getChipActionKindString(ChipActionKind.MoveScene)},
				{"i","8"},
				{"j","4"},
				{"toScene","0"},
				{"toI","38"},
				{"toJ","36"},
				{"toD","down"},
			};

			actions.Add (action);
			actions.Add (action2);
		}

		Dictionary<string,string>[,] mapInfos = new Dictionary<string, string>[mapYSize, mapXSize];
		for (int i = 0; i < mapYSize; i++) {
			for (int j = 0; j < mapXSize; j++) {
				mapInfos [i, j] = getChipInfo (map [i, j]);
			}
		}

		for (int i = 0; i < mapYSize; i++) {
			for (int j = 0; j < mapXSize; j++) {
				if (map [i, j] == ChipKind.None)
					continue;
				int height = int.Parse(mapInfos [i, j]["height"]);
				for (int h = 0; h < height; h++) {
					GameObject tmpObj = new GameObject ("Sprite");
					int imageIndex = int.Parse(mapInfos [i, j]["chipId"]);
					tmpObj.AddComponent<SpriteRenderer> ().sprite = mapImageSprites [imageIndex - h * 10];
					//GameObject tmpObj = new GameObject ("Sprite").AddComponent<SpriteRenderer> ().sprite = mapImageSprites [map [i, j]];
					tmpObj.transform.position = new Vector3 (j * chipSize, (mapYSize - (i-h) - 1) * chipSize, getZPosition(j,mapYSize - 1 - i));
					tmpObj.transform.parent = this.transform;
					tmpObj.transform.localScale = new Vector3 (1.0f / spriteSize, 1.0f / spriteSize, 0.0f);

					mapObjects.Add (tmpObj);
				}
			}
		}
	}

	public Dictionary<string,string> getRelatedAction(int x,int y) {
		Dictionary<string,string> action = new Dictionary<string,string> (){ {"kind",enumDefine.getChipActionKindString (ChipActionKind.None)},
		};
		for (int i = 0; i < actions.Count; i++) {
			if (int.Parse (actions [i] ["i"]) == mapYSize - y - 1 && int.Parse (actions [i] ["j"]) == x) {
				return actions [i];
			}
		}
		return action;
	}

	public bool canThrough(int x,int y) {
		int I = mapYSize - y - 1;
		int J = x;
		if (J < 0 || I < 0 || J >= mapXSize || I >= mapYSize) {
			return false;
		}
		return Convert.ToBoolean (getChipInfo (map [I, J]) ["canThrough"]);
	}

	public float getZPosition(int x,int y) {
		int I = mapYSize - y - 1;
		int J = x;
		if (J < 0 || I < 0 || J >= mapXSize || I >= mapYSize) {
			return -10000.0f;
		}
		return (mapYSize - I - 1) * chipSize*0.1f;
	}

	public float[] getXYPosition(int x,int y) {
		int I = mapYSize - y - 1;
		int J = x;
		if (J < 0 || I < 0 || J >= mapXSize || I >= mapYSize) {
			return new float[] { -10000.0f, -10000.0f };
		}
		int height = int.Parse(getChipInfo (map [I, J])["height"]);
		return new float[] { J * chipSize, (mapYSize - (I - (height-1)) - 1) * chipSize };
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Dictionary<string,string> getChipInfo(ChipKind chipId) {
		Dictionary<string,string> dic = new Dictionary<string,string> ();
		/*
		string isSea = "true";
		if (chipId == ) {
			isSea = "false";
		}
		dic ["isSea"] = isSea;
		*/

		dic ["chipId"] = ((int)chipId).ToString ();

		string canThrough = "false";
		if(chipId == ChipKind.Grass) {
			canThrough = "true";
		}

		dic["canThrough"] = canThrough;

		int height = 1;
		if (chipId == ChipKind.GrassTree || chipId == ChipKind.GrassStone) {
			height = 2;
		}
		dic ["height"] = height.ToString ();
		
		return dic;
	}
	/*
	int getImageIndex(Dictionary<string,string> info,Dictionary<string,string> upInfo,Dictionary<string,string> rightInfo,Dictionary<string,string> downInfo,Dictionary<string,string> leftInfo) {
		if (info ["chipId"] == "1") {
			return 1;
		}
		if (info ["chipId"] == "0") {
			//海の場合は境界条件を調べる
			bool upSea, rightSea, downSea, leftSea = false;

			upSea = Convert.ToBoolean (upInfo ["isSea"]);
			rightSea = Convert.ToBoolean (rightInfo ["isSea"]);
			downSea = Convert.ToBoolean (downInfo ["isSea"]);
			leftSea = Convert.ToBoolean (leftInfo ["isSea"]);

			if (upSea && rightSea && downSea && leftSea)
				return 0;
			if (upSea && rightSea && downSea && !leftSea)
				return 20;
			if (upSea && !rightSea && downSea && leftSea)
				return 21;
			if (!upSea && rightSea && downSea && leftSea)
				return 22;
			if (upSea && rightSea && !downSea && leftSea)
				return 23;
			if (!upSea && rightSea && !downSea && leftSea)
				return 24;
			if (upSea && !rightSea && downSea && !leftSea)
				return 25;
			if (!upSea && rightSea && downSea && !leftSea)
				return 32;
			if (!upSea && !rightSea && downSea && leftSea)
				return 33;
			if (upSea && rightSea && !downSea && !leftSea)
				return 42;
			if (upSea && !rightSea && !downSea && leftSea)
				return 43;
		}
		return 0;
	}
	*/
}
