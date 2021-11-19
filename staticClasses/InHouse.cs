using System;
using System.Collections.Generic;

namespace StaticClass
{
    static class InHouse
    {
        // Bilmärken
        static List<string> carBrands = new List<string>() {
            "Volvo",
            "SAAB",
            "Koenigsegg",
            "Åtvidabergsbilen",
            "Hult Healey",
            "Allvelo",
            "Cederholm",
            "Sandcat",
            "Jösse Car",
            "Rengsjöbilen"
        };

        // Kryddor
        static List<string> tofuSpices = new List<string>() {
            "Kanel",
            "Spiskummin",
            "Pommeskrydda",
            "Dill",
            "Chilipulver",
            "Grillkrydda",
            "Överraska mig!",
        };

        // Properies
        public static List<string> CarBrands
        {
            get { return carBrands; }
        }
        public static List<string> TofuSpices
        {
            get { return tofuSpices; }
        }
    }

    // Färger
    public enum Colors
    {
        Svart = 0,
        // Mörkblå = 1,
        // Mörkgrön = 2,
        // Mörkturkos = 3,
        // Mörkröd = 4,
        // Mörklila = 5,
        // Mörkgul = 6,
        Grå = 7,
        // Mörkgrå = 8,
        Blå = 9,
        Grön = 10,
        Turkos = 11,
        Röd = 12,
        Lila = 13,
        Gul = 14,
        Vit = 15,
    };

    // Smaker
    public enum Flavours
    {
        Lakrits = 0, // Svart
        // Mörkblå = 1,
        // Mörkgrön = 2,
        // Mörkturkos = 3,
        // Mörkröd = 4,
        // Mörklila = 5,
        // Mörkgul = 6,
        // Mörkgrå = 8,
        Blåbär = 9, // Blå
        Surt = 10, // Grön
        // Turkos = 11,
        Hallon = 12, // Röd
        // Lila = 13, // Lila
        Banan = 14, // Gul
        Vanilj = 15, // Vit
        GottOchBlandat = 99
    };
}
