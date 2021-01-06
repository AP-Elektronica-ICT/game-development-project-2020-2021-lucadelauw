﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using BlockHunt.LevelDesign.Background;

namespace BlockHunt.LevelDesign.Background
{
    public class ParallaxBackground : IBackground
    {
        private ContentManager content;

        private Texture2D texture_layer1;
        private Texture2D texture_layer2;
        private Texture2D texture_layer3;
        private Texture2D texture_layer4;
        private Texture2D texture_layer5;

        private Rectangle sourceRectangle;
        private BackgroundLayer[,] layers;


        public ParallaxBackground(ContentManager content)
        {
            this.content = content;
            sourceRectangle = new Rectangle(0, 0, 1920, 1080);
            layers = new BackgroundLayer[5, 2];
            InitializeContent();
        }

        private void InitializeContent()
        {

            texture_layer1 = content.Load<Texture2D>("Background/layer_01_1920 x 1080");
            texture_layer2 = content.Load<Texture2D>("Background/layer_02_1920 x 1080");
            texture_layer3 = content.Load<Texture2D>("Background/layer_03_1920 x 1080");
            texture_layer4 = content.Load<Texture2D>("Background/layer_04_1920 x 1080");
            texture_layer5 = content.Load<Texture2D>("Background/layer_05_1920 x 1080");

            for (int i = 0; i < layers.GetLength(1); i++)
            {
                layers[0, i] = new BackgroundLayer(texture_layer1, sourceRectangle);
                layers[1, i] = new BackgroundLayer(texture_layer2, sourceRectangle);
                layers[2, i] = new BackgroundLayer(texture_layer3, sourceRectangle);
                layers[3, i] = new BackgroundLayer(texture_layer4, sourceRectangle);
                layers[4, i] = new BackgroundLayer(texture_layer5, sourceRectangle);
            }
        }

        public void Update(Vector2 heroPosition)
        {
            layers[0, 0].positionRectangle = new Rectangle((int)(heroPosition.X - 960), 0, 1920, 1080);
            layers[0, 1].positionRectangle = new Rectangle(layers[0, 0].positionRectangle.X + layers[0, 0].positionRectangle.Width, 0, 1920, 1080);

            int pos1 = (int)(heroPosition.X / 2);
            while (pos1 < heroPosition.X - 2880)
                pos1 = pos1 + 1920;
            layers[1, 0].positionRectangle = new Rectangle(pos1, 0, 1920, 1080);
            layers[1, 1].positionRectangle = new Rectangle(layers[1, 0].positionRectangle.X + layers[1, 0].positionRectangle.Width, 0, 1920, 1080);

            int pos2 = (int)(heroPosition.X / 4);
            while (pos2 < heroPosition.X - 2880)
                pos2 = pos2 + 1920;
            layers[2, 0].positionRectangle = new Rectangle(pos2, 0, 1920, 1080);
            layers[2, 1].positionRectangle = new Rectangle(layers[2, 0].positionRectangle.X + layers[2, 0].positionRectangle.Width, 0, 1920, 1080);

            int pos3 = (int)(heroPosition.X / 8);
            while (pos3 < heroPosition.X - 2880)
                pos3 = pos3 + 1920;
            layers[3, 0].positionRectangle = new Rectangle(pos3, 0, 1920, 1080);
            layers[3, 1].positionRectangle = new Rectangle(layers[3, 0].positionRectangle.X + layers[3, 0].positionRectangle.Width, 0, 1920, 1080);

            int pos4 = (int)(heroPosition.X / 16);
            while (pos4 < heroPosition.X - 2880)
                pos4 = pos4 + 1920;
            layers[4, 0].positionRectangle = new Rectangle(pos4, 0, 1920, 1080);
            layers[4, 1].positionRectangle = new Rectangle(layers[4, 0].positionRectangle.X + layers[4, 0].positionRectangle.Width, 0, 1920, 1080);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < layers.GetLength(0); i++)
            {
                for (int q = 0; q < layers.GetLength(1); q++)
                {
                    spriteBatch.Draw(layers[i, q].texture, layers[i, q].positionRectangle, layers[i, q].sourceRectangle, Color.White);
                }
            }
        }
    }
}
