using MHG.Surveys.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace MHG.Surveys.Domain.Services
{
    public class SurveyService
    {
        private readonly SurveyDbContext _context;

        public SurveyService(SurveyDbContext context)
        {
            _context = context;
        }

        public async Task<Survey> CreateSurveyAsync(Survey survey)
        {
            _context.Surveys.Add(survey);
            await _context.SaveChangesAsync();
            return survey;
        }

        public async Task<List<Survey>> GetAllSurveysAsync()
        {
            return await _context.Surveys.Include(s => s.Questions).ThenInclude(q => q.Options).ToListAsync();
        }
    }
}
