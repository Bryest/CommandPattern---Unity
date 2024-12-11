using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InputHandler : MonoBehaviour
{
    private Dictionary<KeyCode, Vector3> movementKeyMapping;
    private Stack<ICommand> commandHistory = new Stack<ICommand>();
    public Player player;
    private ExecuteCommand executeCommand;

    void Awake()
    {
        movementKeyMapping = new Dictionary<KeyCode, Vector3>{
            {KeyCode.W,Vector3.forward},
            {KeyCode.S,Vector3.back},
            {KeyCode.A,Vector3.left},
            {KeyCode.D,Vector3.right},
        };
    }

    void Start()
    {
        executeCommand = GetComponent<ExecuteCommand>();
    }

    void Update()
    {
        PlayerInputs();
        UndoInput();
    }

    private void PlayerInputs()
    {
        HandleMovementInput(KeyCode.W);
        HandleMovementInput(KeyCode.A);
        HandleMovementInput(KeyCode.S);
        HandleMovementInput(KeyCode.D);
    }

    private void UndoInput()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            executeCommand.UndoLastCommand();
        }
    }

    private void HandleMovementInput(KeyCode inputKey)
    {
        if (Input.GetKeyDown(inputKey))
        {
            ExecuteMoveCommand(movementKeyMapping[inputKey]);
            Debug.Log("Input: " + inputKey);
            return;
        }
    }

    private void ExecuteMoveCommand(Vector3 direction)
    {
        // Create and execute a move command
        ICommand moveCommand = new MoveCommand(player, direction);
        executeCommand.ExecuteCommandPattern(moveCommand);
    }
}