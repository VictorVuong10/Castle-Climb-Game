using Castle_Climb_Game.Models;
using Castle_Climb_Game.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Castle_Climb_Game.States
{
    class GameState : State
    {

        private List<Component> _components;

        public GameState(Game1 game, GraphicsDevice device, ContentManager content) : base(game, device, content)
        {
            LoadContent();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void LoadContent()
        {
            var floorTexture = _content.Load<Texture2D>("Platforms/bridge_tile");
            var floorY = _graphicsDevice.PresentationParameters.BackBufferHeight - floorTexture.Height - 25;
            var scale = 0.7f;

            _components = new List<Component>();

            for (int i = 0; i < _graphicsDevice.PresentationParameters.BackBufferWidth; i += (int)(floorTexture.Width * scale) - 1)
            {
                _components.Add(new Platform(floorTexture)
                {
                    Position = new Vector2(i, floorY),
                    Scale = scale,
                }); ;
            }

            var animations = new Dictionary<string, Animation>()
            {
                {"Idle", new Animation(_content.Load<Texture2D>("Players/Pink_Monster_Idle_4"), 4) {FrameSpeed = 0.2f } },
                {"Walk", new Animation(_content.Load<Texture2D>("Players/Pink_Monster_Run_6"), 6) {FrameSpeed = 0.1f} }
            };

            var input = new Input()
            {
                Up = Keys.Up,
                Down = Keys.Down,
                Left = Keys.Left,
                Right = Keys.Right
            };

            _components.Add(new Pink(animations, input)
            {
                Position = new Vector2(400, 240),
                Speed = 267f
            });
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }

            PostUpdate(gameTime);
        }
    }
}
