using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;

namespace Snake
{
    public class Food
    {
        Random random;
        public Vector2 position;
        int sz = 0;
        int w;
        int r;
        Texture2D texture;
        public Food()
        {
            
            random = new Random();
            sz = Game1.Width / 20;
            texture = Game1.Create_Rec(sz , sz , Color.Red);
            w = Game1.Width / sz;
            r = Game1.height / sz;
            position = new Vector2(0, 0);
        }

        public void Generate(List<Vector2>pos )
        {
            bool ok = false;
            while(ok == false)
            {
                float t = sz *  random.Next(0, w-1);
                float z = sz * random.Next(0, r - 1);
                ok = true;
                position = new Vector2(t, z);
                foreach(Vector2 position in pos)
                {
                    if(t <= position.X + sz && t >= position.X)
                    {
                        if(z <= position.Y + sz && z >= position.Y )
                        {
                            ok = false;
                            break;
                        }
                    }
                }
            }
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texture , position , Color.White);
            _spriteBatch.End();
        }
    }
}
