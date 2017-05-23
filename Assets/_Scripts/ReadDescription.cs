using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ReadDescription : MonoBehaviour {
  public  List<string> fileLines = new List<string>();
   List<BoneInformation> bones;
   //struct Bone
   // {
   //     public string name;
   //     public int id;
   //     public string description;
   // }


	// Use this for initialization
	void Start () {
        ReadFile();
        saveToBones();
	}


    void ReadFile()
    {
        StreamReader sr = File.OpenText("Assets\\BonesDescription.txt");
        fileLines.AddRange(sr.ReadToEnd().Split('\n'));// ToList();
        sr.Close();
    }


    void saveToBones()
    {
        int index = 0;
        string line;
        while(index < fileLines.Count-1)
        {
            BoneInformation newBone = new BoneInformation();
            string[] name = fileLines[index].Split(' ');
            
            newBone.name = name[1];
            newBone.description = null;
            index++;
            line = fileLines[index];

            while (!line.Contains("##End"))
            {
               // Debug.Log(line);
                newBone.description += line;
                index++;
                line = fileLines[index];
            }
            index++;
            Debug.Log(newBone.name);
            Debug.Log(newBone.description);
            //string[] name = fileLines[i].Split(' ');
        }
    }
}
