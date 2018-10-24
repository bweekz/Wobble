﻿using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wobble.Audio.Tracks;
using Wobble.Graphics;
using Wobble.Graphics.BitmapFonts;
using Wobble.Graphics.Sprites;
using Wobble.Screens;
using Wobble.Window;
using Color = Microsoft.Xna.Framework.Color;

namespace Wobble.Tests.Screens.Tests.BitmapFont
{
    public class TestBitmapFontScreenView : ScreenView
    {
        /// <summary>
        ///     Audio track
        /// </summary>
        public AudioTrack Track { get; }

        /// <summary>
        ///     The text that is being displayed.
        /// </summary>
        public SpriteTextBitmap SongTimeText { get; }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="screen"></param>
        public TestBitmapFontScreenView(Screen screen) : base(screen)
        {
            // (This should normally be done at the start of the game.)
            // Load up a font to use by a byte[] / ResourceStore.
            if (!BitmapFontFactory.CustomFonts.ContainsKey("exo2-bold"))
                BitmapFontFactory.AddFont("exo2-bold", GameBase.Game.Resources.Get("Wobble.Tests.Resources/Fonts/exo2-bold.otf"));

            // (This should normally be done at the start of the game.)
            // Load up a font to use by file
            // BitmapFontFactory.AddFont("exo2-regular", @"C:\users\admin\desktop\exo2-regular.otf");

            SongTimeText = new SpriteTextBitmap("exo2-bold", "0", 16)
            {
                Parent = Container,
            };

            Track = new AudioTrack(GameBase.Game.Resources.Get("Wobble.Tests.Resources/Tracks/virt - Send My Love To Mars.mp3"));
            Track.Play();
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            // Update the text with the current song time.
            SongTimeText.Text = ((int) Track.Time).ToString();

            Container?.Update(gameTime);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            GameBase.Game.GraphicsDevice.Clear(Color.CornflowerBlue);
            Container?.Draw(gameTime);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override void Destroy()
        {
            Track.Dispose();
            Container?.Destroy();
        }
    }
}