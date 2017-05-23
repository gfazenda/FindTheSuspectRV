using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    List<BoneInformation> bones;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }
    // Use this for initialization
    void Start () {
		
	}

    public BoneInformation getBoneInfo(int id)
    {
        for (int i = 0; i < bones.Count; i++)
        {
            if (bones[i].id == id)
                return bones[i];
        }
        return null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
