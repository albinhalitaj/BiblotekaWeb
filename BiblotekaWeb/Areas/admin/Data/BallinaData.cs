using System.Collections.Generic;
using System.Linq;
using BiblotekaWeb.Areas.admin.Models;
using BiblotekaWeb.Areas.admin.ViewModels;

namespace BiblotekaWeb.Areas.admin.Data
{
    public static class BallinaData
    {
        private static List<MapViewModel> Data()
        {
            var list = new List<MapViewModel>
            {
                new() {Kodi = "kv-841", Numri = 0},
                new() {Kodi = "kv-7318", Numri = 0},
                new() {Kodi = "kv-7319", Numri = 0},
                new() {Kodi = "kv-7320", Numri = 0},
                new() {Kodi = "kv-7321", Numri = 0},
                new() {Kodi = "kv-7322", Numri = 0},
                new() {Kodi = "kv-844", Numri = 0},
                new() {Kodi = "kv-7302", Numri = 0},
                new() {Kodi = "kv-7303", Numri = 0},
                new() {Kodi = "kv-7304", Numri = 0},
                new() {Kodi = "kv-7305", Numri = 0},
                new() {Kodi = "kv-7306", Numri = 0},
                new() {Kodi = "kv-845", Numri = 0},
                new() {Kodi = "kv-7307", Numri = 0},
                new() {Kodi = "kv-7308", Numri = 0},
                new() {Kodi = "kv-7309", Numri = 0},
                new() {Kodi = "kv-7310", Numri = 0},
                new() {Kodi = "kv-7311", Numri = 0},
                new() {Kodi = "kv-842", Numri = 0},
                new() {Kodi = "kv-7312", Numri = 0},
                new() {Kodi = "kv-7313", Numri = 0},
                new() {Kodi = "kv-7314", Numri = 0},
                new() {Kodi = "kv-843", Numri = 0},
                new() {Kodi = "kv-7315", Numri = 0},
                new() {Kodi = "kv-7316", Numri = 0},
                new() {Kodi = "kv-7317", Numri = 0},
                new() {Kodi = "kv-7323", Numri = 0},
                new() {Kodi = "kv-7324", Numri = 0},
                new() {Kodi = "kv-7325", Numri = 0},
                new() {Kodi = "kv-7326", Numri = 0},
            };
            return list;
        }

        public static List<MapViewModel> GetList(IEnumerable<MapData> mapData)
        {
            var mapDatas = Data();
            foreach (var data in mapData)
            {
                MapViewModel model = null;
                switch (data.Qyteti)
                {
                    case "Suharek??":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7316");
                        model.Numri = data.Numri;
                        break;
                    case "Prishtin??":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7310");
                        model.Numri = data.Numri;
                        break;
                    case "Prizren":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-843");
                        model.Numri = data.Numri;
                        break;
                    case "De??an":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7320");
                        model.Numri = data.Numri;
                        break;
                    case "Gjakov??":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7321");
                        model.Numri = data.Numri;
                        break;
                    case "Gllogoc":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7307");
                        model.Numri = data.Numri;
                        break;
                    case "Gjilan":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-842");
                        model.Numri = data.Numri;
                        break;
                    case "Dragash":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7315");
                        model.Numri = data.Numri;
                        break;
                    case "Istog":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7318");
                        model.Numri = data.Numri;
                        break;
                    case "Ka??anik":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7326");
                        model.Numri = data.Numri;
                        break;
                    case "Klin??":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7319");
                        model.Numri = data.Numri;
                        break;
                    case "Fush?? Kosov??":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-845");
                        model.Numri = data.Numri;
                        break;
                    case "Kamenic??":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7314");
                        model.Numri = data.Numri;
                        break;
                    case "Leposaviq":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7302");
                        model.Numri = data.Numri;
                        break;
                    case "Lipjan":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7311");
                        model.Numri = data.Numri;
                        break;
                    case "Obiliq":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7308");
                        model.Numri = data.Numri;
                        break;
                    case "Rahovec":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7322");
                        model.Numri = data.Numri;
                        break;
                    case "Pej??":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-843");
                        model.Numri = data.Numri;
                        break;
                    case "Podujev??":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7309");
                        model.Numri = data.Numri;
                        break;
                    case "Sk??nderaj":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7305");
                        model.Numri = data.Numri;
                        break;
                    case "Shtime":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7323");
                        model.Numri = data.Numri;
                        break;
                    case "Sht??rpc??":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7325");
                        model.Numri = data.Numri;
                        break;
                    case "Ferizaj":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7324");
                        model.Numri = data.Numri;
                        break;
                    case "Viti":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7312");
                        model.Numri = data.Numri;
                        break;
                    case "Vushtrri":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7304");
                        model.Numri = data.Numri;
                        break;
                    case "Zubin Potok":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7306");
                        model.Numri = data.Numri;
                        break;
                    case "Malishev??":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7317");
                        model.Numri = data.Numri;
                        break;
                    case "Artan??":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7313");
                        model.Numri = data.Numri;
                        break;
                    case "Mitrovic??":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7303");
                        model.Numri = data.Numri;
                        break;
                }
            }
            return mapDatas;
        }

        public static List<string> GetCities(string country)
        {
            var qytetet = country switch
            {
                "Kosov??" => new List<string>
                {
                    "De??an",
                    "Gjakov??",
                    "Gllogoc",
                    "Gjilan",
                    "Dragash",
                    "Istog",
                    "Ka??anik",
                    "Klin??",
                    "Fush?? Kosov??",
                    "Kamenic??",
                    "Leposaviq",
                    "Lipjan",
                    "Obiliq",
                    "Rahovec",
                    "Pej??",
                    "Podujev??",
                    "Prishtin??",
                    "Prizren",
                    "Sk??nderaj",
                    "Shtime",
                    "Sht??rpc??",
                    "Therand??",
                    "Ferizaj",
                    "Viti",
                    "Vushtrri",
                    "Zubin Potok",
                    "Zve??an",
                    "Malishev??",
                    "Novob??rd??",
                    "Mitrovic?? e Veriu",
                    "Mitrovic?? e Jugu",
                    "Junik",
                    "Hani i Elezit",
                    "Mamush??",
                    "Gra??anic??",
                    "Ranillug",
                    "Partesh",
                    "Kllokot"
                },
                "Shqip??ri" => new List<string>
                {
                    "Tirana",
                    "Durr??si",
                    "Shkodra",
                    "Elbasani",
                    "Vlora",
                    "Kor??a",
                    "Fieri",
                    "Berati",
                    "Lushnja",
                    "Pogradeci",
                    "Kavaja",
                    "La??i",
                    "Lezha",
                    "Kuk??si",
                    "Gjirokastra",
                    "Patosi",
                    "Kruja",
                    "Ku??ova",
                    "Saranda",
                    "Peshkopia",
                    "Burreli",
                    "C??rriku",
                    "??orovoda",
                    "Shijaku",
                    "Librazhdi",
                    "Tepelena",
                    "Gramshi",
                    "Poli??ani",
                    "Bulqiza",
                    "P??rmeti",
                    "Fush??-Kruja",
                    "Kam??za",
                    "Rr??sheni",
                    "Ballshi",
                    "Mamurrasi",
                    "Bajram Curri",
                    "Erseka",
                    "Peqini",
                    "Divjaka",
                    "Selenica",
                    "Bilishti",
                    "Roskoveci",
                    "K??lcyra",
                    "Puka",
                    "Memaliaj",
                    "Rrogozhina",
                    "Ura Vajgurore",
                    "Himara",
                    "Delvina",
                    "Vora",
                    "Kopliku",
                    "Maliqi",
                    "P??rrenjasi",
                    "Sht??rmeni",
                    "Kruma",
                    "Libohova",
                    "Orikumi",
                    "Fush??-Arr??za",
                    "Sh??ngjini",
                    "Rubiku",
                    "Miloti",
                    "Leskoviku",
                    "Konispoli",
                    "Krasta",
                    "K??rraba"
                },
                "Maqedoni" => new List<string>
                {
                    "Berova",
                    "Dell??eva",
                    "Ko??ani",
                    "Kamenica",
                    "Pe??eva",
                    "Probishtipi",
                    "Shtipi",
                    "Vinica",
                    "Kratova",
                    "Kriva Pallanka",
                    "Kumanova",
                    "Manastiri",
                    "Demir Hisari",
                    "Krusheva",
                    "Prilepi",
                    "Resnja",
                    "Gostivari",
                    "Tetova",
                    "Shkupi",
                    "Bogdanca",
                    "Gjevgjelia",
                    "Radovishti",
                    "Strumica",
                    "Vallandova",
                    "Dibra",
                    "K??r??ova",
                    "Brod",
                    "Ohri",
                    "Struga",
                    "Demir Kapia",
                    "Kavadari",
                    "Negotina",
                    "Sveti Nikolla",
                    "Velesi"
                },
                "Mali i Zi" => new List<string>
                {
                    "Podgorica",
                    "Nik??i??",
                    "Herceg Novi",
                    "Pljevlja",
                    "Bar",
                    "Bijelo Polje",
                    "Cetinje",
                    "Budva",
                    "Kotor",
                    "Berane",
                    "Ulcinj",
                    "Tivat",
                    "Ro??aje"
                },
                _ => null
            };
            return qytetet;
        }
    }
}