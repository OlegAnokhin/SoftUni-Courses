using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Easter.Models.Workshops.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Bunnies.Contracts;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
        }
        public void Color(IEgg egg, IBunny bunny)
        {
            foreach (var dye in bunny.Dyes.Where(d => d.IsFinished() == false))
            {
                while (dye.IsFinished() == false)
                {
                    bunny.Work();
                    dye.Use();
                    egg.GetColored();
                    if (egg.IsDone())
                    {
                        break;
                    }
                }
                if (egg.IsDone())
                {
                    break;
                }
                if (bunny.Energy < 0)
                {
                    break;
                }
                if (bunny.Dyes.All(d => d.IsFinished() == true))
                {
                    break;
                }
            }
        }
    }
}