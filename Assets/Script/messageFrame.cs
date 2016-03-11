using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class messageFrame : MonoBehaviour {
    public enum messageMode {
        talk,
        announce,
    };
    public messageMode mode;

    //表示用*******
    public string name;         //外部入力
    public string message;      //外部入力
    public Sprite charaImage;   //外部入力
    GameObject talkFrame;
    GameObject announceFrame;
    GameObject charaObject;
    Text textName;
    Text textMessage;

	// Use this for initialization

    void Find()
    {
        talkFrame = transform.FindChild("talkFrame").gameObject;
        announceFrame = transform.FindChild("announceFrame").gameObject;
        if (mode == messageMode.talk)
        {
            announceFrame.SetActive(false);
            textName = 
                transform.FindChild("talkFrame").
                transform.FindChild("name").
                gameObject.GetComponent<Text>();
            textMessage =
                transform.FindChild("talkFrame").
                transform.FindChild("message").
                gameObject.GetComponent<Text>();
            charaObject =
                transform.FindChild("talkFrame").
                transform.FindChild("chara").gameObject;
        }
        if (mode == messageMode.announce)
        {
            talkFrame.SetActive(false);
            textMessage =
                transform.FindChild("announceFrame").
                transform.FindChild("message").
                gameObject.GetComponent<Text>(); ;
            charaObject = null;
            textName = null;
        }
        
    }

	void Start () {
        Find();
	    if (mode == messageMode.talk)
        {
            textName.text = name;
            textMessage.text = message;
        }
        if (mode == messageMode.announce)
        {
            textMessage.text = message;
        }
        StartCoroutine("MessageOpen",message);
    }
	
	// Update is called once per frame
	void Update () {
    }

    IEnumerator MessageOpen(string _message)
    {
        //1文字ずつ列挙する
        for (int i = 0; i < _message.Length; i++)
        {
            textMessage.text = _message.Substring(0, i);
            yield return new WaitForSeconds(0.02f);
        }
        yield return null;
    }
}
