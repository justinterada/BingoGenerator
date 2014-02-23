using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoGenerator
{
    class Program
    {
        readonly static string[] people = new[] {
"Teammate tackles teammate",
"Reminder of the new Pro Bowl format",
"Jerry Rice trash talking",
"Deion Sanders trash talking",
"Coach wearing a Hawaiian shirt",
"Cutaway to a person surfing",
"Any team not scoring in a quarter",
"Discussion of the extra point rumors",
"A two-minute drill in the first or third quarter",
"Quarterback is sacked",
"Fumble recovered by the opposite team",
"50+ yard pass completion",
"25+ yard rush",
"Anybody arguing a call",
"A coach's challenge",
"Fake punt, field goal, or extra point",
"Excessive energy by the announcer",
"Sideline female reporter gives flowery story",
"Crowd shot with a row that is half-full",
"Rush for a loss",
"Pass for a loss",
"Player knocks over somebody on the sideline",
"Overhead camera shot",
"First timeout Team Sanders",
"First timeout Team Rice",
"Declined penalty",
"Touchdown for Team Rice",
"Touchdown for Team Sanders",
"Safety or two-point conversion attempt",
"Somebody in the crowd wearing a long-sleeved shirt",
"A player or coach saying the game is important to them",
"Announcer arguing about a penalty",
"Referees huddle to discuss a penalty",
"Measurement for a first down",
"Interception",
"Frustration shown by a player",
"Touchdown dance",
"Field goal for Team Sanders",
"Field goal for Team Rice",
"Team goes for it on fourth down",
};

        const string cardHtml = @"<html>
<head>
<title>Pro Bowl Bingo!</title>
<style>
table.card
{{
border: 5px solid black;
}}
table.card th
{{
	background-color: black;
	color: white;
	font-size: 2em;
}}
table.card td
{{
	width: 150px;
	height: 150px;
	border: 2px solid black;
	text-align: center;
    font-size: 1.3em;
}}
table.card td.free
{{
	background-color: black;
	color: white;
}}
</style>
</head>
<body>
<h1>Pro Bowl Bingo!</h1>
<table class=""card"">
<tr><th>A</th><th>L</th><th>O</th><th>H</th><th>A</th></tr>
<tr><td>{0}</td><td>{5}</td><td>{10}</td><td>{14}</td><td>{19}</td></tr>
<tr><td>{1}</td><td>{6}</td><td>{11}</td><td>{15}</td><td>{20}</td></tr>
<tr><td>{2}</td><td>{7}</td><td class=""free"">No kickoffs</td><td>{16}</td><td>{21}</td></tr>
<tr><td>{3}</td><td>{8}</td><td>{12}</td><td>{17}</td><td>{22}</td></tr>
<tr><td>{4}</td><td>{9}</td><td>{13}</td><td>{18}</td><td>{23}</td></tr>
</table>
</body>
</html>";

        static void Main(string[] args)
        {
            int cardsToMake = int.Parse(args[1]);

            for (int card = 1; card <= cardsToMake; card++)
            {
                List<string> namesToChoose = new List<string>(people);

                List<string> chosenNames = new List<string>();

                Random rand = new Random();

                for (int i = 0; i < 24; i++)
                {
                    int ordinal = rand.Next(namesToChoose.Count);
                    chosenNames.Add(namesToChoose[ordinal]);
                    namesToChoose.RemoveAt(ordinal);
                }

                using (StreamWriter writer = new StreamWriter(string.Format(args[0], card)))
                {
                    writer.Write(string.Format(cardHtml, chosenNames.ToArray()));
                }
            }
        }
    }
}
