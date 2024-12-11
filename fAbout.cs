using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace KT_Timer_App
{
    public partial class fAbout : KryptonForm
    {
        private static fAbout instance;
        public static fAbout Instance()
        {
            if(instance == null) instance = new fAbout();
            return instance;
        }
        
        private fAbout()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private async void btnCheckUpdate_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                await GetLastestReleaseInfo();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Check for Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private async Task GetLastestReleaseInfo()
        {
            string apiUrl = "https://api.github.com/repos/kimthien128/KT-Timer/releases";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "C# App");

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();
                    
                    string jsonRespone = await response.Content.ReadAsStringAsync();
                    JArray releases = JArray.Parse(jsonRespone);

                    if (releases.Count > 0)
                    {
                        try
                        {
                            JObject lastestRelease = (JObject)releases[0];
                            string tagName = lastestRelease["tag_name"]?.ToString(); //cũng là apiVersion
                            string name = lastestRelease["name"]?.ToString();
                            string downloadUrl = lastestRelease["assets"]?[0]?["browser_download_url"]?.ToString();
                            string fileName = lastestRelease["assets"]?[0]?["name"]?.ToString();
                            long size = lastestRelease["assets"]?[0]?["size"]?.ToObject<long>() ?? 0;
                            string formatSize = Module.Instance().FormatFileSize(size);

                            string currentVersion = Application.ProductVersion.ToString();
                            if (!Module.Instance().IsNewVersionAvailable(currentVersion, tagName))
                            {
                                MessageBox.Show($"No update available. You are using the lastest version.", "Update Notice", MessageBoxButtons.OK);
                                return;
                            }
                            else
                            {
                                DialogResult dr = MessageBox.Show($"New update available!\nRelease Name: {name}\nVersion: {tagName}\nSize: {formatSize}\nDo you want install it?", "Update Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dr == DialogResult.Yes)
                                {
                                    if (File.Exists($".\\{fileName}"))
                                    {
                                        File.Delete($".\\{fileName}");
                                    }
                                    var clientDownload = new WebClient();
                                    clientDownload.DownloadFile(downloadUrl, fileName);

                                    Process process = new Process();
                                    process.StartInfo.FileName = "msiexec";
                                    process.StartInfo.Arguments = $"/i {fileName}";
                                    this.Close();
                                    process.Start();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"No information available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("No releases found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pbBuyMeACoffee_Click(object sender, EventArgs e)
        {
            string url = "https://ko-fi.com/kimthien128";
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open URL. Error: {ex.Message}");
            }
        }
    }
}
