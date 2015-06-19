﻿namespace Nine.Graphics
{
    using Nine.Imaging;
    using System.Numerics;

    public struct Sprite
    {
        public readonly bool IsVisible;
        public readonly float Opacity;
        public readonly Vector2 Position;
        public readonly Vector2 Scale;
        public readonly Vector2 Size;
        public readonly float Rotation;
        public readonly Vector2 Origin;
        public readonly TextureId Texture;
        public readonly float Depth;
        public readonly Color Color;
        public readonly Matrix3x2 Transform;
        public readonly bool HasTransform;

        public static readonly Sprite Default = new Sprite(default(TextureId));
        
        public Sprite(
            TextureId texture,
            Vector2 position = default(Vector2),
            float opacity = 1.0f,
            Vector2? scale = null,
            Vector2? size = null,
            float rotation = 0,
            Vector2 origin = default(Vector2),
            bool isVisible = true,
            float depth = 0,
            Color? color = null,
            Matrix3x2? transform = null)
        {
            this.Texture = texture;
            this.IsVisible = isVisible;
            this.Opacity = opacity;
            this.Position = position;
            this.Scale = scale ?? Vector2.One;
            this.Rotation = rotation;
            this.Size = size ?? Vector2.Zero;
            this.Origin = origin;
            this.Depth = depth;
            this.Color = color ?? Color.White;
            this.Transform = transform ?? Matrix3x2.Identity;
            this.HasTransform = transform != null;
        }
    }
}
