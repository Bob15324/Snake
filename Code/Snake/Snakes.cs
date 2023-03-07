using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Diagnostics.SymbolStore;
using System.Reflection.Metadata.Ecma335;

namespace Snake
{
    public class Snakes
    {
        Texture2D texture;
        public int len = 2;
        float sz;
        List<Vector2> pos;
        int[] dx = new int[4];
        int[] dy = new int[4];
        int direction = 1;
        int frame = 0;
        int maximumframe = 10;
        Food food;
        public Snakes()
        {
            
            sz = Game1.Width / 20;
            texture = Game1.Create_Rec((int)sz, (int)sz, Color.Green);
            pos = new List<Vector2>();
            food = new Food();
 
            dx[0] = 1;
            dx[1] = -1;
            dx[2] = 0;
            dx[3] = 0;
            dy[0] = 0;
            dy[1] = 0;
            dy[2] = 1;
            dy[3] = -1;
            
            
            pos.Add(new Vector2(Game1.Width / 2f, Game1.height / 2f));
            pos.Add(new Vector2(Game1.Width / 2f + sz, Game1.height / 2f));
            food.Generate(pos);
        }

        private bool ChangeDirection()
        {
            KeyboardState key = Keyboard.GetState();
            if((key.IsKeyDown(Keys.D) || key.IsKeyDown(Keys.Right) )  && direction != 1 && direction != 0)
            {
                direction = 0;
                return true;
            }
            if((key.IsKeyDown(Keys.S) || key.IsKeyDown(Keys.Down)) && direction != 3  && direction != 2)
            {
                direction = 2;
                return true;
            }
            if((key.IsKeyDown(Keys.A) || key.IsKeyDown(Keys.Left) ) && direction != 0 && direction != 1)
            {
                direction = 1;
                return true;
            }
            if((key.IsKeyDown(Keys.W) || key.IsKeyDown(Keys.Up) ) && direction != 2 && direction != 3)
            {
                direction = 3;
                return true;
            }
            return false;
        }

        private bool isEaten(Vector2 posi)
        {
            if (posi == food.position)
            {
                return true;
            }
            return false;
        }

        private bool isdead()
        {
            for(int i = 1; i < pos.Count;i++)
            {
                if (pos[i] == pos[0]) return true;
            }
            return false;
        }

        public virtual void Update()
        {
            ChangeDirection();
            if (frame != maximumframe )
            {
                frame++;
                
                return ;
            }
            frame = 0;



            float new_x;
            float new_y;
            new_x = pos[0].X + dx[direction] * sz;
            new_y = pos[0].Y + dy[direction] * sz;
            bool dead = false;
            if (new_x < 0) new_x = Game1.height - sz;
            if (new_x > Game1.height - sz) new_x = 0;
            if (new_y < 0) new_y = Game1.Width - sz;
            if (new_y > Game1.Width - sz) new_y = 0;
            if(isEaten(new Vector2(new_x , new_y)))
            {
                dead = true;
                pos.Add(new Vector2(0 , 0));
            }
            
            for (int i = pos.Count -1; i >= 1; i--)
            {
                pos[i] = pos[i - 1];
            }
            pos[0] = new Vector2(new_x, new_y);

            
            if (dead)
            {
                len++;
                maximumframe--;
                if (maximumframe < 1) maximumframe = 1;
                food.Generate(pos);
            }
            if (isdead())Game1.self.Exit();
        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            foreach(Vector2 position in pos)
            {
                _spriteBatch.Draw(texture , position , Color.White);
            }
            _spriteBatch.End();
            food.Draw(_spriteBatch);
            
        }
    }
}
