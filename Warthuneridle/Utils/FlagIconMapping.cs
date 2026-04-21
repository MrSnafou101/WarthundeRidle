using Blazicons;

namespace Warthuneridle.Utils
{
    public class FlagIconMapping
    {
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
    }
}
