using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Castle_Climb_Game.Sprites
{
    public class UnanimatedSprite : Sprite
    {

        #region Fields

        

        #endregion

        #region Properties

        public override Rectangle Rectangle 
        {
            get
            {
                return new Rectangle
                    ((int)(Position.X - Origin.X),
                    (int)(Position.Y - Origin.Y),
                    (int)(_texture.Width * Scale),
                    (int)(_texture.Height * Scale));
            }
        }

        #endregion

        public UnanimatedSprite(Texture2D texture)
        {
            _texture = texture;

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Colour * Opacity, Rotation, Origin, Scale, SpriteEffects.None, Layer);
        }

    }
}
