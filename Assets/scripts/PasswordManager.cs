using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class PasswordManager : MonoBehaviour {
    private string passwordsFilePath = "data/passwords.xml";
    private List<Password> passwords;

	// Use this for initialization
	void Start () {
        Debug.Log("PasswordManager initialising...");
        passwords = LoadPasswords();
    }


    /// <summary>
    /// Deserialize passwords.xml file
    /// </summary>
    /// <returns>list of passwords</returns>
    private List<Password> LoadPasswords() {
        Debug.Log("Datapath: " + System.IO.Path.Combine(Application.dataPath, passwordsFilePath));

        PasswordsContainer container;

        var serializer = new XmlSerializer(typeof(PasswordsContainer));
        using (var stream = new FileStream(System.IO.Path.Combine(Application.dataPath, passwordsFilePath), FileMode.Open)) {
            container =  serializer.Deserialize(stream) as PasswordsContainer;
        }

        return container.passwords;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public List<string> GetPasswords(string theme, int level) {
        List<string> passwords = new List<string>();

        passwords.Add("test1.l" + level);
        passwords.Add("test2.l" + level);
        passwords.Add("test3.l" + level);

        return passwords;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="password"></param>
    /// <param name="hack"></param>
    /// <returns></returns>
    public int ConfirmPassword(String password, String hack) {
        if (password.Length != hack.Length)
            throw new UnityException("Invalid password lengths [password:" + password + ", hack:" + hack + "]");

        int correctCharacters = 0;

        for (int i = 0; i < password.Length; i++) {
            if (password[i] == hack[i])
                correctCharacters++;
        }

        return correctCharacters;
    }
}
