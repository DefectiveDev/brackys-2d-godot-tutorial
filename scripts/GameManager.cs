using Godot;
using System;

public partial class GameManager : Node
{
    private int score = 0;

    public void AddPoint()
    {
        score += 1;
        GD.Print(score);
    }
}
