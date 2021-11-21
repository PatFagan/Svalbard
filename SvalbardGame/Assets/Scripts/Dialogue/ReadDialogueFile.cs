using UnityEngine;
using System.IO;
public class ReadDialogueFile : MonoBehaviour
{
    public static void ReadString()
    {
        string path = Application.persistentDataPath + "/Dialogue/DialogueFiles/test.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
}