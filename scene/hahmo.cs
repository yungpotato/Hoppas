using Godot;
using System;

public partial class hahmo : CharacterBody2D
{
    public const float Speed = 300.0f;
    public const float JumpVelocity = -400.0f;


    private AnimatedSprite2D _sprite;

    public override void _Ready()
    {
    // Haetaa lapsisolmu joka hoitaa animaatioita
        _sprite = GetNode<AnimatedSprite2D>("hahmo");
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Gravitaatio 
        if (!IsOnFloor())
            velocity += GetGravity() * (float)delta;

        // Hyppy
        if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
            velocity.Y = JumpVelocity;

        // Sivuttasliike
        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (direction != Vector2.Zero)
            velocity.X = direction.X * Speed;
        else
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);

        // Aseta uusi velocity ja movearound
        Velocity = velocity;
        MoveAndSlide();

        // Animaatiot tästä
        if (!IsOnFloor())
        {
        // Pelaaja ilmassa - hyppykuva "hyppy"
            _sprite.Play("hyppy");
        }
        else if (Math.Abs(velocity.X) > 0.1f)
        {
        // Maassa ja liikkeessä - juoksuanimaatio “juoksu”
            _sprite.Play("juoksu");
        }
        else
        {
        // Maassa ja paikallaan - normianimaatio “default”
            _sprite.Play("default");
        }

        // Hahmon kääntö menosuuntaanpäin
        if (velocity.X < 0)
            _sprite.FlipH = true;
        else if (velocity.X > 0)
            _sprite.FlipH = false;
    }
}