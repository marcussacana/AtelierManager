using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GustFontEditor
{
    public static class Draw
    {
        public static Glyph CreateGlyph(char Char, Font Font) {
            Glyph NewGlyph = new Glyph()
            {
                Char = Char
            };

            Size GlyphSize;
            using (Bitmap Texture = new Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(Texture)) {
                GlyphSize = g.MeasureString(Char.ToString(), Font).ToSize();
            }

            using (Bitmap SampleA = new Bitmap(GlyphSize.Width, GlyphSize.Height))
            using (Bitmap SampleB = new Bitmap(GlyphSize.Width, GlyphSize.Height))
            using (Bitmap SampleC = new Bitmap(GlyphSize.Width, GlyphSize.Height))
            using (Bitmap Texture = new Bitmap(GlyphSize.Width, GlyphSize.Height))
            using (Graphics gSampleA = Graphics.FromImage(SampleA))
            using (Graphics gSampleB = Graphics.FromImage(SampleB))
            using (Graphics gSampleC = Graphics.FromImage(SampleC))
            using (Graphics gTex = Graphics.FromImage(Texture))
            {
                gSampleA.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                gSampleA.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                gSampleA.DrawString("_", Font, Brushes.White, Point.Empty);
                gSampleA.Flush();

                gSampleB.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                gSampleB.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                gSampleB.DrawString("¯", Font, Brushes.White, Point.Empty);
                gSampleB.Flush();

                char SimpleChar = RemoveDiacritics(Char);
                bool WithDiacritics = SimpleChar != Char;

                gSampleC.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                gSampleC.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                gSampleC.DrawString($"{SimpleChar}", Font, Brushes.White, Point.Empty);
                gSampleC.Flush();

                var Bottom = ScanBottom(SampleA);
                var Left = ScanLeft(SampleA);
                var Top = ScanTop(SampleB);

                gTex.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                gTex.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                gTex.DrawString(Char.ToString(), Font, Brushes.White, Point.Empty);
                gTex.Flush();

                var CharBottom = ScanBottom(Texture);
                var CharLeft = ScanLeft(Texture);
                var CharTop = ScanTop(WithDiacritics ? SampleC : Texture);
                var DiacriticsTop = ScanTop(Texture);

                int BottomDiff = 0;

                if (CharBottom != Bottom) 
                    BottomDiff = CharBottom - Bottom;
                

                int LeftDiff = -1;

                if (CharLeft != Left) 
                    LeftDiff = CharLeft- Left;                

                int NewTop = CharTop;

                if (CharTop < Top) 
                    NewTop += CharTop - Top;


                if (NewTop != DiacriticsTop && WithDiacritics)
                    NewTop += DiacriticsTop - NewTop;

                var Trimmed = TrimBitmap(Texture);
                if (Trimmed == null) {
                    var DotSize = gSampleA.MeasureString("..", Font).ToSize();
                    var DotSpcSize = gSampleA.MeasureString($".{Char}.", Font).ToSize();

                    int SpaceSize = DotSpcSize.Width - DotSize.Width;
                    NewGlyph.Texture = new Bitmap(3, 3);
                    NewGlyph.PaddingTop += (GlyphSize.Height / 2) - 2;
                    NewGlyph.PaddingLeft = 0;
                    NewGlyph.PaddingBottom = 0;
                    NewGlyph.PaddingRigth = SpaceSize;
                    NewGlyph.Width = (ushort)NewGlyph.Texture.Width;
                    NewGlyph.Height = (ushort)NewGlyph.Texture.Height;
                    return NewGlyph;
                }

                NewGlyph.PaddingTop = NewTop;
                NewGlyph.PaddingBottom = 0;
                NewGlyph.PaddingLeft = LeftDiff;
                NewGlyph.PaddingRigth = Trimmed.Width + 1;

                NewGlyph.Texture = Trimmed;

                NewGlyph.Width = (ushort)NewGlyph.Texture.Width;
                NewGlyph.Height = (ushort)NewGlyph.Texture.Height;

                return NewGlyph;
            }

        }

        public static Point FindEmptyBlock(this Bitmap Texture, Size Size, Rectangle[] Areas) {
            Rectangle? Rect = null;
            for (int X = 0; X < Texture.Width; X += Size.Width)
                for (int Y = 0; Y < Texture.Height; Y += Size.Height)
                {
                    var Area = new Rectangle(X, Y, Size.Width, Size.Height);
                    if (Texture.IsEmpty(Area, Areas))
                    {
                        Rect = Area;
                        break;
                    }
                }

            if (Rect == null)
                throw new Exception("Failed to find free space in the font texture.");


            var Rectangle = Rect.Value;
            do {
                Rect = Rectangle;
                Rectangle.X--;
            } while (Texture.IsEmpty(Rectangle, Areas));

            Rectangle = Rect.Value;
            do
            {
                Rect = Rectangle;
                Rectangle.Y--;
            } while (Texture.IsEmpty(Rectangle, Areas));

            return new Point(Rect.Value.X, Rect.Value.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmpty(this Bitmap Texture, Rectangle Area, Rectangle[] Areas) {
            if (Area != null && Areas.Where(x => x.IntersectsWith(Area)).Any())
                return false;

            for (int x = 0; x < Area.Width; x++)
                for (int y = 0; y < Area.Height; y++) {
                    var PosX = x + Area.X;
                    var PosY = y + Area.Y;
                    if (PosX < 0 || PosY < 0 || PosX + Area.Width >= Texture.Width || PosY + Area.Height >= Texture.Height)
                        return false;
                    var Color = Texture.GetPixel(PosX, PosY);
                    if (Color.A != 0)
                        return false;
                }
            return true;
        }

        static int ScanTop(Bitmap Bitmap)
        {
            for (int Y = 0; Y < Bitmap.Height; Y++)
                for (int X = 0; X < Bitmap.Width; X++)
                {
                    var Pixel = Bitmap.GetPixel(X, Y);
                    if (Pixel.A == 0)
                        continue;
                    return Y;
                }
            return 0;
        }
        static int ScanLeft(Bitmap Bitmap)
        {
            for (int X = 0; X < Bitmap.Width; X++)
                for (int Y = 0; Y < Bitmap.Height; Y++)
                {
                    var Pixel = Bitmap.GetPixel(X, Y);
                    if (Pixel.A == 0)
                        continue;
                    return X;
                }
            return 0;
        }
        static int ScanBottom(Bitmap Bitmap)
        {
            for (int Y = Bitmap.Height - 1; Y >= 0; Y--)
                for (int X = 0; X < Bitmap.Width; X++)
                {
                    var Pixel = Bitmap.GetPixel(X, Y);
                    if (Pixel.A == 0)
                        continue;
                    return Y;
                }
            return 0;
        }

        static Bitmap TrimBitmap(Bitmap source)
        {
            bool Empty = true;
            var srcRect = new Rectangle();
            for (int X = 0; X < source.Width && Empty; X++)
                for (int Y = 0; Y < source.Height; Y++)
                {
                    var Pixel = source.GetPixel(X, Y);
                    if (Pixel.A == 0)
                        continue;

                    if (X > 1)
                        X -= 2;

                    Empty = false;
                    srcRect.X = X;
                    break;
                }

            if (Empty)
                return null;

            Empty = true;
            for (int X = source.Width - 1; X >= 0 && Empty; X--)
                for (int Y = source.Height - 1; Y >= 0; Y--)
                {
                    var Pixel = source.GetPixel(X, Y);
                    if (Pixel.A == 0)
                        continue;

                    if (X < source.Width - 1)
                        X += 2;

                    Empty = false;
                    srcRect.Width = X - srcRect.X;
                    break;
                }

            if (Empty)
                return null;

            Empty = true;
            for (int Y = 0; Y < source.Height && Empty; Y++)
                for (int X = 0; X < source.Width; X++)
                {
                    var Pixel = source.GetPixel(X, Y);
                    if (Pixel.A == 0)
                        continue;

                    if (Y > 0)
                        Y--;

                    Empty = false;
                    srcRect.Y = Y;
                    break;
                }

            if (Empty)
                return null;

            Empty = true;
            for (int Y = source.Height - 1; Y >= 0 && Empty; Y--)
                for (int X = source.Width - 1; X >= 0; X--)
                {
                    var Pixel = source.GetPixel(X, Y);
                    if (Pixel.A == 0)
                        continue;

                    if (Y < source.Height)
                        Y++;

                    Empty = false;
                    srcRect.Height = Y - srcRect.Y;
                    break;
                }

            if (Empty)
                return null;

            Bitmap dest = new Bitmap(srcRect.Width, srcRect.Height);
            Rectangle destRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);
            using (Graphics graphics = Graphics.FromImage(dest))
            {
                graphics.DrawImage(source, destRect, srcRect, GraphicsUnit.Pixel);
                graphics.Flush();
            }
            return dest;
        }
        static char RemoveDiacritics(char Char) => RemoveDiacritics(Char.ToString()).First();
        static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
