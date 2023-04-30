﻿using Microsoft.AspNetCore.Mvc;
using ProjetApiLFL.Dtos.Match;
using ProjetApiLFL.Models;
using ProjetApiLFL.Repositories;

namespace ProjetApiLFL.Controllers
{
    [ApiController]
    [Route("match")]
    public class MatchController : Controller
    {
        private readonly IMatchRepository _matchRepository;
        public MatchController(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }
        [HttpPost]
        public ActionResult CreateMatch(CreateMatchDto MatchDto)
        {
            Match match = new Match
            {
                Date = MatchDto.Date,
                BlueTeamId = MatchDto.BlueTeamId,
                RedTeamId = MatchDto.RedTeamId,

            };
            _matchRepository.CreateMatch(match);
            return Ok();
        }

        [HttpGet]
        public ActionResult<MatchListDto> GetMatchesList()
        {
            List<Match> matches = _matchRepository.GetMatches();

            List<MatchDto> matchesList = new List<MatchDto>();

            foreach(var match in matches)
            {
                matchesList.Add(new MatchDto
                {
                    RedTeamLogo = match.RedTeam.Logo,
                    RedTeamName = match.RedTeam.Name,
                    RedTeamScore = match.RedScore,
                    BlueTeamLogo = match.BlueTeam.Logo,
                    BlueTeamName = match.BlueTeam.Name,
                    BlueTeamScore = match.BlueScore,
                    MatchDate = match.Date
                });
            }

            var groupedMatches = matchesList
            .OrderByDescending(m => m.MatchDate)
                .GroupBy(m => m.MatchDate.Value.Date)
                .Select(g => new MatchListDto
                {
                    MatchDate = g.Key,
                    Matches = g.ToList()
                })
                .ToList();

            return Ok(groupedMatches);
        }
    }
}