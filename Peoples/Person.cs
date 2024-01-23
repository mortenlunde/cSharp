namespace Peoples
{
    public class Person
    {
        private readonly string _fullname;
        private DateTime _birthDate;

        public Person()
        {
            _fullname = "Undefined";
            _birthDate = new DateTime(1970, 01, 01);
        }

        public Person(string fullname)
        {
            this._fullname = fullname;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstname">Firstname</param>
        /// <param name="lastname">Lastname</param>
        public Person(string firstname, string lastname)
        {
            this._fullname = firstname + " " + lastname;
        }

        public string GetName()
        {
            return _fullname;
        }

        public void Update(DateTime dob)
        {
            _birthDate = dob;
        }

        public int GetAge()
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
            DateOnly birthdayThisYear = new DateOnly(currentDate.Year, _birthDate.Month, _birthDate.Day);

            int age = currentDate.Year - _birthDate.Year - (currentDate < birthdayThisYear ? 1 : 0);

            return age;
        }
    }
}