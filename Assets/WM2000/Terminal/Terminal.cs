using UnityEngine;
using System.Reflection;
using System;

public class Terminal : MonoBehaviour {
    private GameManager gameManager;
    private InputDisplayBuffer inputDisplayBuffer;
    private InputBuffer inputBuffer;

    static Terminal primaryTerminal;

    private static string menuDisplayText;
    private static string passwordHintDisplayText;

    private void Awake() {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        if (primaryTerminal == null) {
            primaryTerminal = this;
        } // Be the one

        inputBuffer = new InputBuffer(gameManager);
        inputDisplayBuffer = new InputDisplayBuffer(inputBuffer, gameManager);

        inputBuffer.onCommandSent += NotifyCommandHandlers;
    }


    public string GetInputDisplayBuffer(int width, int height) {
        return inputDisplayBuffer.GetDisplayBuffer(Time.time, width, height);
    }


    public string GetPasswordHintDisplayText() {
        return passwordHintDisplayText;
    }

    public static void SetPasswordHintDisplayText(string text) {
        passwordHintDisplayText = text;
    }


    internal string GetMenuDisplayText() {
        return menuDisplayText;
    }

    public static void SetMenuDisplayText(string text) {
        menuDisplayText = text;
    }


    public void ReceiveFrameInput(string input) {
        inputBuffer.ReceiveFrameInput(input);
    }


    public static void ClearScreen() {
        primaryTerminal.inputDisplayBuffer.Clear();
    }


    public void NotifyCommandHandlers(string input) {
        var allGameObjects = FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour mb in allGameObjects) {
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;
            var targetMethod = mb.GetType().GetMethod("OnUserInput", flags);
            if (targetMethod != null) {
                object[] parameters = new object[1];
                parameters[0] = input;
                targetMethod.Invoke(mb, parameters);
            }
        }
    }
}