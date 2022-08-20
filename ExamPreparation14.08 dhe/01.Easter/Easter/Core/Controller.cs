using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Easter.Core.Contracts;
using Easter.Repositories;
using Easter.Models.Workshops.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Bunnies;
using Easter.Utilities.Messages;
using Easter.Models.Dyes;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Eggs;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly BunnyRepository bunnyRep;
        private readonly EggRepository eggRep;
        private IWorkshop workshop;
        public Controller()
        {
            bunnyRep = new BunnyRepository();
            eggRep = new EggRepository();
            workshop = new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException
                    (ExceptionMessages.InvalidBunnyType);
            }
            bunnyRep.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }
        public string AddDyeToBunny(string bunnyName, int power)
        {
            var currBunny = bunnyRep.FindByName(bunnyName);
            if (currBunny == null)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.InexistentBunny);
            }
            currBunny.AddDye(new Dye(power));
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }
        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggRep.Add(egg);
            return string.Format(OutputMessages.EggAdded, eggName);
        }
        public string ColorEgg(string eggName)
        {
            var currEgg = eggRep.FindByName(eggName);
            var currBunnys = bunnyRep.Models
                .Where(be => be.Energy >= 50)
                .OrderByDescending(b => b.Energy)
                .ToList();
         //   workshop = new Workshop();
            if (currBunnys == null)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.BunniesNotReady);
            }
            foreach (var bunny in currBunnys)
            {
                workshop.Color(currEgg, bunny);
                if (bunny.Energy == 0)
                {
                    bunnyRep.Remove(bunny);
                }
                if (currEgg.IsDone() == true)
                {
                    break;
                }
            }
            return currEgg.IsDone() == true 
                ? string.Format(OutputMessages.EggIsDone, eggName)
                : string.Format(OutputMessages.EggIsNotDone, eggName);
        }
        public string Report()
        {
            var sb = new StringBuilder();
            int coloredEggs = eggRep.Models.Count(e => e.IsDone() == true);
            sb.AppendLine($"{coloredEggs} eggs are done!");
            sb.AppendLine($"Bunnies info:");
            foreach (var bunny in bunnyRep.Models)
            {
                int countDyes = bunny.Dyes.Count(d => d.IsFinished() == false);
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {countDyes} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}