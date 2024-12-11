using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteCommand : MonoBehaviour
{
    private Stack<ICommand> commandHistory = new Stack<ICommand>();

    public void ExecuteCommandPattern(ICommand command)
    {
        command.Execute();
        commandHistory.Push(command);
        Debug.Log("Command added to history");
        Debug.Log("Command history count: "+commandHistory.Count);
    }

    public void UndoLastCommand()
    {
        if (commandHistory.Count > 0)
        {
            ICommand lastCommand = commandHistory.Pop();
            lastCommand.Undo();
            Debug.Log("Command undone");
        }
        else
        {
            Debug.Log("No commands to undo");
        }
    }
}