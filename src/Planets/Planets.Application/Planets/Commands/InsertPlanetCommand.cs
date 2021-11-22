using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets.Application.Planets.Commands
{
    public class InsertPlanetCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
