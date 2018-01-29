/**
 * Copyright 2018 Jean Pascal Bellot
 * 
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the "Software"),
 * to deal in the Software without restriction, including without limitation
 * the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 * and/or sell copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN 
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
 **/

namespace LinkRestorer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using Links;
    public partial class FormMain : Form
    {
        private LinkCache linkCache;
        public FormMain()
        {
            InitializeComponent();
            linkCache = new LinkCache();
            Clear();
            LoadLinks();
            CheckLinks();
            ShowLinks();
            ShowLinkStatus(linkCache.Links, "Loaded");

        }

        private void ShowStatus(string status)
        {
            toolStripStatusLabel1.Text = status;
        }

        private void ShowLinkStatus(IList<Link> links, string text)
        {
            string pluralS = links.Count != 1 ? "s" : "";
            ShowStatus($"{links.Count} Link{pluralS} {text}");
        }

        private string GetLinkCacheFileName()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            path = Path.Combine(path, "LinkRestorer");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var file = Path.Combine(path, "ExistingLinks.xml");
            return file;
        }

        private void ScanLinks()
        {
            UseWaitCursor = true;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ShowStatus("Scanning...");
                Application.DoEvents();
                linkCache.ScanLinks(@"C:\");
                ShowLinkStatus(linkCache.Links, "Found");
                Application.DoEvents();
            }
            finally
            {
                UseWaitCursor = false;
                Cursor.Current = Cursors.Default;
            }
        }

        private void SaveLinks()
        {
            linkCache.SaveLinks(GetLinkCacheFileName());
            ShowLinkStatus(linkCache.Links, "Saved");
        }

        private void LoadLinks()
        {
            linkCache.LoadLinks(GetLinkCacheFileName());
            ShowLinkStatus(linkCache.Links, "Loaded");
        }

        private void ShowLinks()
        {
            listBoxLinks.BeginUpdate();
            listBoxLinks.Items.Clear();
            foreach (var link in linkCache.Links)
            {
                listBoxLinks.Items.Add(link);
            }
            listBoxLinks.EndUpdate();
            listBoxFailed.BeginUpdate();
            listBoxFailed.Items.Clear();
            foreach (var link in linkCache.Failed)
            {
                listBoxFailed.Items.Add(link);
            }
            listBoxFailed.EndUpdate();
        }
        private void RestoreLinks()
        {
            linkCache.RestoreLinks();
            ShowStatus($"Links Restored");
        }
        private void CheckLinks()
        {
            linkCache.CheckLinks();
            ShowLinkStatus(linkCache.Failed, "Missing or Wrong");
        }

        private void Clear()
        {
            linkCache.ClearLinks();
            textBoxSource.Text = "";
            textBoxDestination.Text = "";
            radioButtonJunction.Checked = true;
            radioButtonSymLink.Checked = false;
            ShowLinks();
        }

        private void RemoveSelectedLinks()
        {
            foreach(Link item in listBoxLinks.SelectedItems)
            {
                linkCache.Links.Remove(item);
            }
            ShowLinks();
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            Clear();
            ScanLinks();
            ShowLinks();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveLinks();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadLinks();
            ShowLinks();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            CheckLinks();
            ShowLinks();

        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            RestoreLinks();
            ShowLinks();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Link tempLink = new Link(textBoxSource.Text, textBoxDestination.Text, radioButtonSymLink.Checked ? LinkType.Symbolic : LinkType.Junction);
            tempLink.Create();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Link tempLink = new Link(textBoxSource.Text, textBoxDestination.Text, radioButtonSymLink.Checked ? LinkType.Symbolic : LinkType.Junction);
            tempLink.DeleteLink();
        }

        private void listBoxLinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Link link = listBoxLinks.SelectedItem as Link;
            if (link != null)
            {
                textBoxSource.Text = link.Source;
                textBoxDestination.Text = link.Destination;
                radioButtonJunction.Checked = link.Type == LinkType.Junction;
                radioButtonSymLink.Checked = link.Type == LinkType.Symbolic;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void scanLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            ScanLinks();
            ShowLinks();
        }

        private void saveLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLinks();
        }

        private void loadLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadLinks();
            ShowLinks();
        }

        private void checkLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckLinks();
            ShowLinks();
        }

        private void restoreLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreLinks();
            ShowLinks();
        }

        private void radioButtonJunction_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonSymLink.Checked = !radioButtonJunction.Checked;
        }

        private void radioButtonSymLink_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonJunction.Checked = !radioButtonSymLink.Checked;
        }

        private void removeSelectedLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectedLinks();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RemoveSelectedLinks();
        }
    }
}
