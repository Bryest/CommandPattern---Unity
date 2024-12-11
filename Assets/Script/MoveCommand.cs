using UnityEngine;

public class MoveCommand : ICommand
{
    private Player _player;
    private Vector3 _direction;

    public MoveCommand(Player player, Vector3 direction)
    {
        _player = player;
        _direction = direction;
    }

    public void Execute()
    {
        _player.Move(_direction);
        Debug.Log("ExceuteMove Direction: " + _direction);
    }

    public void Undo()
    {
        _player.UndoMove(_direction);
        Debug.Log("ExceuteMove Direction: " + _direction);
    }
}