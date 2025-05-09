using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Media;
using System.Drawing;
using System.Collections;

namespace Monster_Rancher_Challenger
{
    public partial class MonsterSelectorPage : Page
    {
        // This list contains every monster available within the DX version of Monster Rancher 1.
        List<string> Monsters = new List<string> { "Dino (Dino/Dino)", "Anki (Dino/Golem)", "Lidee (Dino/Tiger)", "Valentino (Dino/Pixie)", "Shel (Dino/Worm)", "Slash (Dino/Jell)"
        , "Mustard (Dino/Suezo)", "Spot (Dino/Hare)", "Goldy (Dino/Gali)", "Black Rex (Dino/Monol)", "Grape (Dino/Naga)", "Aloha (Dino/Plant)", "Geisha (Dino/???)", "Gallop (Dino/???)"
        , "Smiley (Dino/???)"

        , "Tiger (Tiger/Tiger)", "Dento (Tiger/Dino)", "Toto (Tiger/Golem)", "Deton (Tiger/Pixie)", "Yakuto (Tiger/Worm)", "Frost (Tiger/Jell)", "Mono Eye (Tiger/Suezo)"
        , "Rover (Tiger/Hare)", "Ballon (Tiger/Gali)", "Velvet (Tiger/Monol)", "Cabalos (Tiger/Naga)", "Leafy (Tiger/Plant)", "Gray Wolf (Tiger/???)"
        , "White Hound (Tiger/???)", "Gold Wolf (Tiger/???)"

        , "Suezo (Suezo/Suezo)", "Melon (Suezo/Dino)", "Rocky (Suezo/Golem)", "Horn (Suezo/Tiger)", "Pink Eye (Suezo/Pixie)", "Fly Eye (Suezo/Worm)", "Toothy (Suezo/Jell)"
        , "Woody (Suezo/Hare)", "Orion (Suezo/Gali)", "Bloodshot (Suezo/Monol)", "Noro (Suezo/Monol)", "Ray (Suezo/Plant)", "Looker (Suezo/???)", "Planet (Suezo/???)"
        , "Beamer (Suezo/???)"

        , "Worm (Worm/Worm)", "Gecko (Worm/Dino)", "Rock Worm (Worm/Golem)", "Drill (Worm/Tiger)", "Red Worm (Worm/Pixie)", "Tubby (Worm/Jell)", "Eye Guy (Worm/Suezo)"
        , "Karone (Worm/Hare)", "Mask Worm (Worm/Gali)", "Pull Worm (Worm/Monol)", "Wing Worm (Worm/Naga)", "Rainbow (Worm/Plant)", "Tank (Worm/???)"
        , "Express Worm (Worm/???)", "Express Worm(Red) (Worm/???)"

        , "Plant (Plant/Plant)", "Shrub (Plant/Dino)", "Rock Bush (Plant/Golem)", "Iris (Plant/Tiger)", "Allergan (Plant/Pixie)", "Usaba (Plant/Worm)", "Obor (Plant/Jell)"
        , "Hince (Plant/Suezo)", "Spinner (Plant/Hare)", "Regal (Plant/Gali)", "Ash (Plant/Monol)", "Bad Seed (Plant/Naga)", "Neon (Plant/???)", "Bonsai (Plant/???)"
        , "Neon(White) (Plant/???)"

        , "Pixie (Pixie/Pixie)", "Dixie (Pixie/Dino)", "Vixen (Pixie/Golem)", "Mint (Pixie/Tiger)", "Radar (Pixie/Worm)", "Nymph (Pixie/Jell)", "Vanity (Pixie/Suezo)"
        , "Mopsy (Pixie/Hare)", "Angel (Pixie/Gali)", "Prism (Pixie/Monol)", "Allure (Pixie/Naga)", "Serene (Pixie/Plant)", "Bunny (Pixie/???)", "Platinum (Pixie/???)"
        , "Eve (Pixie/???)"

        , "Naga (Naga/Naga)", "Stinger (Naga/Dino)", "Trident (Naga/Golem)", "Striker (Naga/Tiger)", "Liper (Naga/Pixie)", "Gaia (Naga/Worm)", "Cutter (Naga/Jell)"
        , "Cyclops (Naga/Suezo)", "Edgy (Naga/Hare)", "Bazul (Naga/Gali)", "Boxer (Naga/Monol)", "Jungler (Naga/Plant)", "Cari (Naga/???)", "Anguish (Naga/???)"
        , "Anguish(Gold) (Naga/???)"

        , "Nya (Nya/Nya)", "Lovey (Nya/Tiger)", "Mama Nya (Nya/Pixie)", "Nyamix (Nya/Jell)", "Mimi (Nya/Hare)", "Player (Nya/???)", "Teddy (Nya/???)", "Karaoke (Nya/???)"

        , "Monol (Monol/Monol)", "Jura Wall (Monol/Dino)", "Obelisk (Monol/Golem)", "Sponge (Monol/Tiger)", "Ropa (Monol/Pixie)", "Sobo (Monol/Worm)", "Ice Candy (Monol/Jell)"
        , "Sandy (Monol/Suezo)", "Groomy (Monol/Hare)", "Messiah (Monol/Gali)", "Asfar (Monol/Naga)", "New Leaf (Monol/Plant)", "Two-Tone (Monol/???)", "Sky (Monol/???)"
        , "Scribble (Monol/???)"

        , "Magic (Magic/Magic)", "Eye Fan (Magic/Suezo)", "Kaduka (Magic/Naga)", "Kuro (Magic/Plant)", "Gangster (Magic/Henger)", "Ardebaren (Magic/???)", "Zombie (Magic/???)"
        , "Jerod (Magic/???)"

        , "Jell (Jell/Jell)", "Scales (Jell/Dino)", "Fencer (Jell/Golem)", "Icy (Jell/Tiger)", "Pink Jam (Jell/Pixie)", "Jello (Jell/Worm)", "Jupiter (Jell/Suezo)", "Clay (Jell/Hare)"
        , "Gil (Jell/Gali)", "Lava (Jell/Monol)", "Papad (Jell/Naga)", "Kelp (Jell/Plant)", "Stripe (Jell/???)", "Sam (Jell/???)", "Stripe(Red) (Jell/???)"

        , "Henger (Henger/Henger)", "Omega (Henger/Dino)", "Gia (Henger/Golem)", "Proto (Henger/Gali)", "Reformer (Henger/Monol)", "Magnet (Henger/???)", "Skeleton (Henger/???)"
        , "Magnet(Red) (Henger/???)"

        , "Hare (Hare/Hare)", "Scaler (Hare/Dino)", "Stoner (Hare/Golem)", "Pulsar (Hare/Tiger)", "Buster (Hare/Pixie)", "Groucho (Hare/Worm)", "Blue Fur (Hare/Jell)"
        , "Cross Eye (Hare/Suezo)", "Prince (Hare/Gali)", "Evil Hare (Hare/Monol)", "Amethyst (Hare/Naga)", "Good Guy (Hare/Plant)", "Sleeves (Hare/???)", "Santa (Hare/???)"
        , "Sleeves(Black) (Hare/???)"

        , "Golem (Golem/Golem)", "Verde (Golem/Dino)", "Ice Man (Golem/Tiger)", "Dean (Golem/Pixie)", "Magma (Golem/Worm)", "Poseidon (Golem/Jell)", "Titan (Golem/Suezo)"
        , "Maigon (Golem/Hare)", "Amenho (Golem/Gali)", "Shadow (Golem/Monol)", "Marble (Golem/Naga)", "Echo (Golem/Plant)", "Bikini (Golem/???)", "Mt. Tecmo (Golem/???)"
        , "Bikini(Red) (Golem/???)"

        , "Ghost (Ghost/Ghost)", "Mage (Ghost/???)", "Komi (Ghost/???)", "Mage(White) (Ghost/???)"

        , "Gali (Gali/Gali)", "Lexus (Gali/Dino)", "Warrior (Gali/Golem)", "Sapphire (Gali/Tiger)", "Pixel (Gali/Pixie)", "Style (Gali/Worm)", "Aqua (Gali/Jell)", "Omen (Gali/Suezo)"
        , "Galion (Gali/Hare)", "Gara (Gali/Monol)", "Shon Mask (Gali/Naga)", "Color (Gali/Plant)", "Gamer (Gali/???)", "Kuma (Gali/???)", "Milky Way (Gali/???)"

        , "Dragon (Dragon/Dragon)", "Jihad (Dragon/Golem)", "Gariel (Dragon/Gali)", "Laguna (Dragon/Monol)", "Robo (Dragon/Henger)", "Apocolis (Dragon/???)", "Moo (Dragon/???)"
        , "Apocolis(White) (Dragon/???)"

        , "Doodle (Doodle/Doodle)", "Jaques (Doodle/???)", "Sketch (Doodle/???)", "Disrupt (Doodle/???)"

        , "Disk (Disk/Disk)", "Gooaall! (Disk/???)", "Radial (Disk/???)"

        , "Ape (Ape/Ape)", "Stone Ape (Ape/Golem)", "George (Ape/Hare)", "Great Ape (Ape/Gali)", "Pepe (Ape/Plant)", "Shades (Ape/???)", "Cutey (Ape/???)", "Hot Foot (Ape/???)"};

        //List<SolidColorBrush> colors = new List<SolidColorBrush> { new SolidColorBrush(Colors.Salmon), new SolidColorBrush(Colors.RoyalBlue)
        //, new SolidColorBrush(Colors.SteelBlue), new SolidColorBrush(Colors.Fuchsia), new SolidColorBrush(Colors.DarkViolet), new SolidColorBrush(Colors.DarkRed)
        //, new SolidColorBrush(Colors.DarkOliveGreen) };
        string prevMon = string.Empty;
        int index;

        public MonsterSelectorPage()
        {
            InitializeComponent();
            MonsterRandomizer();
        }

        private void MonsterRandomizer()
        {
            Random rng = new Random();
            // Randomize the list of monsters.
            List<string> shuffledMonsters = Monsters.OrderBy(_ => rng.Next(0, Monsters.Count)).ToList();
            Monsters = shuffledMonsters; 
            index = 0;
        }

        private void Color_Change(string mainBreed, string subBreed)
        {
            System.Drawing.Color color1 = System.Drawing.Color.Black;
            System.Drawing.Color color2 = System.Drawing.Color.Black;

            switch ((mainBreed))
            {
                case "Dino":
                    color1 = System.Drawing.Color.Green;
                    break;
                case "Tiger":
                    color1 = System.Drawing.Color.Blue;
                    break;
                case "Suezo":
                    color1 = System.Drawing.Color.Yellow;
                    break;
                case "Golem":
                    color1 = System.Drawing.Color.Gray;
                    break;
                case "Worm":
                    color1 = System.Drawing.Color.Brown;
                    break;
                case "Hare":
                    color1 = System.Drawing.Color.SandyBrown;
                    break;
                case "Plant":
                    color1 = System.Drawing.Color.OrangeRed;
                    break;
                case "Pixie":
                    color1 = System.Drawing.Color.DeepPink;
                    break;
                case "Naga":
                    color1 = System.Drawing.Color.DarkMagenta;
                    break;
                case "Nya":
                    color1 = System.Drawing.Color.Cornsilk;
                    break;
                case "Ghost":
                    color1 = System.Drawing.Color.Snow;
                    break;
                case "Monol":
                    color1 = System.Drawing.Color.Black;
                    break;
                case "Magic":
                    color1 = System.Drawing.Color.RosyBrown;
                    break;
                case "Jell":
                    color1 = System.Drawing.Color.DeepSkyBlue;
                    break;
                case "Henger":
                    color1 = System.Drawing.Color.BlanchedAlmond;
                    break;
                case "Gali":
                    color1 = System.Drawing.Color.DarkGoldenrod;
                    break;
                case "Dragon":
                    color1 = System.Drawing.Color.Red;
                    break;
                case "Doodle":
                    color1 = System.Drawing.Color.White;
                    break;
                case "Disk":
                    color1 = System.Drawing.Color.SaddleBrown;
                    break;
                case "Ape":
                    color1 = System.Drawing.Color.BurlyWood;
                    break;
                default:
                    break;
            }

            switch ((subBreed))
            {
                case "Dino":
                    color2 = System.Drawing.Color.Green;
                    break;
                case "Tiger":
                    color2 = System.Drawing.Color.Blue;
                    break;
                case "Suezo":
                    color2 = System.Drawing.Color.Yellow;
                    break;
                case "Golem":
                    color2 = System.Drawing.Color.Gray;
                    break;
                case "Worm":
                    color2 = System.Drawing.Color.Brown;
                    break;
                case "Hare":
                    color2 = System.Drawing.Color.SandyBrown;
                    break;
                case "Plant":
                    color2 = System.Drawing.Color.OrangeRed;
                    break;
                case "Pixie":
                    color2 = System.Drawing.Color.DeepPink;
                    break;
                case "Naga":
                    color2 = System.Drawing.Color.DarkMagenta;
                    break;
                case "Nya":
                    color2 = System.Drawing.Color.Cornsilk;
                    break;
                case "Ghost":
                    color2 = System.Drawing.Color.Snow;
                    break;
                case "Monol":
                    color2 = System.Drawing.Color.Black;
                    break;
                case "Magic":
                    color2 = System.Drawing.Color.RosyBrown;
                    break;
                case "Jell":
                    color2 = System.Drawing.Color.DeepSkyBlue;
                    break;
                case "Henger":
                    color2 = System.Drawing.Color.BlanchedAlmond;
                    break;
                case "Gali":
                    color2 = System.Drawing.Color.DarkGoldenrod;
                    break;
                case "Dragon":
                    color2 = System.Drawing.Color.Red;
                    break;
                case "Doodle":
                    color2 = System.Drawing.Color.White;
                    break;
                case "Disk":
                    color2 = System.Drawing.Color.SaddleBrown;
                    break;
                case "Ape":
                    color2 = System.Drawing.Color.BurlyWood;
                    break;
                case "???":
                    color2 = System.Drawing.Color.DarkSlateGray;
                    break;
                default:
                    break;
            }

            // Make weights to influence colors
            double weight1 = 0.6;
            double weight2 = 0.4;
            // Using math to get a more accurate color.
            byte r = (byte)(color1.R * weight1 + color2.R * weight2);
            byte g = (byte)(color1.G * weight1 + color2.G * weight2);
            byte b = (byte)(color1.B * weight1 + color2.B * weight2);
            System.Windows.Media.Color combinedColors = System.Windows.Media.Color.FromArgb(255, r, g, b);
            Monster.Foreground = new SolidColorBrush(combinedColors);
        }

        private async Task Silly_Animation(Random rng)
        {
            int randtime = rng.Next(10, 50);
            string full = string.Empty;
            for (int i = 0; i < randtime || prevMon == full; i++)
            {
                full = Monsters[rng.Next(0, Monsters.Count)];
                // Split[0] is before the delim, Split[1] is after the delim.
                string mainBreed = full.Split("/")[0].Split(" (")[1];
                string subBreed = full.Split("/")[1].Split(")")[0];
                Monster.Content = full.Split(" (")[0];
                Breed.Content = "(" + full.Split(" (")[1];
                Color_Change(mainBreed, subBreed);
                await Task.Delay(25);
            }
        }

        private async void Click_Click(object sender, RoutedEventArgs e)
        {
            // Check index value
            // If index == Monsters.Count, run MonsterRandomizer()
            // Else, simply index as normal.
            // While also running the animation.

            // Randomly select a monster from the randomized list of monsters (Unnecessary, might just index later).
            Random rng = new Random();
            await Silly_Animation(rng);
            string full = string.Empty;

            if(index == Monsters.Count)
            {
                MonsterRandomizer();
            }

            full = Monsters[index];
            index++;
            string mainBreed = full.Split("/")[0].Split(" (")[1];
            string subBreed = full.Split("/")[1].Split(")")[0];
            Monster.Content = full.Split(" (")[0];
            Breed.Content = "(" + full.Split(" (")[1];
            Color_Change(mainBreed, subBreed);
            prevMon = full;

            //Monster.Text = Monsters[rng.Next(0, Monsters.Count)];
        }

        private void Monster_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
