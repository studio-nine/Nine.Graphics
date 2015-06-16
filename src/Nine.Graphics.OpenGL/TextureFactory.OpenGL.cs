﻿namespace Nine.Graphics.OpenGL
{
    using Nine.Graphics.Content;
    using OpenTK.Graphics.OpenGL;

    partial class TextureFactory
    {
        private TextureSlice PlatformCreateTexture(TextureContent data)
        {
            GLDebug.CheckAccess();

            var texture = GL.GenTexture();

            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, data.Pixels);

            return new TextureSlice(texture, data.Width, data.Height, 0, data.Width, 0, data.Height);
        }
    }
}
