using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Links
{
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
