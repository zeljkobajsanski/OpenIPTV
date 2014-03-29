using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using System.Linq;
using OpenIPTV.WebHarvester.Models;

namespace OpenIPTV.WebHarvester
{
    public class Harvester
    {
        public IEnumerable<Emisija> Harvest(int idKanala, DateTime datum)
        {
            using (var client = new WebClient())
            {
                using (var reader = new MemoryStream(client.DownloadData("http://open.telekom.rs/iptv/ProgramByChannel.aspx?datum=" + datum.ToString("dd.MM.yyyy") + "&channel=" + idKanala)))
                {
                    var html = new HtmlDocument();
                    html.Load(reader, Encoding.UTF8);
                    var table = html.DocumentNode.SelectNodes("//table[contains(@id, 'gvProgramShema')]");
                    var rows = table.Descendants("tr").ToArray();
                    var emisije = new List<Emisija>();
                    foreach (var row in rows)
                    {
                        string boja = null;
                        if (row.HasAttributes && row.Attributes["bgcolor"] != null)
                        {
                            boja = row.Attributes["bgcolor"].Value;
                        }
                        var spans = row.Descendants("span").ToArray();
                        if (spans.Length == 2)
                        {
                            string vreme = spans.Single(x => x.Id == "spTime").InnerText;
                            string naziv = spans.Single(x => x.Attributes["style"].Value == "cursor:pointer").InnerText;
                            var emisija = new Emisija {Naziv = naziv, Vreme = vreme, Tip = KonvertujBojuUTip(boja)};
                            if (emisije.All(x => !x.Vreme.Equals(vreme)))
                            {
                                emisije.Add(emisija);
                            }
                        }
                    }
                    return emisije;
                }
            }
        }

        private string KonvertujBojuUTip(string boja)
        {
            switch (boja)
            {
                case null:
                    return "ostalo";
                case "#F29B36":
                    return "film";
                case "#F05D87":
                    return "serija";
                case "#C4D82D":
                    return "sport";
                default:
                    throw new Exception("Nepoznata boja " + boja);
            }
        }
    }
}