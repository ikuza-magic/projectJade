﻿using UnityEngine;
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
	int[,] heightMap;
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
			int[,] tmpHeightMap = new int[10, 10] {
				{ 0, 3, 3, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 1, 2, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
			};

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
					ChipKind.Sand,
					ChipKind.Sand,
					ChipKind.Sand,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass
				}, {
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.Grass,
					ChipKind.SandTree,
					ChipKind.Sand,
					ChipKind.SandTree,
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
			heightMap = new int[mapYSize, mapXSize];
			for (int i = 0; i < mapYSize; i++) {
				for (int j = 0; j < mapXSize; j++) {
					map [i, j] = tmpmap [i % 10, j % 10];
					heightMap [i, j] = tmpHeightMap [i % 10, j % 10];
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

			heightMap = new int[10, 10] {
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
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
				int height = heightMap[i,j];

				ChipBackKind backKind = ChipBackKind.Grass;
				if (map [i, j] == ChipKind.Sand || map [i, j] == ChipKind.SandTree) {
					backKind = ChipBackKind.Sand;
				}

				for (int h = 0; h <= height; h++) {
					GameObject tmpObj = new GameObject ("Sprite");
					int imageIndex = 0;
					if (backKind == ChipBackKind.Sand) {
						imageIndex = 12;
					}

					if (height >= 1) {
						imageIndex = 47;
						if (h != height) {
							imageIndex = 37;
						} else {
							imageIndex = 17;
							if (backKind == ChipBackKind.Sand) {
								imageIndex = 12;
							}
						}
					}

					tmpObj.AddComponent<SpriteRenderer> ().sprite = mapImageSprites [imageIndex];
					tmpObj.transform.position = new Vector3 (j * chipSize, (mapYSize - (i-h) - 1) * chipSize, getZPosition(j,mapYSize - 1 - i));
					tmpObj.transform.parent = this.transform;
					tmpObj.transform.localScale = new Vector3 (1.0f / spriteSize, 1.0f / spriteSize, 0.0f);

					mapObjects.Add (tmpObj);

					if(imageIndex == 47) {
						int backImageIndex = 0;
						if (backKind == ChipBackKind.Sand) {
							backImageIndex = 12;
						}
						GameObject tmpObj2 = new GameObject ("Sprite");
						tmpObj2.AddComponent<SpriteRenderer> ().sprite = mapImageSprites [backImageIndex];
						tmpObj2.transform.position = new Vector3 (j * chipSize, (mapYSize - (i-h) - 1) * chipSize, getZPosition(j,mapYSize - 1 - i)+0.0001f);
						tmpObj2.transform.parent = this.transform;
						tmpObj2.transform.localScale = new Vector3 (1.0f / spriteSize, 1.0f / spriteSize, 0.0f);
						mapObjects.Add (tmpObj2);
					}
				}

				if(map[i,j] == ChipKind.GrassTree || map[i,j] == ChipKind.SandTree) {
					for(int t=0;t<2;t++) {
						int treeImageIndex = 20;
						if(t == 1) treeImageIndex = 10;
						GameObject tmpObj2 = new GameObject ("Sprite");
						tmpObj2.AddComponent<SpriteRenderer> ().sprite = mapImageSprites [treeImageIndex];
						tmpObj2.transform.position = new Vector3 (j * chipSize, (mapYSize - (i-(height+t)) - 1) * chipSize, getZPosition(j,mapYSize - 1 - i)-0.0001f);
						tmpObj2.transform.parent = this.transform;
						tmpObj2.transform.localScale = new Vector3 (1.0f / spriteSize, 1.0f / spriteSize, 0.0f);
						mapObjects.Add (tmpObj2);
					}
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

	public bool canThrough(int x,int y,int nx,int ny) {
		//高さが違うと移動させない

		int I = mapYSize - y - 1;
		int J = x;
		if (J < 0 || I < 0 || J >= mapXSize || I >= mapYSize) {
			return false;
		}
		int nI = mapYSize - ny - 1;
		int nJ = nx;
		if (heightMap [nI, nJ] != heightMap [I, J]) {
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
		return (mapYSize - I - 1) * chipSize*1.0f;
	}

	public float[] getXYPosition(int x,int y) {
		int I = mapYSize - y - 1;
		int J = x;
		if (J < 0 || I < 0 || J >= mapXSize || I >= mapYSize) {
			return new float[] { -10000.0f, -10000.0f };
		}
		float height = (float)heightMap[I,J];
		if (map [I, J] == ChipKind.RightUpStair || map [I, J] == ChipKind.LeftUpStair) {
			height += 0.5f;
		}
		return new float[] { J * chipSize, (mapYSize - (I - (height)) - 1) * chipSize };
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Dictionary<string,string> getChipInfo(ChipKind chipId) {
		Dictionary<string,string> dic = new Dictionary<string,string> ();


		dic ["chipId"] = ((int)chipId).ToString ();

		string canThrough = "false";
		if(chipId == ChipKind.Grass || chipId == ChipKind.Sand) {
			canThrough = "true";
		}

		dic["canThrough"] = canThrough;
		
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
