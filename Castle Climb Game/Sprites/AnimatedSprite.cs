using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle_Climb_Game.Managers;
using Castle_Climb_Game.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Castle_Climb_Game.Sprites
{
    public class AnimatedSprite : Sprite
    {
        #region Fields

        public SpriteEffects effect = SpriteEffects.None;

        protected Dictionary<string, Animation> _animations;
        protected AnimationManager _animationManager;

        #endregion

        #region Properties

        public override Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                if (_animationManager != null)
                    _animationManager.Position = _position;
            }
        }

        public override Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
            }
        }

        #endregion

        public AnimatedSprite(Dictionary<string, Animation> animations)
        {
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }

        public override void Update(GameTime gameTime)
        {
            setAnimations();
            _animationManager.Update(gameTime);

        }

        protected virtual void setAnimations()
        {
            _animationManager.play(_animations["Idle"]);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
                _animationManager.Draw(spriteBatch, effect, Scale);
        }



    }
}
