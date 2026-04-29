using Blazicons;
using System.Collections.Generic;

namespace Warthuneridle.Utils
{
    public class FlagIconMapping
    {
        static readonly Dictionary<string, SvgIcon> _map = new() {
            ["argentina"] = FlagIcon4x3.Ar,
            ["australia"] = FlagIcon4x3.Au,
            ["austria"] = FlagIcon4x3.At,
            ["bangladesh"] = FlagIcon4x3.Bd,
            ["belgium"] = FlagIcon4x3.Be,
            ["brazil"] = FlagIcon4x3.Br,
            ["canada"] = FlagIcon4x3.Ca,
            ["china"] = FlagIcon4x3.Cn,
            ["colombia"] = FlagIcon4x3.Co,
            ["cuba"] = FlagIcon4x3.Cu,
            ["czechia"] = FlagIcon4x3.Cz,
            ["denmark"] = FlagIcon4x3.Dk,
            ["egypt"] = FlagIcon4x3.Eg,
            ["finland"] = FlagIcon4x3.Fi,
            ["france"] = FlagIcon4x3.Fr,
            ["germany"] = FlagIcon4x3.De,
            ["greece"] = FlagIcon4x3.Gr,
            ["hungary"] = FlagIcon4x3.Hu,
            ["india"] = FlagIcon4x3.In,
            ["indonesia"] = FlagIcon4x3.Id,
            ["iran"] = FlagIcon4x3.Ir,
            ["iraq"] = FlagIcon4x3.Iq,
            ["ireland"] = FlagIcon4x3.Ie,
            ["israel"] = FlagIcon4x3.Il,
            ["italy"] = FlagIcon4x3.It,
            ["japan"] = FlagIcon4x3.Jp,
            ["jordan"] = FlagIcon4x3.Jo,
            ["kazakhstan"] = FlagIcon4x3.Kz,
            ["kuwait"] = FlagIcon4x3.Kw,
            ["lithuania"] = FlagIcon4x3.Lt,
            ["malaysia"] = FlagIcon4x3.My,
            ["netherlands"] = FlagIcon4x3.Nl,
            ["new zealand"] = FlagIcon4x3.Nz,
            ["north korea"] = FlagIcon4x3.Kp,
            ["norway"] = FlagIcon4x3.No,
            ["oman"] = FlagIcon4x3.Om,
            ["pakistan"] = FlagIcon4x3.Pk,
            ["philippines"] = FlagIcon4x3.Ph,
            ["poland"] = FlagIcon4x3.Pl,
            ["portugal"] = FlagIcon4x3.Pt,
            ["romania"] = FlagIcon4x3.Ro,
            ["russia"] = FlagIcon4x3.Ru,
            ["saudi arabia"] = FlagIcon4x3.Sa,
            ["slovakia"] = FlagIcon4x3.Sk,
            ["south africa"] = FlagIcon4x3.Za,
            ["south korea"] = FlagIcon4x3.Kr,
            ["spain"] = FlagIcon4x3.Es,
            ["sweden"] = FlagIcon4x3.Se,
            ["switzerland"] = FlagIcon4x3.Ch,
            ["syria"] = FlagIcon4x3.Sy,
            ["taiwan"] = FlagIcon4x3.Tw,
            ["thailand"] = FlagIcon4x3.Th,
            ["turkey"] = FlagIcon4x3.Tr,
            ["united kingdom"] = FlagIcon4x3.Gb,
            ["united states"] = FlagIcon4x3.Us,
            ["uae"] = FlagIcon4x3.Ae,
            ["usa"] = FlagIcon4x3.Us,
            ["ussr"] = FlagIcon4x3.Ru,
            ["venezuela"] = FlagIcon4x3.Ve,
            ["vietnam"] = FlagIcon4x3.Vn,
            ["null"] = FlagIcon4x3.Xx
        };

        static string Norm(string s) => s?.Trim().ToLowerInvariant() ?? "";
        // usage
        //if (!_map.TryGetValue(Norm(country), out var icon)) icon = FlagIcon4x3.Xx;
    }
}

/*
 public static SvgIcon GetFlagIcon(string country) {
            switch (country.ToLower()) {
                case "australia": return FlagIcon4x3.Au;
                case "austria": return FlagIcon4x3.At;
                case "belgium": return FlagIcon4x3.Be;
                case "brazil": return FlagIcon4x3.Br;
                case "canada": return FlagIcon4x3.Ca;
                case "china": return FlagIcon4x3.Cn;
                case "france": return FlagIcon4x3.Fr;
                case "finland": return FlagIcon4x3.Fi;
                case "germany": return FlagIcon4x3.De;
                case "greece": return FlagIcon4x3.Gr;
                case "hungary": return FlagIcon4x3.Hu;
                case "india": return FlagIcon4x3.In;
                case "iraq": return FlagIcon4x3.Iq;
                case "italy": return FlagIcon4x3.It;
                case "israel": return FlagIcon4x3.Il;
                case "japan": return FlagIcon4x3.Jp;
                case "sourth korea": return FlagIcon4x3.Kr;
                case "netherlands": return FlagIcon4x3.Nl;
                case "norway": return FlagIcon4x3.No;
                case "poland": return FlagIcon4x3.Pl;
                case "russia": return FlagIcon4x3.Ru;
                case "sweden": return FlagIcon4x3.Se;
                case "switzerland": return FlagIcon4x3.Ch;
                case "spain": return FlagIcon4x3.Es;
                case "south africa": return FlagIcon4x3.Za;
                case "thailand": return FlagIcon4x3.Th;
                case "turkey": return FlagIcon4x3.Tr;
                case "united kingdom": return FlagIcon4x3.Gb;
                case "uae": return FlagIcon4x3.Ae;
                case "usa": return FlagIcon4x3.Us;
                case "ussr": return FlagIcon4x3.Ru;
                default : return FlagIcon4x3.Xx;
            }
        }
 */