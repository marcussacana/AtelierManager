using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace AtelierManager
{
    class XML
    {
        byte[] Script;
        public XML(byte[] Script) {
            this.Script = Script;
        }

        XDocument Doc;
        public string[] Import() {
            using (var Strm = new MemoryStream(Script))
            {
                Doc = XDocument.Load(Strm);
                var Elms = Doc.Root.XPathSelectElements("//str[@Text]");
                var Text = Elms.Select(x => x.Attribute("Text").Value).ToArray();
                Doc.Declaration.Encoding = "UTF-8";
                return Text;
            }
        }

        public byte[] Export(string[] Content) {

            var Elms = Doc.Root.XPathSelectElements("//str[@Text]").ToArray();
            for (int i = 0; i < Elms.Length; i++) {
                Elms[i].Attribute("Text").Value = Content[i];
            }

            using (MemoryStream Stream = new MemoryStream())
            {
                Doc.Save(Stream);
                return Stream.ToArray();
            }
        }
    }
}
