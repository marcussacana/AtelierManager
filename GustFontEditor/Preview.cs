using System.Drawing;
using System.Linq;

namespace GustFontEditor
{
    static class Preview
    {
        public static Bitmap Generate(string Text, Bitmap Texture, Glyph[] Glyphs) {
            int MeasuredWith = 1;
            int MeasuredHeight = 1;

            foreach (var Char in Text) {
                var Glyph = Glyphs.Where(x => x.Char == Char).FirstOrDefault();
                if (!Glyph.IsValidGlyph(Texture.Size))
                    continue;

                MeasuredWith += Glyph.PaddingLeft;

                if (Glyph.PaddingRigth != 0)
                    MeasuredWith += Glyph.PaddingRigth;
                else
                    MeasuredWith += Glyph.Width;


                int Height = Glyph.Height + Glyph.PaddingTop + Glyph.PaddingBottom;
                if (MeasuredHeight < Height)
                    MeasuredHeight = Height;
            }

            var Preview = new Bitmap(MeasuredWith, MeasuredHeight);
            using (Graphics Prev = Graphics.FromImage(Preview)) {
                int X = 0;
                foreach (var Char in Text) {
                    var Glyph = Glyphs.Where(x => x.Char == Char).FirstOrDefault();
                    if (!Glyph.IsValidGlyph(Texture.Size))
                        continue;
                    using (var GlyphTex = Texture.Clone(Glyph.CreateRectangle(), System.Drawing.Imaging.PixelFormat.Format32bppArgb)) {
                        Prev.DrawImageUnscaled(GlyphTex, new Point(X + Glyph.PaddingLeft, Glyph.PaddingTop));
                    }
                    X += Glyph.PaddingLeft;

                    if (Glyph.PaddingRigth != 0)
                        X += Glyph.PaddingRigth;
                    else
                        X += Glyph.Width;
                }
                Prev.Flush();
            }
            return Preview;
        }


    }
}
