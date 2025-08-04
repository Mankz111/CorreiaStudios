using Godot;
using System;

public partial class Teste1 : CharacterBody2D
{
    private int _speed = 300;
    private string current_direction = "none";
    private AnimatedSprite2D _animatedSprite2D;

    public override void _Ready()
    {
        _animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public void GetInput()
    {
        Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        Velocity = inputDir * _speed;

        // Atualiza a direção com base no input
        if (inputDir.X > 0)
        {
            current_direction = "right";
        }
        else if (inputDir.X < 0)
        {
            current_direction = "left";
        }
        else if (inputDir.Y > 0)
        {
            current_direction = "down";
        }
        else if (inputDir.Y < 0)
        {
            current_direction = "up";
        }
        else
        {
            current_direction = "idle";
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndSlide();
        play_animation(); 
    }

    public void play_animation()
    {
        if (Velocity.Length() > 0)
        {

            if (current_direction == "right")
            {
                _animatedSprite2D.FlipH = false; 
                _animatedSprite2D.Play("walk");
            }
            else if (current_direction == "left")
            {
                _animatedSprite2D.FlipH = true;
                _animatedSprite2D.Play("walk");
            }
            else if (current_direction == "up")
            {
                _animatedSprite2D.Play("walk_up");
            }
            else if (current_direction == "down")
            {
                _animatedSprite2D.Play("walk_down");
            }
        }
        else
        {
            _animatedSprite2D.Play("idle");
        }
    }
}




