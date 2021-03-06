﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DataAnnotationsExtensions;

namespace HibernatingRhinos.Loci.Common.Models
{
	public class ChangePasswordModel
	{
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Current password")]
		public string OldPassword { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "New password")]
		public string NewPassword { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm new password")]
		[Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }
	}

	public class LogOnModel
	{
		[Required]
		[Email]
		[Display(Name = "Login")]
		public string Login { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Display(Name = "Remember me?")]
		public bool RememberMe { get; set; }
	}

	public class RegisterModel
	{
		[Required]
		[Display(Name = "First name")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last name")]
		public string LastName { get; set; }

		[Required]
		[StringLength(50, ErrorMessage = "E-mail address longer than 50 characters isn't valid.")]
		[Email]
		[Display(Name = "Email address", Description = "Used as your login ID")]
		public string Email { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		public string SendOutKey { get; set; }
	}

	public class ForgotPasswordModel
	{
		[Required]
		[StringLength(50, ErrorMessage = "E-mail address longer than 50 characters isn't valid.")]
		[DataType(DataType.EmailAddress)]
		[Email]
		[Display(Name = "Email address")]
		public string Email { get; set; }

		[HiddenInput]
		public string Key { get; set; }
	}
}
