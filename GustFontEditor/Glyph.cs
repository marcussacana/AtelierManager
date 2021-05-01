using System;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GustFontEditor
{
    public struct Glyph
    {
        public uint UTF8;
        public ushort X;
        public ushort Y;
        public ushort Width;
        public ushort Height;
        public int PaddingLeft;
        public int PaddingTop;
        public int PaddingRigth;
        public int PaddingBottom;

        public Bitmap Texture;
        public char Char
        {
            get
            {
                if (UTF8 == 0)
                    return char.MinValue;
                var Bytes = BitConverter.GetBytes(UTF8);
                while (Bytes.Last() == 0)
                    Array.Resize(ref Bytes, Bytes.Length - 1);
                Bytes = Bytes.Reverse().ToArray();

                return Encoding.UTF8.GetString(Bytes).Single();
            }
            set
            {
                var Bytes = Encoding.UTF8.GetBytes(value.ToString());
                Bytes = Bytes.Reverse().ToArray();

                byte[] DW = new byte[4];
                Bytes.CopyTo(DW, 0);

                UTF8 = BitConverter.ToUInt32(DW, 0);
            }
        }

        public bool IsEmpty() {
            return UTF8 == 0 && X == 0 && Y == 0 && Width == 0 && Height == 0
                && PaddingBottom == 0 && PaddingTop == 0
                && PaddingLeft == 0 && PaddingRigth == 0;
        }

        public byte[] Build() {
            byte[] Data = new byte[0x1C];
            BitConverter.GetBytes(UTF8).CopyTo(Data, 0);
            BitConverter.GetBytes(X).CopyTo(Data, 4);
            BitConverter.GetBytes(Y).CopyTo(Data, 6);
            BitConverter.GetBytes(Width).CopyTo(Data, 8);
            BitConverter.GetBytes(Height).CopyTo(Data, 10);
            BitConverter.GetBytes(PaddingLeft).CopyTo(Data, 12);
            BitConverter.GetBytes(PaddingTop).CopyTo(Data, 16);
            BitConverter.GetBytes(PaddingRigth).CopyTo(Data, 20);
            BitConverter.GetBytes(PaddingBottom).CopyTo(Data, 24);
            return Data;
        }

        public unsafe Glyph(void* Ptr) {
            var StructPtr = ((byte*)Ptr);

            Texture = null;

            UTF8 = *(uint*)StructPtr;
            X = *(ushort*)(StructPtr + 4);
            Y = *(ushort*)(StructPtr + 6);
            Width = *(ushort*)(StructPtr + 8);
            Height = *(ushort*)(StructPtr + 10);
            PaddingLeft = *(int*)(StructPtr + 12);
            PaddingTop = *(int*)(StructPtr + 16);
            PaddingRigth = *(int*)(StructPtr + 20);
            PaddingBottom = *(int*)(StructPtr + 24);
        }

        public unsafe Glyph(byte[] Data, int Position) {
            fixed (byte* Ptr = Data) {
                var StructPtr = (Ptr + Position);

                Texture = null;

                UTF8 = *(uint*)StructPtr;
                X = *(ushort*)(StructPtr + 4);
                Y = *(ushort*)(StructPtr + 6);
                Width = *(ushort*)(StructPtr + 8);
                Height = *(ushort*)(StructPtr + 10);
                PaddingLeft = *(int*)(StructPtr + 12);
                PaddingTop = *(int*)(StructPtr + 16);
                PaddingRigth = *(int*)(StructPtr + 20);
                PaddingBottom = *(int*)(StructPtr + 24);
            }
        }
    }
}
