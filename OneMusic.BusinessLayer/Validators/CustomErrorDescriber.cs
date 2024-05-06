using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.BusinessLayer.Validators
{
	public class CustomErrorDescriber : IdentityErrorDescriber
	{
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError
			{
				Description = "Sifre en az 6 karakterden olusmalidir."
			};
		}

		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError
			{
				Description = "Sifre en az bir rakam(0-9) icermelidir."
			};
		}

		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError
			{
				Description = "Sifre en az bir kucuk harf (a-z) icermelidir."
			};
		}

		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError
			{
				Description = "Sifre en az bir buyuk harf (A-Z) icermelidir."
			};
		}

		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError
			{
				Description = "Sifre en az bir ozel karakter(*,!,@,&,-,+,#,$)  icermelidir."
			};
		}
	}
}