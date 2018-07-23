using ProjectFinderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFinderApp.DAL
{
    public class ProjectInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProjectContext>
    {
        protected override void Seed(ProjectContext context)
        {
            var projects = new List<ProjectContext>
           {
              // new Project{ProjectTitle="Neon Leaves bracelet",ProjectDesigner="Lorraine Coetzee",MagazineID=1,IssueID=0618,Technique="loomwork",Supplies="cylinder beads",PublisherLink="https://store.jewelrymakingmagazines.com/product/back-issue/bnb180601-c",OnlineLink="http://facetjewelry.com/stitching/projects/2018/04/neon-leaves-bracelet-word-chart",FilePath=""};
           };
        }
    }
}