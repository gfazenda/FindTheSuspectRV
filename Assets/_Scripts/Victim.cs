using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictimScript : MonoBehaviour {
    public List<int> missingBones;
    public Text boneList;
	// Use this for initialization
	void Start () {
        setupList();
    }

    void setupList()
    {
        for (int i = 0; i < missingBones.Count; i++)
        {
            boneList.text += "- " + GameManager.Instance.getBoneInfo(missingBones[i]);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
