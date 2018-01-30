using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayManager : MonoBehaviour {
    private readonly string logo = @"
===========================================================
     _       __           __       __                __
    | |     / ____ ______/ /____  / ____ _____  ____/ /
    | | /| / / __ `/ ___/ __/ _ \/ / __ `/ __ \/ __  /
    | |/ |/ / /_/ (__  / /_/  __/ / /_/ / / / / /_/ /
    |__/|__/\__,_/____/\__/\___/_/\__,_/_/ /_/\__,_/

                __  __           __
               / / / ____ ______/ /_____  _____
              / /_/ / __ `/ ___/ //_/ _ \/ ___/
             / __  / /_/ / /__/ ,< /  __/ /
            /_/ /_/\__,_/\___/_/|_|\___/_/

===========================================================

press Enter key to start...
";

    internal void LoadMainMenu() {
        Terminal.SetMenuDisplayText(logo);
    }


    internal void LoadPasswords(List<string> passwords) {
        string passwordDisplayString = PasswordManager.GetRandomCharacters(5);
        foreach (string password in passwords) {
            passwordDisplayString += password + PasswordManager.GetRandomCharacters(5);
        }

        Terminal.SetPasswordHintDisplayText(passwordDisplayString);
    }

    internal void ClearScreen() {
        Terminal.ClearScreen();
    }
}
