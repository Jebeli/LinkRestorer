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
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            foreach (var link in linkCache.Links)
            {
                listBox1.Items.Add(link);
            }
            listBox1.EndUpdate();
            listBox2.BeginUpdate();
            listBox2.Items.Clear();
            foreach (var link in linkCache.Failed)
            {
                listBox2.Items.Add(link);
            }
            listBox2.EndUpdate();
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
            textBox1.Text = "";
            textBox2.Text = "";
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            ShowLinks();
        }

        private void RemoveSelectedLinks()
        {
            foreach(Link item in listBox1.SelectedItems)
            {
                linkCache.Links.Remove(item);
            }
            ShowLinks();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
            ScanLinks();
            ShowLinks();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveLinks();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadLinks();
            ShowLinks();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CheckLinks();
            ShowLinks();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            RestoreLinks();
            ShowLinks();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Link tempLink = new Link(textBox1.Text, textBox2.Text, radioButton2.Checked ? LinkType.Symbolic : LinkType.Junction);
            tempLink.Create();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Link tempLink = new Link(textBox1.Text, textBox2.Text, radioButton2.Checked ? LinkType.Symbolic : LinkType.Junction);
            tempLink.DeleteLink();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Link link = listBox1.SelectedItem as Link;
            if (link != null)
            {
                textBox1.Text = link.Source;
                textBox2.Text = link.Destination;
                radioButton1.Checked = link.Type == LinkType.Junction;
                radioButton2.Checked = link.Type == LinkType.Symbolic;
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = !radioButton1.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = !radioButton2.Checked;
        }

        private void removeSelectedLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectedLinks();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RemoveSelectedLinks();
        }
    }
}
