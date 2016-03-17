using UnityEngine;
using System.Collections;

public enum ChipKind {
	None = -1,
	Grass,
	GrassTree,
	Sand,
	SandTree,
	RightUpStair,
	LeftUpStair,
};

public enum ChipBackKind {
	Grass,
	Sand,
}

public enum ChipActionKind {
	None,
	MoveScene,
}


public class enumDefine : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string getChipActionKindString(ChipActionKind kind) {
		if (kind == ChipActionKind.MoveScene)
			return "moveScene";
		return "none";
	}

	public ChipActionKind getChipActionKindEnum(string kind) {
		if (kind == "moveScene") {
			return ChipActionKind.MoveScene;
		}
		return ChipActionKind.None;
	}

}

