using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Snake;

public class Game1 : Game
{
    public static GraphicsDeviceManager _graphics;
    public static SpriteBatch _spriteBatch;
    public static int Width = 800;
    public static int height = 800;
    Snakes snake;

    public static Game1 self;
    SpriteFont font;


    public Game1()
    {
        self = this;
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = Width;
        _graphics.PreferredBackBufferHeight = height;
        _graphics.ApplyChanges();
        snake = new Snakes();
        base.Initialize();
    }

    protected override void UnloadContent()
    {
        base.UnloadContent();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        font = Content.Load<SpriteFont>("File");
    }

    protected override void Update(GameTime gameTime)
    {
        snake.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        snake.Draw(_spriteBatch);
        _spriteBatch.Begin();
        _spriteBatch.DrawString(font, "" + (snake.len - 2), new Vector2(0, 0), Color.White);
        _spriteBatch.End();
        base.Draw(gameTime);
    }

    public static Texture2D Create_Rec(int width , int height , Color color)
    {
        Texture2D Rec = new Texture2D(Game1._graphics.GraphicsDevice , width , height);
        Color[] Data = new Color[width * height];
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++ )
            {
                Data[width * i + j ] = color;
            }
        }
        Rec.SetData(Data);
        return Rec;
    }
}
