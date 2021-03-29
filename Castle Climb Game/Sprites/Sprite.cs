using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Castle_Climb_Game.Sprites
{
    public abstract class Sprite : Component
    {

        #region Fields

        protected Vector2 _position;

        public float _layer;

        protected Texture2D _texture;

        #endregion

        #region Properties

        public float Scale { get; set; }

        public float Rotation { get; set; }

        public float Opacity { get; set; }

        public Color Colour { get; set; }

        public Vector2 Origin { get; set; }

        public virtual Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
            }
        }

        public Sprite()
        {
            Scale = 1f;
            Origin = new Vector2(0, 0);
            Colour = Color.White;
            Opacity = 1;
            Rotation = 0;
        }

        public virtual float Layer
        {
            get { return _layer;  }
            set
            {
                _layer = value;
            }
        }

        public virtual Rectangle Rectangle { get; }

        #endregion



        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
