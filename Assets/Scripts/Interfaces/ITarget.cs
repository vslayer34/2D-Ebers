using UnityEngine;

public interface ITarget
{
    Vector3 MyPosition { get; }

    void FinishGame();
}
