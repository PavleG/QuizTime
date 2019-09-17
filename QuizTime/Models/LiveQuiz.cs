using System.Collections.Generic;
using System.Linq;

namespace QuizTime.Models {
    // LiveQuiz class is used for an ongoing quiz (a quiz in progress)
    // It holds the quiz that the quiz master has selected, the quiz master's information
    // and the information about players that are participating
    public class LiveQuiz{
        private List<Player> Participants = new List<Player>();
        public IEnumerable<Player> Players => Participants;
        public string HostName { get; set; }
        public QuizModel Quiz { get; set; }
        public bool AddPlayerToQuiz(string NewUserName){
            Player player = Players.Where(p => p.UserName == NewUserName).FirstOrDefault();
            if (player == null){
                Participants.Add(new Player{
                    UserName = NewUserName, 
                    Points = 0
                    });
                return true;
            }
            return false;
        }
        public void RemovePlayerFromQuiz(string UserName){
            Participants.RemoveAll(p => p.UserName == UserName);
        }
    }

    public class Player
    {
        public string UserName { get; set; }
        public int Points { get; set; }

        public string Connection { get; set; }
    }
}