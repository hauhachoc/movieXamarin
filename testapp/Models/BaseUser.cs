using System;
using System.Collections.Generic;

namespace testapp
{
    public class BaseUser
    {
        public string email { get; set; }
	    public string password { get; set; }
		public string full_name { get; set; }
		public string gender { get; set; }
        public string birthday { get; set; }

		public BaseUser( string fn, string em,string pw)
		{
			this.full_name = fn;
			this.email = em;
            this.password = pw;
			this.gender = "male";
            this.birthday = "1990-12-12";
		}

        public BaseUser(){
            this.email = "";
            this.password = "";
			this.full_name = "";
			this.gender = "";
			this.birthday = "";
        }

        public static implicit operator List<object>(BaseUser v)
        {
            throw new NotImplementedException();
        }
    }
}
