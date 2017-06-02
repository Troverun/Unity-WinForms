﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using UE = UnityEngine;

namespace Unity.API
{
    public class UnityGdiTexture : ITexture
    {
        internal readonly UE.Texture2D texture;

        public int Height { get { return texture.height; } }
        public int Width { get { return texture.width; } }

        public UnityGdiTexture(int width, int height)
        {
            texture = new UE.Texture2D(width, height);
        }
        public UnityGdiTexture(UE.Texture2D tex)
        {
            texture = tex;
        }

        public void Apply()
        {
            texture.Apply();
        }
        public Color GetPixel(int x, int y)
        {
            return texture.GetPixel(x, y).ToColor();
        }

        public Color[] GetPixels()
        {
            return GetPixels(0, 0, Width, Height);
        }
        public Color[] GetPixels(int x, int y, int width, int height)
        {
            var ucs = texture.GetPixels(x, y, width, height);
            var cs = new Color[ucs.Length];
            for (int i = 0; i < ucs.Length; i++)
                cs[i] = ucs[i].ToColor();

            return cs;
        }
        public void SetPixel(int x, int y, Color color)
        {
            texture.SetPixel(x, y, color.ToUnityColor());
        }
        public void SetPixels(Color[] colors)
        {
            var ucs = new UnityEngine.Color32[colors.Length];
            for (int i = 0; i < ucs.Length; i++)
                ucs[i] = colors[i].ToUnityColor();

            texture.SetPixels32(ucs);
        }
        public void SetPixels(int x, int y, int width, int height, Color[] colors)
        {
            var ucs = new UnityEngine.Color32[colors.Length];
            for (int i = 0; i < ucs.Length; i++)
                ucs[i] = colors[i].ToUnityColor();

            texture.SetPixels32(x, y, width, height, ucs);
        }
    }
}
