using System;
using System.Collections.Generic;
using System.Web.Mvc;
using OpenIPTV.Web.Models;
using System.Linq;
using OpenIPTV.WebHarvester;
using System.Data.Entity;

namespace OpenIPTV.Web.Controllers
{
    public class JsonController : Controller
    {
        public ActionResult Azuriraj()
        {
            using (var ctx = new DataContext())
            {
                var datum = GetTime().Date;
                if (ctx.Emisije.Any(x => x.Datum == datum)) return new EmptyResult();
                var kanali = ctx.Kanal.ToArray();
                ctx.Database.ExecuteSqlCommand("DELETE Emisije");
                var harvester = new Harvester();
                foreach (var kanal in kanali)
                {
                    var e = from i in harvester.Harvest(kanal.Id, datum)
                            let vreme = i.Vreme.Split(':')
                            select new Emisija()
                            {
                                Datum = datum, 
                                Kanal = kanal, 
                                Naziv = i.Naziv, 
                                Tip = i.Tip, 
                                Sat = int.Parse(vreme[0]), 
                                Minut = int.Parse(vreme[1])
                            };
                    ctx.Emisije.AddRange(e);
                }
                ctx.SaveChanges();
            }
            return new EmptyResult();
        }

        public JsonResult VratiEmisije(string timestamp, string tip, int? skip, int? take)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            using (var ctx = new DataContext())
            {
                var now = timestamp != null ? DateTime.Parse(timestamp) : GetTime();
                var datum = now.Date;
                var query = ctx.Emisije.Include(x => x.Kanal).Where(x => x.Datum == datum).OrderBy(x => x.Sat).ThenBy(x => x.Minut).ThenBy(x => x.Kanal.Broj).AsQueryable();
                if (!string.IsNullOrEmpty(tip))
                {
                    query = query.Where(x => x.Tip == tip);
                }
                
                var emisije = query.ToArray();
                var emisijePoKanalima = emisije.GroupBy(x => x.KanalId);
                foreach (var emisijeKanala in emisijePoKanalima)
                {
                    Emisija prethodna = null;
                    foreach (var emisijaKanala in emisijeKanala)
                    {
                        if (emisijaKanala.Vreme < now.TimeOfDay)
                        {
                            emisijaKanala.SadaNaProgramu = true;
                            if (prethodna != null)
                            {
                                prethodna.SadaNaProgramu = false;
                            }
                        }
                        prethodna = emisijaKanala;
                    }
                }
                var nadjenaPrva = false;
                var filtriraneEmisije = new List<Emisija>();
                foreach (var emisija in emisije)
                {
                    if (!nadjenaPrva && emisija.SadaNaProgramu)
                    {
                        nadjenaPrva = true;
                    }
                    if (!nadjenaPrva) continue;
                    filtriraneEmisije.Add(emisija);
                }
                if (skip.HasValue && take.HasValue)
                {
                    filtriraneEmisije = filtriraneEmisije.Skip(skip.Value).Take(take.Value).ToList();
                }
                
                var json = from e in filtriraneEmisije
                           select new
                           {
                               id = e.Id,
                               kanal = e.Kanal.Naziv,
                               kanalId = e.KanalId,
                               vreme = e.Sat.ToString("00") + ":" + e.Minut.ToString("00"),
                               emisija = e.Naziv,
                               tip = e.Tip,
                               aktivna = e.SadaNaProgramu,
                               logo = e.Kanal.Logo
                           };
                return Json(new{ timestamp = now.ToString("dd.MM.yyyy HH:mm"), program = json.ToArray() }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult VratiProgram(int id)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            using (var ctx = new DataContext())
            {
                var now = GetTime();
                var datum = now.Date;
                var kanal = ctx.Kanal.Single(x => x.Id == id);
                var query = ctx.Emisije.Where(x => x.KanalId == id && x.Datum == datum).OrderBy(x => x.Sat).ThenBy(x => x.Minut).ToArray();
                Emisija prethodna = null;
                foreach (var emisija in query)
                {
                    if (emisija.Vreme < now.TimeOfDay)
                    {
                        emisija.SadaNaProgramu = true;
                        if (prethodna != null)
                        {
                            prethodna.SadaNaProgramu = false;
                        }
                        prethodna = emisija;
                    }
                }

                var emisije = query.Select(e => new
                {
                    vreme = e.Sat.ToString("00") + ":" + e.Minut.ToString("00"),
                    naziv = e.Naziv,
                    tip = e.Tip,
                    sad = e.SadaNaProgramu
                });
                var result = new
                {
                    naziv = kanal.Naziv,
                    logo = kanal.Logo,
                    program = emisije
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        private DateTime GetTime()
        {
            var time = DateTime.UtcNow;
            var tz = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            time = TimeZoneInfo.ConvertTime(time, tz);
            return time;
        }

    }
}
