using System;
using System.Collections.ObjectModel;

namespace DOC_Forms
{
    public static class SharedResources
    {
        [NonSerialized]
        private static ObservableCollection<String> _redBlueGuides = null; 
        [NonSerialized]
        private static ObservableCollection<String> _fiftySocialSkills = null;

        public static ObservableCollection<string> FiftySocialSkills
        {
            get
            {
                if(_fiftySocialSkills == null)
                    LoadSocialSkills();
                return _fiftySocialSkills;
            }
            set { _fiftySocialSkills = value; }
        }

        public static ObservableCollection<string> RedBlueGuides
        {
            get
            {
                if (_redBlueGuides == null)
                    LoadRedBlueGuides();
                return _redBlueGuides;
            }

            set
            {
                _redBlueGuides = value;
            }
        }

        private static void LoadRedBlueGuides()
        {
            _redBlueGuides = new ObservableCollection<string>()
            {
                "Co-occurring Disorders",
                "Drug Dealers",
                "Engaging Prococial Disorders",
                "Female Offenders",
                "Impaired Driving",
                "Intimate Partner Violence",
                "Involving Families",
                "Managing Sex Offenders",
                "Mental Health",
                "Meth Users",
                "Reentry",
                "Responding to Violations",
                "Violence and Lethality",
                "A Practitioner's Guide to Evidence-Based Practices",
                "Anger",
                "Anti-Social Peers",
                "Antisocial Thinking",
                "Emotional Regulation",
                "Empathy",
                "Interpersonal Skills",
                "Moral Reasoning",
                "Overcoming Family Challenges",
                "Problem Solving",
                "Prosocial Leisure Activities",
                "Substance Abuse",
            };
        }

        public static void LoadSocialSkills()
        {
            _fiftySocialSkills = new ObservableCollection<string>()
            {
                "Listening", // 1
                "Starting a Conversation", // 2
                "Having a Conversation", // 3
                "Asking a Question", // 4
                "Saying Thank You", // 5
                "Introducing Yourself", // 6
                "Introducing Other People", // 7
                "Giving a Compliment", // 8
                "Asking for Help", // 9
                "Joining In", // 10
                "Giving Instructions", // 11
                "Following Instructions", // 12
                "Apologizing", // 13
                "Convincing Others", // 14
                "Knowing Your Feelings", // 15
                "Expressing Your Feelings", // 16
                "Understanding the Feelings of Others", // 17
                "Dealing with Someone Else's Anger", // 18
                "Expressing Affection", // 19
                "Dealing with Fear", // 20
                "Rewarding Yourself", // 21
                "Asking Permission", // 22
                "Sharing Something", // 23
                "Helping Others", // 24
                "Negotiating", // 25
                "Using Self-Control", // 26
                "Standing Up for Your Rights", // 27
                "Responding to Teasing", // 28
                "Avoiding Trouble with Others", // 29
                "Keeping Out of Fights", // 30
                "Making a Complaint", // 31
                "Answering a Complaint", // 32
                "Being a Good Sport", // 33
                "Dealing with Embarrassment", // 34
                "Dealing with Being Left Out", // 35
                "Standing up for a Friend", // 36
                "Responding to Persuasion", // 37
                "Responding to Failure", // 38
                "Dealing with Contradictory Messages", // 39
                "Dealing with an Accusation", // 40
                "Getting Ready for a Difficult Conversation", // 41
                "Dealing with Group Pressure", // 42
                "Deciding on Something to Do", // 43
                "Deciding What Caused a Problem", // 44
                "Setting a Goal", // 45
                "Deciding on Your Abilities", // 46
                "Gathering Information", // 47
                "Arranging Problems by Importance", // 48
                "Making a Decision", // 49
                "Concentrating on a Task" // 50
            };

        }


    }
}
