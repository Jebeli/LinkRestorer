/**
 * Copyright 2018 Jean Pascal Bellot
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
 * to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 * and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
 **/

namespace Links
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    public class LinkCache
    {
        private List<Link> links;
        private List<Link> failed;

        public LinkCache()
        {
            links = new List<Link>();
            failed = new List<Link>();
        }

        public IList<Link> Links
        {
            get { return links; }
        }

        public IList<Link> Failed
        {
            get { return failed; }
        }

        public void ScanLinks(string root)
        {
            links.Clear();
            links.AddRange(Link.FindLinks(root));
        }

        public void SaveLinks(string fileName)
        {
            XmlSerializer writer = new XmlSerializer(links.GetType());
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            using (FileStream fs = File.Create(fileName))
            {
                writer.Serialize(fs, links);
            }
        }

        public void LoadLinks(string fileName)
        {
            if (File.Exists(fileName))
            {
                XmlSerializer reader = new XmlSerializer(links.GetType());
                using (FileStream fs = File.Open(fileName, FileMode.Open))
                {
                    var loaded = reader.Deserialize(fs) as List<Link>;
                    if (loaded != null)
                    {
                        links = loaded;
                    }
                }
            }
        }

        public void CheckLinks()
        {
            failed.Clear();
            foreach (var link in links)
            {
                if (!link.CheckLink())
                {
                    failed.Add(link);
                }
            }
        }

        public void ClearLinks()
        {
            links = new List<Link>();
            failed = new List<Link>();
        }

        public void RestoreLinks()
        {
            CheckLinks();
            List<Link> stillFailed = new List<Link>();
            foreach (var link in failed)
            {
                if (!link.RestoreLink())
                {
                    stillFailed.Add(link);
                }
            }
            failed = stillFailed;
        }
    }
}
