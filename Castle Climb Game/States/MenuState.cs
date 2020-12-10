using Castle_Climb_Game.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Castle_Climb_Game.States
{
    public class MenuState : State
    {

        private List<Component> _components;

        public MenuState(Game1 game, GraphicsDevice device, ContentManager content) : base(game, device, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 100),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

            var loadGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "Load Game",
            };

            loadGameButton.Click += LoadGameButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 300),
                Text = "Quit",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                loadGameButton,
                quitGameButton,
            };
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Load Game");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach(var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();

        }

        public override void PostUpdate(GameTime gameTime)
        {
            //remove things
        }

        public override void Update(GameTime gameTime)
        {
            foreach(var component in _components)
            {
                component.Update(gameTime);
            }

            PostUpdate(gameTime);
        }
    }
}
