using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GustFontEditor
{
    public partial class Main : Form
    {
        int SelectedGlyph = -1;
        int TableOffset;
        int GlyphCount;

        Glyph[] Glyphs = null;
        Rectangle[] Areas = null;
        Graphics GDI = null;

        Bitmap OriTexture;

        DDS DDSTexture;

        MemoryStream FontBuffer;

        public Main()
        {
            InitializeComponent();
        }

        #region IO
        private void btnSelectTex_Click(object sender, EventArgs e)
        {
            fdOpenTexture.ShowDialog();
        }

        private void fdOpenTexture_FileOk(object sender, CancelEventArgs e)
        {
            tbTexturePath.Text = fdOpenTexture.FileName;

            DDSTexture = null;
            FontBuffer = new MemoryStream(File.ReadAllBytes(fdOpenTexture.FileName));

            if (fdOpenTexture.FileName.ToLowerInvariant().EndsWith(".dds")) {
                DDSTexture = new DDS(FontBuffer);
                var Image = DDSTexture.Import().Single();
                FontBuffer.Dispose();
                FontBuffer = new MemoryStream();
                Image.Save(FontBuffer, ImageFormat.Png);
            }

            OriTexture = (Bitmap)Image.FromStream(FontBuffer);
            
            Restore();
            FindGlyphCount();
        }

        private void btnSelectExe_Click(object sender, EventArgs e)
        {
            fdExecutable.ShowDialog();
        }
        private void fdExecutable_FileOk(object sender, CancelEventArgs e)
        {
            tbExePath.Text = fdExecutable.FileName;
            tbGame.Text = FileVersionInfo.GetVersionInfo(fdExecutable.FileName)?.FileDescription;
            TableOffset = TableFinder.FindTableOffset(fdExecutable.FileName);
            tbTableOffset.Text = $"0x{TableOffset:X8}";
            FindGlyphCount();
        }

        private void btnRetryOffsetFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbExePath.Text) || string.IsNullOrEmpty(tbTexturePath.Text))
                return;

            TableOffset = TableFinder.FindTableOffset(fdExecutable.FileName, TableOffset + 1);
            tbTableOffset.Text = $"0x{TableOffset:X8}";
            FindGlyphCount();
        }

        void FindGlyphCount() {
            if (string.IsNullOrEmpty(tbExePath.Text) || string.IsNullOrEmpty(tbTexturePath.Text))
                return;

            GlyphCount = TableFinder.FindGlyphCount(tbExePath.Text, pbMainTexture.Image.Size, TableOffset);
            tbGlyphCount.Text = GlyphCount.ToString();
        }


        private void btnReload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbExePath.Text) || string.IsNullOrEmpty(tbTexturePath.Text))
                return;

            btnReload.Text = "Reload Font";
            GlyphCount = int.Parse(tbGlyphCount.Text.Trim());            
            TableOffset = int.Parse(tbTableOffset.Text.Trim().Replace("0x", ""), NumberStyles.HexNumber);

            FontBuffer.Position = 0;
            OriTexture = Image.FromStream(FontBuffer) as Bitmap;
            Restore();

            Glyphs = GlyphViewer.LoadGlyphs(fdExecutable.FileName, TableOffset, GlyphCount);
            Areas = GlyphViewer.CreateRectangles(Glyphs);


            GDI.DrawRectangles(Areas, SelectedGlyph);
            GDI.Flush();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbExePath.Text) || string.IsNullOrEmpty(tbTexturePath.Text) || Areas == null)
                return;

            var Executable = File.ReadAllBytes(tbExePath.Text);

            var NewTable = Glyphs.OrderBy(x => x.UTF8).ToArray();

            for (int i = 0; i < NewTable.Length; i++) {
                var Data = NewTable[i].Build();
                var Offset = TableOffset + (0x1C * i);
                Data.CopyTo(Executable, Offset);
            }


            var OutTexPath = Path.Combine(Path.GetDirectoryName(tbTexturePath.Text), Path.GetFileNameWithoutExtension(tbTexturePath.Text) + "-new" + Path.GetExtension(tbTexturePath.Text));
            var OutExePath = Path.Combine(Path.GetDirectoryName(tbExePath.Text), Path.GetFileNameWithoutExtension(tbExePath.Text) + "-new.exe");

            if (DDSTexture != null)
            {
                using (Stream Output = File.Create(OutTexPath))
                    DDSTexture.Export(Output, new Bitmap[] { OriTexture });
            } else
                OriTexture.Save(OutTexPath, ImageFormat.Png);

            File.WriteAllBytes(OutExePath, Executable);

            MessageBox.Show("Font Updated!", "Gust Font Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Viewer

        string EditorPath = null;
        private void pbCharVeiwer_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbExePath.Text) || string.IsNullOrEmpty(tbTexturePath.Text) || Areas == null)
                return;

            if (SelectedGlyph == -1)
                return;

            if (EditorPath == null)
            {

                string[] CommonPaths = new string[] {
                    @"Program Files\Adobe\Adobe Photoshop 2020\Photoshop.exe",
                    @"Program Files\Corel\CorelDRAW Graphics Suite 2020\Programs64\CorelDRW.exe",
                    @"Program Files\paint.net\PaintDotNet.exe"
                };

                foreach (var Drive in DriveInfo.GetDrives())
                {
                    var Root = Drive.RootDirectory.FullName;

                    var Paths = CommonPaths.Select(x => Path.Combine(Root, x)).Where(x => File.Exists(x));

                    if (Paths.Any())
                    {
                        EditorPath = Paths.First();
                        break;
                    }
                }
            }

            if (EditorPath == null) {
                MessageBox.Show("No Supported Image Editors Found,\nYou just neeed install the Paint.Net in the default location :)", "Gust Font Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tmp = Path.GetTempFileName();
            File.Delete(tmp);
            tmp += ".png";

            var Glyph = Glyphs[SelectedGlyph];
            var Area = Areas[SelectedGlyph];

            using (var Copy = OriTexture.Clone(Area, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                Copy.Save(tmp, System.Drawing.Imaging.ImageFormat.Png);

            var OriTime = new FileInfo(tmp).LastWriteTimeUtc;
            var Proc = Process.Start(EditorPath, tmp);
            Proc.WaitForExit();

            bool Changed = OriTime != new FileInfo(tmp).LastWriteTimeUtc;

            if (Changed)
            {
                using (var Img = Bitmap.FromFile(tmp))
                using (var g = Graphics.FromImage(OriTexture))
                {
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.CompositingMode = CompositingMode.SourceOver;
                    g.DrawImageUnscaled(Img, Area.Location);
                    g.Flush();
                }

                Restore();
                GDI.DrawRectangles(Areas, SelectedGlyph);
                SetSelection(SelectedGlyph);
            }

            File.Delete(tmp);

            if (Changed)
                MessageBox.Show("Glyph Texture Updated!", "Gust Font Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void pbMainTexture_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbExePath.Text) || string.IsNullOrEmpty(tbTexturePath.Text) || Areas == null)
                return;

            var Pos = MousePosition;
            Pos = pbMainTexture.PointToClient(Pos);

            var NewSelection = Areas.Select((x, i) => (Rect: x, Ind: i)).Where(x => Pos.X >= x.Rect.Left
                                                                                 && Pos.X <= x.Rect.Right
                                                                                 && Pos.Y >= x.Rect.Top
                                                                                 && Pos.Y <= x.Rect.Bottom).Select(x => x.Ind).FirstOrDefault();
            SetSelection(NewSelection);
        }
        private void btnSearchChar_Click(object sender, EventArgs e)
        {
            var Str = tbSearchChar.Text.Trim();
            if (tbSearchChar.Text == " ")
                Str = " ";

            if (Str.Length == 1)
                SetSelection(Glyphs.Select((x, i) => (Glyph: x, Ind: i)).Where(x => x.Glyph.Char == Str.First()).Select(x => x.Ind).FirstOrDefault());
            else if (int.TryParse(Str, out int Val))
                SetSelection(Val);
        }

        private void SetSelection(int NewSelection)
        {
            pbCharVeiwer.Cursor = Cursors.Hand;

            int OldSel = SelectedGlyph;
            if (OldSel == -1)
                OldSel = 0;

            GDI.UpdateSelectedRectangle(Areas[OldSel], NewSelection == -1 ? null : (Rectangle?)Areas[NewSelection]);
            pbMainTexture.Refresh();

            if (NewSelection == -1 || !Glyphs[NewSelection].IsValidGlyph(OriTexture.Size))
                return;

            SelectedGlyph = -1;

            lblID.Text = $"ID: {NewSelection}";
            tbChar.Text = Glyphs[NewSelection].Char.ToString();

            nudX.Value = Glyphs[NewSelection].X;
            nudY.Value = Glyphs[NewSelection].Y;

            nudWidth.Value = Glyphs[NewSelection].Width;
            nudHeight.Value = Glyphs[NewSelection].Height;

            nudTop.Value = Glyphs[NewSelection].PaddingTop;
            nudBottom.Value = Glyphs[NewSelection].PaddingBottom;
            nudLeft.Value = Glyphs[NewSelection].PaddingLeft;
            nudRigth.Value = Glyphs[NewSelection].PaddingRigth;

            PreviewPadding(NewSelection);

            SelectedGlyph = NewSelection;
        }

        private void PreviewPadding(int Index = -1) {
            if (Index == -1)
                Index = SelectedGlyph;

            var Glyph = Glyphs[Index];

            var Img = OriTexture.Clone(Areas[Index], PixelFormat.Format32bppArgb);
            var NewImg = Img.ApplyPadding(Glyph);
            Img?.Dispose();

            using (Graphics g = Graphics.FromImage(NewImg)) {
                g.DrawRectangle(Pens.Red, new Rectangle(0, 0, NewImg.Width - 1, NewImg.Height - 1));

                var PaddingRect = new Rectangle
                {
                    X = Glyph.PaddingLeft == -1 ? 0 : Glyph.PaddingLeft,
                    Y = Glyph.PaddingTop == -1 ? 0 : Glyph.PaddingTop,
                };

                PaddingRect.Width = Glyph.PaddingRigth <= 0 ? NewImg.Width - 1 : Glyph.PaddingRigth;
                PaddingRect.Height = Glyph.PaddingBottom <= 0 ? NewImg.Height - 1 : Glyph.PaddingBottom;

                g.DrawRectangle(Pens.Blue, PaddingRect);
                g.Flush();
            }

            pbCharVeiwer.Image?.Dispose();
            pbCharVeiwer.Image = NewImg;
        }

        private void Restore() {
            GDI?.Dispose();
            pbMainTexture.Image?.Dispose();
            pbMainTexture.Image = OriTexture.Clone() as Bitmap;

            GDI = Graphics.FromImage(pbMainTexture.Image);
        }

        #endregion

        #region ViewerEvents
        private void tbSearchChar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearchChar.PerformClick();
        }

        private void nudX_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedGlyph >= 0 && SelectedGlyph < Glyphs.Length)
            {
                Areas[SelectedGlyph].X = Glyphs[SelectedGlyph].X = (ushort)nudX.Value;

                Restore();
                GDI.DrawRectangles(Areas, SelectedGlyph);
            }
        }
        private void nudY_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedGlyph >= 0 && SelectedGlyph < Glyphs.Length)
            {
                Areas[SelectedGlyph].Y = Glyphs[SelectedGlyph].Y = (ushort)nudY.Value;

                Restore();
                GDI.DrawRectangles(Areas, SelectedGlyph);
            }
        }

        private void nudWidth_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedGlyph >= 0 && SelectedGlyph < Glyphs.Length)
            {
                Areas[SelectedGlyph].Width = Glyphs[SelectedGlyph].Width = (ushort)nudWidth.Value;

                Restore();
                GDI.DrawRectangles(Areas, SelectedGlyph);
            }
        }

        private void nudHeight_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedGlyph >= 0 && SelectedGlyph < Glyphs.Length)
            {
                Areas[SelectedGlyph].Height = Glyphs[SelectedGlyph].Height = (ushort)nudHeight.Value;

                Restore();
                GDI.DrawRectangles(Areas, SelectedGlyph);
            }
        }

        private void tbChar_TextChanged(object sender, EventArgs e)
        {
            if (SelectedGlyph >= 0 && SelectedGlyph < Glyphs.Length && tbChar.Text.Length > 0)
            {
                Glyphs[SelectedGlyph].Char = tbChar.Text.First();
            }
        }

        private void nudTop_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedGlyph >= 0 && SelectedGlyph < Glyphs.Length) {
                Glyphs[SelectedGlyph].PaddingTop = (int)nudTop.Value;
                PreviewPadding();
            }
        }

        private void nudBottom_ValueChanged(object sender, EventArgs e)
        {            
            if (SelectedGlyph >= 0 && SelectedGlyph < Glyphs.Length) {
                Glyphs[SelectedGlyph].PaddingBottom = (int)nudBottom.Value;
                PreviewPadding();
            }
        }

        private void nudLeft_ValueChanged(object sender, EventArgs e)
        {            
            if (SelectedGlyph >= 0 && SelectedGlyph < Glyphs.Length) {
                Glyphs[SelectedGlyph].PaddingLeft = (int)nudLeft.Value;
                PreviewPadding();
            }
        }

        private void nudRigth_ValueChanged(object sender, EventArgs e)
        {
            
            if (SelectedGlyph >= 0 && SelectedGlyph < Glyphs.Length) {
                Glyphs[SelectedGlyph].PaddingRigth = (int)nudRigth.Value;
                PreviewPadding();
            }
        }
        #endregion

        #region Redraw

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbExePath.Text) || string.IsNullOrEmpty(tbTexturePath.Text) || Areas == null)
                return;

            pbPreview.Image?.Dispose();
            pbPreview.Image = Preview.Generate(tbPreview.Text, OriTexture, Glyphs);
            pbPreview.Refresh();
        }

        private void RedrawTextChanged(object sender, EventArgs e)
        {
            int Cursor = tbRedraw.SelectionStart;

            if (Cursor > 0 && Cursor < tbRemap.Text.Length && tbRemap.Text.Length < tbRedraw.Text.Length)
                tbRemap.Text = tbRemap.Text.Insert(Cursor - 1, new string('-', tbRedraw.Text.Length - tbRemap.Text.Length));
            else if (Cursor > 0 && Cursor < tbRemap.Text.Length && tbRemap.Text.Length > tbRedraw.Text.Length)            
                tbRemap.Text = tbRemap.Text.Remove(Cursor, tbRemap.Text.Length - tbRedraw.Text.Length);            
            else if (tbRemap.Text.Length > tbRedraw.Text.Length)
                tbRemap.Text = tbRemap.Text.Substring(0, tbRedraw.Text.Length);
            else if (tbRedraw.Text.Length > tbRemap.Text.Length)
                tbRemap.Text += new string('-', tbRedraw.Text.Length - tbRemap.Text.Length);
        }
        private void tbPreview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnPreview.PerformClick();
        }

        private void btnRedraw_Click(object sender, EventArgs e)
        {
            bool Remap = cbRemapEnabled.Checked;
            if (!float.TryParse(tbSize.Text.Trim(), out float Size) || (tbRedraw.Text.Length != tbRemap.Text.Length && Remap) || Areas == null)
                return;

            btnRedraw.Enabled = false;

            var ImportantList = tbImportantList.Text.Trim(' ', ',').Split(',').Where(x=>x.Contains(':'));

            var ImportantRanges = ImportantList.Where(x => {
                var Parts = x.Split(':');
                if (Parts.Length != 2)
                    return false;
                return int.TryParse(Parts[0].Trim(), out _) && int.TryParse(Parts[1].Trim(), out _);
            }).Select(x => (Begin: int.Parse(x.Split(':')[0].Trim()), End: int.Parse(x.Split(':')[1].Trim())));

            List<int> Skips = new List<int>();
                
            var Font = new Font(tbFacename.Text, Size, FontStyle.Regular, GraphicsUnit.Pixel);

            var NonImportantGlyphs = Glyphs.Where((x, y) =>
            {
                if (Skips.Contains(y))
                    return false;

                foreach (var Range in ImportantRanges)
                    if (y >= Range.Begin && y <= Range.End)
                        return false;
                return true;
            });

            for (int i = 0; i < tbRedraw.Text.Length; i++) {
                char TargetChar = tbRedraw.Text[i];
                char? RemapChar = Remap ? (char?)tbRemap.Text[i] : null;

                var OriGlyph = NonImportantGlyphs.Where(x => x.Char == (RemapChar ?? TargetChar)).FirstOrDefault();

                var NewGlyph = Draw.CreateGlyph(TargetChar, Font);

                if (!OriGlyph.IsValidGlyph(OriTexture.Size) || OriGlyph.IsEmpty()) {
                    var Available = NonImportantGlyphs.Where(x => !tbRedraw.Text.Contains(x.Char) && x.IsValidGlyph(OriTexture.Size));

                    if (Remap)
                        Available = Available.Where(x => !tbRemap.Text.Replace("-", "").Contains(x.Char));

                    Available = Available.OrderBy(x => x.Width * x.Height);

                    foreach (var Item in Available.Reverse()) {
                        if (NewGlyph.Width <= Item.Width && NewGlyph.Height <= Item.Height)
                        {
                            OriGlyph = Item;
                            break;
                        }
                    }

                    if (OriGlyph.IsEmpty())
                        OriGlyph = Available.Last();
                }

                int OriIndex = -1;
                for (int x = 0; x < Glyphs.Length; x++) {
                    if (Glyphs[x].Char == OriGlyph.Char) {
                        OriIndex = x;
                        break;
                    }
                }

                NewGlyph.Char = RemapChar ?? TargetChar;

                NewGlyph.X = OriGlyph.X;
                NewGlyph.Y = OriGlyph.Y;

                if (NewGlyph.Texture.Width > OriGlyph.Width || NewGlyph.Texture.Height > OriGlyph.Height)
                {
                    var Point = OriTexture.FindEmptyBlock(NewGlyph.Texture.Size, Areas);
                    var NewRect = new Rectangle(Point, NewGlyph.Texture.Size);
                    NewGlyph.X = (ushort)Point.X;
                    NewGlyph.Y = (ushort)Point.Y;
                }

                using (var Bitmap = NewGlyph.Texture)
                using (Graphics g = Graphics.FromImage(OriTexture)) {
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.CompositingMode = CompositingMode.SourceCopy;

                    g.FillRectangle(Brushes.Transparent, OriGlyph.CreateRectangle());
                    g.DrawImageUnscaled(NewGlyph.Texture, NewGlyph.X, NewGlyph.Y);
                    g.Flush();
                }

                if (cbTrimming.Checked) {
                    NewGlyph.PaddingLeft--;
                    NewGlyph.PaddingRigth--;
                }

                Glyphs[OriIndex] = NewGlyph;
                Areas[OriIndex] = NewGlyph.CreateRectangle();
                Skips.Add(OriIndex);

                Application.DoEvents();
            }

            Restore();

            using (Graphics g = Graphics.FromImage(pbMainTexture.Image))
                g.DrawRectangles(Pens.Red, Areas);

            btnRedraw.Enabled = true;

            MessageBox.Show("Font Updated!", "Gust Font Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Egg
        Random Random = new Random();
        private void SecretEnter(object sender, EventArgs e)
        {
            int MaxX = tabAbout.Width - btnSecret.Width - 3;
            int MaxY = tabAbout.Height - btnSecret.Height - 3;

            int MinX = 3;
            int MinY = lblToolTitle.Height;

            btnSecret.Location = new Point(Random.Next(MinX, MaxX), Random.Next(MinY, MaxY));
        }

        private void btnSecret_Click(object sender, EventArgs e)
        {
            wbEgg.Navigate("http://www.partridgegetslucky.com/");
            btnSecret.Visible = false;
            WindowState = FormWindowState.Maximized;
            MessageBox.Show("Ya, you got me", "Oww shit", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Triggered(object sender, WebBrowserNavigatingEventArgs e)
        {
            wbEgg.Visible = true;
        }
        #endregion

        private void btnLoadLST_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Chars.lst file|chars.lst;charsalt.lst";
            if (fd.ShowDialog() != DialogResult.OK)
                return;

            var Lines = File.ReadAllLines(fd.FileName)
                            .Where(x => x.Trim().Length == 3 && x.Trim()[1] == '=')
                            .Select(x=> x.Trim()).ToArray();

            foreach (var Pair in Lines) {
                var PsyChar = Pair[0];
                var FakChar = Pair[2];

                if (tbRedraw.Text.Contains(PsyChar)) {
                    int Ind = tbRedraw.Text.IndexOf(PsyChar);
                    tbRemap.Text = tbRemap.Text.Insert(Ind, FakChar.ToString());
                    tbRemap.Text = tbRemap.Text.Remove(Ind + 1, 1);
                } else {
                    tbRedraw.Text += PsyChar;
                    tbRemap.Text += FakChar;
                }
            }
        }
    }
}
