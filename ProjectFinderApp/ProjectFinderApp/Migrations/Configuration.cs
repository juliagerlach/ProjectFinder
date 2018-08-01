namespace ProjectFinderApp.Migrations
{
    using ProjectFinderApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectFinderApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectFinderApp.Models.ApplicationDbContext context)
        {
            {
                context.Projects.AddOrUpdate(
                    p => p.ProjectTitle,
                new Project() { PageNumber = 14, ProjectTitle = "Mighty Little Acorns", ProjectType = "earrings", ProjectDesigner = "Cara Landry", MagazineID = 2, IssueID = 1016, Technique = "herringbone", Supplies = "15/0 seed beads", OnlineLink = "http://www.facetjewelry.com/bb-extra/2016/09/october-2016-bead-and-button-extra", FilePath = "~Content/Images/acornearrings.jpg", FileName = "acornearrings.jpg" },

                new Project() { PageNumber = 36, ProjectTitle = "Contempo Squares", ProjectType = "pendant", ProjectDesigner = "Irina Miech", MagazineID = 1, IssueID = 1212, Technique = "wirework", Supplies = "4mm crystals", OnlineLink = null, FilePath = "~Content/Images/contemposquares.jpg", FileName = "contemposquares.jpg" },

                new Project() { PageNumber = 3, ProjectTitle = "Criss-cross Button Bracelet", ProjectType = "bracelet", ProjectDesigner = "Julia Gerlach", MagazineID = 2, IssueID = 0812, Technique = "crossweave", Supplies = "20mm buttons, 3mm pearls, 3mm crystals, 6mm crystals, 8/0 seed beads, 11/0 seed beads", OnlineLink = "http://facetjewelry.com/stitching/projects/2016/05/criss-cross-button-bracelet", FilePath = "~Content/Images/Crisscrossbuttonbracelet.jpg", FileName = "Crisscrossbuttonbracelet.jpg" },

                new Project() { PageNumber = 16, ProjectTitle = "Crystal Chic", ProjectType = "necklace", ProjectDesigner = "Julia Gerlach", MagazineID = 1, IssueID = 0813, Technique = "stringing", Supplies = "6mm crystals, crystal drops, 8/0 seed beads, 11/0 seed beads, jump rings", OnlineLink = null, FilePath = "~Content/Images/crystalchic.jpg", FileName = "crystalchic.jpg" },

                new Project() { PageNumber = 45, ProjectTitle = "Crystalline Cuff", ProjectType = "bracelet", ProjectDesigner = "Dana Rudolph", MagazineID = 1, IssueID = 0617, Technique = "right-angle weave", Supplies = "6/0 seed beads, 11/0 seed beads, 15/0 seed beads, 3mm pearls, ss12 rose montees, ss16 rose montees, ss29 cup chain", OnlineLink = null, FilePath = "~Content/Images/crystallinecuff.jpg", FileName = "crystallinecuff.jpg" },

                new Project() { PageNumber = 15, ProjectTitle = "2 Ways to Make a Crystal Quartz Pendant", ProjectType = "pendant", ProjectDesigner = "Julia Gerlach", MagazineID = 2, IssueID = 1017, Technique = "peyote, wirework", Supplies = "quartz crystal, 11/0 seed beads, 15/0 seed beads, wire", OnlineLink = "http://facetjewelry.com/bead-buzz/projects/2017/04/2-ways-to-make-a-quartz-crystal-pendant", FilePath = "~Content/Images/crystalnecklaces.jpg", FileName = "crystalnecklaces.jpg" },

                new Project() { PageNumber = 5, ProjectTitle = "Election Day Earrings", ProjectType = "earrings", ProjectDesigner = "Julia Gerlach", MagazineID = 2, IssueID = 1016, Technique = "brick stitch", Supplies = "11/0 cylinder beads", OnlineLink = "http://facetjewelry.com/bead-buzz/projects/2016/09/election-beading-patterns", FilePath = "~Content/Images/electiondayearrings.jpg", FileName = "electiondayearrings.jpg" },

                new Project() { PageNumber = 90, ProjectTitle = "Mod Makeover", ProjectType = "earrings", ProjectDesigner = "Julia Gerlach", MagazineID = 1, IssueID = 1012, Technique = "peyote", Supplies = "22mm go-go pendants, 11/0 cylinder beads, 15/0 seed beads, 4mm crystals", OnlineLink = "http://facetjewelry.com/-/media/files/projects/bnb/tubular-peyote-stitch-earrings", FilePath = "~Content/Images/Gogoearrings.jpg", FileName = "Gogoearrings.jpg" },

                new Project() { PageNumber = 11, ProjectTitle = "Art glass necklace", ProjectType = "necklace", ProjectDesigner = "Julia Gerlach", MagazineID = 2, IssueID = 0615, Technique = "herringbone", Supplies = "art glass bead, 8mm large-hole slider beads, 11/0 cylinder beads, 11/0 seed beads, 15/0 seed beads", OnlineLink = "http://facetjewelry.com/stitching/projects/2016/05/rope-necklace-with-slider-beads", FilePath = "~Content/Images/Herringbonenecklace.jpg", FileName = "Herringbonenecklace.jpg" },

                new Project() { PageNumber = 30, ProjectTitle = "Constellation pendant", ProjectType = "pendant", ProjectDesigner = "Cathy Andrews", MagazineID = 4, IssueID = 1217, Technique = "peyote, herringbone", Supplies = "11/0 seed beads, 4mm crystals, 8mm crystals, 2mm fire-polished beads, 3mm fire-polished beads, 8mm pearls", OnlineLink = null, FilePath = "~Content/Images/constellationpendant.jpg", FileName = "constellationpendant.jpg" },

                new Project() { PageNumber = 20, ProjectTitle = "Bead single crochet bangle", ProjectType = "bracelet", ProjectDesigner = "Candace Sexton", MagazineID = 1, IssueID = 0216, Technique = "bead crochet", Supplies = "11/0  seed beads, crochet cord, clasp", OnlineLink = null, FilePath = "~Content/Images/sextonombre.jpg", FileName = "sextonombre.jpg" },

                new Project() { PageNumber = 50, ProjectTitle = "Rhinestone Rhapsody", ProjectType = "necklace", ProjectDesigner = "Natalie Smith", MagazineID = 3, IssueID = 0316, Technique = "stringing", Supplies = "acrylic rhinstones", OnlineLink = null, FilePath = "~Content/Images/rhinestonehapsody.jpg", FileName = "rhinestonehapsody.jpg" },

                new Project() { PageNumber = 42, ProjectTitle = "Tempting Treasures", ProjectType = "earrings", ProjectDesigner = "Bonnie Riconda", MagazineID = 5, IssueID = 0615, Technique = "wirework", Supplies = "gemstones, wire", OnlineLink = null, FilePath = "~Content/Images/temptingtreasures.jpg", FileName = "temptingtreasures.jpg" },

                new Project() { PageNumber = 36, ProjectTitle = "A Touch of Vintage", ProjectType = "pendant", ProjectDesigner = "Bonnie Riconda", MagazineID = 3, IssueID = 0114, Technique = "wirework", Supplies = "gemstone cabochon, wire", OnlineLink = null, FilePath = "~Content/Images/wiredpendant.jpg", FileName = "wiredpendant.jpg" },

                new Project() { PageNumber = 27, ProjectTitle = "Waterfall pendant", ProjectType = "pendant", ProjectDesigner = "Mandi Bugatti", MagazineID = 4, IssueID = 0218, Technique = "right-angle weave", Supplies = "4mm crystals", OnlineLink = null, FilePath = "~Content/Images/waterfallpendantbugatti.jpg", FileName = "waterfallpendantbugatti.jpg" },

                new Project() { PageNumber = 62, ProjectTitle = "Waves of Glass", ProjectType = "necklace", ProjectDesigner = "Natalie Smith", MagazineID = 5, IssueID = 0313, Technique = "stringing", Supplies = "sea glass", OnlineLink = null, FilePath = "~Content/Images/wavesofglass.jpg", FileName = "wavesofglass.jpg" },

                new Project() { PageNumber = 44, ProjectTitle = "Winter's Night Nekclace", ProjectType = "necklace", ProjectDesigner = "Alla Maslennikova", MagazineID = 1, IssueID = 0216, Technique = "cubic right-angle weave", Supplies = "15/0 seed beads, gemstone cabochon, 4mm pearls", OnlineLink = null, FilePath = "~Content/Images/wintersnight.jpg", FileName = "wintersnight.jpg" },

                new Project() { PageNumber = 16, ProjectTitle = "Vintage Rosettes", ProjectType = "bracelet", ProjectDesigner = "Deborah Hodoyer", MagazineID = 4, IssueID = 0815, Technique = "cubic right-angle weave", Supplies = "15/0 seed beads, gemstone cabochon, 4mm pearls", OnlineLink = null, FilePath = "~Content/Images/vintagerosettes.jpg", FileName = "vintagerosettes.jpg" },

                new Project() { PageNumber = 18, ProjectTitle = "Venetian Window", ProjectType = "necklace", ProjectDesigner = "Dana Rudolph", MagazineID = 5, IssueID = 1015, Technique = "peyote, kumihimo", Supplies = "button, 11/0 seed beads, 15/0 seed beads, 11/0 cylinder beads, 3mm drop beads", OnlineLink = null, FilePath = "~Content/Images/venetianwindow.jpg", FileName = "venetianwindow.jpg" },

                new Project() { PageNumber = 56, ProjectTitle = "Solstice pendant", ProjectType = "pendant", ProjectDesigner = "Melissa Grakowsky", MagazineID = 3, IssueID = 1117, Technique = "peyote stitch", Supplies = "rivolis, 11/0 seed beads", OnlineLink = null, FilePath = "~Content/Images/solsticependant.jpg", FileName = "solsticependant.jpg" },

                new Project() { PageNumber = 22, ProjectTitle = "Style with an Edge", ProjectType = "necklace", ProjectDesigner = "Cathy Jakicic", MagazineID = 3, IssueID = 0915, Technique = "stringing", Supplies = "crystal pendants", OnlineLink = null, FilePath = "~Content/Images/stylewithanedge.jpg", FileName = "stylewithanedge.jpg" },

                new Project() { PageNumber = 18, ProjectTitle = "Sunset Harbor Earrings", ProjectType = "earrings", ProjectDesigner = "Cathy Jakicic", MagazineID = 1, IssueID = 0814, Technique = "stringing", Supplies = "8mm druks, tassels, bead frames", OnlineLink = null, FilePath = "~Content/Images/sunsetharbor.jpg", FileName = "sunsetharbor.jpg" },

                new Project() { PageNumber = 32, ProjectTitle = "Snowflower Ornament", ProjectType = "ornament", ProjectDesigner = "Julia Gerlach", MagazineID = 1, IssueID = 1212, Technique = "daisy chain", Supplies = "SuperDuo beads, 3mm pearls, 15/0 seed beads", OnlineLink = null, FilePath = "~Content/Images/snowflowerorn.jpg", FileName = "snowflowerorn.jpg" },

                new Project() { PageNumber = 48, ProjectTitle = "Surfin' Around the Waves", ProjectType = "pendant", ProjectDesigner = "Jimmie Boatright", MagazineID = 4, IssueID = 1015, Technique = "peyote", Supplies = "11/0 seed beads, 8/0 seed beads, 6/0 seed beads, rivoli", OnlineLink = null, FilePath = "~Content/Images/surfinaroundthewaves.jpg", FileName = "surfinaroundthewaves.jpg" },

                new Project() { PageNumber = 62, ProjectTitle = "Super Cube Beaded Bead", ProjectType = "beaded bead", ProjectDesigner = "Deborah Hodoyer", MagazineID = 4, IssueID = 0417, Technique = "beadweaving", Supplies = "SuperDuos, 4mm pearls, 11/0 seed beads, 15/0 seed beads", OnlineLink = null, FilePath = "~Content/Images/supercubebeadedbead.jpg", FileName = "supercubebeadedbead.jpg" },

                new Project() { PageNumber = 22, ProjectTitle = "Rondelicious", ProjectType = "bracelet", ProjectDesigner = "Natalie Smith", MagazineID = 3, IssueID = 0115, Technique = "right-angle weave", Supplies = "Crystallets buttons, 11/0 seed beads", OnlineLink = null, FilePath = "~Content/Images/rondeliciouscuff.jpg", FileName = "rondeliciouscuff.jpg" },

                new Project() { PageNumber = 12, ProjectTitle = "Rays of Light", ProjectType = "earrings", ProjectDesigner = "Deborah Hodoyer", MagazineID = 2, IssueID = 0617, Technique = "beadweaving", Supplies = "SuperDuos, 4mm crystals, 11/0 seed beads", OnlineLink = null, FilePath = "~Content/Images/rayoflightearrings.jpg", FileName = "rayoflightearrings.jpg" },

                new Project() { PageNumber = 46, ProjectTitle = "Raw Talent", ProjectType = "bracelet", ProjectDesigner = "Mandi Bugatti", MagazineID = 4, IssueID = 0215, Technique = "right-angle weave", Supplies = "4mm fire-polished beads, 8/0 seed beads, bangle blank", OnlineLink = null, FilePath = "~Content/Images/rawtalent.jpg", FileName = "rawtalent.jpg" },

                new Project() { PageNumber = 30, ProjectTitle = "Radiant Tiles", ProjectType = "pendant", ProjectDesigner = "Mandi Bugatti", MagazineID = 4, IssueID = 0415, Technique = "beadweaving", Supplies = "46mm tiles, 4mm crystals, 11/0 seed beads", OnlineLink = null, FilePath = "~Content/Images/radianttiles.jpg", FileName = "radianttiles.jpg" },

                new Project() { PageNumber = 8, ProjectTitle = "Ghostly Pumpkins", ProjectType = "earrings", ProjectDesigner = "Julia Gerlach", MagazineID = 2, IssueID = 1016, Technique = "beadweaving", Supplies = "crescent beads, 11/0 seed beads, bead caps", OnlineLink = null, FilePath = "~Content/Images/pumpkinearrings.jpg", FileName = "pumpkinearrings.jpg" },

                new Project() { PageNumber = 16, ProjectTitle = "Proactive Pearls", ProjectType = "necklace", ProjectDesigner = "Cathy Jakicic", MagazineID = 3, IssueID = 0714, Technique = "stringing", Supplies = "6mm pearls, 8mm pearls, 10mm pearls, crystal pendant, chain", OnlineLink = null, FilePath = "~Content/Images/provacativepearls.jpg", FileName = "provacativepearls.jpg" },

                new Project() { PageNumber = 12, ProjectTitle = "Phoenix Pendant", ProjectType = "pendant", ProjectDesigner = "Cara Landry", MagazineID = 4, IssueID = 0616, Technique = "brick stitch", Supplies = "11/0 cylinder beads", OnlineLink = null, FilePath = "~Content/Images/phoenixpendant.jpg", FileName = "phoenixpendant.jpg" },

                new Project() { PageNumber = 45, ProjectTitle = "On the Edge", ProjectType = "bracelet", ProjectDesigner = "Jaimie Eakin", MagazineID = 5, IssueID = 0816, Technique = "loomwork", Supplies = "11/0 cylinder beads, 4mm crystals", OnlineLink = null, FilePath = "~Content/Images/ontheedgeeakin.jpg", FileName = "ontheedgeeakin.jpg" },

                new Project() { PageNumber = 68, ProjectTitle = "Neon Leaves", ProjectType = "bracelet", ProjectDesigner = "Jaimie Eakin", MagazineID = 1, IssueID = 0618, Technique = "loomwork", Supplies = "11/0 cylinder beads", OnlineLink = null, FilePath = "~Content/Images/NeonLeavesbracelet.jpg", FileName = "NeonLeavesbracelet.jpg" },

                new Project() { PageNumber = 21, ProjectTitle = "Shooting Stars", ProjectType = "earrings", ProjectDesigner = "Cara Landry", MagazineID = 3, IssueID = 0714, Technique = "peyote", Supplies = "11/0 cylinder beads, 4mm crystals, rivoli, chain", OnlineLink = null, FilePath = "~Content/Images/shootingstars.jpg", FileName = "shootingstars.jpg" },

                new Project() { PageNumber = 32, ProjectTitle = "Multistrand Necklace", ProjectType = "necklace", ProjectDesigner = "Natalie Smith", MagazineID = 3, IssueID = 0313, Technique = "stringing", Supplies = "crystals, gemstones", OnlineLink = null, FilePath = "~Content/Images/multistandnecklace.jpg", FileName = "multistandnecklace.jpg" },

                new Project() { PageNumber = 21, ProjectTitle = "Magic Carpet Bracelet", ProjectType = "bracelet", ProjectDesigner = "Dana Rudolph", MagazineID = 3, IssueID = 0915, Technique = "loomwork", Supplies = "11/0 seed beads, 8/0 seed beads, 6/0 seed beads ", OnlineLink = null, FilePath = "~Content/Images/magicarpet.jpg", FileName = "magicarpet.jpg" },

                new Project() { PageNumber = 45, ProjectTitle = "Lotus Flower Necklace", ProjectType = "necklace", ProjectDesigner = "Dana Rudolph", MagazineID = 4, IssueID = 0615, Technique = "beadweaving", Supplies = "3mm druks, 8mm fire-polished beads, 11/0 seed beads, 4mm druks, chain", OnlineLink = null, FilePath = "~Content/Images/Lotusflowernecklace.jpg", FileName = "Lotusflowernecklace.jpg" },

                new Project() { PageNumber = 33, ProjectTitle = "Leaf Motif Bracelet", ProjectType = "bracelet", ProjectDesigner = "Candace Sexton", MagazineID = 5, IssueID = 0813, Technique = "herringbone", Supplies = "11/0 seed beads, 3mm fire-polished beads, 8/0 seed beads, button", OnlineLink = null, FilePath = "~Content/Images/Leafmotifbracelet.jpg", FileName = "Leafmotifbracelet.jpg" }

                    );

                context.Magazines.AddOrUpdate(
                    m => m.MagazineTitle,
                    new Magazine() { MagazineTitle = "Bead&Button Magazine" },
                    new Magazine() { MagazineTitle = "B&B Extra" },
                    new Magazine() { MagazineTitle = "Bead Style Magazine" },
                    new Magazine() { MagazineTitle = "Beadwork Magazine" },
                    new Magazine() { MagazineTitle = "Step By Step Beads" },
                    new Magazine() { MagazineTitle = "Bead Design Studio" },
                    new Magazine() { MagazineTitle = "Belle Armoire" },
                    new Magazine() { MagazineTitle = "Jewelry Affaire" },
                    new Magazine() { MagazineTitle = "Creative Beading" },
                    new Magazine() { MagazineTitle = "Bead & Jewellery" },
                    new Magazine() { MagazineTitle = "Bead Magazine" }
                    );





                //  This method will be called after migrating to the latest version.

                //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
                //  to avoid creating duplicate seed data.
            }
        }
        //  This method will be called after migrating to the latest version.

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data.
    }
}

