using System.Drawing;
using System.IO;
using System.Linq;

namespace GustFontEditor
{
    public static class GlyphViewer
    {
        //(Just a note to myself, I don't wanna lost the logic latter)
        //This isn't a fact, sorry guys, I usually didn't work with rendering
        //then I'm not sure of how the padding works, but this is What I supose:
        //What the text render does with the padding:
        //Before draw, he sum PaddingLeft to X and PaddingTop to Y
        //Then he draw the character in the new coordinates
        //Before begin draw the next char, he sum to the next char
        //X point the PaddingRigth and in the Height of the next line
        //will sum the PaddingBottom if the current Height is smaller than the new one.

        public static Bitmap ApplyPadding(this Bitmap Texture, Glyph Info)
        {
            int Top = Info.PaddingTop == -1 ? 0 : Info.PaddingTop;
            int Left = Info.PaddingLeft == -1 ? 0 : Info.PaddingLeft;

            int NewX = Left;
            int NewY = Top;

            int NewWidth = NewX + Info.Width;
            int NewHeight = NewY + Info.Height;

            if (NewWidth < Info.PaddingRigth)
                NewWidth = Info.PaddingRigth;
            if (NewHeight < Info.PaddingBottom)
                NewHeight = Info.PaddingBottom;

            Bitmap NewTexture = new Bitmap(NewWidth, NewHeight);
            using (Graphics g = Graphics.FromImage(NewTexture))
            {
                g.DrawImageUnscaled(Texture, NewX, NewY);
                g.Flush();
            }

            return NewTexture;
        }
        public static bool IsValidGlyph(this Glyph Glyph, Size TextureSize) {
            var Valid = !(Glyph.X + Glyph.Width >= TextureSize.Width || Glyph.Y + Glyph.Height >= TextureSize.Height);
            Valid &= Glyph.Width > 0 && Glyph.Height > 0 && Glyph.UTF8 > 0 && Glyph.UTF8 < 0xF09FBFBF;
            return Valid;
        }
        public static Glyph[] LoadGlyphs(string ExePath, int TableOffset, int EntryCount) => LoadGlyphs(File.ReadAllBytes(ExePath), TableOffset, EntryCount);
        public static Glyph[] LoadGlyphs(byte[] Data, int TableOffset, int EntryCount) {
            var Result = new Glyph[EntryCount];
            for (int i = 0; i < EntryCount; i++)
                Result[i] = new Glyph(Data, TableOffset + (0x1C * i));
            return Result;
        }

        public static Rectangle CreateRectangle(this Glyph Glyph)
        {
            return new Rectangle(Glyph.X, Glyph.Y, Glyph.Width, Glyph.Height);
        }
        public static Rectangle[] CreateRectangles(Glyph[] Entries) {
            return Entries.Select(x => new Rectangle(x.X, x.Y, x.Width, x.Height)).ToArray();
        }

        public static void UpdateSelectedRectangle(this Graphics g, Rectangle OldSelection, Rectangle? NewSelection) {

            var OPen = new Pen(Color.Red, 1f);
            g.DrawRectangle(OPen, OldSelection);

            var SPen = new Pen(Color.LimeGreen, 1f);
            if (NewSelection.HasValue)
                g.DrawRectangle(SPen, NewSelection.Value);

            g.Flush();
        }

        public static void DrawRectangles(this Graphics g, Rectangle[] Entries, int Selected = -1) {
            for (int i = 0; i < Entries.Length; i++) {
                var RectColor = Selected == i ? Color.LimeGreen : Color.Red;
                var Pen = new Pen(RectColor, 1f);
                g.DrawRectangle(Pen, Entries[i]);
            }
        }
    }
}
