using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace AtelierManager
{
    class XML
    {
        byte[] Script;
        public XML(byte[] Script)
        {
            HtmlNode.ElementsFlags["str"] = HtmlElementFlag.Empty;
            this.Script = Script;
        }

        HtmlDocument Doc;
        public string[] Import() {
            using (var Strm = new MemoryStream(Script))
            {
                Doc = new HtmlDocument();
                Doc.OptionOutputOriginalCase = true;
                Doc.OptionWriteEmptyNodes = true;

                Doc.Load(Strm);

                var Elms = Doc.DocumentNode.SelectNodes("//str[@text]");
                if (Elms == null)
                    return null;

                var Text = Elms.Select(x => HttpUtility.HtmlDecode(x.Attributes["Text"].Value)).ToArray();
                return Text;
            }
        }

        public byte[] Export(string[] Content) {

            var Elms = Doc.DocumentNode.SelectNodes("//str[@text]").ToArray();
            for (int i = 0; i < Elms.Length; i++) {
                Elms[i].Attributes["Text"].Value = HttpUtility.HtmlEncode(Content[i]);
            }

            using (MemoryStream Stream = new MemoryStream())
            {
                Doc.Save(Stream, Encoding.UTF8);
                return Stream.ToArray();
            }
        }
    }
}
