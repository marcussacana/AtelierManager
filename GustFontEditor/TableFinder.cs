using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GustFontEditor
{
    static class TableFinder
    {

        //You can search for a algorithm like this to find the offset manually
        //this is a 'switch' that choose the game the game font, where each
        //jz short loc_???????? is a offset to a font table in the game executable

        //Sample from Atelier Firis DX
        //.text:000000014027BB9D         sub eax, 1
        //.text:000000014027BBA0 jz      short loc_14027BBDA
        //.text:000000014027BBA2 sub     eax, 1
        //.text:000000014027BBA5 jz      short loc_14027BBD1
        //.text:000000014027BBA7 sub     eax, 1
        //.text:000000014027BBAA jz      short loc_14027BBB6
        //.text:000000014027BBAC sub     eax, 1
        //.text:000000014027BBAF jz      short loc_14027BBC8
        //.text:000000014027BBB1 cmp     eax, 1
        //.text:000000014027BBB4 jz      short loc_14027BBBF
        //.text:000000014027BBB6
        //.text:000000014027BBB6 loc_14027BBB6:                          ; CODE XREF: FindGylph+8A↑j
        //.text:000000014027BBB6 lea     rbx, unk_140B4F010
        //.text:000000014027BBBD jmp     short loc_14027BBE1
        //.text:000000014027BBBF ; ---------------------------------------------------------------------------
        //.text:000000014027BBBF
        //.text:000000014027BBBF loc_14027BBBF:                          ; CODE XREF: FindGylph+94↑j
        //.text:000000014027BBBF lea     rbx, unk_140B9D770
        //.text:000000014027BBC6 jmp     short loc_14027BBE1
        //.text:000000014027BBC8 ; ---------------------------------------------------------------------------
        //.text:000000014027BBC8
        //.text:000000014027BBC8 loc_14027BBC8:                          ; CODE XREF: FindGylph+8F↑j
        //.text:000000014027BBC8 lea     rbx, unk_140B77880
        //.text:000000014027BBCF jmp     short loc_14027BBE1
        //.text:000000014027BBD1 ; ---------------------------------------------------------------------------
        //.text:000000014027BBD1
        //.text:000000014027BBD1 loc_14027BBD1:                          ; CODE XREF: FindGylph+85↑j
        //.text:000000014027BBD1 lea     rbx, unk_140B6BFF0
        //.text:000000014027BBD8 jmp     short loc_14027BBE1
        //.text:000000014027BBDA ; ---------------------------------------------------------------------------
        //.text:000000014027BBDA
        //.text:000000014027BBDA loc_14027BBDA:                          ; CODE XREF: FindGylph+80↑j
        //.text:000000014027BBDA lea     rbx, unk_140B83B30


        public static int FindTableOffset(string FilePath, int FontOffset = -1) => FindTableOffset(File.ReadAllBytes(FilePath), FontOffset);
        public unsafe static int FindTableOffset(byte[] Executable, int FontOffset = -1)
        {
            fixed (byte* Ptr = Executable)
            {
                if (FontOffset == -1)
                {
                    for (int i = 0; i < Executable.Length - 5; i++)
                    {
                        uint DW = *(uint*)(Ptr + i);
                        byte Last = *(Ptr + i + 4);
                        if (DW != 0x746E6F46 || Last != 0x2F)//Font/
                            continue;

                        FontOffset = i;
                        break;
                    }
                }

                if (FontOffset == -1)
                    return -1;

                for (int i = FontOffset + (16 - (FontOffset % 16)); i < Executable.Length; i += 16) {
                    uint* Info = (uint*)(Ptr + i);
                    uint DW = *Info;
                    if (DW != 0)
                        continue;

                    Info++;
                    DW = *Info;
                    if (DW == 0)
                        continue;


                    Info++;
                    DW = *Info;
                    if (DW != 0x00030003)
                        continue;

                    Info++;
                    DW = *Info;
                    if (DW != 0xFFFFFFFF)
                        continue;

                    return i;
                }

                bool DRMFound = false;
                var DRMPattern = System.Text.Encoding.ASCII.GetBytes(".bind");
                fixed (byte* pPattern = DRMPattern)
                {
                    for (int i = 0; i < Executable.Length; i++)
                    {
                        var Found = true;
                        for (int x = 0; x < DRMPattern.Length; x++)
                        {
                            if (DRMPattern[x] != Executable[i+x]) {
                                Found = false;
                                break;
                            }
                        }
                        if (Found) {
                            DRMFound = true;
                            break;
                        }
                    }
                }

                if (DRMFound)
                    MessageBox.Show("This game is protected with the Steam Stub, you must unpack it before.", "Error - Game Protected", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }
        }

        public static unsafe int FindGlyphCount(string ExePath, Size TextureSize, int TableOffset) => FindGlyphCount(File.ReadAllBytes(ExePath), TextureSize, TableOffset);
        public static unsafe int FindGlyphCount(byte[] Exe, Size TextureSize, int TableOffset) {
            int MaxOffset = TableOffset + 1;
            MaxOffset = FindTableOffset(Exe, MaxOffset);
            if (MaxOffset == -1)
                MaxOffset = Exe.Length - 0x1C;

            int Count = 0;

            bool Invalid = false;
            int Offset = 0; 

            while ((Offset = TableOffset + (Count * 0x1C)) < MaxOffset) {
                var Glyph = new Glyph(Exe, Offset);
                var Valid = Glyph.IsValidGlyph(TextureSize);
                
                if (!Valid && Invalid)
                    return Count - 1;
                
                if (!Valid && !Invalid)
                    Invalid = true;

                if (Valid)
                    Invalid = false;

                Count++;
            }

            return Count - 1;
        }

    }
}
