using DirectXTexNet;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace GustFontEditor
{
    public class DDS
    {

        byte[] Data;
        int TexCount;
        ScratchImage Texture;
        TexMetadata Metadata;
        DXGI_FORMAT dFormat;

        public DDS(Stream Data)
        {
            MemoryStream Mem = new MemoryStream();
            Data.CopyTo(Mem);
            this.Data = Mem.ToArray();
        }

        public DDS(byte[] Data)
        {
            this.Data = Data;
        }


        public Bitmap[] Import()
        {
            IntPtr DDS = new MemoryStream(Data).Alloc();
            Texture = TexHelper.Instance.LoadFromDDSMemory(DDS, Data.LongLength, DDS_FLAGS.NONE);
            Metadata = Texture.GetMetadata();

            TexCount = Texture.GetImageCount() / Metadata.MipLevels;
            if (TexCount == 0)
                throw new Exception("Unexpected DDS Entries/MipLevels");

            if (Metadata.IsCompressed())
            {
                Texture = Texture.Decompress(0, DXGI_FORMAT.UNKNOWN);
                dFormat = Texture.GetMetadata().Format;
            }

            if ((Metadata.IsCompressed() ? dFormat : Metadata.Format) != DXGI_FORMAT.R8G8B8A8_UNORM)
                Texture = Texture.Convert(DXGI_FORMAT.R8G8B8A8_UNORM, TEX_FILTER_FLAGS.DEFAULT, 1f);

            Bitmap[] Textures = new Bitmap[TexCount];
            for (int i = 0; i < TexCount; i++)
            {
                Textures[i] = Texture.GetImage(i).GetBitmap();
            }
            return Textures;
        }

        public byte[] Export(Bitmap[] Tex)
        {
            if (Texture.GetMetadata().IsCompressed())
                Texture = Texture.Decompress(0, DXGI_FORMAT.UNKNOWN);

            if (Texture.GetMetadata().Format != DXGI_FORMAT.R8G8B8A8_UNORM)
                Texture = Texture.Convert(DXGI_FORMAT.R8G8B8A8_UNORM, TEX_FILTER_FLAGS.DEFAULT, 1f);

            for (int i = 0; i < TexCount; i++)
                Texture = Texture.SetBitmap(Tex[i], i);

            DXGI_FORMAT Format = (Metadata.IsCompressed() ? dFormat : Metadata.Format);
            if (Format != DXGI_FORMAT.R8G8B8A8_UNORM)
                Texture = Texture.Convert(Format, TEX_FILTER_FLAGS.DEFAULT, 1f);

            if (Metadata.IsCompressed())
                Texture = Texture.Compress(Metadata.Format, TEX_COMPRESS_FLAGS.DEFAULT, 1f);

            using (Stream Stream = Texture.SaveToDDSMemory(DDS_FLAGS.NONE))
            {
                using (MemoryStream MStream = new MemoryStream())
                {
                    Stream.CopyTo(MStream);
                    return MStream.ToArray();
                }
            }
        }


        public void Export(Stream Output, Bitmap[] Texture)
        {
            using (MemoryStream Stream = new MemoryStream(Export(Texture)))
            {
                Stream.CopyTo(Output);
                Stream.Close();
            }
        }
    }

    static class DDSExtensions
    {
        public static Bitmap GetBitmap(this DirectXTexNet.Image Image)
        {
            if (Image.Format != DXGI_FORMAT.R8G8B8A8_UNORM)
                throw new Exception("Only RGBA (UNORM) Is supported");

            int Size = TexHelper.Instance.BitsPerPixel(Image.Format) / 8;
            IntPtr Address = Image.Pixels;
            Bitmap Result = new Bitmap(Image.Width, Image.Height);
            for (int y = 0; y < Result.Height; y++)
                for (int x = 0; x < Result.Width; x++)
                {
                    byte[] Arr = new byte[Size];
                    Marshal.Copy(Address, Arr, 0, Arr.Length);
                    Address = Address.Sum(Size);

                    Color Color = Color.FromArgb(Arr[3], Arr[0], Arr[1], Arr[2]);
                    Result.SetPixel(x, y, Color);
                }

            return Result;
        }

        public static ScratchImage SetBitmap(this ScratchImage Texture, Bitmap Content, int Index = 0)
        {
            var Meta = Texture.GetMetadata();
            if (Meta.Format != DXGI_FORMAT.R8G8B8A8_UNORM)
                throw new Exception("Only RGBA (UNORM) Is supported");

            int Size = TexHelper.Instance.BitsPerPixel(Meta.Format) / 8;
            byte[] Buffer = new byte[Content.Height * Content.Width * Size];
            for (int y = 0, z = 0; y < Content.Height; y++)
                for (int x = 0; x < Content.Width; x++)
                {
                    Color Pixel = Content.GetPixel(x, y);
                    new byte[] { Pixel.R, Pixel.G, Pixel.B, Pixel.A }.CopyTo(Buffer, z);
                    z += Size;
                }

            var Result = Texture.Resize(Content.Width, Content.Height, TEX_FILTER_FLAGS.DEFAULT);
            var Image = Result.GetImage(Index);
            Marshal.Copy(Buffer, 0, Image.Pixels, Buffer.Length);

            return Result;
        }


        public static IntPtr Alloc(this Stream Data)
        {
            byte[] Array = Data.ToArray();
            IntPtr Address = Marshal.AllocHGlobal(Array.Length);
            Marshal.Copy(Array, 0, Address, Array.Length);

            return Address;
        }
        public static bool IsCompressed(this TexMetadata Metadata)
        {
            DXGI_FORMAT[] Compressions = new DXGI_FORMAT[] {
                    DXGI_FORMAT.BC1_TYPELESS,
                    DXGI_FORMAT.BC1_UNORM,
                    DXGI_FORMAT.BC1_UNORM_SRGB,
                    DXGI_FORMAT.BC2_TYPELESS,
                    DXGI_FORMAT.BC2_UNORM,
                    DXGI_FORMAT.BC2_UNORM_SRGB,
                    DXGI_FORMAT.BC3_TYPELESS,
                    DXGI_FORMAT.BC3_UNORM,
                    DXGI_FORMAT.BC3_UNORM_SRGB,
                    DXGI_FORMAT.BC4_SNORM,
                    DXGI_FORMAT.BC4_TYPELESS,
                    DXGI_FORMAT.BC4_UNORM,
                    DXGI_FORMAT.BC5_SNORM,
                    DXGI_FORMAT.BC5_TYPELESS,
                    DXGI_FORMAT.BC5_UNORM,
                    DXGI_FORMAT.BC6H_SF16,
                    DXGI_FORMAT.BC6H_TYPELESS,
                    DXGI_FORMAT.BC6H_UF16,
                    DXGI_FORMAT.BC7_TYPELESS,
                    DXGI_FORMAT.BC7_UNORM,
                    DXGI_FORMAT.BC7_UNORM_SRGB
                };

            return Compressions.Contains(Metadata.Format);
        }
        public static byte[] ToArray(this Stream Data)
        {
            using (MemoryStream Temp = new MemoryStream())
            {
                Data.Position = 0;
                Data.CopyTo(Temp);

                return Temp.ToArray();
            }
        }
        public static void Free(this IntPtr Ptr) => Marshal.FreeHGlobal(Ptr);

        public static IntPtr Sum(this IntPtr Ptr, long Value) => new IntPtr(Ptr.ToInt64() + Value);
    }
}
