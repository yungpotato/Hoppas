using Godot;
using System;

public partial class hahmo : CharacterBody2D
{
    public const float Speed = 300.0f;
    public const float JumpVelocity = -400.0f;

    // Lisätty kenttä AnimatedSprite2D:lle
    private AnimatedSprite2D _sprite;

    public override void _Ready()
    {
        // Hae lapsisolmu joka pyörittää animaatioita
        _sprite = GetNode<AnimatedSprite2D>("hahmo");
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // --- Gravitaatio ---
        if (!IsOnFloor())
            velocity += GetGravity() * (float)delta;

        // --- Hyppy ---
        if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
            velocity.Y = JumpVelocity;

        // --- Vaaka-liike ---
        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (direction != Vector2.Zero)
            velocity.X = direction.X * Speed;
        else
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);

        // Aseta uusi velocity ja liiku
        Velocity = velocity;
        MoveAndSlide();

        // --- Animaatiot ---
        if (!IsOnFloor())
        {
            // Pelaaja ilmassa → hyppy-kuva (Single-frame tai animaatio “hyppy”)
            _sprite.Play("hyppy");
        }
        else if (Math.Abs(velocity.X) > 0.1f)
        {
            // Maassa & liikkeessä → juoksuanimaatio “juoksu”
            _sprite.Play("juoksu");
        }
        else
        {
            // Maassa & paikallaan → oletus-animaatio “default”
            _sprite.Play("default");
        }

        // --- Käännös katselusuuntaan ---
        if (velocity.X < 0)
            _sprite.FlipH = true;
        else if (velocity.X > 0)
            _sprite.FlipH = false;
    }
}