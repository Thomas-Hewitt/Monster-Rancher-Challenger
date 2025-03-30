using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace Monster_Rancher_Tourney_Selector
{
    public partial class MonsterSelectorPage : Page
    {
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

        public MonsterSelectorPage()
        {
            InitializeComponent();
            Random rng = new Random();
            //List<int> indices = new List<int>();
            //for(int i = 0; i < Monsters.Count; i++)
            //{
            //    indices.Add(rng.Next(0, Monsters.Count));
            //}
            // Randomize the list of monsters.
            List<string> shuffledMonsters = Monsters.OrderBy(_ => rng.Next(0, Monsters.Count)).ToList();
            Monsters = shuffledMonsters;
        }

        private void Click_Click(object sender, RoutedEventArgs e)
        {
            // Randomly select a monster from the randomized list of monsters (Unnecessary, might just index later).
            Random rng = new Random();
            Monster.Text = Monsters[rng.Next(0, Monsters.Count)];
        }

        private void Monster_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
