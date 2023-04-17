using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Fungus;

public class SaveManager : MonoBehaviour
{
    private string FilePath;
    //SaveData save;
    [SerializeField] Flowchart flowchart = null;

    [System.Serializable] private struct saveData
    {
        public int END;
    }

    // Start is called before the first frame update
    void Start()
    {
        FilePath = Path.Combine(Application.persistentDataPath, "position.json");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SavePoint()
    {
        OnSave();
        Debug.Log("save! ");

    }

    public void LoadPoint()
    {
        OnLoad();
        Debug.Log("Load!");
    }

    public void OnSave()
    {
        var obj = new saveData
        {
            END = flowchart.GetIntegerVariable("BAD")
        };

        var json = JsonUtility.ToJson(obj, false);
        File.WriteAllText(FilePath, json);
    }

    public void OnLoad()
    {
        if (!File.Exists(FilePath)) return;

        var json = File.ReadAllText(FilePath);
        var obj = JsonUtility.FromJson<saveData>(json);

        flowchart.SetIntegerVariable("BAD", obj.END);

    }

}
