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
                new MapViewModel() {Kodi = "kv-841", Numri = 0},
                new MapViewModel() {Kodi = "kv-7318", Numri = 0},
                new MapViewModel() {Kodi = "kv-7319", Numri = 0},
                new MapViewModel() {Kodi = "kv-7320", Numri = 0},
                new MapViewModel() {Kodi = "kv-7321", Numri = 0},
                new MapViewModel() {Kodi = "kv-7322", Numri = 0},
                new MapViewModel() {Kodi = "kv-844", Numri = 0},
                new MapViewModel() {Kodi = "kv-7302", Numri = 0},
                new MapViewModel() {Kodi = "kv-7303", Numri = 0},
                new MapViewModel() {Kodi = "kv-7304", Numri = 0},
                new MapViewModel() {Kodi = "kv-7305", Numri = 0},
                new MapViewModel() {Kodi = "kv-7306", Numri = 0},
                new MapViewModel() {Kodi = "kv-845", Numri = 0},
                new MapViewModel() {Kodi = "kv-7307", Numri = 0},
                new MapViewModel() {Kodi = "kv-7308", Numri = 0},
                new MapViewModel() {Kodi = "kv-7309", Numri = 0},
                new MapViewModel() {Kodi = "kv-7310", Numri = 0},
                new MapViewModel() {Kodi = "kv-7311", Numri = 0},
                new MapViewModel() {Kodi = "kv-842", Numri = 0},
                new MapViewModel() {Kodi = "kv-7312", Numri = 0},
                new MapViewModel() {Kodi = "kv-7313", Numri = 0},
                new MapViewModel() {Kodi = "kv-7314", Numri = 0},
                new MapViewModel() {Kodi = "kv-843", Numri = 0},
                new MapViewModel() {Kodi = "kv-7315", Numri = 0},
                new MapViewModel() {Kodi = "kv-7316", Numri = 0},
                new MapViewModel() {Kodi = "kv-7317", Numri = 0},
                new MapViewModel() {Kodi = "kv-7323", Numri = 0},
                new MapViewModel() {Kodi = "kv-7324", Numri = 0},
                new MapViewModel() {Kodi = "kv-7325", Numri = 0},
                new MapViewModel() {Kodi = "kv-7326", Numri = 0},
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
                    case "Suharekë":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7316");
                        model.Numri = data.Numri;
                        break;
                    case "Prishtinë":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7310");
                        model.Numri = data.Numri;
                        break;
                    case "Prizren":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-843");
                        model.Numri = data.Numri;
                        break;
                    case "Deçan":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7320");
                        model.Numri = data.Numri;
                        break;
                    case "Gjakovë":
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
                    case "Kaçanik":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7326");
                        model.Numri = data.Numri;
                        break;
                    case "Klinë":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7319");
                        model.Numri = data.Numri;
                        break;
                    case "Fushë Kosovë":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-845");
                        model.Numri = data.Numri;
                        break;
                    case "Kamenicë":
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
                    case "Pejë":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-843");
                        model.Numri = data.Numri;
                        break;
                    case "Podujevë":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7309");
                        model.Numri = data.Numri;
                        break;
                    case "Skënderaj":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7305");
                        model.Numri = data.Numri;
                        break;
                    case "Shtime":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7323");
                        model.Numri = data.Numri;
                        break;
                    case "Shtërpcë":
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
                    case "Malishevë":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7317");
                        model.Numri = data.Numri;
                        break;
                    case "Artanë":
                        model = mapDatas.FirstOrDefault(x => x.Kodi == "kv-7313");
                        model.Numri = data.Numri;
                        break;
                    case "Mitrovicë":
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
                "Kosovë" => new List<string>
                {
                    "Deçan",
                    "Gjakovë",
                    "Gllogoc",
                    "Gjilan",
                    "Dragash",
                    "Istog",
                    "Kaçanik",
                    "Klinë",
                    "Fushë Kosovë",
                    "Kamenicë",
                    "Leposaviq",
                    "Lipjan",
                    "Obiliq",
                    "Rahovec",
                    "Pejë",
                    "Podujevë",
                    "Prishtinë",
                    "Prizren",
                    "Skënderaj",
                    "Shtime",
                    "Shtërpcë",
                    "Therandë",
                    "Ferizaj",
                    "Viti",
                    "Vushtrri",
                    "Zubin Potok",
                    "Zveçan",
                    "Malishevë",
                    "Novobërdë",
                    "Mitrovicë e Veriu",
                    "Mitrovicë e Jugu",
                    "Junik",
                    "Hani i Elezit",
                    "Mamushë",
                    "Graçanicë",
                    "Ranillug",
                    "Partesh",
                    "Kllokot"
                },
                "Shqipëri" => new List<string>
                {
                    "Tirana",
                    "Durrësi",
                    "Shkodra",
                    "Elbasani",
                    "Vlora",
                    "Korça",
                    "Fieri",
                    "Berati",
                    "Lushnja",
                    "Pogradeci",
                    "Kavaja",
                    "Laçi",
                    "Lezha",
                    "Kukësi",
                    "Gjirokastra",
                    "Patosi",
                    "Kruja",
                    "Kuçova",
                    "Saranda",
                    "Peshkopia",
                    "Burreli",
                    "Cërriku",
                    "Çorovoda",
                    "Shijaku",
                    "Librazhdi",
                    "Tepelena",
                    "Gramshi",
                    "Poliçani",
                    "Bulqiza",
                    "Përmeti",
                    "Fushë-Kruja",
                    "Kamëza",
                    "Rrësheni",
                    "Ballshi",
                    "Mamurrasi",
                    "Bajram Curri",
                    "Erseka",
                    "Peqini",
                    "Divjaka",
                    "Selenica",
                    "Bilishti",
                    "Roskoveci",
                    "Këlcyra",
                    "Puka",
                    "Memaliaj",
                    "Rrogozhina",
                    "Ura Vajgurore",
                    "Himara",
                    "Delvina",
                    "Vora",
                    "Kopliku",
                    "Maliqi",
                    "Përrenjasi",
                    "Shtërmeni",
                    "Kruma",
                    "Libohova",
                    "Orikumi",
                    "Fushë-Arrëza",
                    "Shëngjini",
                    "Rubiku",
                    "Miloti",
                    "Leskoviku",
                    "Konispoli",
                    "Krasta",
                    "Kërraba"
                },
                "Maqedoni" => new List<string>
                {
                    "Berova",
                    "Dellçeva",
                    "Koçani",
                    "Kamenica",
                    "Peçeva",
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
                    "Kërçova",
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
                    "Nikšić",
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
                    "Rožaje"
                },
                _ => null
            };
            return qytetet;
        }
    }
}