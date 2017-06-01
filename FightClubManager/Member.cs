namespace FinalProject
{

    public class Member
    {
        private string _firstN;
        private string _lastN;
        private string _nickname;
        private string _nationality;
        private string _dob;
        private int _age;
        private double _weight;
        private string _phoneNr;
        private string _email;
        private string _status;
        private int _professionalWins;
        private int _professionalLosses;
        private int _rofessionalDraws;
        private int _amateurWins;
        private int _amateurLosses;
        private int _amateurDraws;
        private string _adress;
        private byte[] _memberImage;
        private int _memberId;
        public int MemberID { get { return _memberId; } set { _memberId = value; } }
        public string FirstName { get { return _firstN; } set { _firstN = value; } }
        public string LastName { get { return _lastN; } set { _lastN = value; } }
        public string Nickname { get { return _nickname; } set { _nickname = value; } }
        public string Nationality { get { return _nationality; } set { _nationality = value; } }
        public string DateOfBirth { get { return _dob; } set { _dob = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public double Weight { get { return _weight; } set { _weight = value; } }
        public string PhoneNumber { get { return _phoneNr; } set { _phoneNr = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Status { get { return _status; } set { _status = value; } }
        public int ProfessionalWins { get { return _professionalWins; } set { _professionalWins = value; } }
        public int ProfessionalLosses { get { return _professionalLosses; } set { _professionalLosses = value; } }
        public int ProfessionalDraws { get { return _rofessionalDraws; } set { _rofessionalDraws = value; } }
        public int AmateurWins { get { return _amateurWins; } set { _amateurWins = value; } }
        public int AmateurLosses { get { return _amateurLosses; } set { _amateurLosses = value; } }
        public int AmateurDraws { get { return _amateurDraws; } set { _amateurDraws = value; } }
        public string Adress { get { return _adress; } set { _adress = value; } }
        public byte[] MemberImage { get { return _memberImage; } set { _memberImage = value; } }


        public Member() { }



        public Member(string firstN, string lastN, string nickname, string nationality, string dob, int age, double weight, string phoneNr, string email, string status, int proW, int proL, int proD, int amW, int amL, int amD, string adress, byte[] memberImage, int memberId)
        {
            FirstName = firstN;
            LastName = lastN;
            Nickname = nickname;
            Nationality = nationality;
            DateOfBirth = dob;
            Age = age;
            Weight = weight;
            PhoneNumber = phoneNr;
            Email = email;
            Status = status;
            ProfessionalWins = proW;
            ProfessionalLosses = proL;
            ProfessionalDraws = proD;
            AmateurDraws = amD;
            AmateurLosses = amL;
            AmateurDraws = amD;
            Adress = adress;
            MemberImage = memberImage;
            MemberID = memberId;
        }

    }


}
