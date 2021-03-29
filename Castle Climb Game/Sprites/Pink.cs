using Castle_Climb_Game.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Castle_Climb_Game.Sprites
{
    public class Pink : AnimatedSprite
    {

        #region Fields

        public float _speed = 200f;

        public Input _input;

        #endregion

        #region Properties

        public Vector2 velocity;

        public float Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
            }
        }



        #endregion

        public Pink(Dictionary<string, Animation> animations, Input input) : base(animations)
        {
            _input = input;
        }

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);

            setAnimations();

            _animationManager.Update(gameTime);

            Position += velocity;
            //Position = Vector2.Clamp(Position, new Vector2(0, 0), new Vector2(Game1.ScreenWidth - _animations["Idle"].FrameWidth/_animations["Idle"].FrameCount, Game1.ScreenHeight - _animations["Idle"].FrameHeight + 30));
            velocity = Vector2.Zero;
        }

        protected override void setAnimations()
        {
            if (velocity.X > 0)
            {
                _animationManager.play(_animations["Walk"]);
                effect = SpriteEffects.None;
            }
            else if (velocity.X < 0)
            {
                _animationManager.play(_animations["Walk"]);
                effect = SpriteEffects.FlipHorizontally;
            }
            else _animationManager.play(_animations["Idle"]);
        }
        private void Move(GameTime gameTime)
        {
            if (_input == null)
                return;

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(_input.Up))
                velocity.Y -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(_input.Down))
                velocity.Y += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(_input.Left))
                velocity.X -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(_input.Right))
                velocity.X += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        }

    }
}
