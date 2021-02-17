using System.Collections.Generic;
using System.Linq;
using ClassesObjectsMethods.Interfaces;
using ClassesObjectsMethods.Models;

namespace ClassesObjectsMethods.Generators
{
    public class СandidateReportGenerator : IReportGenerator<Candidate>
    {
        public List<Candidate> getReport(List<Candidate> candidates)
        {
            var sortedCandidates = (List<Candidate>) candidates.OrderBy(c => c.Job.Title)
                .ThenBy(c => c.Job.Salary);

            return sortedCandidates;
        }
    }
}