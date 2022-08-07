
using CricketAPI.Standard;
using CricketAPI.Standard.Controllers;
using CricketAPI.Standard.Models;
using Hackathon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Configuration;
using WhatsAppCloudAPI.Standard;
using WhatsAppCloudAPI.Standard.Controllers;
using WhatsAppCloudAPI.Standard.Models;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WhatsAppController : Controller
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        private readonly WhatsAppCloudAPIClient _whatsAppCloudAPIClient = null;
        private static CricketAPIClient _sportmonksCricketAPIClient = null;
        public WhatsAppController()
        {
            _whatsAppCloudAPIClient = new WhatsAppCloudAPIClient.Builder()
                .AccessToken(_configuration.GetValue<string>("WhatsApp:AccessToken"))
                .HttpClientConfig(config => config.NumberOfRetries(0))
                .Build();

            _sportmonksCricketAPIClient = new CricketAPIClient.Builder()
                .CustomQueryAuthenticationCredentials(_configuration.GetValue<string>("Sportsmonks:AccessToken")).Build();
        }

        private MessagesController GetMessagesController()
        {
            return _whatsAppCloudAPIClient.MessagesController;
        }

        private static string GetLiveScore()
        {

            var allInPlayController = GetCricketClient().LivescoresController;
            AllInplay allInplay = allInPlayController.AllInplay();
            string liveScoreString =String.Empty;
            if (allInplay.Data.Count > 0)
            {
                var teamController = GetCricketClient().TeamsController;
                var fixtureWithRunController = GetCricketClient().FixtureWithScoreboardsController;
                List<Match> matches = new List<Match>();
                allInplay.Data.ForEach(play =>
                {
                  
                    var fixtureWithRun = fixtureWithRunController.FixtureWithRun("runs", play.Id);
                    int index = play.Status.Contains("1st") ? 0 : 1;
                    Match match = new Match()
                    {
                        LocalTeam = teamController.TeamByID(play.LocalteamId),
                        VisitiorTeam = teamController.TeamByID(play.VisitorteamId),
                        Note = play.Note,
                        Score = fixtureWithRun.Data.Runs[index].Score.ToString(),
                        Over = fixtureWithRun.Data.Runs[index].Overs.ToString(),
                        Wickets = fixtureWithRun.Data.Runs[index].Wickets.ToString(),
                        Type = play.Type,
                        Inning = play.Status,
                        TossWon = teamController.TeamByID(play.TossWonTeamId).Data.Name,
                        Elected = play.Elected
                    };
                    matches.Add(match);
                });
                foreach (Match match in matches)
                {
                    liveScoreString = liveScoreString + match.ToString();
                }


            }
            else
            {
                liveScoreString = "There is no match is happening right now";
            }

            return liveScoreString;
        }
        private static CricketAPIClient GetCricketClient()
        {
            return _sportmonksCricketAPIClient;
        }

        [HttpGet("webhook")]
        public ActionResult<int> Get(
            [FromQuery(Name = "hub.mode")] string hubMode,
            [FromQuery(Name = "hub.challenge")] int hubChallenge,
            [FromQuery(Name = "hub.verify_token")] string hubVerifyToken)
        {
            if (hubMode.Equals("subscribe", StringComparison.OrdinalIgnoreCase) && hubVerifyToken == _configuration.GetValue<string>("WhatsApp:VerifyToken"))
            {
                return Ok(hubChallenge);
            }
            return BadRequest();
        }

        [HttpPost("webhook")]
        public async Task<ActionResult> PostAsync([FromBody] object messagData)
        {
            var notification = JsonConvert.DeserializeObject<NotificationPayload>(messagData.ToString());
            var phoneNumberId = notification.Entry[0].Changes[0].MValue.Metadata.PhoneNumberId;
            var entry = notification.Entry[0];
            foreach (var change in entry.Changes)
            {
                if (change.MValue.Messages != null)
                {
                    foreach (var message in change.MValue.Messages)
                    {
                        string messageText = $"This keyword {message.Text.Body} is not supported. To get the live score, send keyword 'live updates'";
                        if (message.Text.Body.Equals("live updates", StringComparison.OrdinalIgnoreCase))
                        {
                            messageText = GetLiveScore();
                        }
                        var body = CreateMessage(messageText, message.From);
                        await GetMessagesController().SendMessageAsync(phoneNumberId, body);
                    }
                }
            }

            return Ok();
        }


        private static WhatsAppCloudAPI.Standard.Models.Message CreateMessage(string message, string recipient) =>
         new()
         {
             MessagingProduct = "whatsapp",
             To = recipient,
             Type = MessageTypeEnum.Text,
             Text = new WhatsAppCloudAPI.Standard.Models.Text(message)
         };
    }

}
