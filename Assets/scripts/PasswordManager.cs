using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class PasswordManager : MonoBehaviour {
    public static char[] NON_ALPHA_CHARS = {'!','"','|','\\','%','£','^','&','*','(',')','_','-','+','=','$','>','<',',','.','?','/','`','¬','[',']','{','}',';',':','\'','@','#','~','"'};
    public static System.Random rnd = new System.Random();

    private string passwordsFilePath = "data/passwords.xml";
    private List<Password> passwords;

	// Use this for initialization
	void Start () {
        Debug.Log("PasswordManager initialising...");
        passwords = LoadPasswords();
        Debug.Log(passwords.Count + " passwords retrieved");
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
        Debug.Log("Retrieving theme " + theme + " passwords for level " + level);
        IEnumerable<string> themedPasswords = from p in passwords
                                              where p.Theme == theme 
                                              select p.Word;

        switch (level) {
            case 1:
                return RetrieveRandomPasswords(6, themedPasswords.Where(p => p.Length == 4).ToList());
            case 2:
                return RetrieveRandomPasswords(6, themedPasswords.Where(p => p.Length == 4).ToList());
            case 3:
                return RetrieveRandomPasswords(6, themedPasswords.Where(p => p.Length == 5).ToList());
            case 4:
                return RetrieveRandomPasswords(6, themedPasswords.Where(p => p.Length == 5).ToList());
            case 5:
                return RetrieveRandomPasswords(6, themedPasswords.Where(p => p.Length == 6).ToList());
            default:
                return RetrieveRandomPasswords(6, themedPasswords.Where(p => p.Length == 6).ToList());
        }
        
    }

    private List<string> RetrieveRandomPasswords(int numberOfPasswords, List<string> passwords) {
        Debug.Log("Returning random " + numberOfPasswords + " out of "+passwords.Count()+" passwords from collection " + passwords.ToArray());
        List<string> result = new List<string>();
       
        while (result.Count < numberOfPasswords) {
            int random = rnd.Next(0, passwords.Count - 1);
            result.Add(passwords[random]);
            passwords.Remove(passwords[random]);
        }
        
        return result;
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


    public static string GetRandomCharacters(int num) {
        char[] resultChars = new char[num];
        
        for (int i = 0; i < resultChars.Length; i++) {
            int random = rnd.Next(0, NON_ALPHA_CHARS.Length - 1);
            resultChars[i] = NON_ALPHA_CHARS[random];
        }

        return new string(resultChars);
    }
}
