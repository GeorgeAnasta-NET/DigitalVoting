using DigitalVoting.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVoting.Data.Services
{
    public interface IBallotData
    {
        IEnumerable<Ballot> GetAll();
    }
}
